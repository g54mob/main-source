using System;
using System.Collections.Generic;
using Linework.Common.Utils;
using UnityEngine;

namespace Linework.WideOutline
{
	[CreateAssetMenu(fileName = "Wide Outline Settings", menuName = "Linework/Wide Outline Settings")]
	public class WideOutlineSettings : ScriptableObject
	{
		internal Action OnSettingsChanged;

		[SerializeField]
		private InjectionPoint injectionPoint = InjectionPoint.AfterRenderingPostProcessing;

		[SerializeField]
		private bool showInSceneView = true;

		[SerializeField]
		private List<Outline> outlines = new List<Outline>(10);

		public MaterialType materialType;

		public Material customMaterial;

		[Range(0f, 100f)]
		public float width = 30f;

		public BlendingMode blendMode;

		public bool customDepthBuffer;

		[ColorUsage(true, true)]
		public Color occludedColor = Color.red;

		public InjectionPoint InjectionPoint => injectionPoint;

		public bool ShowInSceneView => showInSceneView;

		public List<Outline> Outlines => outlines;

		public void Changed()
		{
			foreach (Outline outline in outlines)
			{
				outline.SetAdvancedOcclusionEnabled(customDepthBuffer);
			}
			OnSettingsChanged?.Invoke();
		}

		private void OnValidate()
		{
		}

		private void OnDestroy()
		{
			OnSettingsChanged = null;
			outlines = null;
		}

		public void SetActive(bool active)
		{
			foreach (Outline outline in outlines)
			{
				outline.SetActive(active);
			}
		}
	}
}
