using System;
using UnityEngine;

namespace JUTPS.FX
{
	[Serializable]
	public class SurfaceFX
	{
		public string SurfaceTag;

		public GameObject ParticleFXPrefab;

		private static bool Instantiated;

		public static void InstantiateParticleFX(SurfaceFX[] SurfaceFx, string SurfaceTag = "Untagged", Vector3 Postion = default(Vector3), Quaternion Rotation = default(Quaternion), Transform parent = null, float TimeToDestroy = 5f)
		{
			Instantiated = false;
			for (int i = 0; i < SurfaceFx.Length; i++)
			{
				if (SurfaceTag == SurfaceFx[i].SurfaceTag && SurfaceFx[i].ParticleFXPrefab != null)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(SurfaceFx[i].ParticleFXPrefab, Postion, Rotation);
					gameObject.transform.parent = parent;
					if (TimeToDestroy > 0f)
					{
						UnityEngine.Object.Destroy(gameObject, TimeToDestroy);
					}
					Instantiated = true;
				}
			}
			if (!Instantiated && SurfaceFx.Length != 0)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(SurfaceFx[0].ParticleFXPrefab, Postion, Rotation);
				gameObject2.transform.parent = parent;
				if (TimeToDestroy > 0f)
				{
					UnityEngine.Object.Destroy(gameObject2, TimeToDestroy);
				}
				Instantiated = true;
			}
		}
	}
}
