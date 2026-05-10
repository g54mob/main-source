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
		private InjectionPoint injectionPoint;

		[SerializeField]
		private bool showInSceneView;

		[SerializeField]
		private DebugView debugView;

		public bool debugSectionsRaw;

		public DiscontinuityInput discontinuityInput;

		[Range(0f, 1f)]
		public float depthSensitivity;

		[Range(0f, 1f)]
		public float depthDistanceModulation;

		[Range(0f, 1f)]
		public float grazingAngleMaskPower;

		[Range(1f, 30f)]
		public float grazingAngleMaskHardness;

		[Range(0f, 1f)]
		public float normalSensitivity;

		[Range(0f, 1f)]
		public float luminanceSensitivity;

		public bool objectId;

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
		public int outlineThickness;

		public bool scaleWithResolution;

		public Resolution referenceResolution;

		public float customResolution;

		[ColorUsage(true, true)]
		public Color backgroundColor;

		[ColorUsage(true, true)]
		public Color outlineColor;

		public bool overrideColorInShadow;

		[ColorUsage(true, true)]
		public Color outlineColorShadow;

		[ColorUsage(true, true)]
		public Color fillColor;

		public bool fadeByDistance;

		[ColorUsage(true, true)]
		public Color distanceFadeColor;

		[Range(0f, 200f)]
		public float distanceFadeStart;

		[Range(0.1f, 20f)]
		public float distanceFadeDistance;

		public bool fadeByHeight;

		[ColorUsage(true, true)]
		public Color heightFadeColor;

		[Range(0f, 2f)]
		public float heightFadeStart;

		[Range(0.01f, 2f)]
		public float heightFadeDistance;

		public BlendingMode blendMode;

		public SectionMapPrecision sectionMapPrecision;

		[Range(0f, 256f)]
		public int sectionMapClearValue;

		public List<SectionPass> additionalSectionPasses;

		public RenderingLayerMask SectionRenderingLayer;

		public bool showSectionMapSection;

		public bool showDiscontinuitySection;

		public bool showOutlineSection;

		public InjectionPoint InjectionPoint => default(InjectionPoint);

		public bool ShowInSceneView => false;

		public DebugView DebugView => default(DebugView);

		private void OnValidate()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
