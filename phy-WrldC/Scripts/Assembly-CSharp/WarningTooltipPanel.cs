using TMPro;
using UnityEngine;

public class WarningTooltipPanel : TooltipPanelBase
{
	public enum FloatDirection
	{
		Down = 0,
		Up = 1
	}

	private TextMeshProUGUI warningText;

	[Space(10f)]
	[SerializeField]
	private float durationTime = 1f;

	[SerializeField]
	private float floatDistance = 20f;

	private FloatDirection floatDirection;

	private float timeCounter;

	private float yTargetPosition;

	private float yCurrentPosition;

	private float originalPositionY;

	private bool isTimeOver;

	protected override void Awake()
	{
		base.Awake();
		warningText = base.transform.FindComponent<TextMeshProUGUI>("Text", isRecursively: true);
		floatDirection = FloatDirection.Up;
	}

	protected override void Update()
	{
		base.Update();
		if (!isTimeOver)
		{
			timeCounter += Time.deltaTime;
			if (timeCounter >= durationTime && base.IsPanelVisible)
			{
				SetVisibility(isVisible: false);
			}
			float y = Mathf.SmoothDamp(base.transform.position.y, yTargetPosition, ref yCurrentPosition, durationTime + fadeOutTime);
			base.transform.SetPositionY(y);
			if (timeCounter >= durationTime + fadeOutTime)
			{
				isTimeOver = true;
			}
		}
	}

	public void ShowWarningText(string text, FloatDirection floatDirection = FloatDirection.Up)
	{
		ShowWarningText(text, 0f, 0f, floatDirection);
	}

	public void ShowWarningText(string text, float verticalOffset, float horizontalOffset, FloatDirection floatDirection = FloatDirection.Up)
	{
		warningText.text = text;
		this.floatDirection = floatDirection;
		base.verticalOffset = verticalOffset;
		base.horizontalOffset = horizontalOffset;
		Vector3 newPosition = Util.ConvertMousePositionToRectTransform(parentCanvas);
		SetPosition(newPosition, VerticalAlignment.Middle, HorizontalAlignment.Center);
		SetVisibility(isVisible: true);
		isTimeOver = false;
	}

	public override void SetVisibility(bool isVisible)
	{
		base.SetVisibility(isVisible);
		timeCounter = 0f;
		if (floatDirection == FloatDirection.Up)
		{
			yTargetPosition = base.transform.position.y + floatDistance * base.UIPixelScale;
		}
		else if (floatDirection == FloatDirection.Down)
		{
			yTargetPosition = base.transform.position.y - floatDistance * base.UIPixelScale;
		}
	}
}
