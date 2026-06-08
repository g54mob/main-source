using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace BrewedInk.CRT
{
	[Serializable]
	public class CRTData
	{
		[Tooltip("A value of 0 means no down-sampling. Any number above 1 will down-sample the texture by the value.")]
		public int pixelationAmount;

		[Tooltip("Each channel controls the maximum amount of values for that channel. A value of 0 means infinite values.")]
		public ColorChannels maxColorChannels;

		[Tooltip("0 means no dithering. 1 means all dithering. Dithering will help shade a color crunched image to look like it has more coloring that it really does. This dithering uses a 4x4 bayer dithering matrix.")]
		[Range(0f, 1f)]
		[FormerlySerializedAs("dithering")]
		public float dithering4;

		[Tooltip("0 means no dithering. 1 means all dithering. Dithering will help shade a color crunched image to look like it has more coloring that it really does. This dithering uses a 8x8 bayer dithering matrix.")]
		[Range(0f, 1f)]
		public float dithering8;

		[Tooltip("Controls the dark vignette around the inside of the screen")]
		[Range(0f, 1f)]
		public float vignette = 0.1f;

		[Tooltip("Controls how visible the inner picture is.")]
		[Range(0f, 20f)]
		public float innerCurve = 20f;

		[Tooltip("Controls how curved the monitor is")]
		[Range(0f, 0.5f)]
		public float monitorCurve = 0.1f;

		[Tooltip("Controls how big the inner monitor is")]
		[HideInInspector]
		public ScreenDimensions monitorInnerSize = new ScreenDimensions
		{
			height = 0f,
			width = 0f
		};

		[Tooltip("Controls how big the inner monitor is")]
		public ScreenDimensions monitorOutterSize = new ScreenDimensions
		{
			height = 0.1f,
			width = 0.1f
		};

		[Tooltip("Controls how zoomed in the camera is")]
		[Range(0f, 2f)]
		public float zoom = 1f;

		[Tooltip("Controls how round the edge of the screen is")]
		[Range(0f, 1f)]
		[HideInInspector]
		public float monitorRoundness = 0.2f;

		[Tooltip("A detail texture for the monitor")]
		public Texture2D monitorTexture;

		[Tooltip("A tint color for the monitor")]
		public Color monitorColor = Color.grey;

		[Tooltip("The higher the value, the darker the inner monitor section")]
		[Range(0f, 1f)]
		public float innerMonitorDarkness = 0.6f;

		[Tooltip("The higher the value, the shinier the inner monitor section")]
		[Range(0f, 1f)]
		public float innerMonitorShine = 0.1f;

		[Tooltip("Controls the horizontal scan color lines")]
		public ColorScan colorScans = new ColorScan
		{
			greenChannelMultiplier = 0.1f,
			redBlueChannelMultiplier = 0.15f,
			sizeMultiplier = 2f
		};

		[Tooltip("Intensity level of chromatic abberation")]
		[Range(0f, 0.01f)]
		public float chromaticAbberation;

		[Range(-0.1f, 0.1f)]
		[HideInInspector]
		public float innerMonitorShineRadius = -0.087f;

		[Range(0.1f, 10f)]
		[HideInInspector]
		public float innerMonitorShineCurve = 10f;

		public CRTData Clone()
		{
			return JsonUtility.FromJson<CRTData>(JsonUtility.ToJson(this));
		}

		public static CRTData Lerp(CRTData a, CRTData b, float t)
		{
			CRTData cRTData = b.Clone();
			cRTData.zoom = Mathf.Lerp(a.zoom, b.zoom, t);
			cRTData.dithering4 = Mathf.Lerp(a.dithering4, b.dithering4, t);
			cRTData.dithering8 = Mathf.Lerp(a.dithering8, b.dithering8, t);
			cRTData.vignette = Mathf.Lerp(a.vignette, b.vignette, t);
			cRTData.innerCurve = Mathf.Lerp(a.innerCurve, b.innerCurve, t);
			cRTData.monitorCurve = Mathf.Lerp(a.monitorCurve, b.monitorCurve, t);
			cRTData.monitorRoundness = Mathf.Lerp(a.monitorRoundness, b.monitorRoundness, t);
			cRTData.innerMonitorDarkness = Mathf.Lerp(a.innerMonitorDarkness, b.innerMonitorDarkness, t);
			cRTData.innerMonitorShine = Mathf.Lerp(a.innerMonitorShine, b.innerMonitorShine, t);
			cRTData.innerMonitorShineCurve = Mathf.Lerp(a.innerMonitorShineCurve, b.innerMonitorShineCurve, t);
			cRTData.innerMonitorShineRadius = Mathf.Lerp(a.innerMonitorShineRadius, b.innerMonitorShineRadius, t);
			cRTData.colorScans.sizeMultiplier = Mathf.Lerp(a.colorScans.sizeMultiplier, b.colorScans.sizeMultiplier, t);
			cRTData.colorScans.greenChannelMultiplier = Mathf.Lerp(a.colorScans.greenChannelMultiplier, b.colorScans.greenChannelMultiplier, t);
			cRTData.colorScans.redBlueChannelMultiplier = Mathf.Lerp(a.colorScans.redBlueChannelMultiplier, b.colorScans.redBlueChannelMultiplier, t);
			cRTData.monitorColor = Color.Lerp(a.monitorColor, b.monitorColor, t);
			cRTData.maxColorChannels.greyScale = Mathf.Lerp(a.maxColorChannels.greyScale, b.maxColorChannels.greyScale, t);
			cRTData.maxColorChannels.blue = (int)Mathf.Lerp(a.maxColorChannels.blue, b.maxColorChannels.blue, t);
			cRTData.maxColorChannels.green = (int)Mathf.Lerp(a.maxColorChannels.green, b.maxColorChannels.green, t);
			cRTData.maxColorChannels.red = (int)Mathf.Lerp(a.maxColorChannels.red, b.maxColorChannels.red, t);
			cRTData.pixelationAmount = (int)Mathf.Lerp(a.pixelationAmount, b.pixelationAmount, t);
			cRTData.monitorInnerSize.height = Mathf.Lerp(a.monitorInnerSize.height, b.monitorInnerSize.height, t);
			cRTData.monitorInnerSize.width = Mathf.Lerp(a.monitorInnerSize.width, b.monitorInnerSize.width, t);
			cRTData.monitorOutterSize.height = Mathf.Lerp(a.monitorOutterSize.height, b.monitorOutterSize.height, t);
			cRTData.monitorOutterSize.width = Mathf.Lerp(a.monitorOutterSize.width, b.monitorOutterSize.width, t);
			return cRTData;
		}
	}
}
