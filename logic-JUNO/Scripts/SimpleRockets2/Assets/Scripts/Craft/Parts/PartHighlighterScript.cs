using System.Collections.Generic;
using ModApi;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class PartHighlighterScript : MonoBehaviour, IPartHighlighter
	{
		public const int HighlightRenderLayer = 2;

		[SerializeField]
		private Color _highlightColor = Constants.Colors.Primary.Gamma;

		private List<IPartScript> _highlightedParts;

		private Camera _mainCamera;

		private Material _materialCombine;

		private Material _materialHighlightMask;

		private Material _materialOutlineBlurPass1;

		private Material _materialOutlineBlurPass2;

		private Material _materialOutlineMask;

		[SerializeField]
		private Color _outlineColor = Constants.Colors.Primary.Gamma;

		private List<IPartScript> _outlinedParts;

		private Camera _partSelectionCamera;

		[SerializeField]
		private Shader _shaderCombine;

		[SerializeField]
		private Shader _shaderHighlightMask;

		[SerializeField]
		private Shader _shaderOutlineBlurPass1;

		[SerializeField]
		private Shader _shaderOutlineBlurPass2;

		[SerializeField]
		private Shader _shaderOutlineMask;

		private List<PartGroupScript> _tempPartGroupList;

		public static PartHighlighterScript Instance { get; private set; }

		public Color HighlightColor
		{
			get
			{
				return _highlightColor;
			}
			set
			{
				_highlightColor = value;
			}
		}

		public Color OutlineColor
		{
			get
			{
				return _outlineColor;
			}
			set
			{
				_outlineColor = value;
			}
		}

		public void AddPartHighlight(IPartScript part)
		{
			if (!_highlightedParts.Contains(part))
			{
				_highlightedParts.Add(part);
			}
			UpdateEnabledState();
		}

		public void AddPartOutline(IPartScript part)
		{
			if (!_outlinedParts.Contains(part))
			{
				_outlinedParts.Add(part);
			}
			UpdateEnabledState();
		}

		public void RemovePartHighlight(IPartScript part)
		{
			_highlightedParts.Remove(part);
			UpdateEnabledState();
		}

		public void RemovePartOutline(IPartScript part)
		{
			_outlinedParts.Remove(part);
			UpdateEnabledState();
		}

		protected virtual void Awake()
		{
			_highlightedParts = new List<IPartScript>();
			_outlinedParts = new List<IPartScript>();
			_tempPartGroupList = new List<PartGroupScript>();
			Instance = this;
		}

		protected virtual void OnDestroy()
		{
			Instance = null;
			if (_materialHighlightMask != null)
			{
				Object.Destroy(_materialHighlightMask);
			}
			if (_materialOutlineMask != null)
			{
				Object.Destroy(_materialOutlineMask);
			}
			if (_materialOutlineBlurPass1 != null)
			{
				Object.Destroy(_materialOutlineBlurPass1);
			}
			if (_materialOutlineBlurPass2 != null)
			{
				Object.Destroy(_materialOutlineBlurPass2);
			}
			if (_materialCombine != null)
			{
				Object.Destroy(_materialCombine);
			}
		}

		protected virtual void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (_highlightedParts.Count == 0 && _outlinedParts.Count == 0)
			{
				Graphics.Blit(source, destination);
				return;
			}
			int count = _outlinedParts.Count;
			Vector3 position = base.transform.position;
			float num = 0f;
			List<PartGroupScript> tempPartGroupList = _tempPartGroupList;
			foreach (IPartScript highlightedPart in _highlightedParts)
			{
				foreach (IRendererMaterialMap rendererMap in highlightedPart.PartMaterialScript.RendererMaps)
				{
					if (!rendererMap.IsTMProRenderer)
					{
						rendererMap.StartTempRender(2, _materialHighlightMask);
					}
				}
			}
			if (Game.InFlightScene)
			{
				tempPartGroupList.Clear();
				foreach (IPartScript outlinedPart in _outlinedParts)
				{
					PartGroupScript item = (PartGroupScript)outlinedPart.PartGroup;
					if (!tempPartGroupList.Contains(item))
					{
						tempPartGroupList.Add(item);
					}
				}
				foreach (PartGroupScript item2 in tempPartGroupList)
				{
					Material partOutlineMaskMaterial = item2.GetPartOutlineMaskMaterial();
					item2.PartGroupRenderer?.StartTempRender(2, partOutlineMaskMaterial);
					foreach (IPartScript outlinedPart2 in item2.OutlinedParts)
					{
						num += (outlinedPart2.Transform.position - position).magnitude;
						foreach (IRendererMaterialMap rendererMap2 in outlinedPart2.PartMaterialScript.RendererMaps)
						{
							if (!rendererMap2.IsTMProRenderer)
							{
								rendererMap2.StartTempRender(2, partOutlineMaskMaterial);
							}
						}
					}
				}
			}
			else
			{
				foreach (IPartScript outlinedPart3 in _outlinedParts)
				{
					num += (outlinedPart3.Transform.position - position).magnitude;
					foreach (IRendererMaterialMap rendererMap3 in outlinedPart3.PartMaterialScript.RendererMaps)
					{
						if (!rendererMap3.IsTMProRenderer)
						{
							rendererMap3.StartTempRender(2, _materialOutlineMask);
						}
					}
				}
			}
			Camera partSelectionCamera = _partSelectionCamera;
			partSelectionCamera.CopyFrom(_mainCamera);
			partSelectionCamera.clearFlags = CameraClearFlags.Color;
			partSelectionCamera.backgroundColor = Color.black;
			partSelectionCamera.cullingMask = 4;
			RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 24);
			temporary.name = "PartHighlighter1";
			partSelectionCamera.targetTexture = temporary;
			partSelectionCamera.Render();
			RenderTexture renderTexture = null;
			if (count > 0)
			{
				num /= (float)count;
				float num2 = (Device.IsMobileBuild ? (0.25f + Mathf.Clamp01((num - 5f) / 25f) * 0.25f) : (0.25f + Mathf.Clamp01((num - 5f) / 25f) * 0.75f));
				RenderTexture temporary2 = RenderTexture.GetTemporary((int)((float)source.width * num2), (int)((float)source.height * num2), 0);
				RenderTexture temporary3 = RenderTexture.GetTemporary((int)((float)source.width * num2), (int)((float)source.height * num2), 0);
				temporary2.name = "PartHighlighter2";
				temporary3.name = "PartHighlighter3";
				Material materialOutlineBlurPass = _materialOutlineBlurPass1;
				materialOutlineBlurPass.SetFloat("_BlurTexelSize", temporary2.texelSize.x);
				Graphics.Blit(temporary, temporary2, materialOutlineBlurPass);
				Material materialOutlineBlurPass2 = _materialOutlineBlurPass2;
				materialOutlineBlurPass2.SetTexture("_LastPassTex", temporary2);
				materialOutlineBlurPass2.SetColor("_OutlineColor", OutlineColor.linear);
				materialOutlineBlurPass2.SetFloat("_BlurTexelSize", temporary2.texelSize.y);
				Graphics.Blit(temporary, temporary3, materialOutlineBlurPass2);
				RenderTexture.ReleaseTemporary(temporary2);
				renderTexture = temporary3;
			}
			Material materialCombine = _materialCombine;
			materialCombine.SetTexture("_MaskTex", temporary);
			materialCombine.SetTexture("_OutlineTex", renderTexture);
			materialCombine.SetColor("_HighlightColor", HighlightColor.linear);
			Graphics.Blit(source, destination, materialCombine);
			RenderTexture.ReleaseTemporary(renderTexture);
			RenderTexture.ReleaseTemporary(temporary);
			foreach (IPartScript highlightedPart2 in _highlightedParts)
			{
				foreach (IRendererMaterialMap rendererMap4 in highlightedPart2.PartMaterialScript.RendererMaps)
				{
					if (!rendererMap4.IsTMProRenderer)
					{
						rendererMap4.EndTempRender();
					}
				}
			}
			if (Game.InFlightScene)
			{
				foreach (PartGroupScript item3 in tempPartGroupList)
				{
					item3.PartGroupRenderer?.EndTempRender();
					foreach (IPartScript outlinedPart4 in item3.OutlinedParts)
					{
						foreach (IRendererMaterialMap rendererMap5 in outlinedPart4.PartMaterialScript.RendererMaps)
						{
							if (!rendererMap5.IsTMProRenderer)
							{
								rendererMap5.EndTempRender();
							}
						}
					}
				}
				tempPartGroupList.Clear();
				return;
			}
			foreach (IPartScript outlinedPart5 in _outlinedParts)
			{
				foreach (IRendererMaterialMap rendererMap6 in outlinedPart5.PartMaterialScript.RendererMaps)
				{
					if (!rendererMap6.IsTMProRenderer)
					{
						rendererMap6.EndTempRender();
					}
				}
			}
		}

		protected virtual void Start()
		{
			_mainCamera = GetComponent<Camera>();
			_partSelectionCamera = new GameObject("PartSelectionCamera").AddComponent<Camera>();
			_partSelectionCamera.transform.SetParent(base.transform, worldPositionStays: false);
			_partSelectionCamera.enabled = false;
			_materialHighlightMask = new Material(_shaderHighlightMask);
			_materialOutlineMask = new Material(_shaderOutlineMask);
			_materialOutlineBlurPass1 = new Material(_shaderOutlineBlurPass1);
			_materialOutlineBlurPass2 = new Material(_shaderOutlineBlurPass2);
			_materialCombine = new Material(_shaderCombine);
			UpdateEnabledState();
		}

		private void UpdateEnabledState()
		{
			base.enabled = _highlightedParts.Count > 0 || _outlinedParts.Count > 0;
		}
	}
}
