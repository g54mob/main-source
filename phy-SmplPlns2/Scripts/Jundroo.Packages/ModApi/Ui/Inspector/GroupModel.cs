using System;
using System.Collections.Generic;
using ModApi.Ui.Inspector.Events;

namespace ModApi.Ui.Inspector
{
	public class GroupModel : ItemModel, IGroupModel
	{
		private bool _allParentsVisible = true;

		private bool _collapsed;

		private List<ItemModel> _items;

		private List<GroupModel> _subGroups = new List<GroupModel>();

		private bool _visible = true;

		public bool AutoGenerateCollapsedId { get; set; } = true;

		public bool Collapsed
		{
			get
			{
				return _collapsed;
			}
			set
			{
				if (_collapsed != value)
				{
					_collapsed = value;
					UpdateChildVisbility();
					this.CollapsedChanged?.Invoke(this, new GroupModelCollapsedChangedEventArgs(this, value));
				}
			}
		}

		public string CollapsedId { get; private set; }

		public string FullCollapsedId { get; set; }

		public HeaderModel Header { get; set; }

		public int Indentation { get; set; }

		public IReadOnlyList<ItemModel> Items => _items;

		public string Name { get; set; }

		public Action OnDeleteItem { get; set; }

		public Action<int> OnMoveItem { get; set; }

		public string Subtitle { get; set; }

		public override bool Visible
		{
			get
			{
				if (_visible)
				{
					return _allParentsVisible;
				}
				return false;
			}
			set
			{
				if (_visible != value)
				{
					_visible = value;
					UpdateChildVisbility();
				}
			}
		}

		public event EventHandler<GroupModelCollapsedChangedEventArgs> CollapsedChanged;

		public GroupModel(string name, string collapsedId = null)
		{
			Name = name;
			_items = new List<ItemModel>();
			Visible = true;
			if (collapsedId != null)
			{
				CollapsedId = collapsedId;
			}
			else
			{
				CollapsedId = name;
			}
		}

		public T Add<T>(T item) where T : ItemModel
		{
			_items.Add(item);
			if (item is GroupModel)
			{
				GroupModel obj = item as GroupModel;
				_subGroups.Add(item as GroupModel);
				obj.UpdateIndentation(GetChildIndentation());
				UpdateChildVisbility();
			}
			return item;
		}

		public GroupModel AddAndBuild<T>(T item) where T : ItemModel
		{
			new ModelBuilder<T>(item);
			Add(item);
			return this;
		}

		public void Remove(ItemModel item)
		{
			_items.Remove(item);
			if (item is GroupModel)
			{
				GroupModel item2 = item as GroupModel;
				_subGroups.Remove(item2);
			}
		}

		public void UpdateChildVisbility()
		{
			foreach (GroupModel subGroup in _subGroups)
			{
				subGroup._allParentsVisible = Visible && !Collapsed;
				subGroup.UpdateChildVisbility();
			}
		}

		private int GetChildIndentation()
		{
			return Indentation + ((!string.IsNullOrEmpty(Name)) ? 1 : 0);
		}

		private void UpdateIndentation(int indentation)
		{
			Indentation = indentation;
			foreach (GroupModel subGroup in _subGroups)
			{
				subGroup.UpdateIndentation(GetChildIndentation());
			}
		}
	}
}
