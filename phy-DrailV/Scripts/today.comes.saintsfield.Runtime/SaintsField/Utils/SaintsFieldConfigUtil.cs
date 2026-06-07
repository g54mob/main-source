namespace SaintsField.Utils
{
	public static class SaintsFieldConfigUtil
	{
		public const string EditorResourcePath = "SaintsField/SaintsFieldConfig.asset";

		public static SaintsFieldConfig Config;

		public static string ConfigAssetPath = "";

		public static bool IsConfigLoaded;

		public static int GetFoldoutSpaceImGui()
		{
			if (!IsConfigLoaded)
			{
				return 13;
			}
			return Config.foldoutSpaceImGui;
		}

		public static EXP GetComponentExp(EXP defaultValue)
		{
			if (!IsConfigLoaded)
			{
				return defaultValue;
			}
			return Config.getComponentExp;
		}

		public static EXP GetComponentInChildrenExp(EXP defaultValue)
		{
			if (!IsConfigLoaded)
			{
				return defaultValue;
			}
			return Config.getComponentInChildrenExp;
		}

		public static EXP GetComponentInParentExp(EXP defaultValue)
		{
			if (!IsConfigLoaded)
			{
				return defaultValue;
			}
			return Config.getComponentInParentExp;
		}

		public static EXP GetComponentInParentsExp(EXP defaultValue)
		{
			if (!IsConfigLoaded)
			{
				return defaultValue;
			}
			return Config.getComponentInParentsExp;
		}

		public static EXP GetComponentInSceneExp(EXP defaultValue)
		{
			if (!IsConfigLoaded)
			{
				return defaultValue;
			}
			return Config.getComponentInSceneExp;
		}

		public static EXP GetPrefabWithComponentExp(EXP defaultValue)
		{
			if (!IsConfigLoaded)
			{
				return defaultValue;
			}
			return Config.getPrefabWithComponentExp;
		}

		public static EXP GetScriptableObjectExp(EXP defaultValue)
		{
			if (!IsConfigLoaded)
			{
				return defaultValue;
			}
			return Config.getScriptableObjectExp;
		}

		public static EXP GetByXPathExp(EXP defaultValue)
		{
			if (!IsConfigLoaded)
			{
				return defaultValue;
			}
			return Config.getByXPathExp;
		}

		public static EXP GetComponentByPathExp(EXP defaultValue)
		{
			if (!IsConfigLoaded)
			{
				return defaultValue;
			}
			return Config.getComponentByPathExp;
		}

		public static EXP FindComponentExp(EXP defaultValue)
		{
			if (!IsConfigLoaded)
			{
				return defaultValue;
			}
			return Config.findComponentExp;
		}

		public static int ResizableTextAreaMinRow()
		{
			if (!IsConfigLoaded)
			{
				return 3;
			}
			return Config.resizableTextAreaMinRow;
		}

		public static bool DisableOnValueChangedWatchArrayFieldUIToolkit()
		{
			if (IsConfigLoaded)
			{
				return Config.disableOnValueChangedWatchArrayFieldUIToolkit;
			}
			return false;
		}

		public static bool GetValidateInputLoopCheckUIToolkit()
		{
			if (!IsConfigLoaded)
			{
				return false;
			}
			return Config.validateInputLoopCheckUIToolkit;
		}
	}
}
