using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class CardMachine : MonoBehaviour
	{
		[Header("UI")]
		[SerializeField]
		private UI_CardMachine m_interface;

		[Header("3D")]
		[SerializeField]
		private CardMachineModelVisual m_interface3D;

		public UI_CardMachine Interface => m_interface;

		public bool IsActive { get; private set; }

		public event Action<float> Validated
		{
			add
			{
				m_interface.Validated += value;
			}
			remove
			{
				m_interface.Validated -= value;
			}
		}

		private void OnEnable()
		{
			m_interface.OnUIButtonSelected += OnUIButtonSelected;
		}

		private void OnDisable()
		{
			m_interface.OnUIButtonSelected -= OnUIButtonSelected;
		}

		private void OnUIButtonSelected(int buttonIndex)
		{
			m_interface3D.HighLightIndex(buttonIndex);
		}

		public void Show(bool show)
		{
			if (IsActive != show)
			{
				IsActive = show;
				base.gameObject.SetActive(IsActive);
				m_interface.SetActive(IsActive);
			}
		}
	}
}
