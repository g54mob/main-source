using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CDishSourceCabinet : IApplianceProperty, IAttachableProperty, IComponentData, IPlayerSpecificUISource
	{
		public Vector3 DrawLocation;

		Vector3 IPlayerSpecificUISource.DrawLocation => DrawLocation;
	}
}
