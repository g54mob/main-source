using System.Collections.Generic;
using UnityEngine;

namespace Plugins.Runtime.Animators
{
	public class AnimatorRandomBehaviour : StateMachineBehaviour, ISerializationCallbackReceiver
	{
		[SerializeField]
		private RuntimeAnimatorController animatorController;

		[SerializeField]
		private float crossfadeTime = 0.1f;

		[SerializeField]
		private float repeatThreshold = 0.5f;

		[SerializeField]
		private List<int> statesNames = new List<int>();

		private bool isCrossFading;

		private int isCrossFadingFromThis;

		private float lastPickTime = float.NegativeInfinity;

		private int lastPick;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (!isCrossFading)
			{
				float time = Time.time;
				int index;
				if (time - lastPickTime > repeatThreshold || lastPick >= statesNames.Count)
				{
					lastPickTime = time;
					index = (lastPick = Random.Range(0, statesNames.Count));
				}
				else
				{
					index = lastPick;
				}
				int num = statesNames[index];
				if (num != stateInfo.shortNameHash)
				{
					animator.CrossFade(num, crossfadeTime, layerIndex);
					isCrossFadingFromThis = stateInfo.fullPathHash;
				}
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (isCrossFadingFromThis == stateInfo.shortNameHash)
			{
				isCrossFading = false;
				isCrossFadingFromThis = -1;
			}
		}

		[ContextMenu("Collect States")]
		private void CollectStates()
		{
		}

		public void OnBeforeSerialize()
		{
			CollectStates();
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
