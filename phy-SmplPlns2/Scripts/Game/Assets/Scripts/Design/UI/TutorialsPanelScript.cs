using Assets.Scripts.Design.Tutorials;
using Assets.Scripts.UI.Controls;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI
{
	public class TutorialsPanelScript : DesignerPanelScript
	{
		private ListControl<TutorialDatabase.TutorialInfo> _listControl;

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			_listControl = new ListControl<TutorialDatabase.TutorialInfo>(base.Widget.FindWidget<ScrollViewWidget>("scroll-view"), "tutorial-list-item");
			_listControl.CreateListItem = delegate(Widget widget, ListItem<TutorialDatabase.TutorialInfo> item)
			{
				widget.FindWidget<TextWidget>("name").Text = item.Item.Name;
				widget.FindWidget<TextWidget>("description").Text = item.Item.Description;
				widget.FindWidget("status").EnableClass("status-incomplete", !item.Item.IsDone);
				widget.FindWidget("status").EnableClass("status-complete", item.Item.IsDone);
			};
			base.Flyout.Opened += delegate
			{
				BuildList();
			};
			base.Flyout.Closed += delegate
			{
			};
		}

		protected void Update()
		{
			_listControl.Update();
		}

		private void BuildList()
		{
			_listControl.Items.Clear();
			foreach (TutorialDatabase.TutorialInfo tutorial in base.Designer.DesignerScript.Tutorial.TutorialDB.Tutorials)
			{
				_listControl.Items.Add(new ListItem<TutorialDatabase.TutorialInfo>(tutorial.Name, tutorial)
				{
					CanRename = false,
					CanDelete = false
				});
			}
		}

		private void OnStartTutorialClicked(Widget widget)
		{
			ListItem<TutorialDatabase.TutorialInfo> selectedItem = _listControl.SelectedItem;
			if (selectedItem != null)
			{
				base.Flyout.Close();
				base.Designer.DesignerScript.Tutorial.StartTutorial(selectedItem.Item);
			}
		}
	}
}
