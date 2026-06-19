using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace TH20
{
	public class CharacterMugShot : MustCallDestroy
	{
		private struct CachedMaterialSettings
		{
			public Material[] Materials;

			public bool RoomLighting;

			public Renderer Renderer;

			public MaterialPropertyBlock MaterialPropertyBlock;
		}

		private Camera _camera;

		private static List<CharModule.ModuleInstance> _cachedInstances = new List<CharModule.ModuleInstance>(32);

		public RenderTexture Texture { get; private set; }

		public static CharacterMugShot FromCharacterVisual(CharacterVisual visual, int width, int height, HUD.MugshotConfig config)
		{
			if (visual == null)
			{
				return null;
			}
			if (visual.HeadSocket == null)
			{
				return null;
			}
			Vector3 position = visual.HeadSocket.position;
			Quaternion rotation = visual.HeadSocket.rotation;
			bool valueModeEnabled = visual.ValueModeEnabled;
			bool hiddenModeEnable = visual.HiddenModeEnable;
			bool fadingModeEnable = visual.FadingModeEnable;
			visual.ValueModeEnabled = false;
			visual.HiddenModeEnable = false;
			visual.FadingModeEnable = false;
			FilterMode filterMode = FilterMode.Bilinear;
			if (visual.RetroModeEnabled)
			{
				width = 12;
				height = 12;
				filterMode = FilterMode.Point;
			}
			_cachedInstances.Clear();
			if (visual.ModuleInstances != null)
			{
				_cachedInstances.AddRange(visual.ModuleInstances);
			}
			if (visual.MaskInstances != null)
			{
				_cachedInstances.AddRange(visual.MaskInstances);
			}
			CharacterMugShot result = new CharacterMugShot(position, rotation, _cachedInstances, width, height, config, filterMode);
			_cachedInstances.Clear();
			visual.ValueModeEnabled = valueModeEnabled;
			visual.HiddenModeEnable = hiddenModeEnable;
			visual.FadingModeEnable = fadingModeEnable;
			return result;
		}

		public CharacterMugShot(Vector3 focus, Quaternion lookDirection, List<CharModule.ModuleInstance> moduleInstances, int width, int height, HUD.MugshotConfig config, FilterMode filterMode = FilterMode.Bilinear)
		{
			Texture = new RenderTexture(width, height, 16, RenderTextureFormat.ARGB32)
			{
				wrapMode = TextureWrapMode.Clamp,
				filterMode = filterMode,
				antiAliasing = 4
			};
			GameObject gameObject = new GameObject("Mugshot Camera");
			gameObject.SetActive(value: false);
			_camera = gameObject.AddComponent<Camera>();
			_camera.allowHDR = true;
			_camera.allowMSAA = false;
			_camera.clearFlags = CameraClearFlags.Color;
			_camera.backgroundColor = Color.clear;
			_camera.cullingMask = 0;
			_camera.aspect = (float)width / (float)height;
			_camera.fieldOfView = 45f;
			_camera.nearClipPlane = 0.05f;
			_camera.farClipPlane = 40f;
			_camera.renderingPath = RenderingPath.Forward;
			Vector3 position = focus + lookDirection * config.CameraOffset;
			_camera.transform.position = position;
			_camera.transform.LookAt(focus + config.FocusOffset);
			_camera.ResetWorldToCameraMatrix();
			CommandBuffer commandBuffer = new CommandBuffer
			{
				name = "Mugshot"
			};
			commandBuffer.SetRenderTarget(Texture);
			commandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear);
			commandBuffer.SetViewProjectionMatrices(_camera.worldToCameraMatrix, _camera.projectionMatrix);
			List<CachedMaterialSettings> list = new List<CachedMaterialSettings>(moduleInstances.Count + 1);
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			if (config.Lighting != null)
			{
				config.Lighting.Apply(materialPropertyBlock, _camera.transform);
			}
			foreach (CharModule.ModuleInstance moduleInstance in moduleInstances)
			{
				Renderer renderer = moduleInstance.Renderer;
				if (!renderer.enabled || !renderer.gameObject.activeSelf)
				{
					continue;
				}
				Material[] sharedMaterials = renderer.sharedMaterials;
				Material[] materials = renderer.materials;
				CachedMaterialSettings item = new CachedMaterialSettings
				{
					Materials = sharedMaterials,
					RoomLighting = TH20Standard.IsRoomLightingEnabled(sharedMaterials[0]),
					Renderer = renderer
				};
				if (renderer.HasPropertyBlock())
				{
					item.MaterialPropertyBlock = new MaterialPropertyBlock();
					renderer.GetPropertyBlock(item.MaterialPropertyBlock);
				}
				list.Add(item);
				renderer.SetPropertyBlock(materialPropertyBlock);
				if (materials.Length == 0)
				{
					continue;
				}
				for (int i = 0; i < materials.Length; i++)
				{
					if (i < materials.Length)
					{
						Material material = materials[i];
						TH20Standard.EnableRoomLighting(material);
						commandBuffer.DrawRenderer(renderer, material, i, 0);
					}
				}
			}
			Graphics.ExecuteCommandBuffer(commandBuffer);
			foreach (CachedMaterialSettings item2 in list)
			{
				item2.Renderer.sharedMaterials = item2.Materials;
				item2.Renderer.SetPropertyBlock(item2.MaterialPropertyBlock);
			}
		}

		public override void Destroy()
		{
			if (Texture != null)
			{
				Object.Destroy(Texture);
				Texture = null;
			}
			if (_camera != null)
			{
				Object.Destroy(_camera.gameObject);
				_camera = null;
			}
			base.Destroy();
		}
	}
}
