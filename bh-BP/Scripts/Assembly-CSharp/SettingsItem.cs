using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsItem : MonoBehaviour
{
	public OptionType TgtOption;

	public OptionDisplayMode DisplayMode;

	public static readonly string[] kOptionLabels;

	public static readonly string[] kOptionDescs;

	public static readonly string[] kFontLabels;

	public static readonly string[] kAmbientOcclLabels;

	public static readonly string[] kGraphicPresetLabels;

	public SettingsScreen Owner;

	public Localize LocLabel;

	public RectTransform XfmLabel;

	public TextMeshProUGUI TxtLabel;

	public CoolButton BtnBacking;

	[Header("Toggle")]
	public GameObject WrapperToggle;

	public Image ImgToggleOn;

	[Header("List")]
	public GameObject WrapperList;

	public CoolButton BtnListLeft;

	public CoolButton BtnListRight;

	public Localize LocListOption;

	public TextMeshProUGUI TxtListOption;

	[Header("Slider")]
	public TextMeshProUGUI TxtSliderLabel;

	public GameObject WrapperSlider;

	public Slider Slider;

	private float _lastSFXTickVal;

	public Sprite SprMobileSliderFill;

	public Sprite SprMobileSliderHandle;

	public CoolButtonViz VizListButtonMobile;

	private void Awake()
	{
	}

	public void Init(SettingsScreen scrn, OptionType ot)
	{
	}

	public void RefreshValues()
	{
	}

	private void OnClicked()
	{
	}

	public void OnLeftClicked()
	{
	}

	public void OnRightClicked()
	{
	}

	private void OnSliderChanged(float val)
	{
	}

	private void OnGraphicsPresetChanged()
	{
	}

	private void CheckGraphicsSettingChanged()
	{
	}

	private void OnHover()
	{
	}

	private void OnHoverExit()
	{
	}

	public static bool IsGraphicsOption(OptionType t)
	{
		return false;
	}
}
