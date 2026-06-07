using System.Collections.Generic;
using Data.Buildings;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.Variables;
using Events.UI.Overlays;
using Logic.Threading.Events;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Buildings
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/GNNGateActivationBehaviour", fileName = "GNNGateActivationBehaviour", order = 0)]
	public class GNNGateActivationBehaviour : FactoryObjectBehaviour
	{
		[SerializeField]
		private List<BoolVariableSO> _gnnGateCompletedVariables;

		[SerializeField]
		private GNNGateBuiltEvent _gnnGateBuiltEvent;

		[SerializeField]
		private ShowIngameNotificationEvent _showIngameNotificationEvent;

		[SerializeField]
		[LocaKey]
		private string _notificationLocaKey;

		[SerializeField]
		[LocaKey]
		private string _buttonLocaKey;

		[SerializeField]
		private Sprite _notificationSprite;

		private bool _isActivated;

		private GNNGateBehaviour _gnnGateBehaviour;

		public MainThreadEvent OnActivateGNNGate = new MainThreadEvent();

		public bool IsActivated => _isActivated;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_gnnGateBehaviour = factoryObject.GetFactoryObjectBehaviour<GNNGateBehaviour>();
			GNNGateActivationSaveStateDto behaviourSaveStateDto = factoryObject.GetBehaviourSaveStateDto<GNNGateActivationSaveStateDto>();
			if (behaviourSaveStateDto != null)
			{
				_isActivated = behaviourSaveStateDto.IsActivated;
			}
			_gnnGateBehaviour.OnGNNGateCompleted.RegisterMainThread(HandleGNNGateCompleted);
		}

		private void HandleGNNGateCompleted()
		{
			throw new NotIncludedInDemoException();
		}

		public void ActivateGNNGate()
		{
			throw new NotIncludedInDemoException();
		}

		public override void UnInit()
		{
			_gnnGateBehaviour.OnGNNGateCompleted.UnRegisterMainThread(HandleGNNGateCompleted);
			base.UnInit();
		}

		public override void Update()
		{
		}

		public override BehaviourSaveStateDto GetSaveState()
		{
			return new GNNGateActivationSaveStateDto
			{
				IsActivated = _isActivated
			};
		}
	}
}
