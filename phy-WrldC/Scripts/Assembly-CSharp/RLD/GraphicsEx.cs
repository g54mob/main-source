using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class GraphicsEx
	{
		public static void DrawWireBox(AABB box)
		{
			Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitWireBox, box.GetUnitBoxTransform());
		}

		public static void DrawWireCornerBox(AABB box, float wireCornerLinePercentage)
		{
			Mesh unitCoordSystem = Singleton<MeshPool>.Get.UnitCoordSystem;
			List<Vector3> cornerPoints = box.GetCornerPoints();
			wireCornerLinePercentage = Mathf.Clamp(wireCornerLinePercentage, 0f, 1f);
			Vector3 vector = box.Extents * wireCornerLinePercentage;
			Vector3 s = vector;
			Matrix4x4 matrix = Matrix4x4.TRS(cornerPoints[3], Quaternion.identity, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
			Vector3 pos = cornerPoints[2];
			s.x *= -1f;
			matrix = Matrix4x4.TRS(pos, Quaternion.identity, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
			Vector3 pos2 = cornerPoints[1];
			s.y *= -1f;
			matrix = Matrix4x4.TRS(pos2, Quaternion.identity, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
			Vector3 pos3 = cornerPoints[0];
			s = vector;
			s.y *= -1f;
			matrix = Matrix4x4.TRS(pos3, Quaternion.identity, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
			Vector3 pos4 = cornerPoints[7];
			s.y = vector.y;
			s.x *= -1f;
			s.z *= -1f;
			matrix = Matrix4x4.TRS(pos4, Quaternion.identity, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
			Vector3 pos5 = cornerPoints[6];
			s.x = vector.x;
			matrix = Matrix4x4.TRS(pos5, Quaternion.identity, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
			Vector3 pos6 = cornerPoints[5];
			s.y *= -1f;
			matrix = Matrix4x4.TRS(pos6, Quaternion.identity, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
			Vector3 pos7 = cornerPoints[4];
			s.x *= -1f;
			matrix = Matrix4x4.TRS(pos7, Quaternion.identity, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
		}

		public static void DrawWireBox(OBB box)
		{
			Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitWireBox, box.GetUnitBoxTransform());
		}

		public static void DrawWireCornerBox(OBB box, float wireCornerLinePercentage)
		{
			Mesh unitCoordSystem = Singleton<MeshPool>.Get.UnitCoordSystem;
			List<Vector3> cornerPoints = box.GetCornerPoints();
			wireCornerLinePercentage = Mathf.Clamp(wireCornerLinePercentage, 0f, 1f);
			Vector3 vector = box.Extents * wireCornerLinePercentage;
			Vector3 s = vector;
			Matrix4x4 matrix = Matrix4x4.TRS(cornerPoints[3], box.Rotation, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
			Vector3 pos = cornerPoints[2];
			s.x *= -1f;
			matrix = Matrix4x4.TRS(pos, box.Rotation, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
			Vector3 pos2 = cornerPoints[1];
			s.y *= -1f;
			matrix = Matrix4x4.TRS(pos2, box.Rotation, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
			Vector3 pos3 = cornerPoints[0];
			s = vector;
			s.y *= -1f;
			matrix = Matrix4x4.TRS(pos3, box.Rotation, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
			Vector3 pos4 = cornerPoints[7];
			s.y = vector.y;
			s.x *= -1f;
			s.z *= -1f;
			matrix = Matrix4x4.TRS(pos4, box.Rotation, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
			Vector3 pos5 = cornerPoints[6];
			s.x = vector.x;
			matrix = Matrix4x4.TRS(pos5, box.Rotation, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
			Vector3 pos6 = cornerPoints[5];
			s.y *= -1f;
			matrix = Matrix4x4.TRS(pos6, box.Rotation, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
			Vector3 pos7 = cornerPoints[4];
			s.x *= -1f;
			matrix = Matrix4x4.TRS(pos7, box.Rotation, s);
			Graphics.DrawMeshNow(unitCoordSystem, matrix);
		}
	}
}
