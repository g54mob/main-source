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
		private InjectionPoint injectionPoint = InjectionPoint.AfterRenderingPostProcessing;

		[SerializeField]
		private bool showInSceneView = true;

		[SerializeField]
		private List<Outline> outlines = new List<Outline>(10);

		public OutlineType type;

		[Range(0f, 1f)]
		public float hardness = 1f;

		[ColorUsage(true, true)]
		public Color sharedColor = Color.green;

		[Range(0.1f, 30f)]
		public float intensity = 1.2f;

		[Range(0f, 1f)]
		public float gap;

		public BlendingMode blendMode = BlendingMode.Additive;

		public DilationMethod dilationMethod = DilationMethod.Dilate;

		[Range(0f, 50f)]
		public int kernelSize = 20;

		[Range(0.5f, 50f)]
		public float blurSpread = 1.35f;

		[Range(2f, 10f)]
		public int blurPasses = 2;

		public bool scaleWithResolution = true;

		public Linework.Common.Utils.Resolution referenceResolution = Linework.Common.Utils.Resolution._1080;

		public float customResolution;

		public InjectionPoint InjectionPoint => injectionPoint;

		public bool ShowInSceneView => showInSceneView;

		public List<Outline> Outlines => outlines;

		public void Changed()
		{
			foreach (Outline outline in outlines)
			{
				outline.SetOutlineType(type);
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
