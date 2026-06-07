using System;
using System.Collections.Generic;
using Dhs5.Utility.Updates;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class HUDPopup : WorldManager, ICancelInputReceiver
	{
		[Header("HUD Popup")]
		[SerializeField]
		private Canvas m_canvas;

		[SerializeField]
		private GraphicRaycaster m_graphicRaycaster;

		[Header("Modules")]
		[SerializeField]
		private EnumValues<EHUDPopupModuleType, HUDPopupModule> m_modules;

		[SerializeField]
		private ObjectActivator m_objectActivator;

		protected HUDPopupModule m_currentModule;

		protected InputManager.EMap m_previousMap;

		protected HUDPopupModule m_moduleToOpen;

		protected Action<HUDPopupModule> m_moduleOpened;

		protected bool m_levelUpQueued;

		public bool IsActive { get; private set; }

		public static event Action<bool> ActiveStateChanged;

		public static event Action<EHUDPopupModuleType> ModuleValidated;

		protected override void OnEnable()
		{
			base.OnEnable();
			SetActive(active: false);
			foreach (var (_, hUDPopupModule2) in m_modules)
			{
				hUDPopupModule2.Closing += CloseModule;
				hUDPopupModule2.Validated += OnModuleValidated;
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			foreach (var (_, hUDPopupModule2) in m_modules)
			{
				hUDPopupModule2.Closing -= CloseModule;
				hUDPopupModule2.Validated -= OnModuleValidated;
			}
		}

		protected void SetActive(bool active)
		{
			if (IsActive != active)
			{
				IsActive = active;
				m_canvas.enabled = active;
				m_graphicRaycaster.enabled = active;
				CanvasManager.SetMainCanvas(m_canvas);
				if (IsActive)
				{
					OnSetActive();
				}
				else
				{
					OnSetInactive();
				}
				HUDPopup.ActiveStateChanged?.Invoke(IsActive);
			}
		}

		protected virtual void OnSetActive()
		{
			ICancelInputReceiver.Stack(this);
			TransientManager<InputManager>.Instance.SetMap(InputManager.EMap.UI);
		}

		protected virtual void OnSetInactive()
		{
			ICancelInputReceiver.PopCurrent();
			TransientManager<InputManager>.Instance.SetMap(m_previousMap);
		}

		public void Open(EHUDPopupModuleType type)
		{
			m_moduleOpened = null;
			HUDPopupModule module = m_modules[type];
			OpenModule(module);
		}

		public void Open(EHUDPopupModuleType type, Action<HUDPopupModule> callback)
		{
			m_moduleOpened = callback;
			HUDPopupModule module = m_modules[type];
			OpenModule(module);
		}

		protected virtual void OpenModule(HUDPopupModule module)
		{
			m_currentModule = module;
			m_previousMap = ((!module.StackInputMap) ? InputManager.EMap.PLAYER : TransientManager<InputManager>.Instance.CurrentMap);
			SetActive(active: true);
			World.PlayerController.Hud.SetActive(!module.HideHUD);
			PrepareActivateModule(module);
		}

		protected void PrepareActivateModule(HUDPopupModule module)
		{
			m_moduleToOpen = module;
			Updater.CallInXFrames(1, ActivateModuleToOpen, out var _);
		}

		private void ActivateModuleToOpen()
		{
			if (m_moduleToOpen != null)
			{
				m_objectActivator.Activate(m_moduleToOpen);
				m_moduleOpened?.Invoke(m_moduleToOpen);
				m_moduleToOpen = null;
				if (!IsActive)
				{
					CloseModule();
				}
			}
		}

		public void CloseModule()
		{
			World.PlayerController.Hud.SetActive(active: true);
			m_objectActivator.DeactivateCurrent();
			SetActive(active: false);
			CheckLevelUpQueue();
		}

		public void QueueLevelUp()
		{
			if (!m_levelUpQueued)
			{
				if (IsActive)
				{
					m_levelUpQueued = true;
					return;
				}
				m_levelUpQueued = false;
				Open(EHUDPopupModuleType.LEVEL_UP);
			}
		}

		protected void CheckLevelUpQueue()
		{
			if (m_levelUpQueued)
			{
				Open(EHUDPopupModuleType.LEVEL_UP);
				m_levelUpQueued = false;
			}
		}

		protected virtual void OnModuleValidated(HUDPopupModule module)
		{
			HUDPopup.ModuleValidated?.Invoke(module.Type);
			CloseModule();
		}

		public void OnCancel()
		{
			if (m_currentModule != null)
			{
				if (m_currentModule.OverrideCancel())
				{
					m_currentModule.Cancel();
				}
				else
				{
					CloseModule();
				}
			}
		}

		public bool GetModule<T>(EHUDPopupModuleType type, out T module) where T : HUDPopupModule
		{
			if (m_modules[type] is T val)
			{
				module = val;
				return true;
			}
			module = null;
			return false;
		}
	}
}
