using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class CameraSettings : Settings
	{
		[SerializeField]
		private bool _canProcessInput = true;

		public bool CanProcessInput
		{
			get
			{
				return _canProcessInput;
			}
			set
			{
				_canProcessInput = value;
			}
		}
	}
}
