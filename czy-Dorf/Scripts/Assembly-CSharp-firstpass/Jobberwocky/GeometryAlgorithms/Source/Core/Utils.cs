using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.Core
{
	internal class Utils
	{
		public static Vector3 ToCoordinateSystemDefault(Vector3 vector, CoordinateSystem coordinateSystem)
		{
			Vector3 vector2 = default(Vector3);
			switch (coordinateSystem)
			{
			case CoordinateSystem.XZY:
				vector2 = new Vector3(vector.x, vector.z, vector.y);
				break;
			case CoordinateSystem.YXZ:
				vector2 = new Vector3(vector.y, vector.x, vector.z);
				break;
			case CoordinateSystem.YZX:
				vector2 = new Vector3(vector.z, vector.x, vector.y);
				break;
			case CoordinateSystem.ZXY:
				vector2 = new Vector3(vector.y, vector.z, vector.x);
				break;
			case CoordinateSystem.ZYX:
				vector2 = new Vector3(vector.z, vector.y, vector.x);
				break;
			default:
				return vector;
			}
			return vector2;
		}

		public static Vector3 FromCoordinateSystemDefaultTo(Vector3 vector, CoordinateSystem coordinateSystem)
		{
			Vector3 vector2 = default(Vector3);
			switch (coordinateSystem)
			{
			case CoordinateSystem.XZY:
				vector2 = new Vector3(vector.x, vector.z, vector.y);
				break;
			case CoordinateSystem.YXZ:
				vector2 = new Vector3(vector.y, vector.x, vector.z);
				break;
			case CoordinateSystem.YZX:
				vector2 = new Vector3(vector.y, vector.z, vector.x);
				break;
			case CoordinateSystem.ZXY:
				vector2 = new Vector3(vector.z, vector.x, vector.y);
				break;
			case CoordinateSystem.ZYX:
				vector2 = new Vector3(vector.z, vector.y, vector.x);
				break;
			default:
				return vector;
			}
			return vector2;
		}
	}
}
