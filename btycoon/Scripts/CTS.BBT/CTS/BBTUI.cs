using System;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/UI Singleton")]
	public class BBTUI : ScriptableObject
	{
		private static BBTUI _instance;

		public static BBTUI Instance
		{
			get
			{
				if (!_instance)
				{
					_instance = Resources.Load<BBTUI>("Scriptables/CanvaseIdentificators/BBT Interfaces");
				}
				return _instance;
			}
		}

		[field: SerializeField]
		public StringKey ButtonID_Pause { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_OpenBar { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_GoToBar { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_GoToAgency { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_Stocks { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_StocksMissionBasket { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_Machines { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_FurnitureShop { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_Theme { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_WallVisilibity { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_DestructionTool { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_InteriorTool { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_RoomTypeTool { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_Finances { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_Finances_LoanTab { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_TechTree { get; private set; }

		[field: SerializeField]
		public StringKey ButtonID_WorkerManager { get; private set; }

		[field: SerializeField]
		public StringKey PanelID_PauseMenu { get; private set; }

		[field: SerializeField]
		public StringKey PanelID_Stocks { get; private set; }

		[field: SerializeField]
		public StringKey PanelID_Machines { get; private set; }

		[field: SerializeField]
		public StringKey PanelID_FurnitureShop { get; private set; }

		[field: SerializeField]
		public StringKey PanelID_Themes { get; private set; }

		[field: SerializeField]
		public StringKey PanelID_RoomTypeTool { get; private set; }

		[field: SerializeField]
		public StringKey PanelID_Finances { get; private set; }

		[field: SerializeField]
		public StringKey PanelID_TechTree { get; private set; }

		[field: SerializeField]
		public StringKey PanelID_WorkerManager { get; private set; }

		[field: SerializeField]
		public StringKey PanelID_Profiles { get; private set; }

		[field: SerializeField]
		public StringKey PanelID_Difficulty { get; private set; }

		private void Awake()
		{
			_instance = this;
		}

		public static void SetupButtonLock(StringKey key, LockToggle toggle, bool doLock)
		{
			SetupLock(toggle, doLock, GetSelectable(key));
		}

		public static void SetupCanvasLock(StringKey key, LockToggle toggle, bool doLock)
		{
			SetupLock(toggle, doLock, GetCanvas(key));
		}

		public static CanvasGroupController GetCanvas(StringKey key)
		{
			if (MonoSingleton<CanvasGroupManager>.Instance.TryGet(key, out var controller))
			{
				return controller;
			}
			return null;
		}

		public static ISelectable GetSelectable(StringKey key)
		{
			if (CTSSelectable.TryGet(key, out var controller))
			{
				return controller;
			}
			return null;
		}

		private static void SetupLock(LockToggle toggle, bool doLock, ILockable lockable)
		{
			if (lockable.EqualsNull())
			{
				throw new NullReferenceException("No object found");
			}
			toggle.Add(lockable);
			if (doLock)
			{
				toggle.Lock();
			}
		}

		public void OpenCanvas(StringKey key)
		{
			if (MonoSingleton<CanvasGroupManager>.Instance.TryGet(key, out var controller))
			{
				controller.QuickShow();
			}
		}

		public void OpenCanvas(ScriptableStringKey key)
		{
			OpenCanvas((StringKey)key);
		}

		public void CloseCanvas(StringKey key)
		{
			if (MonoSingleton<CanvasGroupManager>.Instance.TryGet(key, out var controller))
			{
				controller.QuickHide();
			}
		}

		public void CloseCanvas(ScriptableStringKey key)
		{
			CloseCanvas((StringKey)key);
		}
	}
}
