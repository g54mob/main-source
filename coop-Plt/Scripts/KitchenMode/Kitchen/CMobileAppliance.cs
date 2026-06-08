using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CMobileAppliance : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public float Speed;

		public bool AimForDirt;

		[HideInInspector]
		public Vector3 Target;
	}
}
