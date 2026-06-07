using UnityEngine;

namespace UMA
{
	public static class SkeletonTools
	{
		public enum ValidateResult
		{
			Ok = 0,
			InvalidScale = 1,
			SkeletonProblem = 2
		}

		private static void CompareRootBone(Transform raceRoot, Transform slotRoot, ref int failure)
		{
		}

		private static Transform RecursiveFindBone(Transform bone, Transform raceRoot)
		{
			return null;
		}

		public static Transform RecursiveFindBone(Transform bone, string Name)
		{
			return null;
		}

		private static void CompareSkeletonRecursive(Transform race, Transform slot, ref int failure)
		{
		}

		public static Transform LocateRoot(Transform parent)
		{
			return null;
		}

		public static ValidateResult ValidateSlot(SkinnedMeshRenderer RaceSMR, SkinnedMeshRenderer SlotSMR, out string description)
		{
			description = null;
			return default(ValidateResult);
		}

		public static void ForceSkeleton(SkinnedMeshRenderer SourceSMR, SkinnedMeshRenderer DestSMR)
		{
		}

		private static void ForceSkeletonRecursive(Transform source, Transform dest)
		{
		}
	}
}
