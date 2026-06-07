using System;
using System.Collections.Generic;
using ModApi.Ui.Inspector.Events;

namespace ModApi.Ui.Inspector
{
	public class TableRowModel : ItemModel, IGroupModel
	{
		private List<ItemModel> _models;

		bool IGroupModel.Collapsed
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public IReadOnlyList<ItemModel> Items => _models;

		string IGroupModel.Name => string.Empty;

		public event EventHandler<GroupModelCollapsedChangedEventArgs> CollapsedChanged
		{
			add
			{
				throw new NotSupportedException();
			}
			remove
			{
				throw new NotSupportedException();
			}
		}

		public TableRowModel()
		{
			_models = new List<ItemModel>();
		}

		public T Add<T>(T model) where T : ItemModel
		{
			_models.Add(model);
			return model;
		}

		public ModelBuilder<T> AddAndBuild<T>(T item) where T : ItemModel
		{
			ModelBuilder<T> result = new ModelBuilder<T>(item);
			Add(item);
			return result;
		}
	}
}
