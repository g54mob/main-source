using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class dimWFHandler : MonoBehaviour
{
	public string JSFile = "Points.json";

	public Dictionary<string, List<int>> data = new Dictionary<string, List<int>>();

	private Dictionary<int, bool> coloredInThisSession = new Dictionary<int, bool>();

	private void Awake()
	{
		Init();
	}

	private void Init()
	{
		TextAsset textAsset = Resources.Load(JSFile) as TextAsset;
		if (textAsset != null)
		{
			data = JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(textAsset.ToString(), Logic.GetGlobalSettings());
		}
	}

	public void WFHandle(string questName, bool isHidden)
	{
		if (data == null)
		{
			Init();
		}
		Mesh mesh = base.gameObject.GetComponent<MeshFilter>().mesh;
		if (data == null)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		Color32[] colors = mesh.colors32;
		if (!data.ContainsKey(questName))
		{
			return;
		}
		List<int> list = data[questName];
		if (isHidden || coloredInThisSession.ContainsKey(questName.GetHashCode()))
		{
			return;
		}
		foreach (int item in list)
		{
			colors[item] = new Color(1f, 1f, 1f, 0f);
		}
		mesh.colors32 = colors;
		coloredInThisSession.Add(questName.GetHashCode(), value: true);
	}
}
