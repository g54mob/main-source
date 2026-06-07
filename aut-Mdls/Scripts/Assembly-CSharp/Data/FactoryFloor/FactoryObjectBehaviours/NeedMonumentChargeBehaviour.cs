using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Maps;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events.Islands;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/NeedMonumentChargeBehaviour", fileName = "NeedMonumentChargeBehaviour", order = 0)]
	public class NeedMonumentChargeBehaviour : FactoryObjectBehaviour
	{
		private enum MonumentColor
		{
			Grey = 0,
			Blue = 1,
			Yellow = 2,
			All = 3
		}

		[SerializeField]
		private List<MainThreadBoolVariableSO> _monumentChargedSOs;

		[SerializeField]
		private MonumentColor _monumentColor;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSo;

		[SerializeField]
		private UnlockedIslandEventSO _unlockedIslandEvent;

		private OperatorStateBehaviour _operatorStateBehaviour;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			_operatorStateBehaviour = factoryObject.GetFactoryObjectBehaviour<OperatorStateBehaviour>();
			SetOperatorState(AllMonumentsCharged());
			foreach (MainThreadBoolVariableSO monumentChargedSO in _monumentChargedSOs)
			{
				monumentChargedSO.ValueChanged.RegisterMainThread(SetOperatorState);
			}
			_unlockedIslandEvent.Register(OnIslandUnlocked);
		}

		private void OnIslandUnlocked(IslandObject unlockedIsland)
		{
			if (unlockedIsland == _factoryObject.GetIsland())
			{
				_unlockedIslandEvent.UnRegister(OnIslandUnlocked);
				SetOperatorState(AllMonumentsCharged());
			}
		}

		public override void UnInit()
		{
			base.UnInit();
			foreach (MainThreadBoolVariableSO monumentChargedSO in _monumentChargedSOs)
			{
				monumentChargedSO.ValueChanged.UnRegisterMainThread(SetOperatorState);
			}
			_unlockedIslandEvent.UnRegister(OnIslandUnlocked);
		}

		private bool AllMonumentsCharged()
		{
			foreach (MainThreadBoolVariableSO monumentChargedSO in _monumentChargedSOs)
			{
				if (!monumentChargedSO.Value)
				{
					return false;
				}
			}
			return true;
		}

		private void SetOperatorState(bool _)
		{
			if (!_unlockedIslandsPersistentSo.IsIslandUnlocked(_factoryObject.GetIsland()))
			{
				return;
			}
			if (AllMonumentsCharged())
			{
				_operatorStateBehaviour.ResetState();
				return;
			}
			switch (_monumentColor)
			{
			case MonumentColor.Grey:
				_operatorStateBehaviour.SetStateNeedsGreyCharge();
				break;
			case MonumentColor.Blue:
				_operatorStateBehaviour.SetStateNeedsBlueCharge();
				break;
			case MonumentColor.Yellow:
				_operatorStateBehaviour.SetStateNeedsYellowCharge();
				break;
			case MonumentColor.All:
				_operatorStateBehaviour.SetStateNeedsAllMonumentsCharged();
				break;
			}
		}

		public override void Update()
		{
			SetOperatorState(_: false);
		}
	}
}
