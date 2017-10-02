using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCrystal : MonoBehaviour {

	[SerializeField]
	private Animator m_anim;

	[SerializeField]
	private AudioClip[] m_audioClips;

	// Use this for initialization
	void Start () {
		m_anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && m_anim.GetBool ("CrystalOpen")) {
			m_anim.SetBool ("CrystalOpen", false);
		} else if(Input.GetKeyDown (KeyCode.Space)){
			m_anim.SetBool ("CrystalOpen", true);
		}
	}
}
