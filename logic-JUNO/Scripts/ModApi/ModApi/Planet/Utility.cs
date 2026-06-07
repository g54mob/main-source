using UnityEngine;

namespace ModApi.Planet
{
	public class Utility
	{
		public static void CubemapDirectionToTextureCoordinates(Vector3d direction, out CubemapFace face, out double u, out double v)
		{
			double num = Mathd.Abs(direction.x);
			double num2 = Mathd.Abs(direction.y);
			double num3 = Mathd.Abs(direction.z);
			if (num >= num2 && num >= num3)
			{
				if (direction.x > 0.0)
				{
					face = CubemapFace.PositiveX;
					u = (0.0 - direction.z) / num;
					v = (0.0 - direction.y) / num;
				}
				else
				{
					face = CubemapFace.NegativeX;
					u = direction.z / num;
					v = (0.0 - direction.y) / num;
				}
			}
			else if (num2 > num3)
			{
				if (direction.y > 0.0)
				{
					face = CubemapFace.PositiveY;
					u = direction.x / num2;
					v = direction.z / num2;
				}
				else
				{
					face = CubemapFace.NegativeY;
					u = direction.x / num2;
					v = (0.0 - direction.z) / num2;
				}
			}
			else if (direction.z > 0.0)
			{
				face = CubemapFace.PositiveZ;
				u = direction.x / num3;
				v = (0.0 - direction.y) / num3;
			}
			else
			{
				face = CubemapFace.NegativeZ;
				u = (0.0 - direction.x) / num3;
				v = (0.0 - direction.y) / num3;
			}
		}

		public static Vector3d CubemapTextureCoordinatesToDirection(CubemapFace face, double u, double v)
		{
			Vector3d vector3d = default(Vector3d);
			switch (face)
			{
			case CubemapFace.PositiveX:
				vector3d = new Vector3d(1.0, 0.0 - v, 0.0 - u);
				break;
			case CubemapFace.NegativeX:
				vector3d = new Vector3d(-1.0, 0.0 - v, u);
				break;
			case CubemapFace.PositiveY:
				vector3d = new Vector3d(u, 1.0, v);
				break;
			case CubemapFace.NegativeY:
				vector3d = new Vector3d(u, -1.0, 0.0 - v);
				break;
			case CubemapFace.PositiveZ:
				vector3d = new Vector3d(u, 0.0 - v, 1.0);
				break;
			case CubemapFace.NegativeZ:
				vector3d = new Vector3d(0.0 - u, 0.0 - v, -1.0);
				break;
			}
			return vector3d.normalized;
		}

		public static Vector3d SpherePositionToCubePosition(Vector3d spherePosition)
		{
			double num = Mathd.Max(Mathd.Abs(spherePosition.x), Mathd.Abs(spherePosition.y), Mathd.Abs(spherePosition.z));
			return new Vector3d(spherePosition.x / num, spherePosition.y / num, spherePosition.z / num);
		}
	}
}
