using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CGenericInputIndicatorOffset : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public Vector3 Offset;
	}
}
