using UnityEngine;

namespace Lightbug.Utilities
{
	public static class PhysicsExtensions
	{
		public enum ClosestHitResult
		{
			NoHit = 0,
			Hit = 1,
			Overlap = 2
		}

		public static ClosestHitResult GetFurthestHit(this RaycastHit[] array, out RaycastHit hitInfo, int length, Hit3DFilterDelegate filter)
		{
			float num = 0f;
			int num2 = -1;
			hitInfo = default(RaycastHit);
			if (length == 0)
			{
				return ClosestHitResult.NoHit;
			}
			for (int i = 0; i < length; i++)
			{
				RaycastHit hitInfo2 = array[i];
				if ((filter == null || filter(ref hitInfo2)) && hitInfo2.distance > num)
				{
					num = hitInfo2.distance;
					num2 = i;
				}
			}
			if (num2 != -1)
			{
				hitInfo = array[num2];
				return ClosestHitResult.Hit;
			}
			return ClosestHitResult.NoHit;
		}

		public static ClosestHitResult GetFurthestHit(this RaycastHit2D[] array, out RaycastHit2D hitInfo, int length, Hit2DFilterDelegate filter)
		{
			float num = 0f;
			int num2 = -1;
			hitInfo = default(RaycastHit2D);
			if (length == 0)
			{
				return ClosestHitResult.NoHit;
			}
			for (int i = 0; i < length; i++)
			{
				RaycastHit2D hitInfo2 = array[i];
				if ((filter == null || filter(ref hitInfo2)) && hitInfo2.distance > num)
				{
					num = hitInfo2.distance;
					num2 = i;
				}
			}
			if (num2 != -1)
			{
				hitInfo = array[num2];
				return ClosestHitResult.Hit;
			}
			return ClosestHitResult.NoHit;
		}

		public static ClosestHitResult GetClosestHit(this RaycastHit[] array, out RaycastHit hitInfo, int length, Hit3DFilterDelegate filter)
		{
			float num = float.PositiveInfinity;
			int num2 = -1;
			hitInfo = default(RaycastHit);
			if (length == 0)
			{
				return ClosestHitResult.NoHit;
			}
			for (int i = 0; i < length; i++)
			{
				RaycastHit hitInfo2 = array[i];
				if ((filter == null || filter(ref hitInfo2)) && hitInfo2.distance < num)
				{
					num = hitInfo2.distance;
					num2 = i;
				}
			}
			if (num2 != -1)
			{
				hitInfo = array[num2];
				return ClosestHitResult.Hit;
			}
			return ClosestHitResult.NoHit;
		}

		public static ClosestHitResult GetClosestHit(this RaycastHit2D[] array, out RaycastHit2D hitInfo, int length, Hit2DFilterDelegate filter)
		{
			float num = float.PositiveInfinity;
			int num2 = -1;
			hitInfo = default(RaycastHit2D);
			if (length == 0)
			{
				return ClosestHitResult.NoHit;
			}
			for (int i = 0; i < length; i++)
			{
				RaycastHit2D hitInfo2 = array[i];
				if ((filter == null || filter(ref hitInfo2)) && hitInfo2.distance < num)
				{
					num = hitInfo2.distance;
					num2 = i;
				}
			}
			if (num2 != -1)
			{
				hitInfo = array[num2];
				return ClosestHitResult.Hit;
			}
			return ClosestHitResult.NoHit;
		}
	}
}
