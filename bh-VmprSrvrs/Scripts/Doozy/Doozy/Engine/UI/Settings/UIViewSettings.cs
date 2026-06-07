using System;
using Doozy.Engine.UI.Base;
using UnityEngine;

namespace Doozy.Engine.UI.Settings
{
	[Serializable]
	public class UIViewSettings : ScriptableObject
	{
		public const string FILE_NAME = "UIViewSettings";

		private static UIViewSettings s_instance;

		[SerializeField]
		private NamesDatabase database;

		public const TargetOrientation TARGET_ORIENTATION_DEFAULT_VALUE = TargetOrientation.Any;

		public const UIViewStartBehavior BEHAVIOUR_AT_START_DEFAULT_VALUE = UIViewStartBehavior.DoNothing;

		public const bool DEFAULT_AUTO_HIDE_AFTER_SHOW = false;

		public const bool DEFAULT_AUTO_SELECT_BUTTON_AFTER_SHOW = false;

		public const bool DESELECT_ANY_BUTTON_SELECTED_ON_HIDE_DEFAULT_VALUE = false;

		public const bool DESELECT_ANY_BUTTON_SELECTED_ON_SHOW_DEFAULT_VALUE = false;

		public const bool DISABLE_CANVAS_WHEN_HIDDEN_DEFAULT_VALUE = true;

		public const bool DISABLE_GAME_OBJECT_WHEN_HIDDEN_DEFAULT_VALUE = true;

		public const bool DISABLE_GRAPHIC_RAYCASTER_WHEN_HIDDEN_DEFAULT_VALUE = true;

		public const bool USE_CUSTOM_START_ANCHORED_POSITION_DEFAULT_VALUE = true;

		public const float DEFAULT_AUTO_HIDE_AFTER_SHOW_DELAY = 3f;

		public const float DISABLE_WHEN_HIDDEN_TIME_BUFFER = 0.05f;

		public const string RENAME_PREFIX_DEFAULT_VALUE = "View - ";

		public const string RENAME_SUFFIX_DEFAULT_VALUE = "";

		public static Vector3 CUSTOM_START_ANCHORED_POSITION_DEFAULT_VALUE;

		public TargetOrientation TargetOrientation;

		public UIViewStartBehavior BehaviorAtStart;

		public Vector3 CustomStartAnchoredPosition;

		public bool DeselectAnyButtonSelectedOnHide;

		public bool DeselectAnyButtonSelectedOnShow;

		public bool DisableCanvasWhenHidden;

		public bool DisableGameObjectWhenHidden;

		public bool DisableGraphicRaycasterWhenHidden;

		public bool UseCustomStartAnchoredPosition;

		public string RenamePrefix;

		public string RenameSuffix;

		private static string ResourcesPath => null;

		public static UIViewSettings Instance => null;

		public static NamesDatabase Database => null;

		public static void UpdateDatabase()
		{
		}

		private void Reset()
		{
		}

		public void Reset(bool saveAssets)
		{
		}

		public void ResetComponent(UIView view)
		{
		}

		public void SetDirty(bool saveAssets)
		{
		}

		public void UndoRecord(string undoMessage)
		{
		}
	}
}
