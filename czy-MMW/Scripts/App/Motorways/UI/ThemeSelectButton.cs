using Motorways.Themes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Motorways.UI
{
	[RequireComponent(typeof(Animator))]
	public class ThemeSelectButton : TouchButton
	{
		private Animator _animator;

		public MotorwaysThemePreference buttonTheme;

		public Image themeColorPreviewImage;

		[SerializeField]
		private ThemeTypeToggler _themeToggler;

		public MapButton mapButton { get; set; }

		protected override void Awake()
		{
			_animator = GetComponent<Animator>();
		}

		public void SetSelectorAlpha(float alpha)
		{
			Color color = _themeToggler.GetComponent<Image>().color;
			color.a = alpha;
			_themeToggler.GetComponent<Image>().color = color;
		}

		public void OnSelected()
		{
			mapButton.SetThemePreference(buttonTheme);
		}

		public void OnClicked()
		{
			mapButton.SetThemePreference(buttonTheme);
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			mapButton.EnsureThemeButtonSelectedState();
		}

		public void SetUnselected()
		{
			_themeToggler.SetSelectedTheme(isFirstSelected: true);
		}

		public void SetSelected()
		{
			_themeToggler.SetSelectedTheme(isFirstSelected: false);
		}

		public void SetHighlighted()
		{
		}

		private void Update()
		{
		}
	}
}
