using System.Collections.Generic;
using UnityEngine;

namespace com.ootii.Utilities.Debug
{
	public class DebugDraw
	{
		private static Material sMaterial;

		private static Material sOverlayMaterial;

		private static MaterialPropertyBlock sMaterialBlock;

		private static List<Vector3> sLines;

		private static Vector3[] sLineVertices;

		private static Mesh sLine;

		private static Mesh sDisk;

		private static Mesh sTetrahedron;

		private static Mesh sCube;

		private static Mesh sOctahedron;

		private static Mesh sDodecahedron;

		private static Mesh sIcosahedron;

		private static Mesh sSphere;

		private static Mesh sBone;

		static DebugDraw()
		{
		}

		public static void Initialize()
		{
		}

		public static void Invalidate()
		{
		}

		public static void DrawCube(Vector3 rCenter, Vector3 rSize, Color rColor, bool rWireframe)
		{
		}

		public static void DrawCircle(Vector3 rCenter, float rRadius, Color rColor)
		{
		}

		public static void DrawWireSphere(Vector3 rCenter, float rRadius, Color rColor)
		{
		}

		public static void DrawArc(Vector3 rCenter, Quaternion rRotation, float rMinAngle, float rMaxAngle, float rRadius, Color rColor)
		{
		}

		public static void DrawFrustumArc(Vector3 rPosition, Quaternion rRotation, float rHAngle, float rVAngle, float rDistance, Color rColor)
		{
		}

		public static void DrawLines(List<Vector3> rLines, Color rColor)
		{
		}

		public static void DrawLine(Vector3 rFrom, Vector3 rTo, Color rColor)
		{
		}

		public static void DrawLine(Vector3 rFrom, Vector3 rTo, float rThickness, Color rColor, float rAlpha)
		{
		}

		public static void DrawLineOverlay(Vector3 rFrom, Vector3 rTo, float rThickness, Color rColor, float rAlpha)
		{
		}

		public static void DrawTetrahedronMesh(Vector3 rPosition, Quaternion rRotation, float rSize, Color rColor, float rAlpha)
		{
		}

		public static void DrawCubeMesh(Vector3 rPosition, Quaternion rRotation, float rSize, Color rColor, float rAlpha)
		{
		}

		public static void DrawOctahedronMesh(Vector3 rPosition, Quaternion rRotation, float rSize, Color rColor, float rAlpha)
		{
		}

		public static void DrawOctahedronOverlay(Vector3 rPosition, Quaternion rRotation, float rSize, Color rColor, float rAlpha)
		{
		}

		public static void DrawDodecahedronMesh(Vector3 rPosition, Quaternion rRotation, float rSize, Color rColor, float rAlpha)
		{
		}

		public static void DrawIcosahedronMesh(Vector3 rPosition, Quaternion rRotation, float rSize, Color rColor, float rAlpha)
		{
		}

		public static void DrawSphereMesh(Vector3 rPosition, float rRadius, Color rColor, float rAlpha)
		{
		}

		public static void DrawSphereOverlay(Vector3 rPosition, float rRadius, Color rColor, float rAlpha)
		{
		}

		public static void DrawDiskMesh(Vector3 rPosition, Quaternion rRotation, float rRadius, Color rColor, float rAlpha)
		{
		}

		public static void DrawBoneMesh(Transform rBoneTransform, Color rColor, float rAlpha)
		{
		}

		public static void DrawSkeleton(Transform rRootTransform, Color rColor, float rAlpha)
		{
		}

		public static void DrawSkeleton(Transform rRootTransform, Color rColor, float rAlpha, bool rDrawAxis, List<Transform> rSelectedBones, Color rSelectedColor)
		{
		}

		public static void DrawHumanoidSkeleton(GameObject rObject, Color rColor, float rAlpha)
		{
		}

		public static void DrawTransform(Transform rTransform, float rSize)
		{
		}

		public static void DrawTransform(Vector3 rPosition, Quaternion rRotation, float rSize)
		{
		}

		public static Mesh CreateTetrahedron()
		{
			return null;
		}

		public static Mesh CreateCube()
		{
			return null;
		}

		public static Mesh CreateOctahedron()
		{
			return null;
		}

		public static Mesh CreateDodecahedron()
		{
			return null;
		}

		public static Mesh CreateIcosahedron()
		{
			return null;
		}

		public static Mesh CreateSphere()
		{
			return null;
		}

		public static Mesh CreateDisk()
		{
			return null;
		}

		public static Mesh CreateBone()
		{
			return null;
		}
	}
}
