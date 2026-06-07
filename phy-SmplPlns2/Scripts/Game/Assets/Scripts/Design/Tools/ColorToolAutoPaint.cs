using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace Assets.Scripts.Design.Tools
{
	public class ColorToolAutoPaint
	{
		private Material _autoPaintMaterial;

		private Material _autoPaintMaterialCullFront;

		private Texture2D _cachedTexture;

		private CommandBuffer _commandBuffer;

		private float _lastCameraFOV;

		private Vector3 _lastCameraPosition;

		private Quaternion _lastCameraRotation;

		private bool? _lastOrthographic;

		private MaterialPropertyBlock _propBlock;

		private RenderTexture _renderTexture;

		public bool GetPartAndMaterialLevelAtScreenPosition(AircraftScript aircraft, Camera camera, Vector2 screenPosition, out PartScript partHit, out int materialLevel)
		{
			if (_commandBuffer == null)
			{
				_commandBuffer = new CommandBuffer();
				_propBlock = new MaterialPropertyBlock();
				_autoPaintMaterial = Game.Instance.ResourceLoader.LoadSharedMaterial("Designer/Materials/DesignerAutoPaint");
				_autoPaintMaterialCullFront = Game.Instance.ResourceLoader.LoadSharedMaterial("Designer/Materials/DesignerAutoPaintCullFlipped");
			}
			bool flag = _cachedTexture == null || camera.transform.position != _lastCameraPosition || camera.transform.rotation != _lastCameraRotation || camera.fieldOfView != _lastCameraFOV || camera.orthographic != _lastOrthographic;
			if (InitializeRenderTexture(camera))
			{
				flag = true;
			}
			if (flag)
			{
				_lastCameraPosition = camera.transform.position;
				_lastCameraRotation = camera.transform.rotation;
				_lastCameraFOV = camera.fieldOfView;
				_lastOrthographic = camera.orthographic;
				_commandBuffer.Clear();
				_commandBuffer.SetRenderTarget(_renderTexture);
				_commandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.blue);
				_commandBuffer.SetGlobalDepthBias(0f, 0f);
				_commandBuffer.EnableShaderKeyword("_DEPTHTEST_ON");
				Matrix4x4 projectionMatrix = camera.projectionMatrix;
				_commandBuffer.SetViewProjectionMatrices(camera.worldToCameraMatrix, projectionMatrix);
				_commandBuffer.SetViewport(new Rect(0f, 0f, _renderTexture.width, _renderTexture.height));
				List<LabelScript> list = new List<LabelScript>();
				foreach (PartData part in aircraft.Parts)
				{
					PartScript partScript = part.PartScript;
					if (!partScript.Part.VisibleInDesigner)
					{
						continue;
					}
					LabelScript modifier = partScript.GetModifier<LabelScript>();
					if (modifier != null && modifier.gameObject.activeInHierarchy)
					{
						list.Add(modifier);
					}
					foreach (PartMaterialScript.RendererMaterialMap rendererMap in partScript.PartMaterialScript.RendererMaps)
					{
						MeshRenderer renderer = rendererMap.Renderer;
						if (renderer == null || !renderer.gameObject.activeInHierarchy || !renderer.enabled)
						{
							continue;
						}
						Mesh mesh = null;
						if ((object)renderer != null)
						{
							mesh = renderer.GetComponent<MeshFilter>().sharedMesh;
						}
						_ = renderer.GetComponent<PartRendererScript>()?.Materials;
						if (!(mesh != null))
						{
							continue;
						}
						for (int i = 0; i < mesh.subMeshCount; i++)
						{
							if (rendererMap.SubmeshToLevelMap != null && i >= rendererMap.SubmeshToLevelMap.Length)
							{
								Debug.LogError($"Renderer is incorrectly configured. SubmeshIndex {i} >= SubmeshToLevelMap.Length {rendererMap.SubmeshToLevelMap.Length}", renderer.gameObject);
								continue;
							}
							int num = ((rendererMap.SubmeshToLevelMap == null) ? i : rendererMap.SubmeshToLevelMap[i]);
							_propBlock.Clear();
							_propBlock.SetFloat("_PartID", partScript.Part.Id);
							_propBlock.SetFloat("_TrimLevel", num);
							Vector3 lossyScale = renderer.transform.lossyScale;
							Material material = ((lossyScale.x * lossyScale.y * lossyScale.z < 0f) ? _autoPaintMaterialCullFront : _autoPaintMaterial);
							_commandBuffer.DrawMesh(mesh, renderer.localToWorldMatrix, material, i, -1, _propBlock);
						}
					}
				}
				foreach (LabelScript item in list)
				{
					int num2 = (int)((item.Label.GetComponent<PartRendererScript>()?.Materials)?[0].MaterialLevel ?? PartRendererMaterialLevel.Primary);
					_propBlock.Clear();
					_propBlock.SetFloat("_PartID", item.PartScript.Part.Id);
					_propBlock.SetFloat("_TrimLevel", num2);
					Vector3 lossyScale2 = item.Label.renderer.transform.lossyScale;
					Material material2 = ((lossyScale2.x * lossyScale2.y * lossyScale2.z < 0f) ? _autoPaintMaterialCullFront : _autoPaintMaterial);
					_commandBuffer.DrawMesh(item.Label.mesh, item.Label.renderer.localToWorldMatrix, material2, 0, -1, _propBlock);
				}
				Graphics.ExecuteCommandBuffer(_commandBuffer);
				if (_cachedTexture == null || _cachedTexture.width != _renderTexture.width || _cachedTexture.height != _renderTexture.height)
				{
					if (_cachedTexture != null)
					{
						Object.Destroy(_cachedTexture);
					}
					_cachedTexture = new Texture2D(_renderTexture.width, _renderTexture.height, TextureFormat.RGFloat, mipChain: false);
				}
				RenderTexture.active = _renderTexture;
				_cachedTexture.ReadPixels(new Rect(0f, 0f, _renderTexture.width, _renderTexture.height), 0, 0);
				_cachedTexture.Apply();
				RenderTexture.active = null;
			}
			Vector2 vector = new Vector2(screenPosition.x / (float)Screen.width * (float)_cachedTexture.width, screenPosition.y / (float)Screen.height * (float)_cachedTexture.height);
			if (vector.x >= 0f && vector.x < (float)_renderTexture.width && vector.y >= 0f && vector.y < (float)_renderTexture.height)
			{
				Color pixel = _cachedTexture.GetPixel((int)vector.x, (int)vector.y);
				int num3 = (int)pixel.r;
				int value = (int)pixel.g;
				if (num3 > 0)
				{
					int max = 10;
					materialLevel = Mathf.Clamp(value, 0, max);
					partHit = aircraft.GetPartById(num3).PartScript;
					return true;
				}
			}
			partHit = null;
			materialLevel = 0;
			return false;
		}

		public void OnColorToolStopped()
		{
			ReleaseAutoPaintTextures();
		}

		private bool InitializeRenderTexture(Camera camera)
		{
			int num = camera.pixelWidth / 2;
			int num2 = camera.pixelHeight / 2;
			bool result = false;
			if (_renderTexture == null)
			{
				_renderTexture = new RenderTexture(num, num2, 0, RenderTextureFormat.RGFloat)
				{
					depthStencilFormat = GraphicsFormat.D32_SFloat_S8_UInt,
					filterMode = FilterMode.Point,
					autoGenerateMips = false
				};
				result = true;
			}
			else if (_renderTexture.width != num || _renderTexture.height != num2)
			{
				_renderTexture.Release();
				_renderTexture.width = num;
				_renderTexture.height = num2;
				_renderTexture.Create();
				result = true;
			}
			return result;
		}

		private void ReleaseAutoPaintTextures()
		{
			if (_renderTexture != null)
			{
				_renderTexture.Release();
				Object.Destroy(_renderTexture);
				_renderTexture = null;
			}
			if (_cachedTexture != null)
			{
				Object.Destroy(_cachedTexture);
				_cachedTexture = null;
			}
		}

		private void SaveTextureToPNG(Texture2D texture, string fileName)
		{
			byte[] bytes = texture.EncodeToPNG();
			string text = Path.Combine(Application.persistentDataPath, fileName);
			File.WriteAllBytes(text, bytes);
			Debug.Log("Saved texture to: " + text);
		}
	}
}
