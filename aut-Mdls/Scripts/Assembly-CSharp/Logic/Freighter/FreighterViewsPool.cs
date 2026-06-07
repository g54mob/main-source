#define ENABLE_DEBUG_EXCEPTIONS
using System.Collections.Generic;
using Data.FactoryFloor.Freighter;
using Events.FactoryFloor;
using Events.Generic;
using Presentation.FactoryFloor;
using Unity.Collections;
using UnityEngine;
using Utils;

namespace Logic.Freighter
{
	public class FreighterViewsPool : MonoBehaviour
	{
		[SerializeField]
		private FreighterView _prefab;

		[Header("Events")]
		[SerializeField]
		private FreighterEventSO _freighterCreatedEvent;

		[SerializeField]
		private IntEvent _freighterDestroyedEvent;

		private readonly List<FreighterView> _unusedInstances = new List<FreighterView>();

		private readonly Dictionary<int, FreighterView> _instances = new Dictionary<int, FreighterView>();

		private void Start()
		{
			_freighterCreatedEvent.Register(OnFreighterCreated);
			_freighterDestroyedEvent.Register(OnFreighterDestroyed);
		}

		private void OnDestroy()
		{
			_freighterCreatedEvent.UnRegister(OnFreighterCreated);
			_freighterDestroyedEvent.UnRegister(OnFreighterDestroyed);
			foreach (FreighterView value in _instances.Values)
			{
				Object.Destroy(value.gameObject);
			}
			_instances.Clear();
			foreach (FreighterView unusedInstance in _unusedInstances)
			{
				Object.Destroy(unusedInstance.gameObject);
			}
			_unusedInstances.Clear();
		}

		private void OnFreighterCreated(FreighterObject freighterObject)
		{
			if (_instances.ContainsKey(freighterObject.CreatedId))
			{
				this.DevException($"View of nameof({freighterObject.CreatedId}) \"{freighterObject.CreatedId}\" already exists. We can't use the same id twice!", "OnFreighterCreated", 50);
				return;
			}
			FreighterView orCreateInstance = GetOrCreateInstance();
			_instances.Add(freighterObject.CreatedId, orCreateInstance);
			orCreateInstance.AssignFreighter(freighterObject);
		}

		private void OnFreighterDestroyed(int createdId)
		{
			if (!_instances.TryGetValue(createdId, out var value))
			{
				this.DevException($"Failed: View for nameof({createdId}) \"{createdId}\" doesn't exists", "OnFreighterDestroyed", 63);
				return;
			}
			value.gameObject.SetActive(value: false);
			_unusedInstances.Add(value);
			_instances.Remove(createdId);
			value.UnAssignFreighter();
		}

		public bool TryGetFreighterView(int createdId, out FreighterView freighterView)
		{
			return _instances.TryGetValue(createdId, out freighterView);
		}

		private FreighterView GetOrCreateInstance()
		{
			if (_unusedInstances.Count > 0)
			{
				FreighterView freighterView = _unusedInstances[0];
				_unusedInstances.RemoveAtSwapBack(0);
				freighterView.gameObject.SetActive(value: true);
				return freighterView;
			}
			FreighterView freighterView2 = Object.Instantiate(_prefab);
			freighterView2.transform.SetParent(base.transform);
			return freighterView2;
		}
	}
}
