using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class ReadXml
{

	public static void ReadNode(XmlNode node)
	{
		Debug.Log("Node Name: " + node.Name);
		if (node.Attributes!= null && node.Attributes.Count > 0)
		{
			for (int i = 0; i < node.Attributes.Count; i++)
			{
				Debug.Log("Attr Name: " + node.Attributes[i].Name + " Attr Value: " + node.Attributes[i].Value);
			}
		}

		if (node.ChildNodes != null && node.ChildNodes.Count > 0)
		{
			for (int i = 0; i < node.ChildNodes.Count; i++)
			{
				ReadNode(node.ChildNodes[i]);
			}
		}
	}


	public static void ReadXmlFile(string filepath)
	{
		XmlDocument xml = new XmlDocument();
		xml.Load(Application.dataPath + "/" + filepath);
		XmlElement root = xml.DocumentElement;
		ReadNode(root);
	}



	public static void ReadNodeByName(XmlNode node, string name, ref List<Dictionary<string, string>> lst)
	{
		if (name == node.Name && node.Attributes != null && node.Attributes.Count > 0)
		{
			Dictionary<string, string> tmp = new Dictionary<string, string>();
			for (int i = 0; i < node.Attributes.Count; i++)
			{
				tmp.Add(node.Attributes[i].Name, node.Attributes[i].Value);
			}
			lst.Add(tmp);
		}

		if (node.ChildNodes != null && node.ChildNodes.Count > 0)
		{
			for (int i = 0; i < node.ChildNodes.Count; i++)
			{
				ReadNodeByName(node.ChildNodes[i], name, ref lst);
			}
		}
	}

	public static List<Dictionary<string, string>> ReadXmlItem(string filepath)
	{
		XmlDocument xml = new XmlDocument();
		xml.Load(Application.dataPath + "/" + filepath);
		XmlElement root = xml.DocumentElement;
		List<Dictionary<string, string>> lst = new List<Dictionary<string, string>>();
		ReadNodeByName(root, "item", ref lst);
		return lst;
	}
}
