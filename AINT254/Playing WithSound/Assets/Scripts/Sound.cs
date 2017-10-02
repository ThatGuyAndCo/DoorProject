using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour
{
    private int m_qSamples = 1024;        // array size - number of samples
	[SerializeField]
	private float m_rmsValue;             // sound level - RMS (root mean squared)
    [SerializeField]
    private float m_scaleSample = 2.0f;   // set how much the scale will vary

    private AudioSource m_source;         //audio source

    private float[] m_samples;            //the array - samples we're getting

    private float m_scaleY = 0;           //original scale on y

	private float m_randR;
	private float m_randG;
	private float m_randB;

	private Light m_light;

    // Use this for initialization
    void Start()
    {
        m_source = GetComponent<AudioSource>(); //refernce to audio source
        m_samples = new float[m_qSamples];      //initialise the array of samples
        m_scaleY = transform.localScale.y;      //get the original scale of the object
		m_light = GetComponent<Light>();
		m_randR = Random.Range (0, 255);
		m_randG = Random.Range (0, 255);
		m_randB = Random.Range (0, 255);
		InvokeRepeating ("ChangeColour", 2.0f, 2.0f);
    }

	void ChangeColour(){
		m_randR = Random.Range (0, 255);
		m_randG = Random.Range (0, 255);
		m_randB = Random.Range (0, 255);
	}

    // Update is called once per frame
    void Update()
    {
        AnalyzeSound(); //we analyse the sound

		if (m_rmsValue > 1)
			m_rmsValue = 1;


		Color newCol = new Color (m_randR * m_rmsValue, m_randG * m_rmsValue, m_randB * m_rmsValue);
		m_light.color = newCol;

        //we scale the object on y based on m_rmsValue
        Vector3 scale = transform.localScale;
        scale.y = m_scaleY + m_scaleSample * m_rmsValue;
        transform.localScale = scale;

        Vector3 pos = new Vector3(0, transform.localScale.y * 0.5f, 0);

        transform.position = pos;
    }

    /// <summary>
    /// we analyze the sound and we assign a value to m_rmsValue
    /// </summary>
    private void AnalyzeSound()
    {
        m_source.GetOutputData(m_samples, 0); //we get some samples 

        float sum = 0;

        for (int i = 0; i < m_samples.Length; i++)
        {
            sum += m_samples[i] * m_samples[i]; //sum squared samples
        }

        //formula for sound level
        m_rmsValue = Mathf.Sqrt(sum / m_qSamples);
    }
}
