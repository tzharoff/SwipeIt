/*/
Tony Zharoff
+This script will handle generating swipe directions.
/*/
using UnityEngine;
using System.Collections;
using System;

public class RandomSwipe : MonoBehaviour {
    //this will tell us which type of swipe we're sending out.
    private GamePlay.IncomingSwipe _sWipeOut = GamePlay.IncomingSwipe.None;

    //I don't think we'll actually end up needing to watch this,
    //but I like to have the option.
    public GamePlay.IncomingSwipe SwipeOut {
        get {return _sWipeOut;}
        set {_sWipeOut = value;}
    }

    //when we make a random swipe, we only return a value, not set a value
    public GamePlay.IncomingSwipe SwipeRandom {
        get {return ConvertFromInt(UnityEngine.Random.Range(0,3));}
        set {Debug.Log("We don't set this value, only get it");}
    }

    private GamePlay.IncomingSwipe ConvertFromInt(int iValue){
        switch(iValue){
            case 0:
                return GamePlay.IncomingSwipe.Down;
            case 1:
                return GamePlay.IncomingSwipe.Left;
            case 2:
                return GamePlay.IncomingSwipe.Right;
            case 3:
                return GamePlay.IncomingSwipe.Up;       
        }
        return GamePlay.IncomingSwipe.None;
    }

}