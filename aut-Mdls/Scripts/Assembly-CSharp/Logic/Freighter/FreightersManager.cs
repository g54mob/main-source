using System;
using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Freighter;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events;
using Events.FactoryFloor;
using Logic.Freighters;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Logic.Freighter
{
	public class FreightersManager : MonoBehaviour
	{
		[SerializeField]
		private FreightersManagerLocator _freightersManagerLocator;

		[SerializeField]
		private FreighterObjectData _freighterData;

		[SerializeField]
		private FreightersNameGenerator _freightersNameGenerator;

		[SerializeField]
		private IntVariableSO _maxFreightersAmount;

		[SerializeField]
		private FactoryStepEvent _factoryStepEvent;

		[SerializeField]
		private BaseEvent _onFinishedLoadingSaveEvent;

		private readonly Dictionary<int, FreighterObject> _freighterObjects = new Dictionary<int, FreighterObject>();

		private FreightersSaveData _freightersSaveData;

		public int FreighterCount => _freighterObjects.Count;

		public int ActiveFreighterCount
		{
			get
			{
				int num = 0;
				foreach (KeyValuePair<int, FreighterObject> freighterObject in _freighterObjects)
				{
					FreighterObject value = freighterObject.Value;
					if (value != null && value.Path.Stops.Count >= 2)
					{
						num++;
					}
				}
				return num;
			}
		}

		public IEnumerable<FreighterObject> Freighters => _freighterObjects.Values;

		public event Action OnFreightersChanged = delegate
		{
		};

		private void Start()
		{
			_freightersManagerLocator.SetFreightersManager(this);
		}

		private void OnDestroy()
		{
			_freightersManagerLocator.ClearFreightersManager();
		}

		public void ApplySaveData(FreightersSaveData freightersSaveData)
		{
			throw new NotIncludedInDemoException();
		}

		private void ApplySaveDataAfterLoad()
		{
			_onFinishedLoadingSaveEvent.UnRegister(ApplySaveDataAfterLoad);
			Reset();
			for (int i = 0; i < _freightersSaveData.FreighterObjectsSaveData.Count; i++)
			{
				TryAddFreighter(out var _);
			}
			if (_freightersSaveData.FreighterObjectsSaveData != null)
			{
				for (int j = 0; j < _freightersSaveData.FreighterObjectsSaveData.Count; j++)
				{
					if (_freighterObjects.Count > j)
					{
						_freighterObjects.ElementAt(j).Value.ApplySaveState(_freightersSaveData.FreighterObjectsSaveData[j]);
					}
				}
			}
			this.OnFreightersChanged();
		}

		public void Reset()
		{
			foreach (FreighterObject value in _freighterObjects.Values)
			{
				value.Dispose();
			}
			_freighterObjects.Clear();
		}

		public bool TryGetFreighter(int createdId, out FreighterObject freighterObject)
		{
			return _freighterObjects.TryGetValue(createdId, out freighterObject);
		}

		public bool TryAddFreighter(out FreighterObject freighterObject)
		{
			if (FreighterCount < _maxFreightersAmount.Value)
			{
				int getNewId = IntIdGenerator.GetNewId;
				freighterObject = new FreighterObject(getNewId, _freighterData, _factoryStepEvent, _freightersNameGenerator);
				_freighterObjects.Add(getNewId, freighterObject);
				this.OnFreightersChanged();
				return true;
			}
			freighterObject = null;
			return false;
		}

		public void DestroyFreighter(int createdId)
		{
			_freighterObjects[createdId].Dispose();
			_freighterObjects.Remove(createdId);
			this.OnFreightersChanged();
		}

		public List<FreighterObject> GetFreightersWithFreightHubInPath(int freightHubReferenceId)
		{
			List<FreighterObject> list = new List<FreighterObject>();
			foreach (KeyValuePair<int, FreighterObject> freighterObject in _freighterObjects)
			{
				FreighterObject value = freighterObject.Value;
				foreach (FreighterStopConfiguration stop in value.Path.Stops)
				{
					if (stop.freightHubReferenceId == freightHubReferenceId)
					{
						list.Add(value);
						break;
					}
				}
			}
			return list;
		}
	}
}
