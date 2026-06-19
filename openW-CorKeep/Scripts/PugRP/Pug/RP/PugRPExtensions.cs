using System.Collections.Generic;
using UnityEngine;

namespace Pug.RP
{
	public static class PugRPExtensions
	{
		private static Dictionary<Camera, PugCamera> s_pugCameraCache = new Dictionary<Camera, PugCamera>();

		private static Dictionary<Light, PugLight> s_pugLightCache = new Dictionary<Light, PugLight>();

		[RuntimeInitializeOnLoadMethod]
		private static void ClearCache()
		{
			s_pugCameraCache.Clear();
			s_pugLightCache.Clear();
		}

		public static bool TryGetPugCamera(this Camera camera, out PugCamera pugCamera)
		{
			pugCamera = null;
			if ((object)camera == null || camera.Equals(null))
			{
				return false;
			}
			if (!s_pugCameraCache.TryGetValue(camera, out pugCamera) || pugCamera == null)
			{
				bool num = pugCamera == null;
				if (!camera.TryGetComponent<PugCamera>(out pugCamera))
				{
					pugCamera = camera.gameObject.AddComponent<PugCamera>();
					pugCamera.SetCamera(camera);
				}
				if (num)
				{
					s_pugCameraCache[camera] = pugCamera;
				}
				else
				{
					s_pugCameraCache.Add(camera, pugCamera);
				}
			}
			return pugCamera != null;
		}

		public static PugCamera GetPugCamera(this Camera camera)
		{
			camera.TryGetPugCamera(out var pugCamera);
			return pugCamera;
		}

		public static PugLight GetPugLight(this Light light)
		{
			if ((object)light == null || light.Equals(null))
			{
				return null;
			}
			if (!s_pugLightCache.TryGetValue(light, out var value) || value == null)
			{
				bool num = value == null;
				if (!light.TryGetComponent<PugLight>(out value))
				{
					value = light.gameObject.AddComponent<PugLight>();
				}
				if (num)
				{
					s_pugLightCache[light] = value;
				}
				else
				{
					s_pugLightCache.Add(light, value);
				}
			}
			return value;
		}

		public static bool TryGetPugLight(this Light light, out PugLight pugLight)
		{
			pugLight = light.GetPugLight();
			return pugLight != null;
		}

		public static void SetShadowDirty(this Light light)
		{
			Shadows.SetLightDirty(light);
		}

		public static bool IsShadowDirty(this Light light)
		{
			return Shadows.GetLightDirty(light);
		}
	}
}
