using UnityEngine;

namespace SaintsField.Utils
{
	public class SaintsFieldConfig : ScriptableObject
	{
		public const int UpdateLoopDefaultMs = 100;

		public int resizableTextAreaMinRow = 3;

		public bool validateInputLoopCheckUIToolkit;

		public const bool ValidateInputLoopCheckDefault = false;

		[Space]
		public bool disableOnValueChangedWatchArrayFieldUIToolkit;

		[Space]
		public int foldoutSpaceImGui = 13;

		public const int FoldoutSpaceImGuiDefault = 13;

		public EXP getComponentExp = EXP.NoAutoResignToNull | EXP.NoPicker;

		public EXP getComponentInChildrenExp = EXP.NoAutoResignToNull | EXP.NoPicker;

		public EXP getComponentInParentExp = EXP.NoAutoResignToNull | EXP.NoPicker;

		public EXP getComponentInParentsExp = EXP.NoAutoResignToNull | EXP.NoPicker;

		public EXP getComponentInSceneExp = EXP.NoAutoResignToNull | EXP.NoPicker;

		public EXP getPrefabWithComponentExp = EXP.NoAutoResignToNull | EXP.NoPicker;

		public EXP getScriptableObjectExp = EXP.NoAutoResignToNull | EXP.NoPicker;

		public EXP getByXPathExp;

		public EXP getComponentByPathExp = EXP.NoAutoResign | EXP.NoPicker;

		public EXP findComponentExp = EXP.NoAutoResignToNull | EXP.NoPicker;
	}
}
