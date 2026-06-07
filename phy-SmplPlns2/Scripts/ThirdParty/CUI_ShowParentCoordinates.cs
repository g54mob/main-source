using UnityEngine;
using UnityEngine.UI;

public class CUI_ShowParentCoordinates : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Text>().text = base.transform.parent.GetComponent<RectTransform>().anchoredPosition.ToString();
	}

	private void Update()
	{
	}
}
