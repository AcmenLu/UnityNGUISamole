using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class ScrollManager : MonoBehaviour
{
	public enum MoveDirection
	{
		Horizontal = 0,
		Vertical,
	}


	public GameObject Item;
	public MoveDirection Movement = MoveDirection.Vertical;
	public Vector2 GridSize;
	public string XmlPath;


	private GameObject mScrollView;
	private UIGrid mGrid;

	// Use this for initialization
	void Start ()
	{
		mScrollView = transform.Find("ScrollView").gameObject;
		mGrid = mScrollView.transform.Find("Grid").GetComponent<UIGrid>();
		InitProperty();
		InitWithXML();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}


	void InitProperty()
	{
		UIWidget widget = gameObject.GetComponent<UIWidget>();
		Vector4 dimen = widget.drawingDimensions;
		float w = dimen.z - dimen.x;
		float h = dimen.w - dimen.y;

		BoxCollider box = gameObject.GetComponent<BoxCollider>();
		box.size = new Vector3(w, h, 1);
		box.center = new Vector3(w / 2, -h / 2, 0);

		UIScrollView uiscroll = mScrollView.GetComponent<UIScrollView>();
		uiscroll.movement = (UIScrollView.Movement)Movement;

		UIPanel panel = mScrollView.GetComponent<UIPanel>();
		panel.baseClipRegion = new Vector4(0, 0, w, h);
		panel.clipOffset = new Vector2(w / 2, -h / 2);

		mGrid.arrangement = (UIGrid.Arrangement)Movement;
		mGrid.cellHeight = GridSize.y;
		mGrid.cellWidth = GridSize.x;

	}

	/// <summary>
	/// 
	/// </summary>
	void InitWithXML()
	{
		if (Item == null || string.IsNullOrEmpty(XmlPath))
			return;

		if (Item.GetComponent<ScrollItem>() == null)
			return;

		List<Dictionary<string, string>> itemLst = ReadXml.ReadXmlItem(XmlPath);
		for (int i = 0; i < itemLst.Count; i ++)
		{
			GameObject go = NGUITools.AddChild(mGrid.gameObject, Item);
			ScrollItem scroll = go.GetComponent<ScrollItem>();
			if (scroll != null)
			{
				Dictionary<string, string> dict = itemLst[i];

				string iconpath = "";
				dict.TryGetValue("texturePath", out iconpath);

				string id = "";
				dict.TryGetValue("id", out id);

				string lowPriceStr = "";
				dict.TryGetValue("lowPrice", out lowPriceStr);
				float lowPrice = (float)System.Convert.ToDouble(lowPriceStr);


				string hightPriceStr = "";
				dict.TryGetValue("hightPrice", out hightPriceStr);
				float hightPrice = (float)System.Convert.ToDouble(hightPriceStr);

				scroll.IconPath = iconpath;
				scroll.ID = id;
				scroll.LowPrice = lowPrice;
				scroll.HightPrice = hightPrice;
			}
		}
	}

	private void AddItem(string icon, string id, float lowprice, float hightprice)
	{

	}
}
