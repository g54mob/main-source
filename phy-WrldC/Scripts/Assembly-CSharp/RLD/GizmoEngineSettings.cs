using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class GizmoEngineSettings : Settings
	{
		[SerializeField]
		private bool _enableGizmoSorting = true;

		public bool EnableGizmoSorting
		{
			get
			{
				return _enableGizmoSorting;
			}
			set
			{
				_enableGizmoSorting = value;
			}
		}
	}
}
