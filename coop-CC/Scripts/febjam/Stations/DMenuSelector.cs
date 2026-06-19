using Aggro.Core;
using UnityEngine;

namespace Stations
{
	public class DMenuSelector : EntityBehaviourBase, IFloaterPopulator
	{
		public BoxCollider activationBoxCollider;

		public LayerMask playerCollisionMask;

		public bool localPlayerWithinBounds;

		private FloaterUI _floaterUI;

		private bool GetPlayerInBounds()
		{
			if (!GameUtil.TryGetLocalPlayer(out var player))
			{
				return false;
			}
			Vector3 center = activationBoxCollider.transform.TransformPoint(activationBoxCollider.center);
			Vector3 halfExtents = activationBoxCollider.size / 2f;
			Collider[] array = Physics.OverlapBox(center, halfExtents, activationBoxCollider.transform.rotation, playerCollisionMask);
			for (int i = 0; i < array.Length; i++)
			{
				Entity entity = array[i].GetComponent<EntityCollider>().entity;
				if (entity == player)
				{
					localPlayerWithinBounds = true;
					return true;
				}
			}
			localPlayerWithinBounds = false;
			return false;
		}

		protected override void OnUpdatePresentation()
		{
			bool playerInBounds = GetPlayerInBounds();
			if (playerInBounds)
			{
				if (AggroInputManager.input.Game.DMenuLeft.WasPressedThisFrame())
				{
					base.entity.GetObject<IDMenuSelector>().LeftPressed();
				}
				if (AggroInputManager.input.Game.DMenuRight.WasPressedThisFrame())
				{
					base.entity.GetObject<IDMenuSelector>().RightPressed();
				}
			}
			if (_floaterUI != null)
			{
				_floaterUI.extrasVisible = playerInBounds;
			}
		}

		public void AddedFloater(FloaterUI floaterAdded)
		{
			_floaterUI = floaterAdded;
		}

		public void RemovedFloater()
		{
			_floaterUI = null;
		}
	}
}
