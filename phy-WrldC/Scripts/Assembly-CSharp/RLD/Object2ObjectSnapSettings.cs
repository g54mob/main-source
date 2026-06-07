using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class Object2ObjectSnapSettings : Settings
	{
		[SerializeField]
		private int _snapDestinationLayers = -1;

		[SerializeField]
		private bool _canClimbObjects = true;

		[SerializeField]
		private float _snapRadius = 0.7f;

		public int SnapDestinationLayers
		{
			get
			{
				return _snapDestinationLayers;
			}
			set
			{
				_snapDestinationLayers = value;
			}
		}

		public bool CanClimbObjects
		{
			get
			{
				return _canClimbObjects;
			}
			set
			{
				_canClimbObjects = value;
			}
		}

		public float SnapRadius
		{
			get
			{
				return _snapRadius;
			}
			set
			{
				_snapRadius = Mathf.Max(0f, value);
			}
		}
	}
}
