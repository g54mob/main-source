using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectSelectionRotationSettings : Settings
	{
		[SerializeField]
		private ObjectRotationPivot _rotationPivot = ObjectRotationPivot.GroupCenter;

		[SerializeField]
		private ObjectKeyRotationSettings _keyRotationSettings = new ObjectKeyRotationSettings();

		public ObjectRotationPivot RotationPivot
		{
			get
			{
				return _rotationPivot;
			}
			set
			{
				_rotationPivot = value;
			}
		}

		public ObjectKeyRotationSettings KeyRotationSettings => _keyRotationSettings;
	}
}
