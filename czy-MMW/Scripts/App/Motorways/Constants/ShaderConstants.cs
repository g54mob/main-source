using UnityEngine;

namespace Motorways.Constants
{
	public static class ShaderConstants
	{
		public static readonly int HighestMotorwayTexture = Shader.PropertyToID("_HighestMotorwayTexture");

		public static readonly int ShadowTypeTexture = Shader.PropertyToID("_ShadowTypeTexture");

		public static readonly int ShadowType = Shader.PropertyToID("_ShadowType");

		public static readonly int HeadlightOcclusionTexture = Shader.PropertyToID("_HeadlightOcclusionTexture");

		public static readonly int ShadowColor = Shader.PropertyToID("_ShadowColor");

		public static readonly int Blend = Shader.PropertyToID("_Blend");

		public static readonly int TintTex = Shader.PropertyToID("_TintTex");

		public static readonly int PaperTex = Shader.PropertyToID("_PaperTex");

		public static readonly int VignetteColor = Shader.PropertyToID("_Vignette_Color");

		public static readonly int VignetteCenter = Shader.PropertyToID("_Vignette_Center");

		public static readonly int VignetteSettings = Shader.PropertyToID("_Vignette_Settings");

		public static readonly int Colors = Shader.PropertyToID("_Colors");

		public static readonly int GroupId = Shader.PropertyToID("_GroupId");

		public static readonly int UseColorsBuffer = Shader.PropertyToID("_UseColorsBuffer");

		public static readonly int ThemeComponentGroupTargetCount = Shader.PropertyToID("_ThemeComponentGroupTargetCount");

		public static readonly int HeadlightOcclusionTypeId = Shader.PropertyToID("_HeadlightOcclusionTypeId");

		public static readonly int MotorwayIdShaderId = Shader.PropertyToID("_MotorwayId");

		public static readonly int BeamLength = Shader.PropertyToID("_BeamLength");

		public static readonly int HalfBeamWidth = Shader.PropertyToID("_HalfBeamWidth");

		public static readonly int CircleOffset = Shader.PropertyToID("_CircleOffset");

		public static readonly int CircleRadius = Shader.PropertyToID("_CircleRadius");

		public static readonly int LeftCutPoint = Shader.PropertyToID("_LeftCutPoint");

		public static readonly int RightCutPoint = Shader.PropertyToID("_RightCutPoint");

		public static readonly int Intensity = Shader.PropertyToID("_Intensity");

		public static readonly int ObjectToLocalMatrix = Shader.PropertyToID("_ObjectToLocalMatrix");

		public static readonly int LeftHeadlightPosition = Shader.PropertyToID("_LeftHeadlightPosition");

		public static readonly int Alpha = Shader.PropertyToID("_Alpha");

		public static readonly float HeadlightNonVehicleOcclusionTypeId = float.MaxValue;

		public static readonly int TrailTime = Shader.PropertyToID("_TrailTime");

		public static readonly int TrailTimeEnd = Shader.PropertyToID("_TrailTimeEnd");

		public static readonly int OpacityThreshold = Shader.PropertyToID("_OpacityThreshold");

		public static readonly int WaveWidth = Shader.PropertyToID("_WaveWidth");

		public static readonly int WaveLength = Shader.PropertyToID("_WaveLength");

		public static readonly int OverallOpacity = Shader.PropertyToID("_OverallOpacity");

		public static readonly int MotorwayInnerOpacity = Shader.PropertyToID("_MotorwayInnerOpacity");

		public static readonly int MotorwayOuterOpacity = Shader.PropertyToID("_MotorwayOuterOpacity");

		public static readonly int RoadWidth = Shader.PropertyToID("_RoadWidth");

		public static readonly int RoadOutlineWidth = Shader.PropertyToID("_RoadOutlineWidth");

		public static readonly int BlendingSize = Shader.PropertyToID("_BlendingSize");

		public static readonly int HazardFadeoutOffset = Shader.PropertyToID("_HazardFadeoutOffset");

		public static readonly int HazardFadeoutDistance = Shader.PropertyToID("_HazardFadeoutDistance");

		public static readonly int HazardStripeWidth = Shader.PropertyToID("_HazardStripeWidth");

		public static readonly int HazardStripeOpacity = Shader.PropertyToID("_HazardStripeOpacity");

		public static readonly int HalfHazardStripeWidth = Shader.PropertyToID("_HalfHazardStripeWidth");

		public static readonly int DistanceBetweenHazardStripes = Shader.PropertyToID("_DistanceBetweenHazardStripes");

		public static readonly int FadeoutDistance = Shader.PropertyToID("_FadeoutDistance");

		public static readonly int SplineSegments = Shader.PropertyToID("_SplineSegments");

		public static readonly int LinearDistanceTable = Shader.PropertyToID("_LinearDistanceTable");

		public static readonly int LinearDistanceTableLength = Shader.PropertyToID("_LinearDistanceTableLength");

		public static readonly int DepthSegmentBuffer = Shader.PropertyToID("_DepthSegmentBuffer");

		public static readonly int DepthSegmentBufferLength = Shader.PropertyToID("_DepthSegmentBufferLength");

		public static readonly int MinMotorwayWorldHeight = Shader.PropertyToID("_MinMotorwayWorldHeight");

		public static readonly int ShadowFadeoutBuffer = Shader.PropertyToID("_ShadowFadeoutBuffer");

		public static readonly int HazardStripeSamples = Shader.PropertyToID("_HazardStripeSamples");

		public static readonly int HazardStripeLastIndex = Shader.PropertyToID("_HazardStripeLastIndex");

		public static readonly int RoadColor = Shader.PropertyToID("_RoadColor");

		public static readonly int MotorwayColor = Shader.PropertyToID("_MotorwayColor");

		public static readonly int OutlineColor = Shader.PropertyToID("_OutlineColor");

		public static readonly int MotorwayOutlineColor = Shader.PropertyToID("_MotorwayOutlineColor");

		public static readonly int MotorwayId = Shader.PropertyToID("_MotorwayId");
	}
}
