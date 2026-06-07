using System;
using System.Collections.Generic;
using Coffee.UIEffectInternal;
using UnityEngine;

namespace Coffee.UIEffects
{
	public class UIEffectProjectSettings : PreloadedProjectSettings<UIEffectProjectSettings>
	{
		[Header("Setting")]
		[SerializeField]
		internal List<UIEffect> m_RuntimePresets;

		[SerializeField]
		internal List<UIEffectPreset> m_RuntimePresetsV2;

		[Header("Editor")]
		[Tooltip("Use HDR color pickers on color fields.")]
		[SerializeField]
		private bool m_UseHDRColorPicker;

		[HideInInspector]
		[SerializeField]
		internal ShaderVariantCollection m_ShaderVariantCollection;

		[HideInInspector]
		[SerializeField]
		private ShaderVariantRegistry m_ShaderVariantRegistry;

		public static ShaderVariantRegistry shaderRegistry => null;

		public static ShaderVariantCollection shaderVariantCollection => null;

		public static bool useHdrColorPicker
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static void RegisterRuntimePreset(UIEffectPreset preset)
		{
		}

		[Obsolete("LoadRuntimePreset is obsolete. Use LoadPreset instead.", false)]
		public static UIEffect LoadRuntimePreset(string presetName)
		{
			return null;
		}

		public static UnityEngine.Object LoadPreset(string presetName)
		{
			return null;
		}
	}
}
