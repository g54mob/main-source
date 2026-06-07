using Jundroo.Common.Platform;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Activity
{
	public class ActivityWidgetScript : WidgetScript
	{
		private TextWidget _nameText;

		public SelectActivityDialogScript.ActivityInfo Activity { get; private set; }

		public bool IsLocked { get; private set; }

		public void Initialize(SelectActivityDialogScript.ActivityInfo activity)
		{
			Activity = activity;
			_nameText = base.Widget.FindWidget<TextWidget>("name");
			_nameText.Text = activity.DisplayName;
			IsLocked = Device.IsDemoBuild && !activity.Activity.IsSupportedInDemo;
			base.Widget.FindWidget("icon").SetStyle("sprite", IsLocked ? "Sprites/Flight/IconLock" : activity.Icon);
			Widget widget = base.Widget.FindWidget("stars");
			if (activity.ShowTiers && !IsLocked)
			{
				for (int i = 0; i < activity.UnlockedScoreTier; i++)
				{
					widget.FindWidget($"star-{i + 1}").EnableClass("star-completed", enabled: true);
				}
			}
			else
			{
				widget.Visible = false;
			}
			if (IsLocked)
			{
				base.Widget.AddClass("locked");
			}
			((base.Widget.Widgets.Count > 0) ? base.Widget.Widgets[0] : null).Show();
		}

		public void SetSelected(bool selected)
		{
			base.Widget.EnableClass("list-item-selected", selected);
		}
	}
}
