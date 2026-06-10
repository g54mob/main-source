using System;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	internal struct MessageTypeTransform
	{
		[SerializeField]
		public WarningMessageCategory messageType;

		[SerializeField]
		public Transform transform;
	}
}
