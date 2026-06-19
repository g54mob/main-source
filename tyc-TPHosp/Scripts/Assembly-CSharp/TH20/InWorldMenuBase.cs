using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class InWorldMenuBase : AnimatedMenuBase
	{
		[SerializeField]
		protected float _menuYOffset = 3f;

		[SerializeField]
		protected GraphicRaycaster _graphicRaycaster;

		[SerializeField]
		private InWorldHUDElement _inWorldHUDElement;

		private Level _level;

		private static float MenuDepthBias = 100f;

		public Level Level => _level;

		protected virtual void Setup(Level level)
		{
			_level = level;
			if (_inWorldHUDElement != null)
			{
				_inWorldHUDElement.Position = GetMenuPosition();
				_inWorldHUDElement.DepthBias = MenuDepthBias;
				_level.HUD.AddElement(_inWorldHUDElement);
			}
			if (_graphicRaycaster != null)
			{
				_level.InputManager.AddGraphicRayCaster(_graphicRaycaster);
			}
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Combine(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpen));
			OpenMenu();
		}

		public override void Destroy()
		{
			if (_inWorldHUDElement != null)
			{
				_level.HUD.RemoveElement(_inWorldHUDElement);
			}
			if (_graphicRaycaster != null)
			{
				_level.InputManager.RemoveGraphicRayCaster(_graphicRaycaster);
			}
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Remove(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpen));
		}

		protected override void Update()
		{
			base.Update();
			if (!IsClosing() && _inWorldHUDElement != null)
			{
				_inWorldHUDElement.Position = GetMenuPosition();
			}
		}

		protected abstract Vector3 GetMenuPosition();

		protected virtual void OnMenuOpen(MenuBase menu)
		{
			CloseMenu();
		}
	}
}
