using UnityEngine;

namespace TH20
{
	public class LevelHUD : HUD
	{
		private readonly Level _level;

		private bool _iconsAreHidden;

		public LevelHUD(RectTransform menusTransform, RectTransform inWorldTransform, Config config, InputManager inputManager, Level level, bool destroyChildren = true)
			: base(menusTransform, inWorldTransform, config, level.HUDEvents, inputManager, level, destroyChildren)
		{
			_level = level;
		}

		public override void Update()
		{
			base.Update();
			bool button = _level.InputManager.GetButton(33);
			if (!button && _iconsAreHidden)
			{
				SetInWorldElementsVisible(visible: true);
				SetCharacterStatusIconsVisible(visible: true);
			}
			else if (button)
			{
				SetInWorldElementsVisible(visible: false);
				SetCharacterStatusIconsVisible(visible: false);
			}
			_iconsAreHidden = button;
		}

		private void SetInWorldElementsVisible(bool visible)
		{
			foreach (InWorldHUDElement element in _elements)
			{
				if (element.CanBeHidden)
				{
					GameObjectUtils.SetActive(element.gameObject, visible);
				}
			}
		}

		private void SetCharacterStatusIconsVisible(bool visible)
		{
			foreach (Character allCharacter in _level.CharacterManager.AllCharacters)
			{
				allCharacter.GetComponent<SirenCharacterComponent>()?.SetVisible(visible);
			}
		}
	}
}
