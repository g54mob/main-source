using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CDeskTarget : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool RequireUpgrade;

		public bool RequireCopyable;

		public bool RequireMakeFree;

		public float RetargetTime;

		[Header("Game")]
		public float NextTarget;

		public Entity Target;
	}
}
