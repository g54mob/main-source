using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CAutomatedInteractorRandomActiveInterval : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public float MinSeconds;

		public float MaxSeconds;

		[HideInInspector]
		public float RemainingSeconds;

		[HideInInspector]
		public bool Active;
	}
}
