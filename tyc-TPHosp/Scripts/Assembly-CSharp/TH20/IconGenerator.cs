using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace TH20
{
	public class IconGenerator : MustCallDestroy
	{
		public class Config
		{
			public Material Material;

			public int TextureSize = 256;

			public Texture2D TextureBackground;

			public int SDFDistance = 32;

			public Color OutlineColor = Color.white;

			public int OutlineInner = 8;

			public int OutlineOuter = 24;

			public int OutlineAlpha = 4;

			public Color ShadowColor = new Color(0f, 0f, 0f, 0.5f);

			public Vector3 ShadowOffset = new Vector3(-8f, 4f, 0f);

			public int ShadowMinFalloff = 4;

			public int ShadowMaxFalloff = 16;

			public float CameraDistance;

			public float CameraFOV = 10f;

			public Vector3 CameraRotation = new Vector3(-30f, 45f, 10f);

			public Color LightColor = Color.white;

			public Vector3 LightAngle = new Vector3(45f, 90f, 45f);

			public float LightIntensity = 2f;

			public Color LightAmbientColor = Color.grey;

			public float LightAmbientIntensity = 0.6f;
		}

		private struct RendererInstance
		{
			public Renderer Renderer;

			public List<Material> Materials;
		}

		private Config _config;

		private int _textureSize;

		private Texture2D _texture;

		private RenderTexture _renderTextureFinal;

		private RenderTexture _renderTextureObject;

		private MaterialPropertyBlock _materialPropertyBlock;

		private List<RendererInstance> _rendererInstances = new List<RendererInstance>();

		private Camera _camera;

		private GameObject _object;

		private float _cameraDistance;

		public IconGenerator()
		{
			_materialPropertyBlock = new MaterialPropertyBlock();
			GameObject gameObject = new GameObject("Icon Object Camera");
			_camera = gameObject.AddComponent<Camera>();
			_camera.allowHDR = true;
			_camera.allowMSAA = true;
			_camera.clearFlags = CameraClearFlags.Color;
			_camera.backgroundColor = Color.clear;
			_camera.cullingMask = 0;
			_camera.aspect = 1f;
			_camera.fieldOfView = 10f;
			_camera.nearClipPlane = 5f;
			_camera.farClipPlane = 20f;
			_camera.renderingPath = RenderingPath.Forward;
		}

		private void CreateTextures(int textureSize)
		{
			if (textureSize != _textureSize && textureSize != 0)
			{
				_textureSize = textureSize;
				_texture = new Texture2D(_textureSize, _textureSize, TextureFormat.ARGB32, mipChain: true);
				_renderTextureObject = new RenderTexture(_textureSize, _textureSize, 16, RenderTextureFormat.ARGB32)
				{
					wrapMode = TextureWrapMode.Clamp,
					filterMode = FilterMode.Bilinear,
					antiAliasing = 4
				};
				_renderTextureFinal = new RenderTexture(_textureSize, _textureSize, 16, RenderTextureFormat.ARGB32)
				{
					wrapMode = TextureWrapMode.Clamp,
					filterMode = FilterMode.Bilinear,
					antiAliasing = 4
				};
			}
		}

		public override void Destroy()
		{
			DestroyRendererInstances();
			UnityEngine.Object.DestroyImmediate(_texture);
			UnityEngine.Object.DestroyImmediate(_renderTextureFinal);
			UnityEngine.Object.DestroyImmediate(_renderTextureObject);
			UnityEngine.Object.DestroyImmediate(_camera.gameObject);
			base.Destroy();
		}

		public Texture2D Generate(Config config, GameObject gameObject)
		{
			_config = config;
			SetObject(gameObject);
			CreateTextures(config.TextureSize);
			if (_object != null && _rendererInstances.Count != 0)
			{
				FrameCamera();
				RenderMesh();
			}
			RenderTexture();
			return _texture;
		}

		private void SetObject(GameObject gameObject)
		{
			if (!(gameObject != _object))
			{
				return;
			}
			_object = gameObject;
			DestroyRendererInstances();
			Renderer[] componentsInChildren = _object.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				if (!renderer.enabled || !renderer.gameObject.activeSelf || renderer is ParticleSystemRenderer)
				{
					continue;
				}
				RendererInstance item = new RendererInstance
				{
					Renderer = renderer,
					Materials = new List<Material>()
				};
				Material[] sharedMaterials = renderer.sharedMaterials;
				for (int j = 0; j < sharedMaterials.Length; j++)
				{
					if (j < sharedMaterials.Length)
					{
						Material material = sharedMaterials[j];
						if (material != null)
						{
							item.Materials.Add(new Material(material));
						}
						else
						{
							item.Materials.Add(null);
						}
					}
				}
				_rendererInstances.Add(item);
			}
		}

		private void DestroyRendererInstances()
		{
			foreach (RendererInstance rendererInstance in _rendererInstances)
			{
				rendererInstance.Materials.ClearAndDestroyImmediate();
			}
			_rendererInstances.Clear();
		}

		private void FrameCamera()
		{
			Bounds bounds = _object.RenderBounds();
			float num = 1f / Mathf.Max(Mathf.Max(bounds.extents.x, bounds.extents.y), bounds.extents.z);
			bounds.center *= num;
			bounds.extents *= num;
			_object.transform.position = Vector3.zero;
			_object.transform.localScale *= num;
			if (_config.CameraDistance > 0f || _config.CameraDistance < 0f)
			{
				_cameraDistance = _config.CameraDistance;
			}
			else
			{
				_cameraDistance = bounds.size.magnitude / 2f / Mathf.Sin(_camera.fieldOfView * ((float)Math.PI / 180f) / 2f);
			}
			Vector3 vector = Vector3.forward * _cameraDistance;
			Vector3 vector2 = Quaternion.Euler(_config.CameraRotation) * vector;
			Vector3 worldUp = Quaternion.Euler(_config.CameraRotation) * Vector3.up;
			_camera.transform.position = vector2 + bounds.center;
			_camera.transform.LookAt(bounds.center, worldUp);
			_camera.fieldOfView = _config.CameraFOV;
			_camera.nearClipPlane = _cameraDistance - _cameraDistance / 2f;
			_camera.farClipPlane = _cameraDistance + _cameraDistance / 2f;
		}

		private void RenderMesh()
		{
			CommandBuffer commandBuffer = new CommandBuffer
			{
				name = "Icon Model"
			};
			commandBuffer.SetRenderTarget(_renderTextureObject);
			commandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear);
			commandBuffer.SetViewProjectionMatrices(_camera.worldToCameraMatrix, _camera.projectionMatrix);
			_materialPropertyBlock.SetColor("_DirectionalRoomLightColor", _config.LightColor);
			_materialPropertyBlock.SetVector("_DirectionalRoomLightDirection", Quaternion.Euler(_config.LightAngle) * -Vector3.up);
			_materialPropertyBlock.SetFloat("_DirectionalRoomLightIntensity", _config.LightIntensity);
			_materialPropertyBlock.SetFloat("_AmbientRoomLightIntensity", _config.LightAmbientIntensity);
			_materialPropertyBlock.SetColor("_AmbientRoomLightColor", _config.LightAmbientColor);
			foreach (RendererInstance rendererInstance in _rendererInstances)
			{
				rendererInstance.Renderer.SetPropertyBlock(_materialPropertyBlock);
				for (int i = 0; i < rendererInstance.Materials.Count; i++)
				{
					Material material = rendererInstance.Materials[i];
					if (material != null)
					{
						TH20Standard.EnableRoomLighting(material);
						commandBuffer.DrawRenderer(rendererInstance.Renderer, material, i, 0);
					}
				}
			}
			Graphics.ExecuteCommandBuffer(commandBuffer);
		}

		private void RenderTexture()
		{
			float num = 1f / (float)_renderTextureFinal.width;
			float num2 = (float)_config.TextureSize / 256f;
			Material material = _config.Material;
			material.SetTexture("_BackTex", _config.TextureBackground);
			material.SetFloat("_TextureSize", _config.TextureSize);
			material.SetFloat("SDFDistance", (float)_config.SDFDistance * num2);
			material.SetFloat("OutlineInner", (float)_config.OutlineInner * num * num2);
			material.SetFloat("OutlineOuter", (float)_config.OutlineOuter * num * num2);
			material.SetFloat("OutlineAlpha", (float)_config.OutlineAlpha * num * num2);
			material.SetColor("OutlineColor", _config.OutlineColor);
			material.SetColor("ShadowColor", _config.ShadowColor);
			material.SetVector("ShadowOffset", _config.ShadowOffset * num2);
			material.SetFloat("ShadowMinFalloff", (float)_config.ShadowMinFalloff * num * num2);
			material.SetFloat("ShadowMaxFalloff", (float)_config.ShadowMaxFalloff * num * num2);
			Graphics.Blit(_renderTextureObject, _renderTextureFinal, material);
			UnityEngine.RenderTexture.active = _renderTextureFinal;
			_texture.ReadPixels(new Rect(0f, 0f, _renderTextureFinal.width, _renderTextureFinal.height), 0, 0);
			_texture.Apply();
		}
	}
}
