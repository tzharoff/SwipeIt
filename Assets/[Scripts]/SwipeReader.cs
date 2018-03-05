//Tony Zharoff Fun Times

using UnityEngine;
using System.Collections;

public class SwipeReader : MonoBehaviour {
	public static SwipeReader instance;

	public delegate void SwipeDirection();
	public static event SwipeDirection SwipeUp; 
	public static event SwipeDirection SwipeDown; 
	public static event SwipeDirection SwipeLeft; 
	public static event SwipeDirection SwipeRight; 

	public float minDeviationHorizontal = 50f;
	public float minDeviationVertical = 50f;
	public float minSwipeDistance = 14f;
	public float maxSwipeTime = 0f;

	private float _fStartTime;
	private Vector2 _vStartPos;

	private void Awake() {
		if(instance != null) {
			Debug.LogError("Too many SwipeReader objects found");
		} else {
			instance = this;
		}
	}

	private void Update() {
		int iTouchCount = 0;
		iTouchCount = Input.touchCount;
		if(iTouchCount > 0) {
			Touch tTemp = Input.touches[0];

			switch(tTemp.phase) {
				case TouchPhase.Began:
					StartTouch(tTemp);
					//Debug.Log("Starting Touch");
					break;
				case TouchPhase.Ended:
					//Debug.Log("Stopping Touch");
					StopTouch(tTemp);
					break;
			}
		}
	}

	private void StartTouch(Touch theTouch) {
		_fStartTime = Time.time;
		_vStartPos = theTouch.position;
	}

	private void StopTouch(Touch theTouch) {
		float fSwipeTime = Time.time - _fStartTime;
		float fDistance = (theTouch.position - _vStartPos).magnitude;
		float fYValue = Mathf.Sign(theTouch.position.y - _vStartPos.y);
		float fXValue = Mathf.Sign(theTouch.position.x - _vStartPos.x);
		/*/
		Left: Y=1, X=-1
		Up: Y=1, X=1
		Right: Y=-1, X=1
		Down: Y=-1, X=1
		/*/
		if(Mathf.Abs(_vStartPos.y - theTouch.position.y) > minDeviationVertical
			&& fSwipeTime < maxSwipeTime
			&& fDistance > minSwipeDistance){
				if(fYValue > 0) {
					//Debug.Log("Up");
					if(SwipeUp != null){
						SwipeUp();
					}
					return;
				} else if(fYValue < 0) {
					//Debug.Log("Down");
					if(SwipeDown != null){
						SwipeDown();
					}
					return;
				}
		}

		if(Mathf.Abs(_vStartPos.x - theTouch.position.x) > minDeviationHorizontal
			&& fSwipeTime < maxSwipeTime
			&& fDistance > minSwipeDistance){
				if(fXValue > 0) {
					//Debug.Log("Right");
					if(SwipeRight != null){
						SwipeRight();
					}
					return;
				} else if(fXValue < 0) {
					//Debug.Log("Left");
					if(SwipeLeft != null){
						SwipeLeft();
					}
					return;
				}
		}

	}
}
