using System.Collections.Generic;
using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class PlayerMiniatureBoxStack : ObjectStack
	{
		[Header("Anchors")]
		[SerializeField]
		private Transform[] m_anchors;

		[SerializeField]
		private LayerMask m_collisionLayerMask;

		[Header("Input hint")]
		[SerializeField]
		private InputHint m_inputHint;

		private bool m_containsMiniatureBox;

		private void RearrangeAll()
		{
			RearrangeFrom(0);
		}

		private void RearrangeFrom(int startIndex)
		{
			if (m_stack == null || !m_containsMiniatureBox)
			{
				return;
			}
			Queue<int> queue = new Queue<int>();
			for (int i = startIndex; i < m_stack.Length; i++)
			{
				if (m_stack[i] == null)
				{
					queue.Enqueue(i);
				}
				else if (m_stack[i] != null && queue.Count > 0)
				{
					IStackable stackable = m_stack[i];
					int num = queue.Dequeue();
					m_stack[num] = stackable;
					stackable.Anchor(m_container, GetIndexedStackPosition(num, stackable.Bounds));
					m_stack[i] = null;
					queue.Enqueue(i);
				}
			}
		}

		protected override int GetLastOccupiedIndex()
		{
			for (int i = 0; i < base.Size; i++)
			{
				if (m_stack[i] != null)
				{
					return i;
				}
			}
			return -1;
		}

		protected override void OnStackNewType(IStackable stackable)
		{
			m_containsMiniatureBox = stackable is MiniatureBoxProduct;
			base.OnStackNewType(stackable);
			if (m_containsMiniatureBox)
			{
				m_stack = new IStackable[m_anchors.Length];
			}
		}

		protected override void OnStack(int index, IStackable stackable)
		{
			base.OnStack(index, stackable);
			if (CanUseInputHint(stackable, out var product))
			{
				if (CanShowInputHintInstant())
				{
					ShowInputHint(product);
				}
				else
				{
					DelayedShowInputHint();
				}
			}
		}

		protected override void OnUnstacked(int index, IStackable stackable)
		{
			base.OnUnstacked(index, stackable);
			RearrangeFrom(index);
		}

		protected override void OnEmpty()
		{
			base.OnEmpty();
			m_inputHint.enabled = false;
			PlayerSensor.SensableChanged -= OnSensableChanged_TryShowInputHint;
		}

		protected override Vector3 GetIndexedStackPosition(int index, Bounds stackableBounds)
		{
			if (m_containsMiniatureBox)
			{
				return m_container.InverseTransformPoint(m_anchors[index].position);
			}
			return base.GetIndexedStackPosition(index, stackableBounds);
		}

		private bool CanUseInputHint(IStackable stackable, out Product product)
		{
			product = stackable as Product;
			if (product != null && product.InputHint != null)
			{
				return !product.InputHint.enabled;
			}
			return false;
		}

		private bool CanShowInputHintInstant()
		{
			ISensable currentSensable = World.PlayerController.Sensor.CurrentSensable;
			if (currentSensable is IMainInteractable mainInteractable)
			{
				if (mainInteractable.CanMainInteract(World.PlayerCharacter))
				{
					return false;
				}
			}
			else if (currentSensable is ISecondInteractable secondInteractable)
			{
				if (secondInteractable.CanSecondInteract(World.PlayerCharacter))
				{
					return false;
				}
			}
			else if (currentSensable is IHoldInteractable holdInteractable)
			{
				if (holdInteractable.CanMainHoldInteractBy(World.PlayerCharacter))
				{
					return false;
				}
				if (holdInteractable.CanSecondHoldInteractBy(World.PlayerCharacter))
				{
					return false;
				}
			}
			return true;
		}

		private void DelayedShowInputHint()
		{
			PlayerSensor.SensableChanged += OnSensableChanged_TryShowInputHint;
		}

		private void OnSensableChanged_TryShowInputHint(ISensable former, ISensable next)
		{
			PlayerSensor.SensableChanged -= OnSensableChanged_TryShowInputHint;
			if (CanShowInputHintInstant() && m_stack.IsValid())
			{
				ShowInputHint((Product)m_stack[0]);
			}
		}

		private void ShowInputHint(Product product)
		{
			m_inputHint.SetDatas(product.InputHint.GetDatas());
			m_inputHint.enabled = true;
		}
	}
}
