using System;
using System.Collections.Generic;
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

		public bool objectId = true;

		public bool particles;

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

		public bool fadeByDistance;

		[ColorUsage(true, true)]
		public Color distanceFadeColor = Color.clear;

		[Range(0f, 200f)]
		public float distanceFadeStart = 100f;

		[Range(0.1f, 20f)]
		public float distanceFadeDistance = 10f;

		public bool fadeByHeight;

		[ColorUsage(true, true)]
		public Color heightFadeColor = Color.clear;

		[Range(0f, 2f)]
		public float heightFadeStart = 1f;

		[Range(0.01f, 2f)]
		public float heightFadeDistance = 0.5f;

		public BlendingMode blendMode;

		public SectionMapPrecision sectionMapPrecision = SectionMapPrecision._16bit;

		[Range(0f, 256f)]
		public int sectionMapClearValue = 1;

		public List<SectionPass> additionalSectionPasses = new List<SectionPass>();

		public RenderingLayerMask SectionRenderingLayer = RenderingLayerMask.defaultRenderingLayerMask;

		public RenderingLayerMask SectionMaskRenderingLayer = 0;

		public MaskInfluence maskInfluence = MaskInfluence.Sections | MaskInfluence.Depth | MaskInfluence.Normals | MaskInfluence.Luminance;

		public bool showSectionMapSection;

		public bool showDiscontinuitySection;

		public bool showOutlineSection;

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
