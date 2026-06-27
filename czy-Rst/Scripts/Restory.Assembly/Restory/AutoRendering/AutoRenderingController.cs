using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Restory.Data.Elements;
using UnityEngine;
using UnityEngine.Pool;

namespace Restory.AutoRendering
{
	public class AutoRenderingController : MonoBehaviour
	{
		[SerializeField]
		private AutoRenderingObject[] renderingObjects = Array.Empty<AutoRenderingObject>();

		[SerializeField]
		private Camera camera;

		[SerializeField]
		private Vector2Int[] sizes = new Vector2Int[2]
		{
			new Vector2Int(120, 120),
			new Vector2Int(380, 380)
		};

		[SerializeField]
		private string saveBasePath = "Assets/Restory/Art/Images/Devices/";

		[SerializeField]
		private bool transparentBackground = true;

		[SerializeField]
		private LayerMask renderMask = -1;

		[SerializeField]
		[Min(0f)]
		private float thresholdAlpha = 0.01f;

		[SerializeField]
		private ElementsTintColoringSettings tintColoringSettings;

		private Coroutine renderRoutine;

		public void StartRender()
		{
			if (renderRoutine != null)
			{
				StopCoroutine(renderRoutine);
				renderRoutine = null;
			}
			if (camera == null)
			{
				Debug.LogError("AutoRenderingController: Camera is not assigned.");
			}
			else if (renderingObjects == null || renderingObjects.Length == 0)
			{
				Debug.LogWarning("AutoRenderingController: No rendering objects to render.");
			}
			else if (sizes == null || sizes.Length == 0)
			{
				Debug.LogWarning("AutoRenderingController: No sizes.");
			}
			else if (string.IsNullOrEmpty(saveBasePath))
			{
				Debug.LogWarning("AutoRenderingController: Save base path is not set.");
			}
			else
			{
				renderRoutine = StartCoroutine(Render());
			}
		}

		public void StopRender()
		{
			if (renderRoutine != null)
			{
				StopCoroutine(renderRoutine);
				renderRoutine = null;
			}
		}

		public void SetAllChildObjects(GameObject parent)
		{
			if (!(parent == null))
			{
				renderingObjects = parent.GetComponentsInChildren<AutoRenderingObject>();
			}
		}

		private IEnumerator Render()
		{
			for (int i = 0; i < renderingObjects.Length; i++)
			{
				if (renderingObjects[i] != null)
				{
					renderingObjects[i].gameObject.SetActive(value: false);
				}
			}
			for (int j = 0; j < renderingObjects.Length; j++)
			{
				AutoRenderingObject renderingObj = renderingObjects[j];
				if (renderingObj != null)
				{
					renderingObj.gameObject.SetActive(value: true);
					yield return RenderObjectGroup(renderingObj);
					renderingObj.gameObject.SetActive(value: false);
				}
			}
		}

		private IEnumerator RenderObjectGroup(AutoRenderingObject renderingObj)
		{
			if (camera == null || sizes == null || sizes.Length == 0)
			{
				yield return null;
				yield break;
			}
			GameObject[] childObjects = renderingObj.ChildObjects;
			if (childObjects == null || childObjects.Length == 0)
			{
				Debug.LogWarning("AutoRenderingController: No child objects found in " + renderingObj.name);
				yield return null;
				yield break;
			}
			for (int i = 0; i < childObjects.Length; i++)
			{
				if (childObjects[i] != null)
				{
					childObjects[i].SetActive(value: false);
				}
			}
			Color tintColor;
			bool setTint = renderingObj.TryGetTintColor(out tintColor);
			foreach (GameObject gameObject in childObjects)
			{
				if (!(gameObject == null))
				{
					gameObject.SetActive(value: true);
					if (setTint)
					{
						SetTintColor(gameObject, tintColor);
					}
					for (int j = 0; j < sizes.Length; j++)
					{
						Vector2Int size = sizes[j];
						int width = Mathf.Max(1, size.x);
						int height = Mathf.Max(1, size.y);
						Texture2D texture = RenderWithTransparency(width, height);
						SaveTexture(renderingObj, gameObject, texture, size);
					}
					gameObject.SetActive(value: false);
					yield return null;
				}
			}
		}

