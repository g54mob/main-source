using System;

namespace ModApi.Ui.Inspector.Events
{
	public class GroupModelCollapsedChangedEventArgs : EventArgs
	{
		public bool Collapsed { get; }

		public GroupModel GroupModel { get; }

		public GroupModelCollapsedChangedEventArgs(GroupModel groupModel, bool collapsed)
		{
			GroupModel = groupModel;
			Collapsed = collapsed;
		}
	}
}
