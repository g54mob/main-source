using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class TraderSlot
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private Vector3[] visualAssetSlots;

		public string ID => id;

		public Vector3[] VisualAssetSlots => visualAssetSlots;
	}
}
