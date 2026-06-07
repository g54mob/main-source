using System.Collections.Generic;

namespace FractureField.Rocks
{
	public static class RockObjectPools
	{
		private static readonly Stack<Rock.ApplyDamageOptions> _damageOptionsPool;

		private static readonly Stack<List<RockLayerHitResult>> _hitResultListPool;

		public static Rock.ApplyDamageOptions GetDamageOptions()
		{
			return null;
		}

		public static void ReturnDamageOptions(Rock.ApplyDamageOptions options)
		{
		}

		public static List<RockLayerHitResult> GetHitResultList()
		{
			return null;
		}

		public static void ReturnHitResultList(List<RockLayerHitResult> list)
		{
		}
	}
}
