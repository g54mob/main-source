using UnityEngine;

namespace Gh.Tk
{
	[AllowDynamicRestore]
	public class LookAtAnimationOverride : AttachedBehaviour
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		public Actor LookingAt;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public Actor NextActorToLookAt;

		[PersistenceOptIn]
		private bool _markedForDestruction;

		private Transform _neckBone;

		private Transform _chestBone;

		private Transform _neckBoneParent;

		private Transform _chestBoneParent;

		private float _percentage;

		private bool _on;

		private const float ChestPercentage = 0.5f;

		private const float NeckPercentage = 0.5f;

		private const string NeckBoneName = "bn_neck";

		private const string ChestBoneName = "bn_chest";

		private const string BrokenBonePrefix = "Broken_";

		public static readonly string[] PossiblyBrokenBones;

		public override void Start()
		{
		}

		private static Transform BreakBone(Transform bone)
		{
			return null;
		}

		private static void HealBone(Transform bone)
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		public void LookAt(Actor actor, bool immediate = false)
		{
		}

		public void StopLooking()
		{
		}

		private void StopLookingInternal()
		{
		}

		private void LateUpdate()
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
