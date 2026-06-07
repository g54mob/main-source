using System.Collections;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class ConveyorBeltPlatform : Platform
	{
		[SerializeField]
		protected MovementAction movementAction = new MovementAction();

		private Vector3 preSimulationPosition = Vector3.zero;

		private void Start()
		{
			movementAction.Initialize(base.transform);
			StartCoroutine(PostSimulationUpdate());
		}

		private void FixedUpdate()
		{
			float deltaTime = Time.deltaTime;
			preSimulationPosition = base.RigidbodyComponent.Position;
			Vector3 position = preSimulationPosition;
			movementAction.Tick(deltaTime, ref position);
			base.RigidbodyComponent.Move(position);
		}

		private IEnumerator PostSimulationUpdate()
		{
			YieldInstruction waitForFixedUpdate = new WaitForFixedUpdate();
			while (true)
			{
				yield return waitForFixedUpdate;
				base.RigidbodyComponent.Position = preSimulationPosition;
			}
		}
	}
}
