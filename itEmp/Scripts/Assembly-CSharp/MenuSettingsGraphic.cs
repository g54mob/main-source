using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MenuSettingsGraphic : MonoBehaviour
{
	public MenuSettingsDisplay menuSettingsDisplay;

	public PostProcessProfile processGameProfile;

	[Header("Menu Shadow Quality")]
	public List<string> shadowQuality;

	public TMP_Text viewShadowQuality;

	private int nowindexShadowQuality;

	private string selectedShadowQuality;

	[Header("Menu Shadow Quality")]
	public List<string> shadingQuality;

	public TMP_Text viewShadingQuality;

	private int nowindexShadingQuality;

	private string selectedShadingQuality;

	[Header("Menu Anti Alising")]
	public List<string> antiAlising;

	public TMP_Text viewAntiAlising;

	private int nowindexAntiAlising;

	private string selectedAntiAlising;

	[Header("Menu Quality Graphic")]
	public List<string> qualityGraphic;

	public TMP_Text viewQualityGraphic;

	private int nowindexQualityGraphic;

	private string selectedQualityGraphic;

	[Header("Menu Post Processing")]
	public List<string> postProcessing;

	public TMP_Text viewPostProcessing;

	private int nowindexPostProcessing;

	private string selectedPostProcessing;

	private MenuSettingsListAnimView animPostProcessing1;

	private MenuSettingsListAnimView animPostProcessing2;

	private MenuSettingsListAnimView animPostProcessing3;

	private MenuSettingsListAnimView animPostProcessing4;

	[Header("Menu Post Processing Intensity")]
	public List<string> postProcessing_intensity;

	public TMP_Text viewPostProcessing_intensity;

	private int nowindexPostProcessing_intensity;

	private string selectedPostProcessing_intensity;

	public CanvasGroup postProcessingCanvasGroup_intensity;

	public RectTransform postProcessingRectTransform_intensity;

	[Header("Menu Bloom")]
	public List<string> postProcessing_bloom;

	public TMP_Text viewPostProcessing_bloom;

	private int nowindexPostProcessing_bloom;

	private string selectedPostProcessing_bloom;

	public CanvasGroup postProcessingCanvasGroup_bloom;

	public RectTransform postProcessingRectTransform_bloom;

	[Header("Menu Montion Blur")]
	public List<string> postProcessing_montionBlur;

	public TMP_Text viewPostProcessing_montionBlur;

	private int nowindexPostProcessing_montionBlur;

	private string selectedPostProcessing_montionBlur;

	public CanvasGroup postProcessingCanvasGroup_montionBlur;

	public RectTransform postProcessingRectTransform_montionBlur;

	[Header("Menu Depth Of Field")]
	public List<string> postProcessing_depthOfField;

	public TMP_Text viewPostProcessing_depthOfField;

	private int nowindexPostProcessing_depthOfField;

	private string selectedPostProcessing_depthOfField;

	public CanvasGroup postProcessingCanvasGroup_depthOfField;

	public RectTransform postProcessingRectTransform_depthOfField;

	private void Awake()
	{
	}

	public void SetNextShadowQualityButton(int value)
	{
	}

	private void SetShadowQualityAction(int value, bool increment = true)
	{
	}

	public static void SetShadowQuality(int mode)
	{
	}

	public void SetNextShadingQualityButton(int value)
	{
	}

	private void SetShadingQualityAction(int value, bool increment = true)
	{
	}

	public static void SetShadingQuality(int mode)
	{
	}

	public void SetNextAntiAlisingButton(int value)
	{
	}

	private void SetAntiAlisingAction(int value, bool increment = true)
	{
	}

	public static void SetAntiAlising(int mode)
	{
	}

	public void SetNextQualityGraphicButton(int value)
	{
	}

	private void SetQualityGraphicAction(int value, bool increment = true)
	{
	}

	public static void SetQualityGraphic(int mode)
	{
	}

	public void SetNextPostProcessingButton(int value)
	{
	}

	private void SetPostProcessingAction(int value, bool increment = true)
	{
	}

	private void SetPostProcessing(int mode)
	{
	}

	public void SetNextPostProcessingIntensityButton(int value)
	{
	}

	private void SetPostProcessingIntensityAction(int value, bool increment = true)
	{
	}

	private void SetPostProcessingIntensity(int mode)
	{
	}

	public void SetNextPostProcessingBloomButton(int value)
	{
	}

	private void SetPostProcessingBloomAction(int value, bool increment = true)
	{
	}

	private void SetPostProcessingBloom(int mode)
	{
	}

	public void SetNextPostProcessingMontionBlurButton(int value)
	{
	}

	private void SetPostProcessingMontionBlurAction(int value, bool increment = true)
	{
	}

	private void SetPostProcessingMontionBlur(int mode)
	{
	}

	public void SetNextPostProcessingDepthOfFieldButton(int value)
	{
	}

	private void SetPostProcessingDepthOfFieldAction(int value, bool increment = true)
	{
	}

	private void SetPostProcessingDepthOfField(int mode)
	{
	}

	public void SetDeflaut()
	{
	}

	public void LoadSettings()
	{
	}

	public void UpdateTranslateText()
	{
	}
}
