using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Rendering
{
	public static class UniversalRenderPipelineSettings
	{
		private static class UniversalRenderPipelineAssetReflectionFields
		{
			public static FieldInfo AdditionalLightShadowsSupported { get; }

			public static PropertyInfo Cascade4Split { get; }

			public static PropertyInfo MainLightShadowmapResolution { get; }

			public static FieldInfo MainLightShadowsSupported { get; }

			static UniversalRenderPipelineAssetReflectionFields()
			{
				Type typeFromHandle = typeof(UniversalRenderPipelineAsset);
				BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
				MainLightShadowsSupported = typeFromHandle.GetField("m_MainLightShadowsSupported", bindingAttr);
				AdditionalLightShadowsSupported = typeFromHandle.GetField("m_AdditionalLightShadowsSupported", bindingAttr);
				Cascade4Split = typeFromHandle.GetProperty("cascade4Split", BindingFlags.Instance | BindingFlags.Public);
				MainLightShadowmapResolution = typeFromHandle.GetProperty("mainLightShadowmapResolution", BindingFlags.Instance | BindingFlags.Public);
			}
		}

		private abstract class UniversalRenderPipelineAssetSetting
		{
			public abstract void RevertToOriginal();
		}

		private class UniversalRenderPipelineAssetSetting<T> : UniversalRenderPipelineAssetSetting
		{
			private class OriginalValue
			{
				public UniversalRenderPipelineAsset Pipeline { get; }

				public T Value { get; }

				public OriginalValue(UniversalRenderPipelineAsset pipeline, T value)
				{
					Pipeline = pipeline;
					Value = value;
				}
			}

			private OriginalValue _originalValue;

			public T Value
			{
				get
				{
					return GetValueFunc(CurrentPipelineAsset);
				}
				set
				{
					SetValue(value);
				}
			}

			protected Func<UniversalRenderPipelineAsset, T> GetValueFunc { get; }

			protected Action<UniversalRenderPipelineAsset, T> SetValueAction { get; }

			public UniversalRenderPipelineAssetSetting(Func<UniversalRenderPipelineAsset, T> getValue, Action<UniversalRenderPipelineAsset, T> setValue)
			{
				GetValueFunc = getValue;
				SetValueAction = setValue;
			}

			public override void RevertToOriginal()
			{
				if (_originalValue != null)
				{
					SetValueAction(_originalValue.Pipeline, _originalValue.Value);
					_originalValue = null;
				}
			}

			private void SetValue(T value)
			{
				UniversalRenderPipelineAsset currentPipelineAsset = CurrentPipelineAsset;
				if (_originalValue == null)
				{
					_originalValue = new OriginalValue(currentPipelineAsset, GetValueFunc(currentPipelineAsset));
				}
				else if (_originalValue.Pipeline != currentPipelineAsset)
				{
					RevertToOriginal();
					_originalValue = new OriginalValue(currentPipelineAsset, GetValueFunc(currentPipelineAsset));
				}
				SetValueAction(currentPipelineAsset, value);
			}
		}

		private static UniversalRenderPipelineAssetSetting<Vector3> _cascade4Split = new UniversalRenderPipelineAssetSetting<Vector3>((UniversalRenderPipelineAsset p) => (Vector3)UniversalRenderPipelineAssetReflectionFields.Cascade4Split.GetValue(p), delegate(UniversalRenderPipelineAsset p, Vector3 v)
		{
			UniversalRenderPipelineAssetReflectionFields.Cascade4Split.SetValue(p, v);
		});

		private static UniversalRenderPipelineAssetSetting<float> _cascadeBorder = new UniversalRenderPipelineAssetSetting<float>((UniversalRenderPipelineAsset p) => p.cascadeBorder, delegate(UniversalRenderPipelineAsset p, float v)
		{
			p.cascadeBorder = v;
		});

		private static UniversalRenderPipelineAssetSetting<int> _mainLightShadowmapResolution = new UniversalRenderPipelineAssetSetting<int>((UniversalRenderPipelineAsset p) => (int)UniversalRenderPipelineAssetReflectionFields.MainLightShadowmapResolution.GetValue(p), delegate(UniversalRenderPipelineAsset p, int v)
		{
			UniversalRenderPipelineAssetReflectionFields.MainLightShadowmapResolution.SetValue(p, v);
		});

		private static UniversalRenderPipelineAssetSetting<int> _msaaSampleCount = new UniversalRenderPipelineAssetSetting<int>((UniversalRenderPipelineAsset p) => p.msaaSampleCount, delegate(UniversalRenderPipelineAsset p, int v)
		{
			p.msaaSampleCount = v;
		});

		private static UniversalRenderPipelineAssetSetting<int> _shadowCascadeCount = new UniversalRenderPipelineAssetSetting<int>((UniversalRenderPipelineAsset p) => p.shadowCascadeCount, delegate(UniversalRenderPipelineAsset p, int v)
		{
			p.shadowCascadeCount = v;
		});

		private static UniversalRenderPipelineAssetSetting<float> _shadowDistance = new UniversalRenderPipelineAssetSetting<float>((UniversalRenderPipelineAsset p) => p.shadowDistance, delegate(UniversalRenderPipelineAsset p, float v)
		{
			p.shadowDistance = v;
		});

		private static UniversalRenderPipelineAssetSetting<bool> _supportsAdditionalLightShadows = new UniversalRenderPipelineAssetSetting<bool>((UniversalRenderPipelineAsset p) => (bool)UniversalRenderPipelineAssetReflectionFields.AdditionalLightShadowsSupported.GetValue(p), delegate(UniversalRenderPipelineAsset p, bool v)
		{
			UniversalRenderPipelineAssetReflectionFields.AdditionalLightShadowsSupported.SetValue(p, v);
		});

		private static UniversalRenderPipelineAssetSetting<bool> _supportsMainLightShadows = new UniversalRenderPipelineAssetSetting<bool>((UniversalRenderPipelineAsset p) => (bool)UniversalRenderPipelineAssetReflectionFields.MainLightShadowsSupported.GetValue(p), delegate(UniversalRenderPipelineAsset p, bool v)
		{
			UniversalRenderPipelineAssetReflectionFields.MainLightShadowsSupported.SetValue(p, v);
		});

		public static Vector3 Cascade4Split
		{
			get
			{
				return _cascade4Split.Value;
			}
			set
			{
				_cascade4Split.Value = value;
			}
		}

		public static float CascadeBorder
		{
			get
			{
				return _cascadeBorder.Value;
			}
			set
			{
				_cascadeBorder.Value = value;
			}
		}

		public static UniversalRenderPipelineAsset CurrentPipelineAsset => GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;

		public static int MainLightShadowmapResolution
		{
			get
			{
				return _mainLightShadowmapResolution.Value;
			}
			set
			{
				_mainLightShadowmapResolution.Value = value;
			}
		}

		public static int MsaaSampleCount
		{
			get
			{
				return _msaaSampleCount.Value;
			}
			set
			{
				_msaaSampleCount.Value = value;
			}
		}

		public static int ShadowCascadeCount
		{
			get
			{
				return _shadowCascadeCount.Value;
			}
			set
			{
				_shadowCascadeCount.Value = value;
			}
		}

		public static float ShadowDistance
		{
			get
			{
				return _shadowDistance.Value;
			}
			set
			{
				_shadowDistance.Value = value;
			}
		}

		public static bool SupportsAdditionalLightShadows
		{
			get
			{
				return _supportsAdditionalLightShadows.Value;
			}
			set
			{
				_supportsAdditionalLightShadows.Value = value;
			}
		}

		public static bool SupportsMainLightShadows
		{
			get
			{
				return _supportsMainLightShadows.Value;
			}
			set
			{
				_supportsMainLightShadows.Value = value;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void Initialize()
		{
			Application.quitting += delegate
			{
				OnUnload(isEditor: false);
			};
			OnLoad(isEditor: false);
		}

		private static void OnLoad(bool isEditor)
		{
		}

		private static void OnUnload(bool isEditor)
		{
			if (isEditor)
			{
				RevertSettingsToOriginalValues();
			}
		}

		private static void RevertSettingsToOriginalValues()
		{
			foreach (UniversalRenderPipelineAssetSetting item in (from x in typeof(UniversalRenderPipelineSettings).GetFields(BindingFlags.Static | BindingFlags.NonPublic)
				where typeof(UniversalRenderPipelineAssetSetting).IsAssignableFrom(x.FieldType)
				select (UniversalRenderPipelineAssetSetting)x.GetValue(null)).ToList())
			{
				item.RevertToOriginal();
			}
		}
	}
}
