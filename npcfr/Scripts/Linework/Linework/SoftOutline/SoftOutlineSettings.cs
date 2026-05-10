using System;
using System.Collections.Generic;
using Linework.Common.Utils;
using UnityEngine;

namespace Linework.SoftOutline
{
	[CreateAssetMenu(fileName = "Soft Outline Settings", menuName = "Linework/Soft Outline Settings")]
	public class SoftOutlineSettings : ScriptableObject
	{
		internal Action OnSettingsChanged;

		[SerializeField]
		private InjectionPoint injectionPoint;

		[SerializeField]
		private bool showInSceneView;

		[SerializeField]
		private List<Outline> outlines;

		public OutlineType type;

		[Range(0f, 1f)]
		public float hardness;

		[ColorUsage(true, true)]
		public Color sharedColor;

		[Range(0.1f, 30f)]
		public float intensity;

		[Range(0f, 1f)]
		public float gap;

		public BlendingMode blendMode;

		public DilationMethod dilationMethod;

		[Range(0f, 50f)]
		public int kernelSize;

		[Range(0.5f, 50f)]
		public float blurSpread;

		[Range(2f, 10f)]
		public int blurPasses;

		public bool scaleWithResolution;

		public Linework.Common.Utils.Resolution referenceResolution;

		public float customResolution;

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
