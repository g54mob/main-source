using System;
using MalbersAnimations.Reactions;
using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	[AddTypeMenu("Unity/Collider", 0)]
	public class ColliderReaction : Reaction
	{
		public enum ColliderOption
		{
			Enable = 1,
			IsTrigger = 2,
			Material = 4
		}

		[Flag]
		public ColliderOption option = ColliderOption.Enable;

		[Hide("option", false, true, true, new int[] { 1, 3, -1 })]
		public bool enable;

		[Hide("option", false, true, true, new int[] { 2, 6, -1 })]
		public bool isTrigger;

		[Hide("option", false, true, true, new int[] { 5, 6, -1 })]
		public PhysicMaterial material;

		public override Type ReactionType => typeof(Collider);

		protected override bool _TryReact(Component reactor)
		{
			Collider collider = reactor as Collider;
			if (collider != null)
			{
				if ((option & ColliderOption.Enable) == ColliderOption.Enable)
				{
					collider.enabled = enable;
				}
				if ((option & ColliderOption.IsTrigger) == ColliderOption.IsTrigger)
				{
					collider.isTrigger = isTrigger;
				}
				if ((option & ColliderOption.Material) == ColliderOption.Material)
				{
					collider.material = material;
				}
				return true;
			}
			return false;
		}
	}
}
