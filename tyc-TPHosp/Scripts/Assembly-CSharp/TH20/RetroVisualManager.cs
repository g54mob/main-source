using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace TH20
{
	[DontSave]
	public class RetroVisualManager : MustCallDestroy
	{
		private struct RetroResources
		{
			public Material Material;

			public RenderTexture RenderTexture;
		}

		private struct ActiveRetroEffect
		{
			public RetroResources RetroResources;

			public CharacterVisual CharacterVisual;
		}

		private RetroVisualManagerConfig _config;

		private Level _level;

		private Mesh _mesh;

		private Material _material;

		private Camera _retroCamera;

		private CommandBuffer _commandBuffer;

		private List<RetroResources> _cachedRetroResourceses = new List<RetroResources>(256);

		private List<ActiveRetroEffect> _activeRetroEffects = new List<ActiveRetroEffect>(256);

		private float _updateCooldown;

		public Mesh Mesh => _mesh;

		public Vector3 MeshScale => _config.MeshScale;

		public float CameraHeightOffset => _config.CameraHeightOffset;

		public AdvisorLighting Lighting => _config.Lighting;

		public RetroVisualManager(Level level, RetroVisualManagerConfig config)
		{
			_config = config;
			_level = level;
			_mesh = MeshUtils.CreatePlaneMesh();
			_material = config.RetroPlaneMaterial;
			GameObject gameObject = new GameObject("Retro Effect Camera");
			gameObject.SetActive(value: false);
			_retroCamera = gameObject.AddComponent<Camera>();
			_retroCamera.clearFlags = CameraClearFlags.Color;
			_retroCamera.backgroundColor = Color.clear;
			_retroCamera.cullingMask = 0;
			_retroCamera.fieldOfView = 45f;
			_retroCamera.nearClipPlane = 5f;
			_retroCamera.farClipPlane = 50f;
			_retroCamera.allowHDR = false;
			_retroCamera.allowMSAA = true;
			_retroCamera.transform.position = new Vector3(0f, 0f, 35f);
			_retroCamera.renderingPath = RenderingPath.Forward;
			_retroCamera.ResetProjectionMatrix();
			_retroCamera.ResetWorldToCameraMatrix();
			_commandBuffer = new CommandBuffer();
			_commandBuffer.name = "Retro";
		}

		public float GetMeshBias(float headSocketHeight)
		{
			return _config.MeshBias.Evaluate(headSocketHeight);
		}

		public Material GetRetroMaterial(CharacterVisual characterVisual)
		{
			RetroResources retroResources;
			if (_cachedRetroResourceses.Count > 0)
			{
				retroResources = _cachedRetroResourceses[_cachedRetroResourceses.Count - 1];
				_cachedRetroResourceses.RemoveAt(_cachedRetroResourceses.Count - 1);
			}
			else
			{
				RenderTextureDescriptor desc = new RenderTextureDescriptor(_config.RetroTextureWidth, _config.RetroTextureHeight, RenderTextureFormat.ARGB32);
				desc.useMipMap = false;
				desc.autoGenerateMips = false;
				desc.depthBufferBits = 8;
				desc.msaaSamples = 4;
				retroResources = new RetroResources
				{
					Material = new Material(_material),
					RenderTexture = new RenderTexture(desc)
					{
						filterMode = FilterMode.Point
					}
				};
				retroResources.Material.mainTexture = retroResources.RenderTexture;
			}
			AddActiveRetroEffect(ref retroResources, characterVisual);
			return retroResources.Material;
		}

		public void ReleaseMaterial(Material material)
		{
			int index = -1;
			for (int i = 0; i < _activeRetroEffects.Count; i++)
			{
				if (_activeRetroEffects[i].RetroResources.Material == material)
				{
					index = i;
					break;
				}
			}
			RetroResources retroResources = _activeRetroEffects[index].RetroResources;
			_activeRetroEffects.RemoveAt(index);
			_cachedRetroResourceses.Add(retroResources);
		}

		private void AddActiveRetroEffect(ref RetroResources retroResources, CharacterVisual characterVisual)
		{
			_activeRetroEffects.Add(new ActiveRetroEffect
			{
				RetroResources = retroResources,
				CharacterVisual = characterVisual
			});
		}

		public void Update()
		{
			if (_activeRetroEffects.Count == 0)
			{
				return;
			}
			_updateCooldown -= Time.unscaledDeltaTime;
			if (_updateCooldown > 0f)
			{
				return;
			}
			_updateCooldown = Mathf.Max(-1f / (float)_config.RetroFrameRate, _updateCooldown);
			_updateCooldown += 1f / (float)_config.RetroFrameRate;
			_commandBuffer.Clear();
			_retroCamera.ResetProjectionMatrix();
			_retroCamera.fieldOfView = _config.CameraFieldOfView;
			foreach (ActiveRetroEffect activeRetroEffect in _activeRetroEffects)
			{
				GameObject characterGameObject = activeRetroEffect.CharacterVisual.CharacterGameObject;
				Vector3 position = characterGameObject.transform.position;
				if (GeometryUtility.TestPlanesAABB(_level.CameraLogic.FrustumPlanes, new Bounds(position, new Vector3(2f, 2f, 2f))))
				{
					_commandBuffer.SetRenderTarget(activeRetroEffect.RetroResources.RenderTexture);
					_commandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear);
					_retroCamera.targetTexture = activeRetroEffect.RetroResources.RenderTexture;
					characterGameObject.GetComponent<Animator>().cullingMode = AnimatorCullingMode.AlwaysAnimate;
					Vector3 forward = characterGameObject.transform.forward;
					Vector3 forward2 = _level.CameraLogic.CameraComponent.transform.forward;
					Vector3 right = _level.CameraLogic.CameraComponent.transform.right;
					float num = Vector3.SignedAngle(Vector3.forward, new Vector3(forward2.x, 0f, forward2.z), Vector3.up);
					float num2 = Vector3.SignedAngle(new Vector3(forward2.x, 0f, forward2.z), forward2, right);
					float num3 = Vector3.SignedAngle(forward, Vector3.forward, Vector3.up);
					float angle = Mathf.Round((num + num3) / 45f) * 45f;
					float num4 = 12f;
					float f = (90f - num2) * ((float)Math.PI / 180f);
					float y = activeRetroEffect.CharacterVisual.HeadSocket.position.y;
					Vector3 vector = new Vector3(0f, Mathf.Cos(f), 0f - Mathf.Sin(f)) * num4;
					_retroCamera.transform.position = position + Quaternion.AngleAxis(angle, Vector3.up) * characterGameObject.transform.rotation * vector;
					_retroCamera.transform.LookAt(position + _config.CameraLookAtOffset);
					_retroCamera.transform.position = _retroCamera.transform.position + new Vector3(0f, _config.CameraHeightOffset + y, 0f);
					_retroCamera.ResetWorldToCameraMatrix();
					_commandBuffer.SetViewProjectionMatrices(_retroCamera.worldToCameraMatrix, _retroCamera.projectionMatrix);
					foreach (CharModule.ModuleInstance moduleInstance in activeRetroEffect.CharacterVisual.ModuleInstances)
					{
						DrawModuleInstance(moduleInstance);
					}
					if (activeRetroEffect.CharacterVisual.MaskInstances != null)
					{
						foreach (CharModule.ModuleInstance maskInstance in activeRetroEffect.CharacterVisual.MaskInstances)
						{
							DrawModuleInstance(maskInstance);
						}
					}
					if (activeRetroEffect.CharacterVisual.OverlayInstances == null)
					{
						continue;
					}
					foreach (CharModule.ModuleInstance overlayInstance in activeRetroEffect.CharacterVisual.OverlayInstances)
					{
						DrawModuleInstance(overlayInstance);
					}
				}
				else
				{
					characterGameObject.GetComponent<Animator>().cullingMode = AnimatorCullingMode.CullUpdateTransforms;
				}
			}
			Graphics.ExecuteCommandBuffer(_commandBuffer);
		}

		private void DrawModuleInstance(CharModule.ModuleInstance moduleInstance)
		{
			Renderer renderer = moduleInstance.Renderer;
			if (!renderer.gameObject.activeInHierarchy)
			{
				return;
			}
			Material[] sharedMaterials = renderer.sharedMaterials;
			if (sharedMaterials.Length == 0)
			{
				return;
			}
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				if (i < sharedMaterials.Length)
				{
					if (renderer is SkinnedMeshRenderer)
					{
						((SkinnedMeshRenderer)renderer).updateWhenOffscreen = true;
					}
					_commandBuffer.DrawRenderer(renderer, sharedMaterials[i], i, 0);
				}
			}
		}

		public override void Destroy()
		{
			foreach (RetroResources cachedRetroResourcese in _cachedRetroResourceses)
			{
				UnityEngine.Object.Destroy(cachedRetroResourcese.Material);
				UnityEngine.Object.Destroy(cachedRetroResourcese.RenderTexture);
			}
			foreach (ActiveRetroEffect activeRetroEffect in _activeRetroEffects)
			{
				UnityEngine.Object.Destroy(activeRetroEffect.RetroResources.Material);
				UnityEngine.Object.Destroy(activeRetroEffect.RetroResources.RenderTexture);
			}
			if (_retroCamera != null)
			{
				UnityEngine.Object.Destroy(_retroCamera.gameObject);
				_retroCamera = null;
			}
			base.Destroy();
		}
	}
}
