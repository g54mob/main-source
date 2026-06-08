using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CMobileApplianceResetPoint : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public Vector3 Start;
	}
}
