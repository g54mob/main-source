using System.Linq;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class CashObject : MonoBehaviour, ISensable
	{
		[Header("Components")]
		[SerializeField]
		private Outline m_outline;

		[SerializeField]
		private BoxCollider m_boxCollider;

		[SerializeField]
		private CashAmount m_cashAmount;

		[SerializeField]
		private InputHint m_inputHint;

		public ECashAmount CashAmount => m_cashAmount.Get();

		public float Height => m_boxCollider.size.y * base.transform.localScale.y;

		private void Start()
		{
			RefreshInputHint();
		}

		private void OnEnable()
		{
			GameplayApplicationOptions.Currency.OnValueChanged += OnCurrentValueChanged;
		}

		private void OnDisable()
		{
			GameplayApplicationOptions.Currency.OnValueChanged -= OnCurrentValueChanged;
		}

		public bool CanBeSensed()
		{
			return World.PlayerController.Context == EControllerContext.REGISTER;
		}

		public void OnSensed()
		{
			if ((bool)m_outline)
			{
				m_outline.enabled = true;
			}
			if (m_inputHint != null)
			{
				m_inputHint.enabled = true;
			}
		}

		public void OnUnsensed()
		{
			if ((bool)m_outline)
			{
				m_outline.enabled = false;
			}
			if (m_inputHint != null)
			{
				m_inputHint.enabled = false;
			}
		}

		private void OnCurrentValueChanged(GameplayApplicationOptions.ECurrency currency)
		{
			RefreshInputHint();
		}

		private void RefreshInputHint()
		{
			if (!(m_inputHint == null))
			{
				InputHint.Data[] array = m_inputHint.Datas.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					InputHint.Data data = array[i];
					data.formatArgs = m_cashAmount.Get().Name();
					array[i] = data;
				}
				m_inputHint.SetDatas(array);
			}
		}
	}
}
