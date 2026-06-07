using Client;
using UnityEngine;

namespace Motorways.Themes
{
	[RequireComponent(typeof(ThemedComponent))]
	public class ThemeTypeToggler : MonoBehaviour, IThemeComponent
	{
		private bool _isFirstColorSelected = true;

		[StringEnumSearch(typeof(ThemedMaterialType))]
		public string firstType;

		[StringEnumSearch(typeof(ThemedMaterialType))]
		public string secondType;

		private ThemedMaterialType _firstMaterialType;

		private ThemedMaterialType _secondMaterialType;

		private ThemedComponent _componentToChange;

		private ITheme _currentTheme;

		public ThemedMaterialType FirstMaterialType
		{
			get
			{
				if (_firstMaterialType.ToString() != firstType && !Diagnostics.Verify(firstType.TryParse(out _firstMaterialType), "{0} isn't a valid ThemedMaterialType!", firstType))
				{
					return ThemedMaterialType.Land;
				}
				return _firstMaterialType;
			}
		}

		public ThemedMaterialType SecondMaterialType
		{
			get
			{
				if (_secondMaterialType.ToString() != secondType && !Diagnostics.Verify(secondType.TryParse(out _secondMaterialType), "{0} isn't a valid ThemedMaterialType!", secondType))
				{
					return ThemedMaterialType.Land;
				}
				return _secondMaterialType;
			}
		}

		public void SetSelectedTheme(bool isFirstSelected)
		{
			_isFirstColorSelected = isFirstSelected;
			_componentToChange.MaterialType = (_isFirstColorSelected ? FirstMaterialType : SecondMaterialType);
			if (_currentTheme != null)
			{
				_componentToChange.ApplyTheme(_currentTheme);
			}
		}

		private void Awake()
		{
			_componentToChange = GetComponent<ThemedComponent>();
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			ApplyTheme(newTheme);
			return ThemeBlendingResult.StopBlending;
		}

		public void ApplyTheme(ITheme theme)
		{
			_currentTheme = theme;
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
		}
	}
}
