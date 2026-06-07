using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public static class SgtHelper
	{
		public delegate void DistanceDelegate(Vector3 worldPosition, ref float distance);

		public const string ShaderNamePrefix = "Hidden/Sgt";

		public const string HelpUrlPrefix = "https://bitbucket.org/Darkcoder/space-graphics-toolkit/wiki/";

		public const string ComponentMenuPrefix = "Space Graphics Toolkit/SGT ";

		public const string GameObjectMenuPrefix = "GameObject/Space Graphics Toolkit/";

		public static readonly int QuadsPerMesh;

		public static List<Material> tempMaterials;

		public static DistanceDelegate OnCalculateDistance;

		private static Stack<Random.State> seedStates;

		private static GradientAlphaKey[] tempAlphaKeys;

		private static GradientColorKey[] tempColorKeys;

		private static List<Material> materials;

		public static T GetIndex<T>(ref List<T> list, int index)
		{
			return default(T);
		}

		public static void ClearCapacity<T>(List<T> list, int minCapacity)
		{
		}

		public static bool Enabled(Behaviour b)
		{
			return false;
		}

		public static T GetOrAddComponent<T>(GameObject gameObject, bool recordUndo = true) where T : Component
		{
			return null;
		}

		public static T AddComponent<T>(GameObject gameObject, bool recordUndo = true) where T : Component
		{
			return null;
		}

		public static T Destroy<T>(T o) where T : Object
		{
			return null;
		}

		public static bool Zero(float v)
		{
			return false;
		}

		public static float Reciprocal(float v)
		{
			return 0f;
		}

		public static float Acos(float v)
		{
			return 0f;
		}

		public static Vector3 Reciprocal3(Vector3 xyz)
		{
			return default(Vector3);
		}

		public static float Divide(float a, float b)
		{
			return 0f;
		}

		public static double Divide(double a, double b)
		{
			return 0.0;
		}

		public static Vector4 NewVector4(Vector3 xyz, float w)
		{
			return default(Vector4);
		}

		public static Color GetPixel(Cubemap cube, Vector3 p)
		{
			return default(Color);
		}

		public static Color GetPixel(Cubemap cube, CubemapFace face, float h, float v)
		{
			return default(Color);
		}

		public static T Pop<T>(HashSet<T> collection)
		{
			return default(T);
		}

		public static float Sharpness(float a, float p)
		{
			return 0f;
		}

		public static float CubicInterpolate(float a, float b, float c, float d, float t)
		{
			return 0f;
		}

		public static float HermiteInterpolate(float a, float b, float c, float d, float t)
		{
			return 0f;
		}

		public static Color HermiteInterpolate(Color a, Color b, Color c, Color d, float t)
		{
			return default(Color);
		}

		public static Vector3 HermiteInterpolate3(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
		{
			return default(Vector3);
		}

		public static float DampenFactor(float dampening, float deltaTime)
		{
			return 0f;
		}

		public static float DampenFactor(float dampening, float deltaTime, float linear)
		{
			return 0f;
		}

		public static int Mod(int a, int b)
		{
			return 0;
		}

		public static Bounds NewBoundsFromMinMax(Vector3 min, Vector3 max)
		{
			return default(Bounds);
		}

		public static Bounds NewBoundsCenter(Bounds b, Vector3 c)
		{
			return default(Bounds);
		}

		public static int GetRandomSeed(int newSeed, long x, long y, long z)
		{
			return 0;
		}

		public static void BeginRandomSeed(int newSeed, long x, long y, long z)
		{
		}

		public static void BeginRandomSeed(int newSeed)
		{
		}

		public static void EndRandomSeed()
		{
		}

		public static Material CreateTempMaterial(string materialName, string shaderName)
		{
			return null;
		}

		public static float GetMeshRadius(Mesh mesh)
		{
			return 0f;
		}

		public static Mesh CreateTempMesh(string meshName)
		{
			return null;
		}

		public static Texture2D CreateTempTexture2D(string name, int width, int height, TextureFormat format = TextureFormat.ARGB32, bool mips = false, bool linear = false)
		{
			return null;
		}

		public static Gradient CreateGradient(Color color)
		{
			return null;
		}

		public static GameObject CreateGameObject(string name, int layer, Transform parent = null, bool recordUndo = true)
		{
			return null;
		}

		public static GameObject CreateGameObject(string name, int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, bool recordUndo = true)
		{
			return null;
		}

		public static Vector2 CartesianToPolar(Vector3 xyz)
		{
			return default(Vector2);
		}

		public static Vector2 CartesianToPolarUV(Vector3 xyz)
		{
			return default(Vector2);
		}

		public static Vector4 CalculateSpriteUV(Sprite s)
		{
			return default(Vector4);
		}

		public static void CalculateHorizonThickness(float innerRadius, float middleRadius, float distance, out float innerThickness, out float outerThickness)
		{
			innerThickness = default(float);
			outerThickness = default(float);
		}

		public static void EnableKeyword(string keyword, Material material)
		{
		}

		public static void DisableKeyword(string keyword, Material material)
		{
		}

		public static void Resize<T>(List<T> list, int size)
		{
		}

		public static void AddMaterial(Renderer r, Material m)
		{
		}

		public static void ReplaceMaterial(Renderer r, Material m)
		{
		}

		public static void RemoveMaterial(Renderer r, Material m)
		{
		}

		public static float UniformScale(Vector3 scale)
		{
			return 0f;
		}

		public static Matrix4x4 ShearingZ(Vector2 xy)
		{
			return default(Matrix4x4);
		}

		public static Color Brighten(Color color, float brightness)
		{
			return default(Color);
		}

		public static Color Premultiply(Color color)
		{
			return default(Color);
		}

		public static void SetTempMaterial(Material material)
		{
		}

		public static void SetTempMaterial(Material material1, Material material2)
		{
		}

		public static void EnableKeyword(string keyword)
		{
		}

		public static void DisableKeyword(string keyword)
		{
		}

		public static void SetMatrix(string key, Matrix4x4 value)
		{
		}
	}
}
