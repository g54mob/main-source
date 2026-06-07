using System;
using System.Collections.Generic;
using Linework.Common.Utils;
using UnityEngine;

namespace Linework.SurfaceFill
{
	[CreateAssetMenu(fileName = "Surface Fill Settings", menuName = "Linework/Surface Fill Settings")]
	public class SurfaceFillSettings : ScriptableObject
	{
		internal Action OnSettingsChanged;

		[SerializeField]
		private InjectionPoint injectionPoint = InjectionPoint.AfterRenderingPostProcessing;

		[SerializeField]
		private bool showInSceneView = true;

		[SerializeField]
		private List<Fill> fills = new List<Fill>(8);

		public InjectionPoint InjectionPoint => injectionPoint;

		public bool ShowInSceneView => showInSceneView;

		public List<Fill> Fills => fills;

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
			fills = null;
		}

		public void SetActive(bool active)
		{
			foreach (Fill fill in fills)
			{
				fill.SetActive(active);
			}
		}
	}
}
