using CTS.Core;
using CTS.ScriptableSettings;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class SwapMaterialWithBoolSetting : CTSBehaviour
	{
		[SerializeField]
		private SettingObject<bool> _setting;

		[SerializeField]
		private ScriptableAddressable _falseMaterial;

		[SerializeField]
		private ScriptableAddressable _trueMaterial;

		[SerializeField]
		private Renderer _renderer;

		private bool IsSettingEnabled()
		{
			return _setting?.GetValue() ?? false;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_setting.ValueChanged += OnSettingChanged;
			Repaint();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_setting.ValueChanged -= OnSettingChanged;
		}

		private void OnSettingChanged(bool obj)
		{
			Repaint();
		}

		public void Repaint()
		{
			RepaintAsset(IsSettingEnabled() ? _trueMaterial : _falseMaterial);
			void RepaintAsset(ScriptableAddressable assetReference)
			{
				_renderer.sharedMaterial = assetReference.Load<Material>();
			}
		}
	}
}
