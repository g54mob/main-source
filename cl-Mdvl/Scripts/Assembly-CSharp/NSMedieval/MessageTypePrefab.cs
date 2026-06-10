using System;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	internal struct MessageTypePrefab
	{
		[SerializeField]
		public WarningMessageCategory messageType;

		[SerializeField]
		public WarningMessageLayoutItemView prefab;
	}
}
