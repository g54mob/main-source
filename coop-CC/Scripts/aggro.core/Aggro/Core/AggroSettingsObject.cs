using System;
using System.Collections.Generic;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

namespace Aggro.Core
{
	[CreateAssetMenu(menuName = "Global Data/Aggro Settings", fileName = "globalData-aggrosettings")]
	public class AggroSettingsObject : GlobalScriptableObject<AggroSettingsObject>, ISerializationCallbackReceiver
	{
		[Serializable]
		public class Category
		{
			public string category;

			public string label;

			public GameObject customPagePrefab;
		}

		[Serializable]
		public class Icon
		{
			public string path;

			public Sprite sprite;

			public Sprite playStationSprite;
		}

		[Serializable]
		public class FallbackPath
		{
			public string action;

			public string kbmPath;

			public string gamepadPath;
		}

		[Serializable]
		public class Template
		{
			public string settingType;

			public GameObject prefab;

			private static Type[] SETTING_TYPES;

			private ValueDropdownList<string> ValueDropDownGetTypes()
			{
				if (SETTING_TYPES == null)
				{
					Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
					Type typeFromHandle = typeof(AggroSettingBase);
					List<Type> list = new List<Type>();
					Assembly[] array = assemblies;
					for (int i = 0; i < array.Length; i++)
					{
						Type[] types = array[i].GetTypes();
						foreach (Type type in types)
						{
							if (!type.IsGenericTypeDefinition && !type.IsAbstract && typeFromHandle.IsAssignableFrom(type))
							{
								list.Add(type);
							}
						}
					}
					list.Sort((Type x, Type y) => string.CompareOrdinal(x.FullName, y.FullName));
					SETTING_TYPES = list.ToArray();
				}
				ValueDropdownList<string> valueDropdownList = new ValueDropdownList<string>();
				for (int num = 0; num < SETTING_TYPES.Length; num++)
				{
					Type type2 = SETTING_TYPES[num];
					valueDropdownList.Add(TypeUtil.GetFriendlyName(type2), type2.AssemblyQualifiedName);
				}
				return valueDropdownList;
			}

			private bool ValidateType(string typeName, ref string errorMessage)
			{
				if (string.IsNullOrEmpty(typeName))
				{
					return true;
				}
				Type type = Type.GetType(typeName);
				if (type == null)
				{
					errorMessage = "Invalid type name! (" + typeName + ")";
					return false;
				}
				if (!typeof(AggroSettingBase).IsAssignableFrom(type))
				{
					errorMessage = "Type does not inherit from AggroSettingBase! (" + TypeUtil.GetFriendlyName(type) + ")";
					return false;
				}
				return true;
			}
		}

		public uint version;

		public GameObject optionsPrefab;

		public GameObject categoryPrefab;

		[Space]
		public Texture2D kbmIconSpriteSheet;

		public Texture2D gamepadIconSpriteSheet;

		public Sprite unknownInputIcon;

		[Space]
		public Category[] categories;

		public Template[] templates = new Template[0];

		public Icon[] inputIcons = new Icon[0];

		public FallbackPath[] fallbackPaths = new FallbackPath[0];

		private Dictionary<Type, GameObject> _typeToPrefab;

		private Dictionary<string, string> _categoryToLabel;

		private Dictionary<string, GameObject> _categoryToPagePrefab;

		private Dictionary<string, Icon> _pathToIcon;

		private Dictionary<string, FallbackPath> _actionToFallbackPaths;

		[Space]
		public Color[] gradeColors;

		public Color[] playerUIColors;

		public bool TryGetTemplate(Type type, out GameObject template)
		{
			CheckInitialize();
			return _typeToPrefab.TryGetValue(type, out template);
		}

		public bool TryGetCategoryLabel(string category, out string label)
		{
			CheckInitialize();
			return _categoryToLabel.TryGetValue(category, out label);
		}

		public bool TryGetCategoryPagePrefab(string category, out GameObject pagePrefab)
		{
			CheckInitialize();
			return _categoryToPagePrefab.TryGetValue(category, out pagePrefab);
		}

		public Sprite GetInputSprite(string path)
		{
			CheckInitialize();
			if (string.IsNullOrEmpty(path) || !_pathToIcon.TryGetValue(path, out var value))
			{
				return unknownInputIcon;
			}
			if (IsPlayStationController() && value.playStationSprite != null)
			{
				return value.playStationSprite;
			}
			return value.sprite;
		}

		public static bool IsPlayStationController()
		{
			if (Platform.GetPlatformType() == PlatformType.Steam || Platform.GetPlatformType() == PlatformType.PC)
			{
				return Gamepad.current is DualShockGamepad;
			}
			return false;
		}

