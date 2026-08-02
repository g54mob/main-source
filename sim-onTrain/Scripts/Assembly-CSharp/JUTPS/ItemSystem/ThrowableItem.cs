using JUTPSEditor.JUHeader;
using UnityEngine;

namespace JUTPS.ItemSystem
{
	public class ThrowableItem : HoldableItem
	{
		[JUHeader("Throw Settings")]
		public string AnimationTriggerParameterName = "Throw";

		public float ThrowForce = 10f;

		public float ThrowUpForce = 10f;

		public float RotationForce = 10f;

		public float SecondsToDestroy = 5f;

		public Vector3 PositionToThrow = new Vector3(0f, 1f, 0.8f);

		public Vector3 DirectionToThrow = Vector3.forward;

		[HideInInspector]
		public bool IsThrowed;

		public override void UseItem()
		{
			if (ItemQuantity > 0 && CanUseItem && !IsThrowed)
			{
				ThrowThis(ThrowForce, ThrowUpForce, PositionToThrow, DirectionToThrow, RotationForce);
				base.UseItem();
			}
		}

		public virtual GameObject ThrowThis(float forceToThrow, float ThrowUpForce, Vector3 positionToThrow, Vector3 directionToThrow, float angularForce = 0f)
		{
			RemoveItem();
			Vector3 position = Owner.transform.TransformPoint(positionToThrow);
			Vector3 vector = Owner.transform.rotation * directionToThrow;
			Vector3 lossyScale = base.transform.lossyScale;
			GameObject gameObject = Object.Instantiate(base.gameObject, position, base.transform.rotation);
			gameObject.transform.localScale = lossyScale;
			gameObject.GetComponent<ThrowableItem>().IsThrowed = true;
			if (SecondsToDestroy > 0f)
			{
				Object.Destroy(gameObject, SecondsToDestroy);
			}
			if (gameObject.TryGetComponent<Rigidbody>(out var component))
			{
				component.isKinematic = false;
				component.AddForce(vector * forceToThrow, ForceMode.Impulse);
				component.AddForce(((Owner != null) ? Owner.transform.up : Vector3.up) * ThrowUpForce, ForceMode.Impulse);
				component.AddTorque(new Vector3(Random.Range(0f - angularForce, angularForce), Random.Range(0f - angularForce, angularForce), Random.Range(0f - angularForce, angularForce)), ForceMode.Impulse);
			}
			if (gameObject.TryGetComponent<Collider>(out var component2))
			{
				component2.enabled = true;
				component2.isTrigger = false;
			}
			return gameObject;
		}

		private void OnDrawGizmos()
		{
			if (Owner == null)
			{
				RefreshItemDependencies();
				return;
			}
			Vector3 vector = Owner.transform.TransformPoint(PositionToThrow);
			Vector3 direction = Owner.transform.rotation * DirectionToThrow;
			Gizmos.DrawSphere(vector, 0.05f);
			Gizmos.DrawRay(vector, direction);
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
