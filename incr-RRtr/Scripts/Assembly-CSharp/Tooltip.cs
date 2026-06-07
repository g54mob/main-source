using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
	private RectTransform rectTransform;

	public TMP_Text tooltipText;

	private void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		base.gameObject.SetActive(value: false);
	}

	public void SetInfo(string tooltip)
	{
		tooltipText.text = tooltip;
		FollowMousePosition();
	}

	private void Update()
	{
		FollowMousePosition();
	}

	private void FollowMousePosition()
	{
		Vector2 vector = Input.mousePosition;
		float x = vector.x / (float)Screen.width;
		float y = vector.y / (float)Screen.height;
		rectTransform.pivot = new Vector2(x, y);
		base.transform.position = vector;
	}
}