		public bool HasKnownSprite(string path)
		{
			CheckInitialize();
			if (string.IsNullOrEmpty(path) || !_pathToIcon.ContainsKey(path))
			{
				return false;
			}
			return true;
		}

		public bool TryGetFallbackPath(string action, out string kbmPath, out string gamepadPath)
		{
			CheckInitialize();
			if (_actionToFallbackPaths.TryGetValue(action, out var value))
			{
				kbmPath = value.kbmPath;
				gamepadPath = value.gamepadPath;
				return true;
			}
			kbmPath = null;
			gamepadPath = null;
			return false;
		}

		private void OnValidate()
		{
			_typeToPrefab = null;
			_categoryToLabel = null;
			_pathToIcon = null;
			_categoryToPagePrefab = null;
			_actionToFallbackPaths = null;
			AggroSettings.SetSettingsDirty();
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			if (!Application.isEditor)
			{
				_typeToPrefab = null;
				_categoryToLabel = null;
				_pathToIcon = null;
				_categoryToPagePrefab = null;
				_actionToFallbackPaths = null;
				CheckInitialize();
			}
		}

		private void CheckInitialize()
		{
			if (_typeToPrefab == null)
			{
				_typeToPrefab = new Dictionary<Type, GameObject>();
				for (int i = 0; i < templates.Length; i++)
				{
					Template template = templates[i];
					Type type = Type.GetType(template.settingType);
					if (!(template.prefab == null))
					{
						if (type == null)
						{
							Debug.LogWarning("[SETTINGS] Invalid setting type for a template! (" + template.settingType + ")", this);
						}
						else if (_typeToPrefab.ContainsKey(type))
						{
							Debug.LogWarning("[SETTINGS] Duplicate setting type for a template! (" + TypeUtil.GetFriendlyName(type) + ")", this);
						}
						else
						{
							_typeToPrefab[type] = template.prefab;
						}
					}
				}
			}
			if (_categoryToLabel == null)
			{
				_categoryToLabel = new Dictionary<string, string>();
				_categoryToPagePrefab = new Dictionary<string, GameObject>();
				for (int j = 0; j < categories.Length; j++)
				{
					Category category = categories[j];
					if (string.IsNullOrWhiteSpace(category.category))
					{
						Debug.LogWarning($"[SETTINGS] Category cannot be empty! Index: {j}", this);
						continue;
					}
					if (_categoryToLabel.ContainsKey(category.category))
					{
						Debug.LogWarning($"[SETTINGS] Duplicate category! Index: {j} Category: {category.category}", this);
						continue;
					}
					if (string.IsNullOrWhiteSpace(category.label))
					{
						Debug.LogWarning($"[SETTINGS] Category label cannot be empty! Index: {j} Category: {category.category}", this);
						continue;
					}
					_categoryToLabel[category.category] = category.label;
					if (category.customPagePrefab != null)
					{
						if (Application.isEditor && category.customPagePrefab.GetComponent<AggroSettingsCustomPageUI>() == null)
						{
							Debug.LogWarning("[SETTINGS] Custom category page prefab needs AggroSettingsCustomPageUI! Category: " + category.category + " Prefab: " + category.customPagePrefab.name, category.customPagePrefab);
						}
						else
						{
							_categoryToPagePrefab[category.category] = category.customPagePrefab;
						}
					}
				}
			}
			if (_pathToIcon == null)
			{
				_pathToIcon = new Dictionary<string, Icon>();
				for (int k = 0; k < inputIcons.Length; k++)
				{
					Icon icon = inputIcons[k];
					if (!(icon.sprite == null))
					{
						if (string.IsNullOrEmpty(icon.path))
						{
							Debug.LogWarning("[SETTINGS] Icon path is empty!", this);
						}
						else if (_pathToIcon.ContainsKey(icon.path))
						{
							Debug.LogWarning("[SETTINGS] Icon path already has an entry! Path: " + icon.path, this);
						}
						else
						{
							_pathToIcon[icon.path] = icon;
						}
					}
				}
			}
			if (_actionToFallbackPaths != null)
			{
				return;
			}
			_actionToFallbackPaths = new Dictionary<string, FallbackPath>();
			for (int l = 0; l < fallbackPaths.Length; l++)
			{
				FallbackPath fallbackPath = fallbackPaths[l];
				if (string.IsNullOrEmpty(fallbackPath.action))
				{
					Debug.LogWarning("[SETTINGS] Fallback action is empty!", this);
				}
				else if (string.IsNullOrEmpty(fallbackPath.kbmPath) && string.IsNullOrEmpty(fallbackPath.gamepadPath))
				{
					Debug.LogWarning("[SETTINGS] Fallback action paths are empty! Action: " + fallbackPath.action, this);
				}
				else
				{
					_actionToFallbackPaths[fallbackPath.action] = fallbackPath;
				}
			}
		}
	}
}
