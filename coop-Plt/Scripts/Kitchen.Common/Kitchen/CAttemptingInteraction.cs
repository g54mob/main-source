using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CAttemptingInteraction : IComponentData
	{
		public Entity Target;

		public InteractionType Type;

		public InteractionResult Result;

		public bool IsHeld;

		public Vector3 Location;

		public InteractionMode Mode;

		public bool TransferOnly;

		public int Process;

		public SystemReference PerformedBy;

		public static implicit operator Entity(CAttemptingInteraction a)
		{
			return a.Target;
		}
	}
}
