using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public abstract class RendererLodInputData : LodInputData
	{
		[Tooltip("The renderer to use for this input.\n\nCan be anything that inherits from <i>Renderer</i> like <i>MeshRenderer</i>, <i>TrailRenderer</i> etc.")]
		[SerializeField]
		internal Renderer _Renderer;

		[Tooltip("Forces the renderer to only render into the LOD data, and not to render in the scene as it normally would.")]
		[SerializeField]
		internal bool _DisableRenderer = true;

		[Tooltip("Whether to set the shader pass manually.")]
		[SerializeField]
		internal bool _OverrideShaderPass;

		[Tooltip("The shader pass to execute.\n\nSet to -1 to execute all passes.")]
		[SerializeField]
		internal int _ShaderPassIndex;

		[Tooltip("Check that the shader applied to this object matches the input type.\n\nFor example, an Animated Waves input object has an Animated Waves input shader.")]
		[SerializeField]
		internal bool _CheckShaderName = true;

		[Tooltip("Check that the shader applied to this object has only a single pass, as only the first pass is executed for most inputs.")]
		[SerializeField]
		internal bool _CheckShaderPasses = true;

		internal List<Material> _Materials = new List<Material>();

		private MaterialPropertyBlock _MaterialPropertyBlock;

		internal abstract string ShaderPrefix { get; }

		internal override bool IsEnabled
		{
			get
			{
				if (_Renderer != null)
				{
					return _MaterialPropertyBlock != null;
				}
				return false;
			}
		}

		public bool CheckShaderName
		{
			get
			{
				return _CheckShaderName;
			}
			set
			{
				_CheckShaderName = value;
			}
		}

		public bool CheckShaderPasses
		{
			get
			{
				return _CheckShaderPasses;
			}
			set
			{
				_CheckShaderPasses = value;
			}
		}

		public bool DisableRenderer
		{
			get
			{
				return _DisableRenderer;
			}
			set
			{
				SetDisableRenderer(_DisableRenderer, _DisableRenderer = value);
			}
		}

		public bool OverrideShaderPass
		{
			get
			{
				return _OverrideShaderPass;
			}
			set
			{
				_OverrideShaderPass = value;
			}
		}

		public Renderer Renderer
		{
			get
			{
				return _Renderer;
			}
			set
			{
				SetRenderer(_Renderer, _Renderer = value);
			}
		}

		public int ShaderPassIndex
		{
			get
			{
				return _ShaderPassIndex;
			}
			set
			{
				_ShaderPassIndex = value;
			}
		}

		internal override void RecalculateRect()
		{
			_Rect = Rect.MinMaxRect(_Renderer.bounds.min.x, _Renderer.bounds.min.z, _Renderer.bounds.max.x, _Renderer.bounds.max.z);
		}

		internal override void RecalculateBounds()
		{
			_Bounds = _Renderer.bounds;
		}

		private bool AnyOtherInputsControllingRenderer(Renderer renderer)
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				if (!sceneAt.isLoaded)
				{
					continue;
				}
				GameObject[] rootGameObjects = sceneAt.GetRootGameObjects();
				for (int j = 0; j < rootGameObjects.Length; j++)
				{
					LodInput[] componentsInChildren = rootGameObjects[j].GetComponentsInChildren<LodInput>();
					foreach (LodInput lodInput in componentsInChildren)
					{
						if (!(lodInput == _Input) && lodInput.Data is RendererLodInputData rendererLodInputData && lodInput.isActiveAndEnabled && rendererLodInputData._DisableRenderer && rendererLodInputData._Renderer == renderer)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		internal override void OnEnable()
		{
			if (_MaterialPropertyBlock == null)
			{
				_MaterialPropertyBlock = new MaterialPropertyBlock();
			}
			if (!(_Renderer == null))
			{
				_Renderer.GetSharedMaterials(_Materials);
				if (_DisableRenderer)
				{
					_Renderer.forceRenderingOff = true;
				}
			}
		}

		internal override void OnDisable()
		{
			if (_Renderer != null && _DisableRenderer && !AnyOtherInputsControllingRenderer(_Renderer))
			{
				_Renderer.forceRenderingOff = false;
			}
		}

		internal override void OnUpdate()
		{
			if (!(_Renderer == null))
			{
				_Renderer.GetSharedMaterials(_Materials);
				_RecalculateBounds = true;
				_RecalculateRect = _Bounds != _Renderer.bounds;
			}
		}

		internal override void Draw(Lod lod, Component component, CommandBuffer buffer, RenderTargetIdentifier target, int slice)
		{
			for (int i = 0; i < _Materials.Count; i++)
			{
				Material material = _Materials[i];
				int num = 0;
				if (ShapeWaves.s_RenderPassOverride > -1)
				{
					num = ShapeWaves.s_RenderPassOverride;
				}
				else if (_OverrideShaderPass)
				{
					num = _ShaderPassIndex;
				}
				if (num > material.shader.passCount - 1)
				{
					break;
				}
				if (RenderPipelineHelper.IsLegacy || RenderPipelineHelper.IsHighDefinition)
				{
					_Renderer.GetPropertyBlock(_MaterialPropertyBlock);
					_MaterialPropertyBlock.SetVector(ShaderIDs.Unity.s_Time, new Vector4(Time.timeSinceLevelLoad / 20f, Time.timeSinceLevelLoad, Time.timeSinceLevelLoad * 2f, Time.timeSinceLevelLoad * 3f));
					_Renderer.SetPropertyBlock(_MaterialPropertyBlock);
				}
				buffer.DrawRenderer(_Renderer, material, i, num);
			}
		}

		private void SetRenderer(Renderer previous, Renderer current)
		{
			if (!(previous == current) && !(_Input == null) && _Input.isActiveAndEnabled)
			{
				if (previous != null && _DisableRenderer && !AnyOtherInputsControllingRenderer(previous))
				{
					previous.forceRenderingOff = false;
				}
				if (current != null)
				{
					current.forceRenderingOff = true;
				}
			}
		}

		private void SetDisableRenderer(bool previous, bool current)
		{
			if (previous != current && !(_Input == null) && _Input.isActiveAndEnabled && _Renderer != null && !AnyOtherInputsControllingRenderer(_Renderer))
			{
				_Renderer.forceRenderingOff = _DisableRenderer;
			}
		}
	}
}
