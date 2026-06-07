using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI
{
	public class UndoHistoryPanelScript : DesignerPanelScript
	{
		private ListControl<UndoStep> _listControl;

		private bool _refresh;

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			ScrollViewWidget scrollView = base.Widget.FindWidget<ScrollViewWidget>("scroll-view");
			_listControl = new ListControl<UndoStep>(scrollView);
			_listControl.CreateListItem = delegate(Widget widget, ListItem<UndoStep> item)
			{
				widget.FindWidget<TextWidget>("item-name").Text = item.Name;
				widget.FindWidget<TextWidget>("item-details").Text = Utilities.RelativeDateShort(DateTime.UtcNow, item.Item.DateTime);
			};
			_listControl.SelectListItem = delegate(ListItem<UndoStep> x)
			{
				RestoreToUndoStep(x.Item);
			};
			base.Flyout.Opened += OnFlyoutOpened;
			base.Designer.UndoHistory.Changed += OnUndoHistoryChanged;
		}

		protected void OnDestroy()
		{
			base.Designer.UndoHistory.Changed -= OnUndoHistoryChanged;
		}

		protected virtual void Update()
		{
			if (_refresh)
			{
				_refresh = false;
				Refresh();
			}
			_listControl.Update();
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			_refresh = true;
		}

		private void OnUndoHistoryChanged(object sender, EventArgs e)
		{
			_refresh = true;
		}

		private void Refresh()
		{
			List<UndoStep> list = base.Designer.UndoHistory.UndoSteps.Reverse().ToList();
			_listControl.Items.Clear();
			ListItem<UndoStep> listItem = null;
			foreach (UndoStep item in list)
			{
				ListItem<UndoStep> listItem2 = new ListItem<UndoStep>(item.Description, item)
				{
					CanDelete = false,
					CanRename = false
				};
				_listControl.Items.Add(listItem2);
				if (base.Designer.UndoHistory.CurrentUndoStep == item)
				{
					listItem = listItem2;
				}
			}
			_listControl.Refresh();
			_listControl.SelectedItem = listItem;
			_listControl.ScrollToListItem(listItem);
		}

		private void RestoreToUndoStep(UndoStep item)
		{
			if (base.Designer.UndoHistory.CurrentUndoStep != item)
			{
				_ = base.Designer.UndoHistory.RedoStepsAvailable;
				base.Designer.UndoHistory.CurrentUndoStep = item;
				base.Designer.RestoreFromUndoStep(item);
			}
		}
	}
}
