using UnityEngine;

namespace DistantLands.Cozy
{
	public class CustomCozyChanceEffector : ScriptableObject
	{
		public virtual float GetChance()
		{
			return 1f;
		}
	}
}
