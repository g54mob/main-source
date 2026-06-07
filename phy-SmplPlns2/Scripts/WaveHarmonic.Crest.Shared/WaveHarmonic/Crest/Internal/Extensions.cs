using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace WaveHarmonic.Crest.Internal
{
	internal static class Extensions
	{
		private static readonly Vector3[] s_BoundsPoints = new Vector3[8];

		public static Vector2 XZ(this Vector3 v)
		{
			return new Vector2(v.x, v.z);
		}

		public static Vector2 XY(this Vector4 v)
		{
			return new Vector2(v.x, v.y);
		}

		public static Vector2 ZW(this Vector4 v)
		{
			return new Vector2(v.z, v.w);
		}

		public static Vector3 XYZ(this Vector4 v)
		{
			return new Vector3(v.x, v.y, v.z);
		}

		public static Vector3 XNZ(this Vector2 v, float n = 0f)
		{
			return new Vector3(v.x, n, v.y);
		}

		public static Vector3 XNZ(this Vector3 v, float n = 0f)
		{
			return new Vector3(v.x, n, v.z);
		}

		public static Vector3 XNN(this Vector3 v, float n = 0f)
		{
			return new Vector3(v.x, n, n);
		}

		public static Vector3 NNZ(this Vector3 v, float n = 0f)
		{
			return new Vector3(n, n, v.z);
		}

		public static Vector3 NYN(this Vector3 v, float n = 0f)
		{
			return new Vector3(n, v.y, n);
		}

		public static Vector4 XYZN(this Vector3 v, float n = 0f)
		{
			return new Vector4(v.x, v.y, v.z, n);
		}

		public static Vector4 XYNN(this Vector2 v, float n = 0f)
		{
			return new Vector4(v.x, v.y, n, n);
		}

		public static Vector4 XYNN(this Vector2 v, Vector2 n)
		{
			return new Vector4(v.x, v.y, n.x, n.y);
		}

		public static Vector4 NNZW(this Vector2 v, float n = 0f)
		{
			return new Vector4(n, n, v.x, v.y);
		}

		public static Vector4 XNZW(this Vector4 v, float n)
		{
			return new Vector4(v.x, n, v.z, v.w);
		}

		public static float Maximum(this Vector3 v)
		{
			return Mathf.Max(Mathf.Max(v.x, v.y), v.z);
		}

		public static Vector2 Absolute(this Vector2 v)
		{
			return new Vector2(Mathf.Abs(v.x), Mathf.Abs(v.y));
		}

		public static Color Clamped01(this Color c)
		{
			return new Color(Mathf.Clamp01(c.r), Mathf.Clamp01(c.g), Mathf.Clamp01(c.b), Mathf.Clamp01(c.a));
		}

		public static void SetKeyword(this Material material, string keyword, bool enabled)
		{
			if (enabled)
			{
				material.EnableKeyword(keyword);
			}
			else
			{
				material.DisableKeyword(keyword);
			}
		}

		public static void SetKeyword(this ComputeShader shader, string keyword, bool enabled)
		{
			if (enabled)
			{
				shader.EnableKeyword(keyword);
			}
			else
			{
				shader.DisableKeyword(keyword);
			}
		}

		public static void SetShaderKeyword(this CommandBuffer buffer, string keyword, bool enabled)
		{
			if (enabled)
			{
				buffer.EnableShaderKeyword(keyword);
			}
			else
			{
				buffer.DisableShaderKeyword(keyword);
			}
		}

		public static Bounds Bounds(this Transform transform)
		{
			Bounds result = default(Bounds);
			result.center = transform.position;
			Vector3 vector = new Vector3(0f, 0f, 0.5f);
			Vector3 vector2 = new Vector3(0f, 0.5f, 0f);
			Vector3 vector3 = new Vector3(0.5f, 0f, 0f);
			result.Encapsulate(transform.TransformPoint(vector + vector2 + vector3));
			result.Encapsulate(transform.TransformPoint(-vector + vector2 + vector3));
			result.Encapsulate(transform.TransformPoint(vector + -vector2 + vector3));
			result.Encapsulate(transform.TransformPoint(vector + vector2 + -vector3));
			result.Encapsulate(transform.TransformPoint(-vector + -vector2 + vector3));
			result.Encapsulate(transform.TransformPoint(vector + -vector2 + -vector3));
			result.Encapsulate(transform.TransformPoint(-vector + vector2 + -vector3));
			result.Encapsulate(transform.TransformPoint(-vector + -vector2 + -vector3));
			return result;
		}

		public static Bounds TransformBounds(this Transform transform, Bounds bounds)
		{
			s_BoundsPoints[0] = bounds.min;
			s_BoundsPoints[1] = bounds.max;
			s_BoundsPoints[2] = new Vector3(bounds.min.x, bounds.min.y, bounds.max.z);
			s_BoundsPoints[3] = new Vector3(bounds.min.x, bounds.max.y, bounds.min.z);
			s_BoundsPoints[4] = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z);
			s_BoundsPoints[5] = new Vector3(bounds.min.x, bounds.max.y, bounds.max.z);
			s_BoundsPoints[6] = new Vector3(bounds.max.x, bounds.min.y, bounds.max.z);
			s_BoundsPoints[7] = new Vector3(bounds.max.x, bounds.max.y, bounds.min.z);
			return GeometryUtility.CalculateBounds(s_BoundsPoints, transform.localToWorldMatrix);
		}

		public static Bounds Rotate(this Bounds bounds, Quaternion rotation)
		{
			Vector3 center = rotation * bounds.center;
			Vector3 vector = rotation * bounds.extents * 2f;
			return new Bounds(center, new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z)));
		}

		public static bool IntersectsXZ(this Bounds a, Bounds b)
		{
			if (a.min.x <= b.max.x && a.max.x >= b.min.x && a.min.z <= b.max.z)
			{
				return a.max.z >= b.min.z;
			}
			return false;
		}

		public static Rect RectXZ(this Bounds bounds)
		{
			return Rect.MinMaxRect(bounds.min.x, bounds.min.z, bounds.max.x, bounds.max.z);
		}

		public static Rect RectXZ(this Transform transform)
		{
			Vector2 size = transform.lossyScale.XZ();
			size = Helpers.RotateAndEncapsulateXZ(size, transform.rotation.eulerAngles.y);
			return new Rect(transform.position.XZ() - size * 0.5f, size);
		}

		public static Vector2 RotationXZ(this Transform transform)
		{
			return new Vector2(transform.localToWorldMatrix.m20, transform.localToWorldMatrix.m00).normalized;
		}

		public static Color MaybeLinear(this Color color)
		{
			if (QualitySettings.activeColorSpace != ColorSpace.Linear)
			{
				return color;
			}
			return color.linear;
		}

		public static Color MaybeGamma(this Color color)
		{
			if (QualitySettings.activeColorSpace != ColorSpace.Linear)
			{
				return color.gamma;
			}
			return color;
		}

		public static Color FinalColor(this Light light)
		{
			bool lightsUseLinearIntensity = GraphicsSettings.lightsUseLinearIntensity;
			Color color = (lightsUseLinearIntensity ? light.color.linear : light.color);
			color *= light.intensity;
			if (lightsUseLinearIntensity && light.useColorTemperature)
			{
				color *= Mathf.CorrelatedColorTemperatureToRGB(light.colorTemperature);
			}
			if (!lightsUseLinearIntensity)
			{
				color = color.MaybeLinear();
			}
			if (!lightsUseLinearIntensity)
			{
				return color;
			}
			return color.MaybeGamma();
		}

		public static void SetMSAASamples(this ref RenderTextureDescriptor descriptor, Camera camera)
		{
			descriptor.msaaSamples = ((!Helpers.IsMSAAEnabled(camera)) ? 1 : Mathf.Max(QualitySettings.antiAliasing, 1));
			descriptor.msaaSamples = SystemInfo.GetRenderTextureSupportedMSAASampleCount(descriptor);
		}

		internal static RenderTextureDescriptor GetDescriptor(this Texture texture)
		{
			if (texture is RenderTexture renderTexture)
			{
				return renderTexture.descriptor;
			}
			RenderTextureDescriptor result = new RenderTextureDescriptor(0, 0);
			result.width = texture.width;
			result.height = texture.height;
			result.graphicsFormat = texture.graphicsFormat;
			result.dimension = texture.dimension;
			result.volumeDepth = 1;
			result.msaaSamples = 1;
			result.useMipMap = false;
			result.enableRandomWrite = true;
			return result;
		}

		public static bool GetBoolean(this Material material, int id)
		{
			return material.GetFloat(id) != 0f;
		}

		public static void SetBoolean(this Material material, int id, bool value)
		{
			material.SetFloat(id, value ? 1f : 0f);
		}

		public static void SetGlobalBoolean(this CommandBuffer buffer, int id, bool value)
		{
			buffer.SetGlobalFloat(id, value ? 1f : 0f);
		}

		public static bool IsEmpty(this UnityEvent @event)
		{
			return @event.GetPersistentEventCount() == 0;
		}

		public static bool IsEmpty<T>(this UnityEvent<T> @event)
		{
			return @event.GetPersistentEventCount() == 0;
		}

		public static bool Encapsulates(this Rect r1, Rect r2)
		{
			if (r1.Contains(r2.min))
			{
				return r1.Contains(r2.max);
			}
			return false;
		}

		internal static int GetEntityId(this Object @this)
		{
			return @this.GetInstanceID();
		}

		internal static ulong GetRawSceneHandle(this Scene @this)
		{
			return (ulong)@this.handle;
		}
	}
}
