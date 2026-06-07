using System;
using System.Collections.Generic;
using Coffee.UISoftMaskInternal;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace Coffee.UISoftMask
{
	internal static class SoftMaskUtils
	{
		public static readonly ObjectPool<CommandBuffer> commandBufferPool = new ObjectPool<CommandBuffer>(() => new CommandBuffer(), (CommandBuffer x) => x != null, delegate(CommandBuffer x)
		{
			x.Clear();
		});

		public static readonly ObjectPool<MaterialPropertyBlock> materialPropertyBlockPool = new ObjectPool<MaterialPropertyBlock>(() => new MaterialPropertyBlock(), (MaterialPropertyBlock x) => x != null, delegate(MaterialPropertyBlock x)
		{
			x.Clear();
		});

		private static Material s_SoftMaskingMaterialAdd;

		private static Material s_SoftMaskingMaterialSub;

		private static readonly int s_SoftMaskableStereo = Shader.PropertyToID("_SoftMaskableStereo");

		private static readonly int s_SoftMaskableEnable = Shader.PropertyToID("_SoftMaskableEnable");

		private static readonly int s_SoftMaskOutsideColor = Shader.PropertyToID("_SoftMaskOutsideColor");

		private static readonly int s_SoftMaskTex = Shader.PropertyToID("_SoftMaskTex");

		private static readonly int s_SoftMaskColor = Shader.PropertyToID("_SoftMaskColor");

		private static readonly int s_MainTex = Shader.PropertyToID("_MainTex");

		private static readonly int s_ColorMask = Shader.PropertyToID("_ColorMask");

		private static readonly int s_BlendOp = Shader.PropertyToID("_BlendOp");

		private static readonly int s_StencilReadMask = Shader.PropertyToID("_StencilReadMask");

		private static readonly int s_ThresholdMin = Shader.PropertyToID("_ThresholdMin");

		private static readonly int s_ThresholdMax = Shader.PropertyToID("_ThresholdMax");

		private static readonly string[] s_SoftMaskableShaderNameFormats = new string[3] { "{0}", "Hidden/{0} (SoftMaskable)", "{0} (SoftMaskable)" };

		private static readonly Dictionary<int, string> s_SoftMaskableShaderNames = new Dictionary<int, string>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeOnLoadMethod()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(delegate(UnityEngine.Object obj)
			{
				if (obj is TextMeshProUGUI textMeshProUGUI)
				{
					MaskingShape component2;
					if (textMeshProUGUI.TryGetComponent<SoftMask>(out var component))
					{
						UpdateSubMeshUI(textMeshProUGUI, component.showMaskGraphic, component.antiAliasingThreshold, component.softnessRange);
					}
					else if (textMeshProUGUI.TryGetComponent<MaskingShape>(out component2))
					{
						UpdateSubMeshUI(textMeshProUGUI, component2.showMaskGraphic, component2.antiAliasingThreshold, component2.softnessRange);
					}
				}
			});
		}

		private static void UpdateSubMeshUI(TextMeshProUGUI text, bool show, float aa, MinMax01 softness)
		{
			List<TMP_SubMeshUI> toRelease = ListPool<TMP_SubMeshUI>.Rent();
			text.GetComponentsInChildren(toRelease, 1);
			for (int i = 0; i < toRelease.Count; i++)
			{
				MaskingShape orAddComponent = toRelease[i].GetOrAddComponent<MaskingShape>();
				orAddComponent.hideFlags = UISoftMaskProjectSettings.hideFlagsForTemp;
				orAddComponent.antiAliasingThreshold = aa;
				orAddComponent.softnessRange = softness;
				orAddComponent.showMaskGraphic = show;
			}
			ListPool<TMP_SubMeshUI>.Return(ref toRelease);
		}

		public static void ApplyMaterialPropertyBlock(MaterialPropertyBlock mpb, int depth, Texture texture, MinMax01 threshold, float alpha)
		{
			Vector4 zero = Vector4.zero;
			zero[depth] = alpha;
			mpb.SetVector(s_ColorMask, zero);
			mpb.SetTexture(s_MainTex, texture ? texture : null);
			mpb.SetFloat(s_ThresholdMin, threshold.min);
			mpb.SetFloat(s_ThresholdMax, threshold.max);
		}

		public static Material GetSoftMaskingMaterial(MaskingShape.MaskingMethod method)
		{
			if (method != MaskingShape.MaskingMethod.Additive)
			{
				return GetSoftMaskingMaterial(ref s_SoftMaskingMaterialSub, BlendOp.ReverseSubtract);
			}
			return GetSoftMaskingMaterial(ref s_SoftMaskingMaterialAdd, BlendOp.Add);
		}

		private static Material GetSoftMaskingMaterial(ref Material mat, BlendOp op)
		{
			if ((bool)mat)
			{
				return mat;
			}
			mat = new Material(Shader.Find("Hidden/UI/SoftMask"))
			{
				hideFlags = (HideFlags.DontSave | HideFlags.NotEditable)
			};
			mat.SetInt(s_BlendOp, (int)op);
			return mat;
		}

		public static Material CreateSoftMaskable(Material baseMat, Texture softMaskBuffer, int softMaskDepth, int stencilBits, bool isStereo, UISoftMaskProjectSettings.FallbackBehavior fallbackBehavior)
		{
			Material material = new Material(baseMat);
			material.shader = GetSoftMaskableShader(baseMat.shader, fallbackBehavior);
			material.hideFlags = HideFlags.HideAndDontSave;
			material.SetTexture(s_SoftMaskTex, softMaskBuffer);
			material.SetInt(s_SoftMaskableStereo, isStereo ? 1 : 0);
			material.SetInt(s_SoftMaskableEnable, 1);
			material.SetInt(s_StencilReadMask, stencilBits);
			material.SetVector(s_SoftMaskColor, new Vector4((0 <= softMaskDepth) ? 1 : 0, (1 <= softMaskDepth) ? 1 : 0, (2 <= softMaskDepth) ? 1 : 0, (3 <= softMaskDepth) ? 1 : 0));
			return material;
		}

		public static Shader GetSoftMaskableShader(Shader baseShader, UISoftMaskProjectSettings.FallbackBehavior fallback)
		{
			int instanceID = baseShader.GetInstanceID();
			if (s_SoftMaskableShaderNames.TryGetValue(instanceID, out var value))
			{
				return Shader.Find(value);
			}
			value = baseShader.name;
			for (int i = 0; i < s_SoftMaskableShaderNameFormats.Length; i++)
			{
				string text = string.Format(s_SoftMaskableShaderNameFormats[i], value);
				if (text.EndsWith(" (SoftMaskable)", StringComparison.Ordinal))
				{
					Shader shader = Shader.Find(text);
					if ((bool)shader)
					{
						s_SoftMaskableShaderNames.Add(instanceID, text);
						return shader;
					}
				}
			}
			switch (fallback)
			{
			case UISoftMaskProjectSettings.FallbackBehavior.DefaultSoftMaskable:
				s_SoftMaskableShaderNames.Add(instanceID, "Hidden/UI/Default (SoftMaskable)");
				return Shader.Find("Hidden/UI/Default (SoftMaskable)");
			case UISoftMaskProjectSettings.FallbackBehavior.None:
				s_SoftMaskableShaderNames.Add(instanceID, value);
				return baseShader;
			default:
				throw new ArgumentOutOfRangeException("fallback", fallback, null);
			}
		}
	}
}
