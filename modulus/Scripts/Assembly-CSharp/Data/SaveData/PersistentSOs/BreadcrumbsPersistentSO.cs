#define ENABLE_DEBUG_EXCEPTIONS
using System.Collections.Generic;
using Data.Breadcrumbs;
using Events.Breadcrumbs;
using UnityEngine;
using Utils;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Breadcrumbs", fileName = "BreadcrumbsPersistentSO", order = 0)]
	public class BreadcrumbsPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private BreadcrumbEvent _breadcrumbUpdatedEvent;

		[Tooltip("This is used for save and loading and the order matters")]
		[SerializeField]
		private BreadcrumbStateSO[] _persistentBreadcrumbStates;

		private readonly Dictionary<string, Breadcrumb> _breadcrumbsById = new Dictionary<string, Breadcrumb>();

		private readonly Dictionary<string, HashSet<Breadcrumb>> _breadcrumbSetsByTag = new Dictionary<string, HashSet<Breadcrumb>>();

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			if (!(saveData is BreadcrumbsSaveData breadcrumbsSaveData))
			{
				this.DevException("saveData isn't the type BreadcrumbsSaveData. Can't apply the wrong save data.", "ApplyLoadedSaveData", 23);
				return;
			}
			foreach (BreadcrumbsSaveData.BreadcrumbSaveData breadcrumb2 in breadcrumbsSaveData.Breadcrumbs)
			{
				List<BreadcrumbStateSO> list = new List<BreadcrumbStateSO>();
				if (breadcrumb2.StateIndexes != null)
				{
					foreach (int stateIndex in breadcrumb2.StateIndexes)
					{
						list.Add(_persistentBreadcrumbStates[stateIndex]);
					}
				}
				Breadcrumb breadcrumb = new Breadcrumb(breadcrumb2.Id, breadcrumb2.Tags, list);
				_breadcrumbsById.TryAdd(breadcrumb.Id, breadcrumb);
				foreach (string tag in breadcrumb.Tags)
				{
					AddBreadcrumbToTag(tag, breadcrumb);
				}
			}
		}

		public override void ResetToDefaults()
		{
			_breadcrumbsById.Clear();
			_breadcrumbSetsByTag.Clear();
		}

		public void ClearAllStates()
		{
			foreach (Breadcrumb value in _breadcrumbsById.Values)
			{
				if (value.HasStates())
				{
					value.ClearStates();
					_breadcrumbUpdatedEvent.Fire(value);
				}
			}
		}

		public override AbstractSaveData GetSaveData()
		{
			return new BreadcrumbsSaveData(_breadcrumbsById.Values, _persistentBreadcrumbStates);
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<BreadcrumbsSaveData>(fullPath);
		}

		public bool GetBreadcrumbState(string breadcrumbID, BreadcrumbStateSO state)
		{
			if (_breadcrumbsById.TryGetValue(breadcrumbID, out var value))
			{
				return value.GetState(state);
			}
			return false;
		}

		public bool GetTagState(string tag, BreadcrumbStateSO state)
		{
			if (!_breadcrumbSetsByTag.TryGetValue(tag, out var value))
			{
				return false;
			}
			foreach (Breadcrumb item in value)
			{
				if (item.GetState(state))
				{
					return true;
				}
			}
			return false;
		}

		public void AddBreadcrumbState(BreadcrumbStateSO state, string breadcrumbId)
		{
			if (string.IsNullOrEmpty(breadcrumbId))
			{
				this.DevException(string.Format("Cannot add {0} for a null {1}", state, "breadcrumbId"), "AddBreadcrumbState", 102);
				return;
			}
			if (!_breadcrumbsById.TryGetValue(breadcrumbId, out var value))
			{
				value = new Breadcrumb(breadcrumbId);
				AddNewBreadcrumb(value);
			}
			value.SetState(state, value: true);
			_breadcrumbUpdatedEvent.Fire(value);
		}

		public void SetBreadcrumbTags(string breadcrumbId, params string[] tags)
		{
			if (string.IsNullOrEmpty(breadcrumbId))
			{
				this.DevException("Cannot set tags for a null breadcrumbId", "SetBreadcrumbTags", 120);
				return;
			}
			if (!_breadcrumbsById.TryGetValue(breadcrumbId, out var value))
			{
				value = new Breadcrumb(breadcrumbId);
				string[] array = tags;
				foreach (string tag in array)
				{
					value.AddTag(tag);
				}
				AddNewBreadcrumb(value);
			}
			else
			{
				string[] array = tags;
				foreach (string tag2 in array)
				{
					value.AddTag(tag2);
					AddBreadcrumbToTag(tag2, value);
				}
			}
			_breadcrumbUpdatedEvent.Fire(value);
		}

		public void RemoveBreadcrumbState(string breadcrumbId, BreadcrumbStateSO state)
		{
			if (_breadcrumbsById.TryGetValue(breadcrumbId, out var value))
			{
				value.SetState(state, value: false);
				_breadcrumbUpdatedEvent.Fire(value);
			}
		}

		private void AddNewBreadcrumb(Breadcrumb breadcrumb)
		{
			_breadcrumbsById[breadcrumb.Id] = breadcrumb;
			foreach (string tag in breadcrumb.Tags)
			{
				AddBreadcrumbToTag(tag, breadcrumb);
			}
		}

		private void AddBreadcrumbToTag(string tag, Breadcrumb breadcrumb)
		{
			if (!_breadcrumbSetsByTag.TryGetValue(tag, out var value))
			{
				value = new HashSet<Breadcrumb> { breadcrumb };
				_breadcrumbSetsByTag.Add(tag, value);
			}
			else if (!value.Contains(breadcrumb))
			{
				value.Add(breadcrumb);
			}
		}
	}
}
