using Lightbug.CharacterControllerPro.Core;
using Lightbug.CharacterControllerPro.Implementation;
using Lightbug.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Character/AI/Follow Behaviour")]
	public class AIFollowBehaviour : CharacterAIBehaviour
	{
		[Tooltip("The target transform used by the follow behaviour.")]
		[SerializeField]
		private Transform followTarget;

		[Tooltip("Desired distance to the target. if the distance to the target is less than this value the character will not move.")]
		[SerializeField]
		private float reachDistance = 3f;

		[Tooltip("The wait time between actions updates.")]
		[Min(0f)]
		[SerializeField]
		private float refreshTime = 0.65f;

		private float timer;

		private NavMeshPath navMeshPath;

		protected CharacterStateController stateController;

		protected override void Awake()
		{
			base.Awake();
			stateController = this.GetComponentInBranch<CharacterActor, CharacterStateController>();
			stateController.MovementReferenceMode = MovementReferenceParameters.MovementReferenceMode.World;
		}

		private void OnEnable()
		{
			navMeshPath = new NavMeshPath();
		}

		public override void EnterBehaviour(float dt)
		{
			timer = refreshTime;
		}

		public override void UpdateBehaviour(float dt)
		{
			if (timer >= refreshTime)
			{
				timer = 0f;
				UpdateFollowTargetBehaviour(dt);
			}
			else
			{
				timer += dt;
			}
		}

		public void SetFollowTarget(Transform followTarget, bool forceUpdate = true)
		{
			this.followTarget = followTarget;
			if (forceUpdate)
			{
				timer = refreshTime + Mathf.Epsilon;
			}
		}

		private void UpdateFollowTargetBehaviour(float dt)
		{
			if (followTarget == null)
			{
				return;
			}
			characterActions.Reset();
			NavMesh.CalculatePath(base.transform.position, followTarget.position, -1, navMeshPath);
			if (navMeshPath.corners.Length >= 2)
			{
				Vector3 movementAction = navMeshPath.corners[1] - navMeshPath.corners[0];
				if ((navMeshPath.corners.Length != 2 || !(movementAction.magnitude <= reachDistance)) && navMeshPath.corners.Length > 1)
				{
					SetMovementAction(movementAction);
				}
			}
		}
	}
}
