using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
	public static Dictionary<string, string> tips = new Dictionary<string, string>();

	public static Transform tipDisplay;

	private void Awake()
	{
		tipDisplay = GameObject.Find("tip").transform;
		Hide();
		tips["collections"] = "Filter objects in collections by using the search box (i.e. 'wall').";
		tips["rotate"] = "Hold Q to rotate selected objects using the rotational rings.";
		tips["selection"] = "Select multiple objects by holding SHIFT, or by holding CTRL and dragging over objects.";
		tips["swatches"] = "Click to paint a surface, click Materials ► New material... to create a new material.";
	}

	public static void Show(string _id)
	{
		if (Preferences.data.displayHints && tips.ContainsKey(_id))
		{
			tipDisplay.GetComponentInChildren<Text>().text = tips[_id];
			tipDisplay.gameObject.SetActive(value: true);
		}
	}

	public static void Hide()
	{
		tipDisplay.gameObject.SetActive(value: false);
	}
}
