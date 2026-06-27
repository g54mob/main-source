using System.Collections;
using Restory.Constants;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class ElementPhysicsHandler : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody rigidBody;

		private readonly float minDescentMagnitude = 0.01f;

		private readonly float minDescentTimeInSeconds = 0.2f;

		private Coroutine reachSurfaceAndFreezeCoroutine;

		public bool IsElementInMotion => reachSurfaceAndFreezeCoroutine != null;

		private void OnDisable()
		{
			if (reachSurfaceAndFreezeCoroutine != null)
			{
				StopCoroutine(reachSurfaceAndFreezeCoroutine);
				reachSurfaceAndFreezeCoroutine = null;
			}
		}

		public virtual void TogglePhysics(bool enable)
		{
			if (reachSurfaceAndFreezeCoroutine != null)
			{
				StopCoroutine(reachSurfaceAndFreezeCoroutine);
			}
			rigidBody.isKinematic = !enable;
			if (enable && base.gameObject.activeInHierarchy)
			{
				reachSurfaceAndFreezeCoroutine = StartCoroutine(WaitUntilReachSurfaceAndFreeze());
			}
		}

		private IEnumerator WaitUntilReachSurfaceAndFreeze()
		{
			yield return new WaitForSeconds(minDescentTimeInSeconds);
			while (rigidBody.linearVelocity.magnitude > minDescentMagnitude)
			{
				yield return null;
			}
			ResetElementLayer();
			reachSurfaceAndFreezeCoroutine = null;
		}

		protected virtual void ResetElementLayer()
		{
			if (base.gameObject.layer != 0)
			{
				SetPhysicsLayer(ProjectConstants.Layers.Elements);
			}
		}

		public void SetPhysicsLayer(int layer)
		{
			base.gameObject.layer = layer;
			rigidBody.gameObject.layer = layer;
		}
	}
}
