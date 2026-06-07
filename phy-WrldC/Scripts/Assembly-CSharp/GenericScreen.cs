using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenericScreen : BaseComponentView
{
	private LogicIO screenValueInput;

	private TextMeshProUGUI genericLabel;

	private TextMeshProUGUI genericValue;

	private Slider genericSlider;

	private int screenValueType;

	private float timeCounter;

	private string size;

	public float CurrentValue { get; private set; }

	private void Update()
	{
		timeCounter += Time.deltaTime;
		if (timeCounter >= 0.1f)
		{
			CurrentValue = screenValueInput.ReadAnalogSignal();
			SetScreenValue(CurrentValue);
			timeCounter = 0f;
		}
	}

	public void SetScreenValue(float value)
	{
		if (screenValueType == 0)
		{
			genericValue.SetText($"{value:0.00}");
		}
		else if (screenValueType == 1)
		{
			genericValue.SetText($"{Mathf.RoundToInt(value * 100f)}%");
		}
		else if (screenValueType == 2)
		{
			genericSlider.value = value;
		}
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		timeCounter = 0f;
		screenValueType = base.BlockBodyView.OverridableProperties.GetPropertyAsInt("gscreen_type");
		if (screenValueType == 0 || screenValueType == 1)
		{
			genericValue.gameObject.SetActive(value: true);
			genericSlider.transform.parent.gameObject.SetActive(value: false);
		}
		else if (screenValueType == 2)
		{
			genericValue.gameObject.SetActive(value: false);
			genericSlider.transform.parent.gameObject.SetActive(value: true);
		}
		string property = base.BlockBodyView.OverridableProperties.GetProperty("gscreen_label");
		genericLabel.gameObject.SetActive(!string.IsNullOrEmpty(property));
		genericLabel.SetText(property);
	}

	public override void SetBlockDestroyed()
	{
		base.SetBlockDestroyed();
		genericValue.SetText("---");
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("GenericSceenCanvas"));
		gameObject.transform.SetParent(base.transform, worldPositionStays: false);
		gameObject.name = "GenericSceenCanvas";
		genericLabel = gameObject.transform.FindComponent<TextMeshProUGUI>("GenericLabel", isRecursively: true);
		genericLabel.gameObject.SetActive(value: false);
		genericValue = gameObject.transform.FindComponent<TextMeshProUGUI>("GenericValue", isRecursively: true);
		genericValue.SetText("0");
		genericSlider = gameObject.transform.FindComponent<Slider>("GenericSlider", isRecursively: true);
		genericSlider.transform.parent.gameObject.SetActive(value: false);
		size = properties.GetProperty("size", "small");
		RectTransform rectTransform = gameObject.transform as RectTransform;
		switch (size)
		{
		case "small":
			rectTransform.localPosition = new Vector3(0.004f, 0f, 0f);
			rectTransform.localRotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
			rectTransform.sizeDelta = new Vector2(210f, 210f);
			break;
		case "wide":
			rectTransform.localPosition = new Vector3(0.004f, 0f, 0f);
			rectTransform.localRotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
			rectTransform.sizeDelta = new Vector2(460f, 210f);
			break;
		case "wide45":
			rectTransform.localPosition = new Vector3(0.0307f, 0.1296f, 0f);
			rectTransform.localRotation = Quaternion.Euler(new Vector3(45f, -90f, 0f));
			rectTransform.sizeDelta = new Vector2(460f, 210f);
			break;
		case "full":
			rectTransform.localPosition = new Vector3(0.004f, 0f, 0f);
			rectTransform.localRotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
			rectTransform.sizeDelta = new Vector2(460f, 460f);
			break;
		}
		base.gameObject.AddComponent<GenericScreenReplay>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		screenValueInput = base.BlockBodyView.AddLogicIO(new LogicIO("gscreen_value", LogicIODirection.Input, 0f)
		{
			IsInputWithoutKey = true,
			ValueType = LogicIOValueType.Raw
		});
	}

	protected override void InternalInitializeGizmos<T>(T componentModel)
	{
		base.InternalInitializeGizmos(componentModel);
		if (componentModel.Properties.GetProperty("size", "small") != "wide45")
		{
			InstantiateGizmoObject("GenericScreenGizmo");
		}
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		genericValue.SetText("0");
	}

	public override string GetComponentName()
	{
		return typeof(GenericScreen).Name;
	}
}
