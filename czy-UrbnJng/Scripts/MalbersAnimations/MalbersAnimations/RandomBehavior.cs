using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	public class RandomBehavior : StateMachineBehaviour
	{
		[Tooltip("Max Random Value start from 1 to <Range>")]
		public IntReference Range = new IntReference(15);

		[Tooltip("Priority of the Random Behaviour, Other Layers may be using the Random Behaviour too")]
		public IntReference Priority = new IntReference(0);

		private IRandomizer randomizer;

		private static int RandomHash = Animator.StringToHash("Random");

		private bool HasRandomParam;

		private bool checkfirstTime;

		public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
		{
			if (randomizer == null)
			{
				randomizer = animator.GetComponent<IRandomizer>();
			}
			int value = Random.Range(1, (int)Range + 1);
			if (randomizer != null)
			{
				randomizer.SetRandom(value, Priority.Value);
				return;
			}
			FindRandomParam(animator);
			if (HasRandomParam)
			{
				animator.SetInteger(RandomHash, value);
			}
		}

		private void FindRandomParam(Animator animator)
		{
			if (checkfirstTime)
			{
				return;
			}
			HasRandomParam = false;
			AnimatorControllerParameter[] parameters = animator.parameters;
			for (int i = 0; i < parameters.Length; i++)
			{
				if (parameters[i].nameHash == RandomHash)
				{
					HasRandomParam = true;
					break;
				}
			}
			checkfirstTime = true;
		}

		public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
		{
			randomizer?.ResetRandomPriority(Priority);
		}
	}
}
