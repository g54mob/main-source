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
		private InjectionPoint injectionPoint;

		[SerializeField]
		private bool showInSceneView;

		[SerializeField]
		private List<Outline> outlines;

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
