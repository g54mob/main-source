using System;
using System.Collections.Generic;
using Linework.Common.Utils;
using UnityEngine;

namespace Linework.FastOutline
{
	[CreateAssetMenu(fileName = "Fast Outline Settings", menuName = "Linework/Fast Outline Settings")]
	public class FastOutlineSettings : ScriptableObject
	{
		internal Action OnSettingsChanged;

		[SerializeField]
		private InjectionPoint injectionPoint = InjectionPoint.AfterRenderingPostProcessing;

		[SerializeField]
		private bool showInSceneView = true;

		[SerializeField]
		private List<Outline> outlines = new List<Outline>(10);

		public InjectionPoint InjectionPoint => injectionPoint;

		public bool ShowInSceneView => showInSceneView;

		public List<Outline> Outlines => outlines;

		public void Changed()
		{
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
