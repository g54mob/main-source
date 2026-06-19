using System;
using JetBrains.Annotations;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	[DontSave]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MenuBase : MonoBehaviour
	{
		public enum EDrawOrderSlot
		{
			InWorldElement = 0,
			Default = 1,
			Tooltips = 2,
			NumSlots = 3
		}

		private bool _isClosing;

		private bool _isClosed = true;

		private bool _isCloseButtonRegistered;

		private bool _isFirstOpen = true;

		private HUD _hud;

		[SerializeField]
		private bool _fullScreenMenu;

		[SerializeField]
		private DynamicButton _closeMenuButton;

		[SerializeField]
		private bool _openOnCreate = true;

		[SerializeField]
		private bool _destroyOnClose = true;

		[SerializeField]
		private bool _allowEscapeCloseMenu2;

		[SerializeField]
		private bool _allowOpenPauseMenu2 = true;

		[SerializeField]
		private EDrawOrderSlot _drawOrderSlot = EDrawOrderSlot.Default;

		public bool FullScreenMenu => _fullScreenMenu;

		public bool AllowOpenPauseMenu => _allowOpenPauseMenu2;

		public bool AllowEscapeCloseMenu => _allowEscapeCloseMenu2;

		public EDrawOrderSlot DrawOrderSlot => _drawOrderSlot;

		protected HUD HUD => _hud;

		public Action OnClosed { get; set; }

		protected bool IsFirstOpen()
		{
			return _isFirstOpen;
		}

		public static string GetDrawOrderGameObjectName(EDrawOrderSlot slot)
		{
			return "DrawOrderSlot" + slot;
		}

		protected virtual void Awake()
		{
		}

		public void Initialise(HUD hud)
		{
			_hud = hud;
			if (_openOnCreate)
			{
				OpenMenu();
			}
		}

		public bool IsClosing()
		{
			return _isClosing;
		}

		public bool IsClosed()
		{
			if (!_isClosed)
			{
				return _isFirstOpen;
			}
			return true;
		}

		public virtual void OpenMenu()
		{
			if (_isClosing || _isClosed || _isFirstOpen)
			{
				_hud.HUDEvents.OnMenuOpen.InvokeSafe(this);
			}
			_isClosing = false;
			_isClosed = false;
			_isFirstOpen = false;
			if (_closeMenuButton != null && !_isCloseButtonRegistered)
			{
				_closeMenuButton.onPrimaryDown.AddListener(OnCloseButton);
				_isCloseButtonRegistered = true;
			}
			SetVisible(visible: true);
		}

		public virtual void CloseMenu()
		{
			if (!_isClosing && !_isClosed)
			{
				_isClosing = true;
				_hud.HUDEvents.OnMenuClose.InvokeSafe(this);
			}
			if (_closeMenuButton != null && _isCloseButtonRegistered)
			{
				_closeMenuButton.onPrimaryDown.RemoveListener(OnCloseButton);
				_isCloseButtonRegistered = false;
			}
			if (!base.isActiveAndEnabled)
			{
				CloseInner();
			}
		}

		public void CloseMenuImmediately()
		{
			CloseMenu();
			CloseInner();
		}

		public virtual void TryCloseMenu()
		{
			CloseMenu();
		}

		protected virtual bool HasMenuClosed()
		{
			return true;
		}

		private void OnCloseButton()
		{
			CloseMenu();
		}

		protected virtual void Update()
		{
			if (_isClosing && HasMenuClosed())
			{
				CloseInner();
			}
			if (_isClosing || !_allowEscapeCloseMenu2 || _hud == null || _hud.InputManager == null)
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			Level level = _hud.Level;
			if (level != null)
			{
				if (level.CursorManager.IsModeActive<CursorRoomBuild>() || !_hud.InputManager.GetMouseQuickOnScene(MouseButton.Right))
				{
					flag2 = true;
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				flag2 = true;
			}
			if (flag2 && !_hud.IsMessageBoxOpen && _hud.InputManager.GetKeyDown(KeyCode.Escape))
			{
				flag = true;
			}
			if (flag)
			{
				TryCloseMenu();
			}
		}

		internal void SetVisible(bool visible)
		{
			GameObjectUtils.SetActive(base.gameObject, visible);
		}

		public virtual bool AreTooltipsEnabled()
		{
			if (!_fullScreenMenu)
			{
				return !_hud.IsFullscreenMenuOpen();
			}
			return true;
		}

		private void CloseInner()
		{
			_isClosed = true;
			if (_destroyOnClose)
			{
				_hud.DestroyMenu(this);
			}
			else
			{
				SetVisible(visible: false);
			}
		}

		public virtual void Destroy()
		{
		}
	}
}
