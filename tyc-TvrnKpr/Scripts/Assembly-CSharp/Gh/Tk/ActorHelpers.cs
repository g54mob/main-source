using UnityEngine;

namespace Gh.Tk
{
	public static class ActorHelpers
	{
		public static RaycastHit[] RaycastHits;

		public static bool IsPatron(this Actor actor)
		{
			return false;
		}

		public static bool IsEntertainer(this Actor actor)
		{
			return false;
		}

		public static bool IsHero(this Actor actor)
		{
			return false;
		}

		public static bool IsStaff(this Actor actor)
		{
			return false;
		}

		public static bool IsActiveStaffOrPatron(this Actor actor)
		{
			return false;
		}

		public static string GetShortCharacterNameKey(this Actor actor)
		{
			return null;
		}

		public static bool IsFightingFire(this Actor actor, bool ignoreSmallFire = false)
		{
			return false;
		}

		public static bool IsPanicked(this Actor actor)
		{
			return false;
		}

		public static bool IsInspecting(this Actor actor)
		{
			return false;
		}

		public static bool CanSee(this Actor actor, float distance, float angle, float visibilityDistance, GameObjectX other, Vector3 headPosition)
		{
			return false;
		}

		public static float GetEyesightDistance(this Actor actor, float angle, float visibilityDistance)
		{
			return 0f;
		}

		public static void AttachToCharacterBone(this Actor actor, GameItem item, string boneName = null, bool snap = true)
		{
		}
	}
}
