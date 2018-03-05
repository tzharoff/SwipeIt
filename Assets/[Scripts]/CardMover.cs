using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMover : MonoBehaviour {

	//we'll use this float to increase speed as the game progresses
	private float _fMoveTime = 0.5f;

	//this is the public access to our private variable (_fMoveTime).
	public float fMoveTime {
		get {return _fMoveTime;}
		set {_fMoveTime = value;}
	}

	private float reduceTime() {
		return _fMoveTime * 0.1f;
	}

	// Use this for initialization
	void Start () {


		//Begin testing
		iTween.MoveTo(this.gameObject, Vector3.zero, _fMoveTime);
		//end testing
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
