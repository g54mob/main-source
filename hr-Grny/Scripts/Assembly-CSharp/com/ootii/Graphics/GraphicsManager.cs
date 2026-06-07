using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace com.ootii.Graphics
{
	[ExecuteInEditMode]
	[DefaultExecutionOrder(-5000)]
	public class GraphicsManager : MonoBehaviour
	{
		private class Octahedron
		{
			public Vector3[] Vertices;

			public int[] Triangles;

			private Vector3[] CreateVertices()
			{
				return null;
			}

			private int[] CreateTriangles()
			{
				return null;
			}
		}

		private class Icosahedron
		{
			public Vector3[] Vertices;

			public int[] Triangles;

			public List<Vector3> TriangleList;

			public void Tessellate(int rSubdivisions)
			{
			}

			private Vector3[] CreateVertices()
			{
				return null;
			}

			private int[] CreateTriangles()
			{
				return null;
			}
		}

		private class IcoSphere
		{
			private class Icosahedron
			{
				public Vector3[] Vertices;

				public int[] Triangles;

				private Vector3[] CreateVertices()
				{
					return null;
				}

				private int[] CreateTriangles()
				{
					return null;
				}
			}

			public Vector3[] Vertices;

			public int[] TriangleIndices;

			public int[,] Triangles;

			public List<Vector3> TriangleList;

			public void CreateSphere(int rSubdivisions)
			{
			}

			private void get_triangulation(int num, Icosahedron ico)
			{
			}

			private int[,] triangulate(int num)
			{
				return null;
			}

			private Vector2[] getUV(Vector3[] vertices)
			{
				return null;
			}

			private Vector2 cartToLL(Vector3 point)
			{
				return default(Vector2);
			}

			private float[,] getSubMatrix(int num)
			{
				return null;
			}
		}

		public static GraphicsManager Instance;

		private static Material mSimpleMaterial;

		private static List<Vector3> mVectors1;

		private static List<Vector3> mVectors2;

		private static Stopwatch mInternalTimer;

		private static List<Line> mLines;

		private static List<Line> mSceneLines;

		private static List<Triangle> mTriangles;

		private static List<Triangle> mSceneTriangles;

		private static List<Text> mText;

		private static List<TextString> mSceneText;

		private static string mShader;

		private static Font mFont;

		private static Dictionary<Font, TextFont> mFonts;

		private static Octahedron mOctahedron;

		private static IcoSphere mIcoSphere;

		public static bool IsInUpdate;

		public string _DefaultShader;

		public Font _DefaultFont;

		public bool _DrawToSceneView;

		public bool _DrawToGameView;

		public static Material SimpleMaterial => null;

		public static int LineCount => 0;

		public static int TriangleCount => 0;

		public static int TextCount => 0;

		private static float InternalTime => 0f;

		public string DefaultShader
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Font DefaultFont
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool DrawToSceneView
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool DrawToGameView
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private GraphicsManager()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnDrawGizmos()
		{
		}

		private void OnPostRender()
		{
		}

		private void OnGUI()
		{
		}

		public static void ClearGraphics(int rScope = -1)
		{
		}

		public static void ClearSceneGraphics(int rScope = -1)
		{
		}

		public static void ClearText()
		{
		}

		public static void ClearSceneText(int rScope = -1)
		{
		}

		public static void DrawLine(Vector3 rStart, Vector3 rEnd, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawLines(List<Vector3> rLines, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawTriangle(Vector3 rPoint1, Vector3 rPoint2, Vector3 rPoint3, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawTriangles(List<Vector3> rPoints, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawBox(Vector3 rCenter, float rWidth, float rHeight, float rDepth, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawBox(Bounds rBounds, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawCollider(BoxCollider rColldier, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawSolidCollider(BoxCollider rColldier, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawCircle(Vector3 rCenter, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawCircle(Vector3 rCenter, float rRadius, Color rColor, Vector3 rNormal, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawSolidCircle(Vector3 rCenter, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawSolidCircle(Vector3 rCenter, float rRadius, Color rColor, Vector3 rNormal, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawSolidCone(Vector3 rPosition, Vector3 rDirection, float rHeight, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawArc(Vector3 rCenter, Vector3 rFrom, float rAngle, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawArc(Vector3 rCenter, Vector3 rNormal, Vector3 rFrom, float rAngle, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawSolidArc(Vector3 rCenter, Vector3 rFrom, float rAngle, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawSolidArc(Vector3 rCenter, Vector3 rNormal, Vector3 rFrom, float rAngle, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawSolidCenteredArc(Vector3 rCenter, Vector3 rFrom, float rAngle, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawSolidCenteredArc(Vector3 rCenter, Vector3 rNormal, Vector3 rFrom, float rAngle, float rRadius, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawArrow(Vector3 rStart, Vector3 rEnd, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawFrustum(Vector3 rPosition, Quaternion rRotation, float rHAngle, float rVAngle, float rMinDistance, float rMaxDistance, Color rColor, bool rIsSpherical = true, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawSolidFrustum(Vector3 rPosition, Quaternion rRotation, float rHAngle, float rVAngle, float rMinDistance, float rMaxDistance, Color rColor, bool rIsSpherical = true, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawPoint(Vector3 rCenter, Color rColor, Transform rTransform = null, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawQuaternion(Vector3 rCenter, Quaternion rRotation, float rScale = 1f, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawCapsule(Vector3 rStart, Vector3 rEnd, float rRadius, Color rColor, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawSphere(Vector3 rCenter, float rRadius, Color rColor, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawSolidSphere(Vector3 rCenter, float rRadius, Color rColor, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawTexture(Texture rTexture, Vector3 rPosition, float rWidth, float rHeight)
		{
		}

		public static void DrawTexture(Texture rTexture, Vector2 rPosition, float rWidth, float rHeight)
		{
		}

		public static void DrawText(string rText, Vector3 rPosition, Color rColor, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void DrawText(string rText, Vector3 rPosition, Color rColor, Font rFont, float rDuration = 0f, RenderScope rScope = RenderScope.EDITOR)
		{
		}

		public static void ImmediateDrawLine(Vector3 rStart, Vector3 rEnd, Color rColor, Transform rTransform = null)
		{
		}

		public static void ImmediateDrawLines(List<Vector3> rLines, Color rColor, Transform rTransform = null)
		{
		}

		public static void ImmediateDrawTriangle(Vector3 rPoint1, Vector3 rPoint2, Vector3 rPoint3, Color rColor, Transform rTransform = null)
		{
		}

		public static void ImmediateDrawTriangles(List<Vector3> rPoints, Color rColor, Transform rTransform = null)
		{
		}

		public static bool AddFont(Font rFont)
		{
			return false;
		}

		private static void RenderLines()
		{
		}

		private static void RenderTriangles()
		{
		}

		private static void RenderText()
		{
		}

		private static void RenderSceneLines()
		{
		}

		private static void RenderSceneTriangles()
		{
		}

		private static void RenderSceneText()
		{
		}

		private static void CreateMaterials()
		{
		}

		private static TextCharacter GetCharacterPixels(Font rFont, char rCharacter)
		{
			return null;
		}

		private static Color[] RotatePixelsLeft(Color[] rArray, int rWidth, int rHeight)
		{
			return null;
		}

		private static Color[] FlipPixelsHorizontally(Color[] rArray, int rWidth, int rHeight)
		{
			return null;
		}

		private static Color[] FlipPixelsVertically(Color[] rArray, int rWidth, int rHeight)
		{
			return null;
		}
	}
}
