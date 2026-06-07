using TMPro;
using UnityEngine;

public class RegionButton : MonoBehaviour
{
	public delegate void ClickCallback();

	public ClickCallback clickCallback;

	public TextMeshProUGUI regionName;

	public void OnClick()
	{
	}
}
