using Assets.Scripts.UI;
using TMPro;
using UnityEngine;

public class ShrineLogEntry : MonoBehaviour
{
	public TextMeshProUGUI text;

	public TextSizer textSizer;

	public void Set(string s)
	{
		text.text = s;
		textSizer.Refresh();
		textSizer.Recalculate();
		Transform root = base.transform;
		UiUtility.RebuildUi(root);
	}
}
