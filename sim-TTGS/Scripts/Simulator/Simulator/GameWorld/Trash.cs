using Dhs5.Utility.Databases;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class Trash : Dirt, ISensable, IStackable
	{
		[SerializeField]
		private Outline m_outline;

		[SerializeField]
		private ToggleInputHint m_inputHint;

		[SerializeField]
		private Rigidbody m_rigidbody;

		[SerializeField]
		private BoxCollider[] m_colliders;

		[SerializeField]
		private ClippingObjectBehaviour m_clippingObjectBehaviour;

		private bool m_isStacked;

		private Bounds m_bounds = new Bounds(new Vector3(0f, 0.5f, 0f), new Vector3(0.14f, 1f, 0.08f));

		public bool IsStacked => m_isStacked;

		public IStackableData StackableData => base.DirtData as TrashData;

		public ClippingObjectBehaviour ClippingObjectBehaviour => m_clippingObjectBehaviour;

		public Bounds Bounds => m_bounds;

		Transform IStackable.transform => base.transform;

		public void Drop(Vector3 worldPosition)
		{
			base.transform.position = worldPosition;
			m_rigidbody.isKinematic = false;
			BoxCollider[] colliders = m_colliders;
			for (int i = 0; i < colliders.Length; i++)
			{
				colliders[i].enabled = true;
			}
			m_isStacked = false;
			m_inputHint.enabled = false;
			RefreshInputHint();
			World.DirtManager.Register(this);
		}

		public void OnRecycled()
		{
			World.DirtManager.Unregister(this);
		}

		public bool CanBeSensed()
		{
			if (World.PlayerController.Context == EControllerContext.CHARACTER)
			{
				EPlayerCharacterContext characterContext = World.PlayerCharacter.CharacterContext;
				if ((characterContext == EPlayerCharacterContext.NONE || characterContext == EPlayerCharacterContext.GRABBING) && !m_isStacked)
				{
					return World.PlayerCharacter.CanHandleStackable(this);
				}
			}
			return false;
		}

		public void OnSensed()
		{
			m_outline.enabled = true;
			m_inputHint.enabled = true;
			RefreshInputHint();
		}

		public void OnUnsensed()
		{
			m_outline.enabled = false;
			if (!m_isStacked)
			{
				m_inputHint.enabled = false;
			}
		}

		private void RefreshInputHint()
		{
			if (!(m_inputHint == null))
			{
				m_inputHint.RemoveFlagsAndRefreshInputHint((ToggleInputHint.EActionStates)(-1));
				m_inputHint.AddFlagsAndRefreshInputHint((!m_isStacked) ? ToggleInputHint.EActionStates.TRUE : ToggleInputHint.EActionStates.FALSE);
			}
		}

		public void OnPreStackedIn(ObjectStack stack)
		{
			m_rigidbody.isKinematic = true;
			BoxCollider[] colliders = m_colliders;
			for (int i = 0; i < colliders.Length; i++)
			{
				colliders[i].enabled = false;
			}
			m_isStacked = true;
			World.DirtManager.Unregister(this);
		}

		public void OnStackedIn(ObjectStack stack)
		{
			m_inputHint.enabled = true;
			RefreshInputHint();
		}

		public void OnUnstackedFrom(ObjectStack stack)
		{
		}

		public T GetData<T>() where T : BaseDataContainerScriptableElement
		{
			if (base.DirtData is T result)
			{
				return result;
			}
			return null;
		}
	}
}
