using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CCosmeticSelector : IApplianceProperty, IAttachableProperty, IComponentData, IPlayerSpecificUISource
	{
		public bool AllowNoCosmetic;

		public CosmeticType Type;

		public Vector3 DrawLocation;

		Vector3 IPlayerSpecificUISource.DrawLocation => DrawLocation;
	}
}
