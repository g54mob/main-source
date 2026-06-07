using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class CashBox : MonoBehaviour
	{
		[SerializeField]
		private Transform m_moneyContainer;

		[SerializeField]
		private Vector3 m_openPosition;

		private Vector3 m_closePosition;

		public bool IsOpen { get; private set; }

		public event Action<bool> Opened;

		private void Start()
		{
			m_closePosition = m_moneyContainer.localPosition;
		}

		public void Open(bool open)
		{
			if (IsOpen != open)
			{
				IsOpen = open;
				m_moneyContainer.localPosition = (open ? m_openPosition : m_closePosition);
				this.Opened?.Invoke(IsOpen);
			}
		}
	}
}
