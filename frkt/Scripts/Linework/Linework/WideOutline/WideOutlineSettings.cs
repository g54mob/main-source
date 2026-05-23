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
		private InjectionPoint injectionPoint;

		[SerializeField]
		private bool showInSceneView;

		[SerializeField]
		private List<Outline> outlines;

		public MaterialType materialType;

		public Material customMaterial;

		public WidthControl widthControl;

		[Range(0f, 100f)]
		public float sharedWidth;

		[Range(0f, 1f)]
		public float gap;

		public BlendingMode blendMode;

		public bool customDepthBuffer;

		[ColorUsage(true, true)]
		public Color occludedColor;

		public InjectionPoint InjectionPoint => default(InjectionPoint);

		public bool ShowInSceneView => false;

		public List<Outline> Outlines => null;

		public void Changed()
		{
		}

		private void OnValidate()
		{
		}

		private void OnDestroy()
		{
		}

		public void SetActive(bool active)
		{
		}
	}
}
