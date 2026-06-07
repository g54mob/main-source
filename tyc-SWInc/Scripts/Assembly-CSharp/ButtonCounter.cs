using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCounter : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	public Text CounterLabel;

	public string Title;

	private int Number;

	private bool Open;

	public Vector2 Offset = new Vector2(11f, -6f);

	public Button Parent;

	public Image Self;

	public void SetNumber(int n)
	{
		UpdateColor();
		Number = n;
		if (!Open)
		{
			UpdateActive();
			if (n > 0)
			{
				SetLabel();
			}
		}
	}

	private IEnumerator Start()
	{
		yield return new WaitForEndOfFrame();
		UpdatePosition();
	}

	public void UpdatePosition()
	{
		base.transform.position = Parent.transform.position + new Vector3(Offset.x, Offset.y, 0f);
	}

	public void UpdateActive()
	{
		bool flag = Parent.gameObject.activeSelf && !HUD.Instance.BuildMode && Number > 0;
		if (Open && !flag)
		{
			ToggleOpen(false);
		}
		base.gameObject.SetActive(flag);
	}

	private void SetLabel()
	{
		CounterLabel.text = Mathf.Min(99, Number).ToString();
		if (Number > 99)
		{
			CounterLabel.text += "+";
		}
	}

	private void UpdateColor()
	{
		Self.color = HUD.GetWarningColor();
	}

	private void ToggleOpen(bool open)
	{
		UpdateColor();
		if (!open || !string.IsNullOrEmpty(Title))
		{
			Open = open;
			RectTransform component = GetComponent<RectTransform>();
			if (Open)
			{
				component.sizeDelta = new Vector2(96f, component.sizeDelta.y);
				CounterLabel.text = Title.Loc();
			}
			else
			{
				component.sizeDelta = new Vector2(16f, component.sizeDelta.y);
				SetNumber(Number);
			}
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		ToggleOpen(true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		ToggleOpen(false);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (Parent != null)
		{
			Parent.onClick.Invoke();
		}
	}
}
