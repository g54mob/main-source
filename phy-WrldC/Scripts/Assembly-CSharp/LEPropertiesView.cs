using TMPro;
using UnityEngine.UI;

public class LEPropertiesView : BaseGUIView
{
	public const string GroundHeightSliderEvent = "LEPropertiesView.GroundHeightSliderEvent";

	public const string FailureZoneHeightSliderEvent = "LEPropertiesView.FailureZoneHeightSliderEvent";

	public const string FailureZoneToggleEvent = "LEPropertiesView.FailureZoneToggleEvent";

	public const string HandSnapStepInputEvent = "LEPropertiesView.HandSnapStepInputEvent";

	public const string MoveSnapStepInputEvent = "LEPropertiesView.MoveSnapStepInputEvent";

	public const string RotationSnapStepInputEvent = "LEPropertiesView.RotationSnapStepInputEvent";

	public const string ScaleSnapStepInputEvent = "LEPropertiesView.ScaleSnapStepInputEvent";

	public const string CloseButtonEvent = "LEPropertiesView.CloseButtonEvent";

	private SliderManager groundHeightSlider;

	private SliderManager failureZoneHeightSlider;

	private Toggle failureZoneToggle;

	private TMP_InputField handSnapStepInput;

	private TMP_InputField moveSnapStepInput;

	private TMP_InputField rotationSnapStepInput;

	private TMP_InputField scaleSnapStepInput;

	private Button closeButton;

	public bool IsAnyInputFieldFocused
	{
		get
		{
			if (!handSnapStepInput.isFocused && !moveSnapStepInput.isFocused && !rotationSnapStepInput.isFocused)
			{
				return scaleSnapStepInput.isFocused;
			}
			return true;
		}
	}

	public override void Initialize()
	{
		groundHeightSlider = mainPanel.transform.FindComponent<SliderManager>("GroundHeightSlider", isRecursively: true);
		failureZoneHeightSlider = mainPanel.transform.FindComponent<SliderManager>("FailureZoneHeightSlider", isRecursively: true);
		failureZoneToggle = mainPanel.transform.FindComponent<Toggle>("FailureZoneToggle", isRecursively: true);
		handSnapStepInput = mainPanel.transform.FindComponent<TMP_InputField>("HandSnapStepInput", isRecursively: true);
		moveSnapStepInput = mainPanel.transform.FindComponent<TMP_InputField>("MoveSnapStepInput", isRecursively: true);
		rotationSnapStepInput = mainPanel.transform.FindComponent<TMP_InputField>("RotationSnapStepInput", isRecursively: true);
		scaleSnapStepInput = mainPanel.transform.FindComponent<TMP_InputField>("ScaleSnapStepInput", isRecursively: true);
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		groundHeightSlider.ConfigureProperties(-15f, -15f, 0f, 1f);
		failureZoneHeightSlider.ConfigureProperties(-15f, -15f, 0f, 1f);
		groundHeightSlider.OnValueChangedEvent += delegate(float value)
		{
			NotifyChange("LEPropertiesView.GroundHeightSliderEvent", value);
		};
		failureZoneHeightSlider.OnValueChangedEvent += delegate(float value)
		{
			NotifyChange("LEPropertiesView.FailureZoneHeightSliderEvent", value);
		};
		failureZoneToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("LEPropertiesView.FailureZoneToggleEvent", isOn);
		});
		handSnapStepInput.onEndEdit.AddListener(delegate(string valeu)
		{
			NotifyChange("LEPropertiesView.HandSnapStepInputEvent", valeu);
		});
		moveSnapStepInput.onEndEdit.AddListener(delegate(string valeu)
		{
			NotifyChange("LEPropertiesView.MoveSnapStepInputEvent", valeu);
		});
		rotationSnapStepInput.onEndEdit.AddListener(delegate(string valeu)
		{
			NotifyChange("LEPropertiesView.RotationSnapStepInputEvent", valeu);
		});
		scaleSnapStepInput.onEndEdit.AddListener(delegate(string valeu)
		{
			NotifyChange("LEPropertiesView.ScaleSnapStepInputEvent", valeu);
		});
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("LEPropertiesView.CloseButtonEvent");
		});
		Util.AddMouseOverUIEvents(mainPanel, base.OnMouseOverUIHandler);
	}

	public void SetGroundHeightSliderValue(float height)
	{
		groundHeightSlider.SetCurrentValue(height);
	}

	public void SetFailureZoneHeightSliderValue(float height)
	{
		failureZoneHeightSlider.SetCurrentValue(height);
	}

	public void SetFailureZoneToggleValue(bool isSelected)
	{
		if (failureZoneToggle.isOn != isSelected)
		{
			failureZoneToggle.SetValue(isSelected);
		}
	}

	public bool GetFailureZoneToggleValue()
	{
		return failureZoneToggle.isOn;
	}

	public void SetHandSnapStepInputValue(float value)
	{
		handSnapStepInput.SetTextWithoutNotify(value.ToString());
	}

	public void SetMoveSnapStepInputValue(float value)
	{
		moveSnapStepInput.SetTextWithoutNotify(value.ToString());
	}

	public void SetRotationSnapStepInputValue(float value)
	{
		rotationSnapStepInput.SetTextWithoutNotify(value.ToString());
	}

	public void SetScaleSnapStepInputValue(float value)
	{
		scaleSnapStepInput.SetTextWithoutNotify(value.ToString());
	}
}
