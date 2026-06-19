using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityConsole;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[DontSave]
	public class HUD : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class MugshotConfig
		{
			public AdvisorLighting Lighting;

			public Vector3 FocusOffset = new Vector3(0f, 0.08f, 0f);

			public Vector3 CameraOffset = new Vector3(-0.05f, 0.14f, 0.6f);
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public GameObject InWorldMessagePrefab;

			public InWorldMessagesConfig InWorldMessagesConfig;

			public GameObject[] MenuPrefabs;

			public MugshotConfig MugshotConfig;
		}

		private readonly Config _config;

		private readonly HUDEvents _hudEvents;

		private readonly InputManager _inputManager;

		private readonly RectTransform _menusTransform;

		private readonly RectTransform _inWorldTransform;

		protected readonly List<InWorldHUDElement> _elements = new List<InWorldHUDElement>();

		private List<Transform> _drawOrderedMenuTransforms = new List<Transform>();

		private List<MenuBase> _createdMenus = new List<MenuBase>(128);

		private readonly Level _level;

		private int _fullscreenMenuCount;

		private int _preventOpenPauseMenuCount;

		private int _pauseTimeMenuCount;

		private bool _optionsMenuOpen;

		private bool _messageBoxOpen;

		private bool _hudEnabled = true;

		public bool IsPauseTimeMenuOpen => _pauseTimeMenuCount > 0;

		public HUDEvents HUDEvents => _hudEvents;

		public Level Level => _level;

		public InputManager InputManager => _inputManager;

		public bool IsOptionsMenuOpen => _optionsMenuOpen;

		public bool IsMessageBoxOpen => _messageBoxOpen;

		public RectTransform MenusTransform => _menusTransform;

		public RectTransform InWorldTransform => _inWorldTransform;

		public void SetMessageBoxOpenStatus(bool bOpen)
		{
			_messageBoxOpen = bOpen;
		}

		public HUD(RectTransform menusTransform, RectTransform inWorldTransform, Config config, HUDEvents hudEvents, InputManager inputManager, Level level = null, bool destroyChildren = true)
		{
			_config = config;
			_menusTransform = menusTransform;
			_inWorldTransform = inWorldTransform;
			_level = level;
			_hudEvents = hudEvents;
			_inputManager = inputManager;
			if (destroyChildren)
			{
				DestroyAllDrawOrderedMenus();
				GameObjectUtils.DestroyChildrenImmediate(_menusTransform.gameObject);
				GameObjectUtils.DestroyChildrenImmediate(_inWorldTransform.gameObject);
			}
			CreateAllDrawOrderedMenus();
			HUDEvents hudEvents2 = _hudEvents;
			hudEvents2.OnMenuOpen = (Action<MenuBase>)Delegate.Combine(hudEvents2.OnMenuOpen, new Action<MenuBase>(OnMenuOpenInner));
			HUDEvents hudEvents3 = _hudEvents;
			hudEvents3.OnMenuClose = (Action<MenuBase>)Delegate.Combine(hudEvents3.OnMenuClose, new Action<MenuBase>(OnMenuCloseInner));
			HUDEvents hudEvents4 = _hudEvents;
			hudEvents4.OnOptionsMenuOpen = (Action)Delegate.Combine(hudEvents4.OnOptionsMenuOpen, new Action(OnOptionsMenuOpen));
			HUDEvents hudEvents5 = _hudEvents;
			hudEvents5.OnOptionsMenuClose = (Action)Delegate.Combine(hudEvents5.OnOptionsMenuClose, new Action(OnOptionsMenuClose));
			ConsoleCommandsDatabase.RegisterCommand("SetHUDEnabled", "Enables/disables all HUD elements", "SetHUDEnabled [true|false]", Debug_SetHUDEnabled);
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("SetHUDEnabled");
			DestroyAllDrawOrderedMenus();
			MenuBase[] componentsInChildren = _menusTransform.GetComponentsInChildren<MenuBase>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].Destroy();
			}
			GameObjectUtils.DestroyChildrenImmediate(_menusTransform.gameObject);
			HUDEvents hudEvents = _hudEvents;
			hudEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Remove(hudEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpenInner));
			HUDEvents hudEvents2 = _hudEvents;
			hudEvents2.OnMenuClose = (Action<MenuBase>)Delegate.Remove(hudEvents2.OnMenuClose, new Action<MenuBase>(OnMenuCloseInner));
			HUDEvents hudEvents3 = _hudEvents;
			hudEvents3.OnOptionsMenuOpen = (Action)Delegate.Remove(hudEvents3.OnOptionsMenuOpen, new Action(OnOptionsMenuOpen));
			HUDEvents hudEvents4 = _hudEvents;
			hudEvents4.OnOptionsMenuClose = (Action)Delegate.Remove(hudEvents4.OnOptionsMenuClose, new Action(OnOptionsMenuClose));
			base.Destroy();
		}

		private void CreateAllDrawOrderedMenus()
		{
			_drawOrderedMenuTransforms.Clear();
			if (!(_menusTransform != null))
			{
				return;
			}
			int i = 0;
			for (int num = 3; i < num; i++)
			{
				string drawOrderGameObjectName = MenuBase.GetDrawOrderGameObjectName((MenuBase.EDrawOrderSlot)i);
				if (_menusTransform.Find(drawOrderGameObjectName) == null)
				{
					GameObject gameObject = new GameObject();
					gameObject.AddComponent<RectTransform>();
					gameObject.name = drawOrderGameObjectName;
					gameObject.transform.SetParent(_menusTransform, worldPositionStays: true);
					RectTransform obj = gameObject.transform as RectTransform;
					obj.SetAnchor(AnchorPresets.StretchAll);
					obj.pivot = _menusTransform.pivot;
					obj.sizeDelta = _menusTransform.sizeDelta;
					obj.localPosition = _menusTransform.localPosition;
					obj.localRotation = _menusTransform.localRotation;
					obj.localScale = _menusTransform.localScale;
					_drawOrderedMenuTransforms.Add(gameObject.transform);
				}
			}
		}

		private void DestroyAllDrawOrderedMenus()
		{
			int i = 0;
			for (int count = _drawOrderedMenuTransforms.Count; i < count; i++)
			{
				Transform transform = _drawOrderedMenuTransforms[i];
				if (transform != null)
				{
					MenuBase[] componentsInChildren = transform.GetComponentsInChildren<MenuBase>(includeInactive: true);
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						componentsInChildren[j].Destroy();
					}
					GameObjectUtils.DestroyChildrenImmediate(transform.gameObject);
				}
			}
			_drawOrderedMenuTransforms.Clear();
		}

		private ConsoleCommandResult Debug_SetHUDEnabled(params string[] args)
		{
			return ConsoleCommandHelpers.ExtractBool(SetHUDEnabled, args);
		}

		private void SetHUDEnabled(bool enabled)
		{
			CanvasGroup canvasGroup = _menusTransform.gameObject.GetComponent<CanvasGroup>();
			CanvasGroup canvasGroup2 = _inWorldTransform.gameObject.GetComponent<CanvasGroup>();
			if (enabled)
			{
				if (canvasGroup != null)
				{
					canvasGroup.alpha = 1f;
					canvasGroup.interactable = true;
					UnityEngine.Object.Destroy(canvasGroup);
				}
				if (canvasGroup2 != null)
				{
					canvasGroup2.alpha = 1f;
					canvasGroup2.interactable = true;
					UnityEngine.Object.Destroy(canvasGroup2);
				}
			}
			else
			{
				if (canvasGroup == null)
				{
					canvasGroup = _menusTransform.gameObject.AddComponent<CanvasGroup>();
				}
				if (canvasGroup2 == null)
				{
					canvasGroup2 = _inWorldTransform.gameObject.AddComponent<CanvasGroup>();
				}
				if (canvasGroup != null)
				{
					canvasGroup.alpha = 0f;
					canvasGroup.interactable = false;
				}
				if (canvasGroup2 != null)
				{
					canvasGroup2.alpha = 0f;
					canvasGroup2.interactable = false;
				}
			}
			_hudEnabled = enabled;
		}

		public Config GetConfig()
		{
			return _config;
		}

		public virtual void Update()
		{
			Camera main = Camera.main;
			if (main != null)
			{
				Vector3 cameraPosition = main.transform.position;
				_elements.Sort((InWorldHUDElement x, InWorldHUDElement y) => x.Depth(cameraPosition).CompareTo(y.Depth(cameraPosition)));
				for (int num = 0; num < _elements.Count; num++)
				{
					InWorldHUDElement inWorldHUDElement = _elements[num];
					inWorldHUDElement.transform.SetSiblingIndex(num);
					CalculateElementScreenPos(main, inWorldHUDElement);
				}
			}
			if (_inputManager.GetKey(KeyCode.LeftControl) && _inputManager.GetKey(KeyCode.LeftShift) && _inputManager.GetKeyDown(KeyCode.U))
			{
				SetHUDEnabled(!_hudEnabled);
			}
		}

		private static void CalculateElementScreenPos(Camera camera, InWorldHUDElement element)
		{
			Vector3 position = camera.WorldToScreenPoint(element.Position);
			RectTransform clipRect = element.ClipRect;
			if (clipRect != null)
			{
				float num = position.x + (clipRect.rect.xMin + clipRect.anchoredPosition.x) * clipRect.lossyScale.x;
				float num2 = position.x + (clipRect.rect.xMax + clipRect.anchoredPosition.x) * clipRect.lossyScale.x;
				float num3 = position.y + (clipRect.rect.yMin + clipRect.anchoredPosition.y) * clipRect.lossyScale.y;
				float num4 = position.y + (clipRect.rect.yMax + clipRect.anchoredPosition.y) * clipRect.lossyScale.y;
				if (num < 0f)
				{
					position.x += 0f - num;
				}
				if (num3 < 0f)
				{
					position.y += 0f - num3;
				}
				if (num2 >= (float)camera.pixelWidth)
				{
					position.x -= num2 - (float)camera.pixelWidth;
				}
				if (num4 >= (float)camera.pixelHeight)
				{
					position.y -= num4 - (float)camera.pixelHeight;
				}
			}
			element.transform.position = position;
		}

		private GameObject FindMenuPrefab<T>() where T : MenuBase
		{
			GameObject[] menuPrefabs = _config.MenuPrefabs;
			foreach (GameObject gameObject in menuPrefabs)
			{
				if (gameObject.GetComponent<T>() != null)
				{
					return gameObject;
				}
			}
			return null;
		}

		public T FindMenu<T>(bool includeInactive = true) where T : MenuBase
		{
			if (includeInactive)
			{
				foreach (MenuBase createdMenu in _createdMenus)
				{
					if (createdMenu != null && createdMenu is T result)
					{
						return result;
					}
				}
			}
			else
			{
				foreach (MenuBase createdMenu2 in _createdMenus)
				{
					if (createdMenu2 != null && createdMenu2 is T && createdMenu2.isActiveAndEnabled)
					{
						return (T)createdMenu2;
					}
				}
			}
			return null;
		}

		private static T FindMenuInTransform<T>(Transform t, bool includeInactive, List<T> cachedComponents) where T : MenuBase
		{
			t.GetComponents(cachedComponents);
			T val = ((cachedComponents.Count > 0) ? cachedComponents[0] : null);
			if (val != null && (includeInactive || val.gameObject.activeInHierarchy))
			{
				return val;
			}
			return null;
		}

		public T[] FindAllMenus<T>(bool includeInactive = true) where T : MenuBase
		{
			return _menusTransform.gameObject.GetComponentsInChildren<T>(includeInactive);
		}

		public void SetMenuVisible<T>(bool visible) where T : MenuBase
		{
			T val = FindMenu<T>();
			if ((bool)val)
			{
				val.SetVisible(visible);
			}
		}

		public void SetMenuInteractable<T>(bool interactable) where T : MenuBase
		{
			T val = FindMenu<T>(includeInactive: false);
			if ((bool)val)
			{
				Selectable[] componentsInChildren = val.gameObject.GetComponentsInChildren<Selectable>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					GameObjectUtils.SetInteractable(componentsInChildren[i], interactable);
				}
			}
		}

		private T InstanceMenu<T>(GameObject menuPrefab) where T : MenuBase
		{
			if (menuPrefab != null)
			{
				MenuBase.EDrawOrderSlot index = MenuBase.EDrawOrderSlot.Default;
				MenuBase component = menuPrefab.GetComponent<MenuBase>();
				if (component != null)
				{
					index = component.DrawOrderSlot;
				}
				T component2 = UnityEngine.Object.Instantiate(menuPrefab, _drawOrderedMenuTransforms[(int)index], worldPositionStays: false).GetComponent<T>();
				_createdMenus.Add(component2);
				component2.Initialise(this);
				return component2;
			}
			return null;
		}

		public T CreateMenu<T>(bool recycle = false) where T : MenuBase
		{
			if (recycle)
			{
				T val = FindMenu<T>();
				if (val != null)
				{
					return val;
				}
			}
			return InstanceMenu<T>(FindMenuPrefab<T>());
		}

		public T CreateMenu<T>(GameObject menuPrefab) where T : MenuBase
		{
			return InstanceMenu<T>(menuPrefab);
		}

		public void DestroyMenu<T>() where T : MenuBase
		{
			T val = FindMenu<T>();
			if (val != null)
			{
				DestroyMenu(val);
			}
		}

		public void DestroyMenu(MenuBase menu)
		{
			_createdMenus.Remove(menu);
			menu.Destroy();
			UnityEngine.Object.Destroy(menu.gameObject);
		}

		public void AddElement(InWorldHUDElement element, Transform parent = null)
		{
			_elements.Add(element);
			element.transform.SetParent((parent != null) ? parent : _drawOrderedMenuTransforms[0], worldPositionStays: false);
			if (Camera.main != null)
			{
				CalculateElementScreenPos(Camera.main, element);
			}
		}

		public void RemoveElement(InWorldHUDElement element)
		{
			_elements.Remove(element);
		}

		public Transform GetDrawOrderedMenuTransformForSlot(MenuBase.EDrawOrderSlot slot)
		{
			Transform result = null;
			if (slot >= MenuBase.EDrawOrderSlot.InWorldElement && slot < MenuBase.EDrawOrderSlot.NumSlots)
			{
				result = _drawOrderedMenuTransforms[(int)slot];
			}
			return result;
		}

		public bool IsFullscreenMenuOpen()
		{
			return _fullscreenMenuCount > 0;
		}

		public void AmendExternalFullScreenMenuInstanceCount(int incrAmt)
		{
			_fullscreenMenuCount = Mathf.Max(_fullscreenMenuCount + incrAmt, 0);
		}

		public bool AreAnyMenusPreventingOpenPauseMenu()
		{
			return _preventOpenPauseMenuCount > 0;
		}

		public void CloseAllMenusAllowingEscapeClose()
		{
			MenuBase[] array = FindAllMenus<MenuBase>();
			if (array == null)
			{
				return;
			}
			MenuBase[] array2 = array;
			foreach (MenuBase menuBase in array2)
			{
				if (menuBase.AllowEscapeCloseMenu)
				{
					menuBase.CloseMenuImmediately();
				}
			}
		}

		private void OnMenuOpenInner(MenuBase menu)
		{
			if (menu.FullScreenMenu)
			{
				_fullscreenMenuCount++;
			}
			if (menu is IPauseTimeMenu)
			{
				_pauseTimeMenuCount++;
			}
			if (!menu.AllowOpenPauseMenu)
			{
				_preventOpenPauseMenuCount++;
			}
		}

		private void OnMenuCloseInner(MenuBase menu)
		{
			if (menu.FullScreenMenu)
			{
				_fullscreenMenuCount--;
			}
			if (menu is IPauseTimeMenu)
			{
				_pauseTimeMenuCount--;
			}
			if (!menu.AllowOpenPauseMenu)
			{
				_preventOpenPauseMenuCount--;
			}
			menu.OnClosed.InvokeSafe();
		}

		public void OnOptionsMenuOpen()
		{
			_optionsMenuOpen = true;
		}

		public void OnOptionsMenuClose()
		{
			_optionsMenuOpen = false;
		}

		public void DebugGUI()
		{
		}

		public void Debug_CloseAllFullScreenOrPauseTimeMenus()
		{
			MenuBase[] array = FindAllMenus<MenuBase>();
			if (array == null)
			{
				return;
			}
			MenuBase[] array2 = array;
			foreach (MenuBase menuBase in array2)
			{
				if (menuBase.FullScreenMenu || menuBase is IPauseTimeMenu)
				{
					menuBase.CloseMenuImmediately();
				}
			}
		}
	}
}
