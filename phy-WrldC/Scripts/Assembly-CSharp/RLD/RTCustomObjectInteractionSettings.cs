using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class RTCustomObjectInteractionSettings : Settings
	{
		[SerializeField]
		private Vector3 _noVolumeObjectSize = Vector3Ex.FromValue(0.5f);

		public Vector3 NoVolumeObjectSize
		{
			get
			{
				return _noVolumeObjectSize;
			}
			set
			{
				if (!Application.isPlaying)
				{
					_noVolumeObjectSize = Vector3.Max(Vector3.zero, value);
				}
			}
		}
	}
}
