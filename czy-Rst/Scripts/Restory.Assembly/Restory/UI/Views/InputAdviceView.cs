using System;
using UnityEngine.UIElements;

namespace Restory.UI.Views
{
	public sealed class InputAdviceView : View
	{
		private const string ACTION_GROUP_NAME = "action-group";

		private const string ROTATION_GROUP_NAME = "rotation-group";

		private const string EXIT_GROUP_NAME = "exit-group";

		private VisualElement actionGroup;

		private VisualElement rotationGroup;

		private VisualElement exitGroup;

		public void Init(VisualElement root)
		{
			base.root = root;
			actionGroup = root.Q<VisualElement>("action-group");
			rotationGroup = root.Q<VisualElement>("rotation-group");
			exitGroup = root.Q<VisualElement>("exit-group");
		}

		public void Clear()
		{
			actionGroup = null;
			rotationGroup = null;
			exitGroup = null;
			root = null;
		}

		public void SwitchAdviceVisibility(InputAdviceMode newInputAdviceMode)
		{
			switch (newInputAdviceMode)
			{
			case InputAdviceMode.None:
				actionGroup.style.display = DisplayStyle.None;
				rotationGroup.style.display = DisplayStyle.None;
				exitGroup.style.display = DisplayStyle.None;
				break;
			case InputAdviceMode.MainWorkshopMode:
				actionGroup.style.display = DisplayStyle.Flex;
				rotationGroup.style.display = DisplayStyle.None;
				exitGroup.style.display = DisplayStyle.None;
				break;
			case InputAdviceMode.DisassembleMode:
				actionGroup.style.display = DisplayStyle.Flex;
				rotationGroup.style.display = DisplayStyle.Flex;
				exitGroup.style.display = DisplayStyle.Flex;
				break;
			default:
				throw new NotImplementedException();
			}
		}
	}
}
