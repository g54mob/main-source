using System;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class FallingElementCollisionsDetector : MonoBehaviour
	{
		[SerializeField]
		private ElementPhysicsHandler elementPhysicsHandler;

		public event Action<Collision> OnDropHitDetected;

		private void OnCollisionEnter(Collision other)
		{
			if (elementPhysicsHandler.IsElementInMotion)
			{
				this.OnDropHitDetected?.Invoke(other);
			}
		}
	}
}
