using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAlphaTween : MonoBehaviour {

	private bool mPlaying = false;
	private GameObject mButtonSprite;
	private TweenAlpha mTweenAlpha;

	// Use this for initialization
	void Start ()
	{
		mButtonSprite = transform.Find("PlayButton").gameObject;
		mTweenAlpha = transform.Find("TweenLabel").gameObject.GetComponent<TweenAlpha>();
		ChangeState();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPlayBtnClick()
	{
		mPlaying = !mPlaying;
		ChangeState();
	}


	void ChangeState()
	{
		if (mPlaying == true)
		{
			mButtonSprite.GetComponent<UISprite>().spriteName = "Button_01_Normal_Virgin";
			mButtonSprite.GetComponent<UIButton>().normalSprite = "Button_01_Normal_Virgin";
		}
		else
		{
			mButtonSprite.GetComponent<UISprite>().spriteName = "Button_01_Normal_Up";
			mButtonSprite.GetComponent<UIButton>().normalSprite = "Button_01_Normal_Up";
		}

		mTweenAlpha.enabled = mPlaying;
	}
}
