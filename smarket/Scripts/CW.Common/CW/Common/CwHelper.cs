using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace CW.Common
{
	public static class CwHelper
	{
		private static Stack<UnityEngine.Random.State> seedStates;

		public static List<Material> tempMaterials;

		public static List<MaterialPropertyBlock> tempProperties;

		private static Stack<RenderTexture> actives;

		private static int uniqueSeed;

		private static Mesh quadMesh;

		private static bool quadMeshSet;

		private static List<Material> materials;

		public static event Action<Camera> OnCameraPreRender
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<Camera> OnCameraPostRender
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		static CwHelper()
		{
		}

		public static T FindAnyObjectByType<T>(bool includeInactive = false)
		{
			return default(T);
		}

		public static T[] FindObjectsByType<T>()
		{
			return null;
		}

		public static Mesh GetQuadMesh()
		{
			return null;
		}

		public static T GetOrAddComponent<T>(GameObject gameObject, bool recordUndo = true)
		{
			return default(T);
		}

		public static T AddComponent<T>(GameObject gameObject, bool recordUndo = true)
		{
			return default(T);
		}

		public static bool IndexInMask(int index, int mask)
		{
			return false;
		}

		public static Camera GetCamera(Camera currentCamera, GameObject gameObject = null)
		{
			return null;
		}

		public static Vector3 GetObserverPosition(Transform observer)
		{
			return default(Vector3);
		}

		public static bool Enabled(Behaviour b)
		{
			return false;
		}

		public static void BeginSeed()
		{
		}

		public static void BeginSeed(int newSeed)
		{
		}

		public static void EndSeed()
		{
		}

		public static Color Brighten(Color color, float brightness, bool convertToGamma = true)
		{
			return default(Color);
		}

		public static Color Premultiply(Color color)
		{
			return default(Color);
		}

		public static float Saturate(float c)
		{
			return 0f;
		}

		public static Color Saturate(Color c)
		{
			return default(Color);
		}

		public static void Resize<T>(List<T> list, int size)
		{
		}

		public static float Sharpness(float a, float p)
		{
			return 0f;
		}

		public static Color ToLinear(Color gamma)
		{
			return default(Color);
		}

		public static float ToLinear(float gamma)
		{
			return 0f;
		}

		public static Color ToGamma(Color linear)
		{
			return default(Color);
		}

		public static float ToGamma(float linear)
		{
			return 0f;
		}

		public static float UniformScale(Vector3 scale)
		{
			return 0f;
		}

		public static void BeginActive(RenderTexture renderTexture)
		{
		}

		public static void EndActive()
		{
		}

		public static void SetTempMaterial(Material material)
		{
		}

		public static void SetTempMaterial(Material material1, Material material2)
		{
		}

		public static void SetTempMaterial(List<Material> materials)
		{
		}

		public static void SetTempMaterial(MaterialPropertyBlock properties)
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

		public static Texture2D CreateTempTexture2D(string name, int width, int height, TextureFormat format = TextureFormat.ARGB32, bool mips = false, bool linear = false)
		{
			return null;
		}

		public static Material CreateTempMaterial(string materialName, string shaderName)
		{
			return null;
		}

		public static Material CreateTempMaterial(string materialName, Shader shader)
		{
			return null;
		}

		public static Material CreateTempMaterial(string materialName, Material source)
		{
			return null;
		}

		public static T Destroy<T>(T o)
		{
			return default(T);
		}

		public static GameObject CreateGameObject(string name, int layer, Transform parent = null, string recordUndo = null)
		{
			return null;
		}

		public static GameObject CreateGameObject(string name, int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, string recordUndo = null)
		{
			return null;
		}

		public static T CreateElement<T>(Transform parent)
		{
			return default(T);
		}

		public static float Reciprocal(float v)
		{
			return 0f;
		}

		public static double Reciprocal(double v)
		{
			return 0.0;
		}

		public static float Divide(float a, float b)
		{
			return 0f;
		}

		public static double Divide(double a, double b)
		{
			return 0.0;
		}

		public static float Acos(float v)
		{
			return 0f;
		}

		public static double Acos(double v)
		{
			return 0.0;
		}

		public static float DampenFactor(float speed, float elapsed)
		{
			return 0f;
		}

		public static float DampenFactor(float damping, float deltaTime, float linear)
		{
			return 0f;
		}

		public static float Atan2(Vector2 xy)
		{
			return 0f;
		}

		public static int Mod(int a, int b)
		{
			return 0;
		}

		public static float Mod(float a, float b)
		{
			return 0f;
		}

		public static Texture2D GetReadableCopy(Texture texture, TextureFormat format = TextureFormat.ARGB32, bool mipMaps = false, int width = 0, int height = 0)
		{
			return null;
		}
	}
}
