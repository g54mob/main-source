using System;
using Linework.Common.Utils;
using UnityEngine;

namespace Linework.EdgeDetection
{
	[CreateAssetMenu(fileName = "Edge Detection Settings", menuName = "Linework/Edge Detection Settings")]
	public class EdgeDetectionSettings : ScriptableObject
	{
		internal Action OnSettingsChanged;

		[SerializeField]
		private InjectionPoint injectionPoint = InjectionPoint.AfterRenderingPostProcessing;

		[SerializeField]
		private bool showInSceneView = true;

		[SerializeField]
		private DebugView debugView;

		public bool debugSectionsRaw;

		public DiscontinuityInput discontinuityInput = DiscontinuityInput.Depth | DiscontinuityInput.Normals | DiscontinuityInput.Luminance | DiscontinuityInput.Sections;

		[Range(0f, 1f)]
		public float depthSensitivity = 1f;

		[Range(0f, 1f)]
		public float depthDistanceModulation = 0.4f;

		[Range(0f, 1f)]
		public float grazingAngleMaskPower = 0.2f;

		[Range(1f, 30f)]
		public float grazingAngleMaskHardness = 1f;

		[Range(0f, 1f)]
		public float normalSensitivity = 0.4f;

		[Range(0f, 1f)]
		public float luminanceSensitivity = 0.3f;

		public RenderingLayerMask SectionRenderingLayer = RenderingLayerMask.defaultRenderingLayerMask;

		public bool objectId = true;

		public bool particles;

		public bool sectionsMask;

		public bool depthMask;

		public bool normalsMask;

		public bool luminanceMask;

		public SectionMapInput sectionMapInput;

		public Texture2D sectionTexture;

		public UVSet sectionTextureUvSet;

		public Channel sectionTextureChannel;

		public Channel vertexColorChannel;

		public Kernel kernel;

		[Range(0f, 15f)]
		public int outlineThickness = 3;

		public bool scaleWithResolution;

		public Resolution referenceResolution;

		public float customResolution;

		[ColorUsage(true, true)]
		public Color backgroundColor = Color.clear;

		[ColorUsage(true, true)]
		public Color outlineColor = Color.black;

		public bool overrideColorInShadow;

		[ColorUsage(true, true)]
		public Color outlineColorShadow = Color.white;

		[ColorUsage(true, true)]
		public Color fillColor = Color.black;

		public bool fadeInDistance;

		[ColorUsage(true, true)]
		public Color fadeColor = Color.clear;

		[Range(0f, 200f)]
		public float fadeStart = 100f;

		[Range(0.1f, 20f)]
		public float fadeDistance = 10f;

		public BlendingMode blendMode;

		public bool showDiscontinuitySection;

		public bool showOutlineSection;

		public bool showExperimentalSection;

		public InjectionPoint InjectionPoint => injectionPoint;

		public bool ShowInSceneView => showInSceneView;

		public DebugView DebugView => debugView;

		private void OnValidate()
		{
		}

		private void OnDestroy()
		{
			OnSettingsChanged = null;
		}
	}
}
