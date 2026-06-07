using System.Collections.Generic;

namespace Data.Breadcrumbs
{
	public class Breadcrumb
	{
		private readonly List<BreadcrumbStateSO> _states;

		private readonly List<string> _tags;

		private readonly string _id;

		public string Id => _id;

		public IReadOnlyList<string> Tags => _tags;

		public IReadOnlyList<BreadcrumbStateSO> States => _states;

		public Breadcrumb(string id)
		{
			_id = id;
			_tags = new List<string>();
			_states = new List<BreadcrumbStateSO>();
		}

		public Breadcrumb(string id, List<string> tags, List<BreadcrumbStateSO> states)
		{
			_id = id;
			_tags = tags;
			_states = states;
		}

		public bool HasTag(string tag)
		{
			return _tags.Contains(tag);
		}

		public void AddTag(string tag)
		{
			if (!_tags.Contains(tag))
			{
				_tags.Add(tag);
			}
		}

		public bool HasStates()
		{
			return _states.Count > 0;
		}

		public bool GetState(BreadcrumbStateSO state)
		{
			return _states.Contains(state);
		}

		public void SetState(BreadcrumbStateSO state, bool value)
		{
			if (GetState(state) != value)
			{
				if (value)
				{
					_states.Add(state);
				}
				else
				{
					_states.Remove(state);
				}
			}
		}

		public void ClearStates()
		{
			_states.Clear();
		}
	}
}
