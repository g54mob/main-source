using Data.Lighting;
using Data.Variables;
using UnityEngine;

namespace Logic.Lighting
{
	public class DarkModeManager : MonoBehaviour
	{
		[SerializeField]
		private MainMaterialsConfig _defaultMaterialConfig;

		[SerializeField]
		private MainMaterialsConfig _darkModeMaterialConfig;

		[SerializeField]
		private BoolVariableSO _darkModeIsActive;

		[SerializeField]
		private bool _isStartScreen;

		private void OnEnable()
		{
			if (_isStartScreen)
			{
				OnDarkModeChanged(darkModeActive: false);
				return;
			}
			OnDarkModeChanged(_darkModeIsActive.Value);
			_darkModeIsActive.ValueChanged += OnDarkModeChanged;
		}

		private void OnDisable()
		{
			_darkModeIsActive.ValueChanged -= OnDarkModeChanged;
		}

		private void OnDarkModeChanged(bool darkModeActive)
		{
			if (darkModeActive)
			{
				_darkModeMaterialConfig.ApplyConfig();
			}
			else
			{
				_defaultMaterialConfig.ApplyConfig();
			}
		}
	}
}
