using UnityEngine;

namespace MoreMountains.Tools
{
	public static class MMSpawnAround
	{
		public static void ApplySpawnAroundProperties(GameObject instantiatedObj, MMSpawnAroundProperties props, Vector3 origin)
		{
			instantiatedObj.transform.position = SpawnAroundPosition(props, origin);
			instantiatedObj.transform.rotation = SpawnAroundRotation(props);
			instantiatedObj.transform.localScale = SpawnAroundScale(props);
		}

		public static Vector3 SpawnAroundPosition(MMSpawnAroundProperties props, Vector3 origin)
		{
			Vector3 vector;
			if (props.Shape == MMSpawnAroundProperties.MMSpawnAroundShapes.Sphere)
			{
				float num = Random.Range(props.MinimumSphereRadius, props.MaximumSphereRadius);
				vector = Random.insideUnitSphere;
				if (props.ForcePlane)
				{
					vector = Vector3.Cross(vector, props.NormalToSpawnPlane);
				}
				vector.Normalize();
				vector *= num;
			}
			else
			{
				vector = PickPositionInsideCube(props);
				if (props.ForcePlane)
				{
					vector = Vector3.Cross(vector, props.NormalToSpawnPlane);
				}
			}
			float num2 = Random.Range(props.MinimumNormalAxisOffset, props.MaximumNormalAxisOffset);
			if (props.UseNormalAxisOffsetCurve)
			{
				float time = 0f;
				if (num2 != 0f)
				{
					time = ((!props.InvertNormalOffsetCurve) ? MMMaths.Remap(num2, props.MinimumNormalAxisOffset, props.MaximumNormalAxisOffset, 0f, 1f) : MMMaths.Remap(num2, props.MinimumNormalAxisOffset, props.MaximumNormalAxisOffset, 1f, 0f));
				}
				float x = props.NormalOffsetCurve.Evaluate(time);
				x = MMMaths.Remap(x, 0f, 1f, props.NormalOffsetCurveRemapZero, props.NormalOffsetCurveRemapOne);
				vector *= x;
			}
			vector += props.NormalToSpawnPlane.normalized * num2;
			return vector + origin;
		}

		public static Vector3 PickPositionInsideCube(MMSpawnAroundProperties props)
		{
			int i = 0;
			for (int num = 1000; i < num; i++)
			{
				float num2 = Random.Range(0f, props.MaximumCubeBaseSize.x);
				float num3 = Random.Range(0f, props.MaximumCubeBaseSize.y);
				float num4 = Random.Range(0f, props.MaximumCubeBaseSize.z);
				if (!(num2 < props.MinimumCubeBaseSize.x) || !(num3 < props.MinimumCubeBaseSize.y) || !(num4 < props.MinimumCubeBaseSize.z))
				{
					num2 = ((MMMaths.RollADice(2) > 1) ? (0f - num2) : num2);
					num3 = ((MMMaths.RollADice(2) > 1) ? (0f - num3) : num3);
					num4 = ((MMMaths.RollADice(2) > 1) ? (0f - num4) : num4);
					return new Vector3(num2, num3, num4);
				}
			}
			return Vector3.zero;
		}

		public static Vector3 SpawnAroundScale(MMSpawnAroundProperties props)
		{
			return MMMaths.RandomVector3(props.MinimumScale, props.MaximumScale);
		}

		public static Quaternion SpawnAroundRotation(MMSpawnAroundProperties props)
		{
			return Quaternion.Euler(MMMaths.RandomVector3(props.MinimumRotation, props.MaximumRotation));
		}

		public static void DrawGizmos(MMSpawnAroundProperties props, Vector3 origin, int quantity, float size, Color gizmosColor)
		{
			Gizmos.color = gizmosColor;
			for (int i = 0; i < quantity; i++)
			{
				Gizmos.DrawCube(SpawnAroundPosition(props, origin), SpawnAroundScale(props) * size);
			}
		}
	}
}
