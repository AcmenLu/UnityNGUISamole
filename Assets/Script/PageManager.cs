using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour {

	private int mPlayIndex;
	List<int> mNumberLst;

	private void Awake()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			ChildTweenPlay(i, false);
			//SetChildsShow(i, false);
		}
	}


	// Use this for initialization
	void Start ()
	{
		RandomPlay();
	}

	// Update is called once per frame
	void Update ()
	{

	}


	void SetChildsShow(int index, bool isShow)
	{
		GameObject obj = transform.GetChild(index).gameObject;
		obj.SetActive(isShow);
	}

	/// <summary>
	/// 随机播放动画
	/// </summary>
	void RandomPlay()
	{
		mNumberLst = GetDiffRandom(5, 5);
		for (int i = 0; i < transform.childCount; i++)
		{
			SetChildsShow(i, true);
		}

		mPlayIndex = -1;
		PlayNextTween();
	}

	/// <summary>
	/// 生成指定个数和指定范围的随机,如果指定的count比最大数大则返回的数量为最大数的个数
	/// </summary>
	/// <param name="max"></param>
	/// <param name="count"></param>
	List<int> GetDiffRandom(int max, int count)
	{
		if (max < count)
			count = max;

		List<int> nums = new List<int>();
		System.Random rm = new System.Random();
		while(nums.Count < count)
		{
			int nValue = rm.Next(max);
			if (!nums.Contains(nValue))
				nums.Add(nValue);
		}

		return nums;
	}

	/// <summary>
	/// 页面动画播放完成的回调
	/// </summary>
	public void OnTweenFinish()
	{
		if (mPlayIndex < transform.childCount - 1)
		{
			PlayNextTween();
		}
		else
		{
			for (int i = 0; i < transform.childCount; i++)
				SetChildsShow(i, false);
		
			Invoke("RandomPlay", 2);
		}
	}

	/// <summary>
	/// 播放下一个页面的动画
	/// </summary>
	void PlayNextTween()
	{
		mPlayIndex++;
		int childIndex = mNumberLst[mPlayIndex];
		ChildTweenPlay(childIndex, true);
	}

	/// <summary>
	/// 动画的播放
	/// </summary>
	/// <param name="index"></param>
	/// <param name="enable"></param>
	void ChildTweenPlay(int index, bool enable)
	{
		if (index >= transform.childCount)
			return;

		GameObject obj = transform.GetChild(index).Find("Sprite").gameObject;
		UITweener tween = obj.GetComponent<UITweener>();
		tween.enabled = enable;
		if (enable == true)
		{
			tween.ResetToBeginning();
			tween.PlayForward();
		}
	}
}
