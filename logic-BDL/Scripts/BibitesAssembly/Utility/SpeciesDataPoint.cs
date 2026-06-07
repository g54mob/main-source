using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace Utility
{
	public struct SpeciesDataPoint
	{
		public ushort count;

		public float energy;

		public Vector2 avgPos;

		public Vector2 posStdDev;

		public float posCor;

		public bool alive => count > 0;

		public static byte byteSize => 16;

		public float espXY => posCor * posStdDev.x * posStdDev.y + avgPos.x * avgPos.y;

		public SpeciesDataPoint(Species species)
		{
			float num = 0f;
			Vector2 zero = Vector2.zero;
			Vector2 zero2 = Vector2.zero;
			float num2 = 0f;
			species.bibites.RemoveAll((BibiteBody s) => s == null);
			count = (ushort)(species.bibites.Count + species.eggs.Count);
			if (count < 1)
			{
				energy = (posCor = 0f);
				avgPos = (posStdDev = Vector2.zero);
				return;
			}
			foreach (BibiteBody bibite in species.bibites)
			{
				if (!(bibite == null))
				{
					float totalEnergy = bibite.totalEnergy;
					num += totalEnergy;
					Vector2 vector = bibite.transform.position;
					zero += vector * totalEnergy;
					num2 += vector.x * vector.y * totalEnergy;
				}
			}
			foreach (EggHatching egg in species.eggs)
			{
				float num3 = egg.energy;
				num += num3;
				Vector2 vector2 = egg.transform.position;
				zero += vector2 * num3;
				num2 += vector2.x * vector2.y * num3;
			}
			avgPos = zero / num;
			foreach (BibiteBody bibite2 in species.bibites)
			{
				Vector2 vector3 = (Vector2)bibite2.transform.position - avgPos;
				zero2 += vector3 * vector3 * bibite2.totalEnergy;
			}
			foreach (EggHatching egg2 in species.eggs)
			{
				Vector2 vector4 = (Vector2)egg2.transform.position - avgPos;
				zero2 += vector4 * vector4 * egg2.energy;
			}
			posStdDev = new Vector2(Mathf.Max(10f, Mathf.Sqrt(zero2.x / num)), Mathf.Max(10f, Mathf.Sqrt(zero2.y / num)));
			posCor = (num2 / num - avgPos.x * avgPos.y) / (posStdDev.x * posStdDev.y);
			energy = num;
			if (count < 2)
			{
				posCor = 0f;
				posStdDev = Vector2.one;
			}
		}

		public Vector2 StdDevWithPos(Vector2 pos)
		{
			return posStdDev * posStdDev + (avgPos - pos) * (avgPos - pos);
		}
	}
}
