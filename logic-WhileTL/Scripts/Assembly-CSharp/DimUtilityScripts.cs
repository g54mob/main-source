using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public class DimUtilityScripts : MonoBehaviour
{
	internal class TRS
	{
		public Vector3 pos;

		public string name;
	}

	public string filePath = "e:\\R5_Art\\WTL\\Tree.json";

	public bool isLocal;

	public Vector3[] corners;

	public void TRSTreeExport()
	{
		int childCount = base.gameObject.transform.childCount;
		List<TRS> list = new List<TRS>();
		corners = new Vector3[4];
		base.gameObject.GetComponent<RectTransform>().GetWorldCorners(corners);
		for (int i = 0; i < childCount; i++)
		{
			Transform child = base.gameObject.transform.GetChild(i);
			if (child.gameObject.tag == "TreePlace" && child.gameObject.activeSelf)
			{
				TRS tRS = new TRS();
				tRS.name = child.name;
				if (isLocal)
				{
					tRS.pos = child.transform.localPosition;
				}
				else
				{
					tRS.pos = child.transform.position;
				}
				Debug.Log(child.gameObject.name);
				list.Add(tRS);
			}
		}
		string text = JsonConvert.SerializeObject(list, Formatting.None, Logic.GetGlobalSettings());
		FileStream fileStream = File.Create(filePath);
		char[] chars = text.ToCharArray();
		byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(chars);
		fileStream.Write(bytes, 0, bytes.Length);
		fileStream.Close();
	}
}
