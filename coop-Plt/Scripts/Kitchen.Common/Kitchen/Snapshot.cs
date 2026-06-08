using System.Collections.Generic;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public static class Snapshot
	{
		public static List<Texture2D> DebugSnapshotHistory;

		private static int _SnapshotLayer;

		private static LayerMask _SnapshotLayerMask;

		private static int _SnapshotTemporaryLayer;

		private static Camera _SnapshotCamera;

		[HideInInspector]
		public static int SnapshotLayer
		{
			get
			{
				if (_SnapshotLayer == 0)
				{
					_SnapshotLayer = LayerMask.NameToLayer("Snapshot Camera");
				}
				return _SnapshotLayer;
			}
		}

		[HideInInspector]
		private static int SnapshotLayerMask
		{
			get
			{
				if ((int)_SnapshotLayerMask == 0)
				{
					_SnapshotLayerMask = LayerMask.GetMask("Snapshot Camera");
				}
				return _SnapshotLayerMask;
			}
		}

		[HideInInspector]
		public static int SnapshotTemporaryLayer
		{
			get
			{
				if (_SnapshotTemporaryLayer == 0)
				{
					_SnapshotTemporaryLayer = LayerMask.NameToLayer("Snapshot Temporary");
				}
				return _SnapshotTemporaryLayer;
			}
		}

		[HideInInspector]
		private static Camera SnapshotCamera
		{
			get
			{
				if (_SnapshotCamera == null)
				{
					GameObject gameObject = GameObject.Find("Snapshot Camera");
					if ((bool)gameObject)
					{
						_SnapshotCamera = gameObject.GetComponent<Camera>();
					}
					else
					{
						_SnapshotCamera = new GameObject("Snapshot Camera", typeof(Camera)).GetComponent<Camera>();
						_SnapshotCamera.cullingMask = SnapshotLayerMask;
						_SnapshotCamera.enabled = false;
						_SnapshotCamera.orthographic = true;
						_SnapshotCamera.clearFlags = CameraClearFlags.Depth;
						_SnapshotCamera.backgroundColor = new Color(0f, 0f, 0f, 0f);
					}
				}
				return _SnapshotCamera;
			}
		}

		public static SnapshotTexture RenderPrefabToTexture(int pixel_width, int pixel_height, GameObject prefab, Quaternion rotation, float target_width, float target_height, float near = -10f, float far = 10f, float scale = 1f, Vector3 position = default(Vector3))
		{
			GameObject gameObject = Object.Instantiate(prefab);
			gameObject.transform.rotation = rotation;
			gameObject.transform.localScale = Vector3.one * scale;
			SnapshotTexture result = RenderToTexture(pixel_width, pixel_height, gameObject, target_width, target_height, near, far, position);
			if (PlatformSettings.IsEditor)
			{
				Object.DestroyImmediate(gameObject);
				return result;
			}
			Object.Destroy(gameObject);
			return result;
		}

		public static SnapshotTexture RenderToTexture(int pixel_width, int pixel_height, GameObject target, float target_width, float target_height, float near = -10f, float far = 10f, Vector3 offset = default(Vector3))
		{
			return new SnapshotTexture(SaveSnapshot(TakeSnapshot(SetupSnapshotAbove(pixel_width, pixel_height, target.transform.position - offset, target_width, target_height, near, far), target, pixel_width, pixel_height)), target_width, target_height);
		}

		private static RenderTexture TakeSnapshot(Camera camera, GameObject target, int pixel_width, int pixel_height)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(pixel_width, pixel_height, 0, RenderTextureFormat.ARGB32);
			RenderTexture targetTexture = camera.targetTexture;
			int layer = target.layer;
			camera.targetTexture = temporary;
			List<GameObject> objs = SetLayerActive(target, SnapshotTemporaryLayer);
			SetLayer(target, SnapshotLayer);
			camera.Render();
			camera.targetTexture = targetTexture;
			SetLayer(target, layer);
			RevertLayerActive(objs);
			return temporary;
		}

		private static List<GameObject> SetLayerActive(GameObject obj, int layer)
		{
			List<GameObject> list = new List<GameObject>();
			Transform[] componentsInChildren = obj.GetComponentsInChildren<Transform>(includeInactive: true);
			foreach (Transform transform in componentsInChildren)
			{
				if (transform.gameObject.layer == layer && !transform.gameObject.activeInHierarchy)
				{
					list.Add(transform.gameObject);
					transform.gameObject.SetActive(value: true);
				}
			}
			return list;
		}

		private static void RevertLayerActive(List<GameObject> objs)
		{
			foreach (GameObject obj in objs)
			{
				obj.SetActive(value: false);
			}
		}

		private static void SetLayer(GameObject obj, int layer)
		{
			Transform[] componentsInChildren = obj.GetComponentsInChildren<Transform>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].gameObject.layer = layer;
			}
		}

		private static Texture2D SaveSnapshot(RenderTexture snapshot)
		{
			int width = snapshot.width;
			int height = snapshot.height;
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = snapshot;
			Texture2D texture2D = new Texture2D(width, height);
			texture2D.anisoLevel = 2;
			texture2D.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
			texture2D.Apply(updateMipmaps: false);
			RenderTexture.ReleaseTemporary(snapshot);
			RenderTexture.active = active;
			return texture2D;
		}

		private static Camera SetupSnapshotAbove(int pixel_width, int pixel_height, Vector3 origin, float target_width, float target_height, float near = -10f, float far = 10f)
		{
			return SetupSnapshotCamera(pixel_width, pixel_height, origin, -Vector3.up, Vector3.forward, target_width, target_height, near, far);
		}

		private static Camera SetupSnapshotCamera(int pixel_width, int pixel_height, Vector3 origin, Vector3 cam_forward, Vector3 cam_up, float target_width, float target_height, float near = -10f, float far = 10f)
		{
			Camera snapshotCamera = SnapshotCamera;
			snapshotCamera.transform.position = origin - cam_forward;
			snapshotCamera.transform.rotation = Quaternion.LookRotation(cam_forward, cam_up);
			snapshotCamera.aspect = (float)pixel_width / (float)pixel_height;
			snapshotCamera.orthographicSize = target_height;
			snapshotCamera.nearClipPlane = near;
			snapshotCamera.farClipPlane = far;
			return snapshotCamera;
		}

		public static void Blur(RenderTexture source, Material blurMaterial)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height);
			Graphics.Blit(source, temporary, blurMaterial, 0);
			Graphics.Blit(temporary, source, blurMaterial, 1);
			RenderTexture.ReleaseTemporary(temporary);
		}
	}
}