		private void SetTintColor(GameObject objectToColor, Color tintColor)
		{
			MeshRenderer[] componentsInChildren = objectToColor.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren)
			{
				List<Material> value;
				using (CollectionPool<List<Material>, Material>.Get(out value))
				{
					meshRenderer.GetSharedMaterials(value);
					for (int j = 0; j < value.Count; j++)
					{
						Material material = value[j];
						if ((bool)material.shader && !(material.shader != tintColoringSettings.ShaderToColor))
						{
							Material material2 = new Material(material);
							material2.SetColor(tintColoringSettings.TintShaderProperty, tintColor);
							value[j] = material2;
						}
					}
					meshRenderer.materials = value.ToArray();
				}
			}
		}

		private Texture2D RenderWithTransparency(int width, int height)
		{
			RenderTexture renderTexture = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32);
			renderTexture.Create();
			RenderTexture active = RenderTexture.active;
			RenderTexture targetTexture = camera.targetTexture;
			int cullingMask = camera.cullingMask;
			camera.cullingMask = renderMask;
			RenderTexture.active = renderTexture;
			camera.targetTexture = renderTexture;
			Texture2D texture2D = new Texture2D(width, height, transparentBackground ? TextureFormat.RGBA32 : TextureFormat.RGB24, mipChain: false);
			if (transparentBackground)
			{
				camera.clearFlags = CameraClearFlags.Color;
				camera.backgroundColor = Color.black;
				camera.Render();
				Texture2D texture2D2 = new Texture2D(width, height, TextureFormat.RGB24, mipChain: false);
				texture2D2.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
				texture2D2.Apply();
				camera.backgroundColor = Color.white;
				camera.Render();
				Texture2D texture2D3 = new Texture2D(width, height, TextureFormat.RGB24, mipChain: false);
				texture2D3.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
				texture2D3.Apply();
				Color[] pixels = texture2D2.GetPixels();
				Color[] pixels2 = texture2D3.GetPixels();
				Color[] array = new Color[pixels.Length];
				for (int i = 0; i < pixels.Length; i++)
				{
					float num = 1f - (pixels2[i].r - pixels[i].r);
					if (num <= thresholdAlpha)
					{
						array[i] = Color.clear;
						continue;
					}
					Color color = pixels[i] / num;
					color.a = num;
					array[i] = color;
				}
				texture2D.SetPixels(array);
				texture2D.Apply();
				UnityEngine.Object.DestroyImmediate(texture2D2);
				UnityEngine.Object.DestroyImmediate(texture2D3);
			}
			else
			{
				camera.Render();
				texture2D.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
				texture2D.Apply();
			}
			camera.targetTexture = targetTexture;
			camera.cullingMask = cullingMask;
			RenderTexture.active = active;
			renderTexture.Release();
			UnityEngine.Object.DestroyImmediate(renderTexture);
			return texture2D;
		}

		private void SaveTexture(AutoRenderingObject parentObj, GameObject childObj, Texture2D texture, Vector2Int size)
		{
			try
			{
				string path = parentObj.name.Replace(" ", "_");
				string path2 = $"{size.x}x{size.y}";
				string text = Path.Combine(saveBasePath, path, path2);
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				string text2 = childObj.name.Replace(" ", "_") + ".png";
				string path3 = Path.Combine(text, text2);
				byte[] bytes = texture.EncodeToPNG();
				File.WriteAllBytes(path3, bytes);
				Debug.Log("AutoRender: Saved " + text2 + " to " + text);
			}
			catch (Exception ex)
			{
				Debug.LogError("AutoRender: Failed to save texture for " + parentObj.name + "/" + childObj.name + ": " + ex.Message);
			}
		}
	}
}
