using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_Deliveries : CTSBehaviour
	{
		[SerializeField]
		private UI_Delivery _prefab;

		private Dictionary<Delivery, UI_Delivery> _currentDeliveries = new Dictionary<Delivery, UI_Delivery>();

		private Stack<UI_Delivery> _deliveryPool = new Stack<UI_Delivery>();

		protected override void OnAwake()
		{
			base.OnAwake();
			Deliveries.DeliveryCreated += OnDeliveryCreated;
			Deliveries.DeliveryCompleted += OnDeliveryComplete;
		}

		private void OnDestroy()
		{
			Deliveries.DeliveryCreated -= OnDeliveryCreated;
			Deliveries.DeliveryCompleted -= OnDeliveryComplete;
		}

		private UI_Delivery GetDelivery()
		{
			if (_deliveryPool.Count <= 0)
			{
				return CTSFactory.Instantiate(_prefab, base.transform, instantiateInWorldSpace: false, false);
			}
			return _deliveryPool.Pop();
		}

		private void OnDeliveryCreated(Delivery delivery)
		{
			if (!_currentDeliveries.ContainsKey(delivery))
			{
				UI_Delivery delivery2 = GetDelivery();
				delivery2.SetDelivery(delivery);
				delivery2.gameObject.SetActive(value: true);
				_currentDeliveries.Add(delivery, delivery2);
			}
		}

		private void OnDeliveryComplete(Delivery delivery)
		{
			if (_currentDeliveries.TryGetValue(delivery, out var value))
			{
				value.gameObject.SetActive(value: false);
				_deliveryPool.Push(value);
				_currentDeliveries.Remove(delivery);
			}
		}
	}
}
