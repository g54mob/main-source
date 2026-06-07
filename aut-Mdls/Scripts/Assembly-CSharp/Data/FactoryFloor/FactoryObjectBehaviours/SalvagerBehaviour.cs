using System;
using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events.FactoryFloor;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/Salvager", fileName = "SalvagerBehaviour", order = 0)]
	public class SalvagerBehaviour : ResourceHolderBehaviour
	{
		[Serializable]
		public struct NonShapeResourcePair
		{
			public NonShapeResourceDataSO Data;

			public BoolVariableSO ShowInUI;
		}

		[SerializeField]
		private CurrencyPersistentSO _currencyPersistentSO;

		[SerializeField]
		private MainThreadEventSO _currencyRanOutEvent;

		[SerializeField]
		private List<NonShapeResourcePair> _dataShards = new List<NonShapeResourcePair>();

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceWithdrawnEventSO _resourceWithdrawnEvent;

		private int _chosenResourceDataIndex;

		private bool _isActivity;

		public NonShapeResourcePair ChosenResourceData => _dataShards[_chosenResourceDataIndex];

		public int ChosenResourceDataIndex => _chosenResourceDataIndex;

		public IReadOnlyList<NonShapeResourcePair> DataShards => _dataShards;

		public event Action<NonShapeResourceDataSO> OnChangedResource = delegate
		{
		};

		public override void Init(FactoryObject factoryObject)
		{
			throw new NotIncludedInDemoException();
		}

		public override void UnInit()
		{
			throw new NotIncludedInDemoException();
		}

		public override void Update()
		{
			throw new NotIncludedInDemoException();
		}

		private void TryOutput()
		{
			throw new NotIncludedInDemoException();
		}

		public override void HandleOutputResource(Resource resource, int outputIndex)
		{
			base.HandleOutputResource(resource, outputIndex);
			_currencyPersistentSO.RemoveResources(ChosenResourceData.Data, 1);
			_resourceWithdrawnEvent.Fire(resource);
			SetActivity(value: true);
		}

		private void OnCurrenyRanOut()
		{
			if (_currencyPersistentSO.GetResourceCount(ChosenResourceData.Data) <= 0)
			{
				StopTryingToOutput();
			}
		}

		private void SetActivity(bool value)
		{
			if (_isActivity != value)
			{
				_isActivity = value;
				if (_isActivity)
				{
					StartActivity();
				}
				else
				{
					EndActivity();
				}
			}
		}

		public override void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
		}

		public override bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			return false;
		}

		public override void RemoveResource(Resource resource)
		{
		}

		public void SetChosenResourceIndex(int index)
		{
			throw new NotIncludedInDemoException();
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			throw new NotIncludedInDemoException();
		}

		public override void ApplyConfigurationDto(BehaviourConfigurationDto configDto)
		{
			throw new NotIncludedInDemoException();
		}
	}
}
