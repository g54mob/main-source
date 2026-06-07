using System;
using System.Collections.Generic;
using ModApi.Ui.Inspector.Events;

namespace ModApi.Ui.Inspector
{
	public interface IGroupModel
	{
		bool Collapsed { get; set; }

		IReadOnlyList<ItemModel> Items { get; }

		string Name { get; }

		bool Visible { get; set; }

		event EventHandler<GroupModelCollapsedChangedEventArgs> CollapsedChanged;

		T Add<T>(T item) where T : ItemModel;

		ModelBuilder<T> AddAndBuild<T>(T item) where T : ItemModel;
	}
}
