/*/
Tony Zharoff
+This script will handle most game play elements, such as our swipe events.
/*/
using UnityEngine;
using System.Collections;
using System;

public class GamePlay : MonoBehaviour {

    //we'll use this enum to keep track of which swipe we're tracking. This will be handled in a separate class.
    public enum IncomingSwipe{
        Up,
        Down,
        Left,
        Right,
        None
    }

    //private RandomSwipe _mySwiper = new RandomSwipe();
    private RandomSwipe _mySwiper = null;

    //this is where we'll keep track of swipe interaction
    //Up
    //Down
    //Left
    //Right
    //None is an idle state.
    private IncomingSwipe _IncomingSwipe = IncomingSwipe.None; 


    //we don't always want to be responding to swipes
    private bool _ignoreSwipe = true;
    //I like to use setters and getters for some variables
    //Call it a hunch this will be helpful
    public bool IgnoreSwipe {
        get{ return _ignoreSwipe;}
        set{ _ignoreSwipe = value;}
    }

    //### Begin Required for Event Listeners
    //OnEnable is used for our delegate event listeners.
    //this allows our class to listen to SwipeDirection Events.
    //each listener must be added invidually.
    private void OnEnable(){
        SwipeReader.SwipeUp += HandleSwipeUp;
        SwipeReader.SwipeDown += HandleSwipeDown;
        SwipeReader.SwipeLeft += HandleSwipeLeft;
        SwipeReader.SwipeRight += HandleSwipeRight;
    }

    //OnDisable is used for our delegate event listeners.
    //failing to disable ALL listeners will cause a crash.
    private void OnDisable() {
        SwipeReader.SwipeUp -= HandleSwipeUp;
        SwipeReader.SwipeDown -= HandleSwipeDown;
        SwipeReader.SwipeLeft -= HandleSwipeLeft;
        SwipeReader.SwipeRight -= HandleSwipeRight;
    }

    //### End Required for Event Listeners

    //ççç Begin Custom Methods
    private void HandleSwipeUp() {
        //this will get us out of the method
        if(_ignoreSwipe){
            return;
        }

        //if we got the swipe we're looking for.
        if(_IncomingSwipe == IncomingSwipe.Up){
            GoodSwipe();            
            return;
        }
        BadSwipe();
    }

    private void HandleSwipeDown() {
        //this will get us out of the method
        if(_ignoreSwipe){
            return;
        }

        //if we got the swipe we're looking for.
        if(_IncomingSwipe == IncomingSwipe.Down){
            GoodSwipe();            
            return;
        }
        BadSwipe();
    }

    private void HandleSwipeLeft(){
        //this will get us out of the method
        if(_ignoreSwipe){
            return;
        }

        //if we got the swipe we're looking for.
        if(_IncomingSwipe == IncomingSwipe.Left){
            GoodSwipe();            
            return;
        }
        BadSwipe();
    }

    private void HandleSwipeRight(){
        //this will get us out of the method
        if(_ignoreSwipe){
            return;
        }

        //if we got the swipe we're looking for.
        if(_IncomingSwipe == IncomingSwipe.Right){
            GoodSwipe();            
            return;
        }
        BadSwipe();
    }

    private void GoodSwipe(){
        //clear current swipe
        //restart the countdown timer
        //get new swipe
    }

    private void BadSwipe(){
        //Debug
        Debug.Log("BadSwipe");
    }
    //ççç End Custom Methods

    //∫∫∫ Begin Inherited Unity Monobehaviors

    private void Start() {

        _mySwiper = gameObject.AddComponent<RandomSwipe>() as RandomSwipe;
        //Begin Testing with Start()
        _IncomingSwipe = _mySwiper.SwipeRandom;
        Debug.Log(_IncomingSwipe.ToString());
        //End Testing with Start()
    }

    private void Update() {
        
    }
    //∫∫∫ End Inherited Unity Monobehaviors

}
