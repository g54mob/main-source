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
		private InjectionPoint injectionPoint;

		[SerializeField]
		private bool showInSceneView;

		[SerializeField]
		private List<Fill> fills;

		public InjectionPoint InjectionPoint => default(InjectionPoint);

		public bool ShowInSceneView => false;

		public List<Fill> Fills => null;

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
