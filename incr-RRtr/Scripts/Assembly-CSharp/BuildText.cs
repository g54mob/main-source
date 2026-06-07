using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class BuildText : MonoBehaviour
{
	private Vector2 verticalPos = new Vector2(-26f, 370f);

	private Vector2 horizontalPos = new Vector2(-594f, 12f);

	private void Start()
	{
		GetComponent<TMP_Text>().text = GameManager.ins.build;
		RectTransform component = GetComponent<RectTransform>();
		if (SaveData.ins.verticalMode)
		{
			component.anchoredPosition = verticalPos;
			component.localEulerAngles = new Vector3(0f, 0f, -90f);
		}
		else
		{
			component.anchoredPosition = horizontalPos;
			component.localEulerAngles = new Vector3(0f, 0f, 0f);
		}
	}
}
