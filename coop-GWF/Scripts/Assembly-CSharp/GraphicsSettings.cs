using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(menuName = "Game Settings/Graphics Settings", fileName = "GraphicsSettings")]
public class GraphicsSettings : ScriptableObject
{
	public enum QualityLevel
	{
		High = 0,
		Medium = 1,
		Low = 2
	}

	[Header("Quality Settings")]
	[Tooltip("Overall quality level: Low, Medium, or High")]
	public QualityLevel qualityLevel = QualityLevel.Medium;

	[Header("Quality Level Assets")]
	[Tooltip("URP Asset for Low quality")]
	public UniversalRenderPipelineAsset lowQualityAsset;

	[Tooltip("URP Asset for Medium quality")]
	public UniversalRenderPipelineAsset mediumQualityAsset;

	[Tooltip("URP Asset for High quality")]
	public UniversalRenderPipelineAsset highQualityAsset;

	[Header("Render Settings")]
	[Tooltip("Render scale (0.5 = 50%, 1.0 = 100%, 1.5 = 150%)")]
	[Range(0.5f, 2f)]
	public float renderScale = 1f;

	[Tooltip("Enable HDR rendering")]
	public bool enableHDR = true;

	[Tooltip("Anisotropic filtering mode")]
	public AnisotropicFiltering anisotropicFiltering = AnisotropicFiltering.Enable;

	[Header("Display Settings")]
	[Tooltip("Screen brightness adjustment (0.0 = black, 1.0 = normal, 2.0 = double brightness)")]
	[Range(0f, 2f)]
	public float brightness = 1f;

	[Tooltip("Film grain strength (0 = off, 1 = full)")]
	[Range(0f, 1f)]
	public float filmGrain = 1f;

	[Header("Texture Settings")]
	[Tooltip("Anisotropic filtering level. 0 = Off, valid levels are 2, 4, 8, 16.")]
	[Range(0f, 16f)]
	public int anisotropicFilteringLevel = 16;

	public static event Action<GraphicsSettings> SettingsChanged;

	public void NotifyChanged()
	{
		GraphicsSettings.SettingsChanged?.Invoke(this);
	}

	public UniversalRenderPipelineAsset GetQualityAsset()
	{
		return qualityLevel switch
		{
			QualityLevel.Low => lowQualityAsset, 
			QualityLevel.Medium => mediumQualityAsset, 
			QualityLevel.High => highQualityAsset, 
			_ => mediumQualityAsset, 
		};
	}
}
