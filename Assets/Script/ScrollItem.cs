using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollItem : MonoBehaviour
{
	private string mId;
	private float mLowPrice;
	private float mHightPrice;
	private string mIconPath;

	private UILabel mIdLabel;
	private UILabel mLowPriceLabel;
	private UILabel mHightPriceLabel;
	private UISprite mIconSprite;


	public string ID
	{
		get { return mId; }
		set
		{
			mId = value;
			if(mIdLabel != null)
				mIdLabel.text = mId;
		}
	}

	public float LowPrice
	{
		get { return mLowPrice; }
		set
		{
			mLowPrice = value;
			if (mLowPriceLabel != null)
				mLowPriceLabel.text = mLowPrice.ToString();
		}
	}

	public float HightPrice
	{
		get { return mHightPrice; }
		set
		{
			mHightPrice = value;
			if (mHightPriceLabel != null)
				mHightPriceLabel.text = mHightPrice.ToString();
		}
	}

	public string IconPath
	{
		get { return mIconPath; }
		set
		{
			mIconPath = value;
			if (mIconSprite != null && !string.IsNullOrEmpty(mIconPath))
			{
				string filename = mIconPath.Replace('\\', '/');
				int lastIndex = filename.LastIndexOf("/");
				string filePath = filename.Substring(0, lastIndex);
				string fileName = filename.Substring(lastIndex + 1);
				UIAtlas atlas = Resources.Load(filePath, typeof(UIAtlas)) as UIAtlas;
				mIconSprite.atlas = atlas;
				mIconSprite.spriteName = fileName;
			}
		}
	}
	// Use this for initialization
	void Awake ()
	{
		mIdLabel = transform.Find("Id").gameObject.GetComponent<UILabel>();
		mLowPriceLabel = transform.Find("lowPrice").gameObject.GetComponent<UILabel>();
		mHightPriceLabel = transform.Find("hightPrice").gameObject.GetComponent<UILabel>();
		mIconSprite = transform.Find("Icon").gameObject.GetComponent<UISprite>();

		ID = "";
		LowPrice = 0f;
		HightPrice = 0f;
		IconPath = "";
	}


	private void Start()
	{
		
	}

	// Update is called once per frame
	void Update () {
		
	}


}
