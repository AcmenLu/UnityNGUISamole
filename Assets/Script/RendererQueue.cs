using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererQueue : MonoBehaviour {

	public GameObject Target;
	private Renderer[] mRenders;
	// Use this for initialization
	void Start ()
	{
		mRenders = GetComponentsInChildren<Renderer>();
	
		if (Target == null)
			return;

		UIPanel panel = Target.GetComponent<UIPanel>();
		if (panel.drawCalls == null)
			return;

		int targetqueue = panel.startingRenderQueue;
		for (int i = 0; i < mRenders.Length; i++)
		{
			mRenders[i].material.renderQueue = targetqueue + 3;
		}
	}

}
