using System;
using System.Collections.Generic;
using ModApi.Ui.Inspector.Events;

namespace ModApi.Ui.Inspector
{
	public class InspectorModel : IGroupModel
	{
		private List<GroupModel> _groups = new List<GroupModel>();

		private string _userPrefsId;

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

		public IList<GroupModel> Groups => _groups;

		public string Id { get; }

		public IReadOnlyList<ItemModel> Items => _groups;

		string IGroupModel.Name => Title;

		public IInspectorPanel Panel { get; private set; }

		public string Title { get; set; }

		public string TitleTextTooltip { get; set; }

		public string UserPrefsId
		{
			get
			{
				return _userPrefsId ?? ("InspectorPanel." + Id);
			}
			set
			{
				_userPrefsId = value;
			}
		}

		bool IGroupModel.Visible
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

		public InspectorModel(string id, string title)
		{
			Id = id;
			Title = title;
			Groups.Add(new GroupModel(null));
		}

		public T Add<T>(T model, string groupName = null) where T : ItemModel
		{
			model.InspectorModel = this;
			GetOrCreateGroup(groupName).Add(model);
			return model;
		}

		public T Add<T>(T item) where T : ItemModel
		{
			return Add(item, null);
		}

		public ModelBuilder<T> AddAndBuild<T>(T item) where T : ItemModel
		{
			ModelBuilder<T> result = new ModelBuilder<T>(item);
			Add(item, null);
			return result;
		}

		public GroupModel AddGroup(GroupModel group, int index)
		{
			if (index == -1)
			{
				_groups.Add(group);
			}
			else
			{
				_groups.Insert(index, group);
			}
			return group;
		}

		public GroupModel AddGroup(GroupModel group)
		{
			return AddGroup(group, -1);
		}

		public List<GroupModel> GetAllGroups()
		{
			List<GroupModel> result = new List<GroupModel>();
			GetGroups(Items, result);
			return result;
		}

		public GroupModel GetOrCreateGroup(string groupName)
		{
			GroupModel groupModel = null;
			foreach (GroupModel group in Groups)
			{
				if (group.Name == groupName)
				{
					groupModel = group;
				}
			}
			if (groupModel == null)
			{
				groupModel = new GroupModel(groupName);
				AddGroup(groupModel);
			}
			return groupModel;
		}

		public int IndexOfGroup(GroupModel group)
		{
			return _groups.IndexOf(group);
		}

		public void OnInspectorPanelClosed()
		{
			Panel = null;
		}

		public void OnInspectorPanelCreated(IInspectorPanel panel)
		{
			Panel = panel;
		}

		public T Remove<T>(T model, string groupName = null) where T : ItemModel
		{
			model.InspectorModel = this;
			GetOrCreateGroup(groupName).Remove(model);
			return model;
		}

		public void RemoveGroup(GroupModel group)
		{
			_groups.Remove(group);
		}

		private static void GetGroups(IEnumerable<ItemModel> items, List<GroupModel> result)
		{
			foreach (ItemModel item in items)
			{
				if (item is GroupModel groupModel)
				{
					result.Add(groupModel);
					GetGroups(groupModel.Items, result);
				}
			}
		}
	}
}
