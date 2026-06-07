using System;
using System.Collections.Generic;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class TabletopHUDPopup : HUDPopup
	{
		[Header("Tabletop Modules")]
		[SerializeField]
		private EnumValues<ETabletopHUDPopupModuleType, TabletopHUDPopupModule> m_tabletopModules;

		public ETabletopHUDPopupModuleType CurrentTabletopModule { get; private set; }

		protected override void OnEnable()
		{
			base.OnEnable();
			foreach (var (_, tabletopHUDPopupModule2) in m_tabletopModules)
			{
				tabletopHUDPopupModule2.Closing += base.CloseModule;
				tabletopHUDPopupModule2.Validated += OnModuleValidated;
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			foreach (var (_, tabletopHUDPopupModule2) in m_tabletopModules)
			{
				tabletopHUDPopupModule2.Closing -= base.CloseModule;
				tabletopHUDPopupModule2.Validated -= OnModuleValidated;
			}
		}

		public void Open(ETabletopHUDPopupModuleType type)
		{
			m_moduleOpened = null;
			TabletopHUDPopupModule module = m_tabletopModules[type];
			CurrentTabletopModule = type;
			OpenModule(module);
		}

		public void Open(ETabletopHUDPopupModuleType type, Action<HUDPopupModule> callback)
		{
			m_moduleOpened = callback;
			TabletopHUDPopupModule module = m_tabletopModules[type];
			CurrentTabletopModule = type;
			OpenModule(module);
		}

		protected override void OpenModule(HUDPopupModule module)
		{
			if (module.Type != EHUDPopupModuleType.SPECIFIC)
			{
				CurrentTabletopModule = ETabletopHUDPopupModuleType.NONE;
			}
			base.OpenModule(module);
		}

		public bool GetModule<T>(ETabletopHUDPopupModuleType type, out T module) where T : TabletopHUDPopupModule
		{
			if (m_tabletopModules[type] is T val)
			{
				module = val;
				return true;
			}
			module = null;
			return false;
		}
	}
}
