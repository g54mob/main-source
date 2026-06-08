using TMPro;
using UnityEngine;

public class TableWindow : MonoBehaviour
{
	private TextMeshProUGUI text;

	private float? startingHeight;

	private float? startingPosition;

	private void Start()
	{
		text = GetComponent<TextMeshProUGUI>();
	}

	public void EnableText()
	{
		GetComponent<TextMeshProUGUI>().enabled = true;
		SetVisible();
	}

	public bool SetVisibility(int index, float scrollPositionTop, float scrollPositionBottom)
	{
		Init();
		float value = startingPosition.Value;
		float num = value + startingHeight.Value;
		bool flag = num <= scrollPositionTop && value >= scrollPositionBottom;
		bool flag2 = (value <= scrollPositionTop && scrollPositionTop <= num) || (value <= scrollPositionBottom && scrollPositionBottom <= num) || flag;
		Debug.Log($"{index}: isWithin={flag}, isVisible={flag2} scrollPos=({scrollPositionBottom}, {scrollPositionTop}) -> localPos=({value}, {num}), size={value - num}");
		text.enabled = flag2;
		return flag2;
	}

	public void Init()
	{
		if (!startingHeight.HasValue)
		{
			startingHeight = base.transform.GetComponent<RectTransform>().rect.height;
			Debug.Log($"Init: startingHeight={startingHeight}");
		}
		if (!startingPosition.HasValue)
		{
			startingPosition = base.transform.localPosition.y;
			Debug.Log($"Init: startingPosition={startingPosition}");
		}
	}

	public void SetInvisible()
	{
		GetComponent<TextMeshProUGUI>().color = new Color32(0, 0, 0, 0);
	}

	public void SetVisible()
	{
		GetComponent<TextMeshProUGUI>().color = new Color32(0, 0, 0, byte.MaxValue);
	}

	public void SetPosition()
	{
		text.transform.localPosition = new Vector3(text.transform.localPosition.x, startingPosition.Value, text.transform.localPosition.z);
	}
}
