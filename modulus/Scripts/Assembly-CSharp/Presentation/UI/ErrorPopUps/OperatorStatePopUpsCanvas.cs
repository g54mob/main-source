using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using UnityEngine;
using Utils;

namespace Presentation.UI.ErrorPopUps
{
	public class OperatorStatePopUpsCanvas : MonoBehaviour
	{
		[SerializeField]
		private int _popUpPoolSize = 20;

		[SerializeField]
		private OperatorStatePopUp _popUpPrefab;

		[SerializeField]
		private Transform _popUpPoolParent;

		private ComponentPool<OperatorStatePopUp> _popUpPool;

		private Dictionary<FactoryObject, OperatorStatePopUp> _factoryObjectPopUps;

		private void Awake()
		{
			_factoryObjectPopUps = new Dictionary<FactoryObject, OperatorStatePopUp>();
			_popUpPool = new ComponentPool<OperatorStatePopUp>(_popUpPoolSize, _popUpPrefab, _popUpPoolParent);
			OperatorStateBehaviour.OnStateSet.RegisterMainThread(OnStateSet);
			OperatorStateBehaviour.OnStateReset.RegisterMainThread(OnStateReset);
			OperatorStateBehaviour.OnStateShow.RegisterMainThread(OnStateShow);
			OperatorStateBehaviour.OnStateHide.RegisterMainThread(OnStateHide);
		}

		private void OnDestroy()
		{
			OperatorStateBehaviour.OnStateSet.UnRegisterMainThread(OnStateSet);
			OperatorStateBehaviour.OnStateReset.UnRegisterMainThread(OnStateReset);
			OperatorStateBehaviour.OnStateShow.UnRegisterMainThread(OnStateShow);
			OperatorStateBehaviour.OnStateHide.UnRegisterMainThread(OnStateHide);
		}

		private void OnStateSet(FactoryObject factoryObject, OperatorStateBehaviour.State state)
		{
			if (_factoryObjectPopUps.TryGetValue(factoryObject, out var value))
			{
				value.SetState(factoryObject, state, this);
				return;
			}
			OperatorStatePopUp component = _popUpPool.GetComponent();
			component.SetState(factoryObject, state, this);
			_factoryObjectPopUps.Add(factoryObject, component);
			component.gameObject.SetActive(value: true);
		}

		private void OnStateReset(FactoryObject factoryObject)
		{
			if (_factoryObjectPopUps.TryGetValue(factoryObject, out var value))
			{
				value.Reset();
				_popUpPool.ReturnMono(value);
				_factoryObjectPopUps.Remove(factoryObject);
			}
		}

		private void OnStateShow(FactoryObject factoryObject)
		{
			if (_factoryObjectPopUps.TryGetValue(factoryObject, out var value))
			{
				value.Show();
			}
		}

		private void OnStateHide(FactoryObject factoryObject)
		{
			if (_factoryObjectPopUps.TryGetValue(factoryObject, out var value))
			{
				value.Hide();
			}
		}

		public void ReturnPopUpToPool(OperatorStatePopUp operatorStatePopUp)
		{
			operatorStatePopUp.Reset();
			_factoryObjectPopUps.Remove(operatorStatePopUp.FactoryObject);
			_popUpPool.ReturnMono(operatorStatePopUp);
		}
	}
}
