using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.UI;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI
{
	public class SaveCraftDialogScript : InputDialogScript
	{
		private CraftTagsPanelScript.CraftTagsPanel _craftTagsPanel;

		public static SaveCraftDialogScript Create(string inputText, IReadOnlyList<string> tags, Action<SaveCraftDialogScript> saveAction)
		{
			SaveCraftDialogScript saveCraftDialogScript = Game.Instance.UserInterface.CreateDialog<SaveCraftDialogScript>("Xml/Dialogs/SaveCraftDialog");
			saveCraftDialogScript.Title = "Save Craft";
			saveCraftDialogScript.InputPlaceholderText = "Craft Name";
			saveCraftDialogScript.OkayButtonText = "Save";
			saveCraftDialogScript.CancelButtonText = "Cancel";
			saveCraftDialogScript.ValidationFunction = FileIOUtility.IsValidPath;
			saveCraftDialogScript.InvalidCharacters.AddRange(Path.GetInvalidPathChars());
			saveCraftDialogScript.InputText = inputText;
			saveCraftDialogScript.OkayClicked += delegate(InputDialogScript d)
			{
				saveAction?.Invoke((SaveCraftDialogScript)d);
			};
			saveCraftDialogScript.SetTags(tags);
			return saveCraftDialogScript;
		}

		public void GetTags(List<string> tags)
		{
			_craftTagsPanel.GetSelectedTags(tags);
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_craftTagsPanel = CraftTagsPanelScript.InitializeForHostWidget(base.Widget, base.Widget, saveCraftDialog: true, null);
			_craftTagsPanel.OnHostFlyoutOpened();
		}

		public void SetTags(IReadOnlyList<string> tags)
		{
			_craftTagsPanel.SetSelectedTags(tags);
		}
	}
}
