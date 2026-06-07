using System;
using System.Collections.Generic;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	public class CanvasController : ACanvasController<CanvasController.ElementType>
	{
		[Flags]
		public enum ElementType
		{
			None = 0,
			PauseMenu = 1,
			Inventory = 2,
			Notification = 4,
			Popup = 8,
			Crosshair = 0x10,
			FastTravel = 0x20,
			MouseMode = 0x40,
			LocoContextMenu = 0x80,
			ExternalCamera = 0x100,
			Hotbar = 0x200,
			HUD = 0x400,
			TurntableContextMenu = 0x800,
			TopHUDMount = 0x1000,
			BedSleeping = 0x2000,
			PopupNoPause = 0x4000,
			Blockers = 0x602B
		}

		public enum PreferencesExclusivity
		{
			Any = 0,
			NonVR = 1,
			VR = 2
		}

		public GameObject pauseMenu;

		public GameObject inventory;

		public GameObject crosshair;

		public GameObject fastTravel;

		public GameObject locoContextMenu;

		public GameObject turntableContextMenu;

		public GameObject topHUDMount;

		public GameObject bedSleeping;

		public GameObject notificationManager;

		protected override void Awake()
		{
			base.Awake();
			base.PopupManager.TryOpenPopupCallback = (Popup popup) => TrySetState(popup.pauseOnOpen ? ElementType.Popup : ElementType.PopupNoPause, on: true);
			base.PopupManager.PopupChanged += delegate(Popup popup)
			{
				if (popup == null)
				{
					TrySetState(ElementType.Popup, on: false);
					TrySetState(ElementType.PopupNoPause, on: false);
				}
			};
			base.NotificationManager.NotificationCountUpdated += delegate(int count)
			{
				TrySetState(ElementType.Notification, count != 0);
			};
		}

		public override Element[] GetElements()
		{
			List<Element> elements = new List<Element>();
			NewElement(ElementType.PauseMenu, PreferencesExclusivity.Any).Ensure(ElementType.MouseMode, false, DependencyType.OverrideValue, true, true).Ensure(ElementType.Inventory, false, DependencyType.ChangeDefaultValue, true, true).Ensure(ElementType.Crosshair, false, DependencyType.OverrideValue, true, true)
				.Ensure(ElementType.TopHUDMount, false, DependencyType.OverrideValue, true, true)
				.Ensure(ElementType.HUD, false, DependencyType.OverrideValue, true, true)
				.RequirePointer()
				.RequirePreload()
				.RequirePause()
				.RequireVRRepositioning()
				.SetReference(pauseMenu);
			NewElement(ElementType.Inventory, PreferencesExclusivity.Any).Ensure(ElementType.MouseMode, false, DependencyType.OverrideValue, true, true).Ensure(ElementType.Crosshair, false, DependencyType.OverrideValue, true, true).RequirePointer()
				.RequirePreload()
				.RequireVRRepositioning()
				.SetReference(inventory);
			NewElement(ElementType.ExternalCamera, PreferencesExclusivity.Any).Ensure(ElementType.Inventory, false, DependencyType.OverrideValue, true, true).Ensure(ElementType.Crosshair, false, DependencyType.OverrideValue, true, true);
			NewElement(ElementType.MouseMode, PreferencesExclusivity.Any).Ensure(ElementType.HUD, false, DependencyType.OverrideValue, false, !provider.IsVR()).Ensure(ElementType.Crosshair, false, DependencyType.OverrideValue, true, true).RequirePointer(provider.IsVR());
			NewElement(ElementType.LocoContextMenu, PreferencesExclusivity.Any).Ensure(ElementType.ExternalCamera, true, DependencyType.OnlyCheck, true, true).SetReference(locoContextMenu);
			NewElement(ElementType.TurntableContextMenu, PreferencesExclusivity.Any).SetReference(turntableContextMenu);
			NewElement(ElementType.Crosshair, PreferencesExclusivity.Any).SetReference(crosshair);
			NewElement(ElementType.Hotbar, PreferencesExclusivity.NonVR).Ensure(ElementType.Crosshair, false, DependencyType.OverrideValue, true, true).Ensure(ElementType.MouseMode, false, DependencyType.OverrideValue, true, true);
			NewElement(ElementType.Popup, PreferencesExclusivity.Any).Ensure(ElementType.MouseMode, false, DependencyType.OverrideValue, true, true).Ensure(ElementType.Crosshair, false, DependencyType.OverrideValue, true, true).Ensure(ElementType.Inventory, false, DependencyType.OverrideValue, true, true)
				.Ensure(ElementType.PauseMenu, false, DependencyType.MaintainValue, true, true)
				.Ensure(ElementType.Notification, false, DependencyType.OverrideValue, true, true)
				.RequireVRRepositioning()
				.RequirePause()
				.RequirePointer()
				.SetReference(base.PopupManager.gameObject);
			NewElement(ElementType.PopupNoPause, PreferencesExclusivity.Any).Ensure(ElementType.MouseMode, false, DependencyType.OverrideValue, true, true).Ensure(ElementType.Crosshair, false, DependencyType.OverrideValue, true, true).Ensure(ElementType.Inventory, false, DependencyType.OverrideValue, true, true)
				.Ensure(ElementType.PauseMenu, false, DependencyType.MaintainValue, true, true)
				.Ensure(ElementType.Notification, false, DependencyType.OverrideValue, true, true)
				.RequireVRRepositioning()
				.RequirePointer()
				.SetReference(base.PopupManager.gameObject);
			NewElement(ElementType.FastTravel, PreferencesExclusivity.Any).Ensure(ElementType.MouseMode, false, DependencyType.OverrideValue, true, true).Ensure(ElementType.Crosshair, false, DependencyType.OverrideValue, true, true).Ensure(ElementType.Inventory, false, DependencyType.OverrideValue, true, true)
				.Ensure(ElementType.PauseMenu, false, DependencyType.OnlyCheck, true, true)
				.RequirePointer()
				.RequirePreload()
				.RequireVRRepositioning()
				.SetReference(fastTravel);
			NewElement(ElementType.BedSleeping, PreferencesExclusivity.Any).Ensure(ElementType.MouseMode, false, DependencyType.OverrideValue, true, true).Ensure(ElementType.Crosshair, false, DependencyType.OverrideValue, true, true).Ensure(ElementType.Inventory, false, DependencyType.OverrideValue, true, true)
				.Ensure(ElementType.PauseMenu, false, DependencyType.OnlyCheck, true, true)
				.RequirePointer()
				.RequirePreload()
				.RequireVRRepositioning()
				.SetReference(bedSleeping);
			NewElement(ElementType.HUD, PreferencesExclusivity.Any).SetReference(Placeholder("HUD"));
			NewElement(ElementType.TopHUDMount, PreferencesExclusivity.Any).SetReference(topHUDMount);
			NewElement(ElementType.Notification, PreferencesExclusivity.Any).SetReference(notificationManager);
			return elements.ToArray();
			Element NewElement(ElementType type, PreferencesExclusivity exc)
			{
				Element element = new Element(type);
				if (exc == PreferencesExclusivity.Any || exc == PreferencesExclusivity.VR == provider.IsVR())
				{
					elements.Add(element);
				}
				return element;
			}
		}

		private GameObject Placeholder(string name)
		{
			GameObject obj = new GameObject("[Canvas Controller " + name + " Placeholder]");
			obj.transform.SetParent(base.transform);
			obj.SetActive(value: false);
			return obj;
		}
	}
}
