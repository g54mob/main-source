using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class TooltipComponent : MonoBehaviour
{
	private const int MARGIN_FROM_SCREEN_BORDERS = 10;

	[SerializeField]
	private bool hasCustomTooltipTime;

	[SerializeField]
	private float customTooltipTime;

	[SerializeField]
	private Vector2 positionOffset;

	[SerializeField]
	protected TooltipUI tooltipUIPrefab;

	protected TooltipUI currentTooltipUI;

	private int invokersAmount;

	public bool HasCustomTooltipTime => hasCustomTooltipTime;

	public float CustomTooltipTime => customTooltipTime;

	public Vector2 PositionOffset => positionOffset;

	protected abstract Dictionary<string, object> GetData();

	protected virtual void Awake()
	{
	}

	protected virtual void OnDisable()
	{
		HideTooltip();
	}

	protected virtual void OnDestroy()
	{
		HideTooltip();
	}

	public virtual bool HideTooltip()
	{
		invokersAmount--;
		invokersAmount = Mathf.Max(invokersAmount, 0);
		if (invokersAmount > 0)
		{
			return true;
		}
		if ((bool)currentTooltipUI)
		{
			Object.Destroy(currentTooltipUI.gameObject);
			return true;
		}
		return false;
	}

	public virtual void ShowTooltip(Transform parentTransform)
	{
		invokersAmount++;
		if (invokersAmount <= 1)
		{
			Dictionary<string, object> data = GetData();
			if (data != null && data.Count > 0)
			{
				currentTooltipUI = Object.Instantiate(tooltipUIPrefab, parentTransform);
				currentTooltipUI.Setup(GetData());
				(currentTooltipUI.transform as RectTransform).position = GetStartPosition();
			}
		}
	}

	protected virtual Vector3 GetStartPosition()
	{
		float scaleFactor = GameManager.instance.PlayerController.CurrentHUD.GetComponent<Canvas>().scaleFactor;
		RectTransform rectTransform = currentTooltipUI.transform as RectTransform;
		float num = Mouse.current.position.ReadValue().x + (Vector2.right * 10f * scaleFactor).x;
		float num2 = Mouse.current.position.ReadValue().x + (Vector2.left * (rectTransform.sizeDelta.x * rectTransform.localScale.x + 10f) * scaleFactor).x;
		float num3 = Mouse.current.position.ReadValue().y + (Vector2.up * 10f * scaleFactor).y;
		float num4 = Mouse.current.position.ReadValue().y + (Vector2.down * (rectTransform.sizeDelta.y * rectTransform.localScale.y + 30f) * scaleFactor).y;
		Vector3 vector = new Vector2(num, num4);
		if (num + rectTransform.sizeDelta.x * rectTransform.localScale.x * scaleFactor > (float)Screen.width - 10f * scaleFactor)
		{
			if (num2 > 10f * scaleFactor)
			{
				vector.x = num2;
			}
			else
			{
				vector.x = (float)Screen.width - (10f + rectTransform.sizeDelta.x * rectTransform.localScale.x) * scaleFactor;
			}
		}
		if (num4 < 10f * scaleFactor)
		{
			if (num3 + rectTransform.sizeDelta.y * rectTransform.localScale.y * scaleFactor < (float)Screen.height - 10f * scaleFactor)
			{
				vector.y = num3;
			}
			else
			{
				vector.y = 10f * scaleFactor;
			}
		}
		return vector + (Vector3)positionOffset * scaleFactor;
	}

	protected void InvokeDataChanged()
	{
		if ((bool)currentTooltipUI)
		{
			currentTooltipUI.Setup(GetData());
			(currentTooltipUI.transform as RectTransform).position = GetStartPosition();
		}
	}
}
