using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.UI.Sharing
{
	public class OrthoScreenshotHelper
	{
		private AircraftScript _aircraft;

		private List<Light> _lights;

		public Texture2D FrontScreenshotTexture { get; private set; }

		public Texture2D SideScreenshotTexture { get; private set; }

		public Texture2D TopScreenshotTexture { get; private set; }

		private Vector3 AircraftCenter => _aircraft.CalculateBounds(includeDisconnectedParts: true).center;

		private Vector3 AircraftFrontViewPosition
		{
			get
			{
				Bounds bounds = _aircraft.CalculateBounds(includeDisconnectedParts: true);
				float num = 10f;
				Vector3 result = bounds.center + Vector3.forward * (bounds.max.x * 1.5f);
				if (result.z < num)
				{
					result.z = num;
				}
				return result;
			}
		}

		private Vector3 AircraftSideViewPosition
		{
			get
			{
				Bounds bounds = _aircraft.CalculateBounds(includeDisconnectedParts: true);
				float num = 10f;
				Vector3 result = bounds.center + Vector3.right * bounds.max.x;
				if (result.x < num)
				{
					result.x = num;
				}
				return result;
			}
		}

		private Vector3 AircraftTopViewPosition
		{
			get
			{
				Bounds bounds = _aircraft.CalculateBounds(includeDisconnectedParts: true);
				_ = bounds.extents / Mathf.Tan(MathF.PI / 180f * (Camera.main.fieldOfView / 2f)) / 2f;
				return bounds.center + new Vector3(0f, Mathf.Abs(bounds.max.z - bounds.min.z), 0f);
			}
		}

		public OrthoScreenshotHelper(AircraftScript aircraft)
		{
			_aircraft = aircraft;
			_lights = new List<Light>();
			_lights.AddRange(UnityEngine.Object.FindObjectsByType<Light>(FindObjectsSortMode.None));
		}

		public IEnumerator TakeOrthoScreenshots()
		{
			GameObject cameraOrthoGameObject = UnityEngine.Object.Instantiate(Resources.Load("Designer/OrthoCamera")) as GameObject;
			Camera component = cameraOrthoGameObject.GetComponent<Camera>();
			component.enabled = true;
			TakeOrthoScreenshots(component);
			yield return new WaitForEndOfFrame();
			UnityEngine.Object.Destroy(cameraOrthoGameObject);
		}

		private static Texture2D TakeScreenShot(Camera camera, int width, int height, bool allowTransparency, Rect? sampleRect = null)
		{
			RenderTexture active = RenderTexture.active;
			RenderTexture targetTexture = camera.targetTexture;
			RenderTexture renderTexture = new RenderTexture(width, height, 24);
			renderTexture.anisoLevel = 8;
			renderTexture.antiAliasing = 4;
			camera.targetTexture = renderTexture;
			camera.Render();
			RenderTexture.active = renderTexture;
			int width2;
			int height2;
			if (!sampleRect.HasValue)
			{
				sampleRect = camera.pixelRect;
				width2 = width;
				height2 = height;
			}
			else
			{
				width2 = (int)sampleRect.Value.width;
				height2 = (int)sampleRect.Value.height;
			}
			TextureFormat textureFormat = ((!allowTransparency) ? TextureFormat.RGB24 : TextureFormat.ARGB32);
			Texture2D texture2D = new Texture2D(width2, height2, textureFormat, mipChain: false);
			texture2D.ReadPixels(sampleRect.Value, 0, 0, recalculateMipMaps: false);
			texture2D.Apply();
			RenderTexture.active = active;
			camera.targetTexture = targetTexture;
			return texture2D;
		}

		private void TakeOrthoScreenshots(Camera cameraOrtho)
		{
			if (_aircraft.LoadContext == CraftLoadContext.Designer)
			{
				foreach (PartData part in _aircraft.Parts)
				{
					Assembly.CreateEditorCollidersForPartScript(part.PartScript);
				}
			}
			Bounds bounds = _aircraft.CalculateBounds(includeDisconnectedParts: true);
			cameraOrtho.orthographicSize = Mathf.Max(bounds.extents.x, bounds.extents.y, bounds.extents.z);
			cameraOrtho.gameObject.transform.position = AircraftTopViewPosition;
			cameraOrtho.gameObject.transform.LookAt(AircraftCenter);
			TopScreenshotTexture = TakeScreenShot(cameraOrtho, 720, 720, allowTransparency: false);
			cameraOrtho.gameObject.transform.position = AircraftFrontViewPosition;
			cameraOrtho.gameObject.transform.LookAt(AircraftCenter);
			FrontScreenshotTexture = TakeScreenShot(cameraOrtho, 720, 720, allowTransparency: false);
			cameraOrtho.gameObject.transform.position = AircraftSideViewPosition;
			cameraOrtho.gameObject.transform.LookAt(AircraftCenter);
			SideScreenshotTexture = TakeScreenShot(cameraOrtho, 720, 720, allowTransparency: false);
			cameraOrtho.enabled = false;
		}
	}
}
