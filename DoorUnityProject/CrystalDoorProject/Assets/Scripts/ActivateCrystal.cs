using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ActivateCrystal : MonoBehaviour {

	[SerializeField]
	private Animator m_anim;

	[SerializeField]
	private AudioMixerGroup[] m_mixers;

	[SerializeField]
	private AudioClip[] m_interactionClips;

	private AudioSource m_audio;

	// Use this for initialization
	void Start () {
		m_anim = GetComponent<Animator> ();
		m_audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && m_anim.GetBool ("CrystalOpen")) {
			Invoke ("CloseCrystal", 0.5f);
			m_audio.outputAudioMixerGroup = m_mixers [1];
			m_audio.clip = m_interactionClips [1];
			m_audio.Play ();
		} else if(Input.GetKeyDown (KeyCode.Space)){
			m_anim.SetBool ("CrystalOpen", true);
			m_audio.outputAudioMixerGroup = m_mixers [0];
			m_audio.clip = m_interactionClips [0];
			m_audio.Play ();
		}
	}

	void CloseCrystal(){
		m_anim.SetBool ("CrystalOpen", false);
	}
}
