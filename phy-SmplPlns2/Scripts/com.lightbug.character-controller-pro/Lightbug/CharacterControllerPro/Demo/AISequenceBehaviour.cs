using System.Collections.Generic;
using Lightbug.CharacterControllerPro.Core;
using Lightbug.CharacterControllerPro.Implementation;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Character/AI/Sequence Behaviour")]
	public class AISequenceBehaviour : CharacterAIBehaviour
	{
		private const float DefaultDelayTime = 0.5f;

		[SerializeField]
		private List<CharacterAIAction> actionSequence = new List<CharacterAIAction>();

		private float durationWaitTime;

		private float wallHitWaitTime;

		private int currentActionIndex;

		private void OnEnable()
		{
			base.CharacterActor.OnWallHit += OnWallHit;
		}

		private void OnDisable()
		{
			base.CharacterActor.OnWallHit -= OnWallHit;
		}

		public override void EnterBehaviour(float dt)
		{
			currentActionIndex = 0;
			characterActions = actionSequence[currentActionIndex].action;
			if (actionSequence[currentActionIndex].sequenceType == SequenceType.Duration)
			{
				durationWaitTime = actionSequence[currentActionIndex].duration;
			}
		}

		public override void UpdateBehaviour(float dt)
		{
			if (wallHitWaitTime > 0f)
			{
				wallHitWaitTime = Mathf.Max(0f, wallHitWaitTime - dt);
			}
			if (durationWaitTime > 0f)
			{
				durationWaitTime = Mathf.Max(0f, durationWaitTime - dt);
			}
			if (actionSequence[currentActionIndex].sequenceType != SequenceType.Duration)
			{
				_ = 1;
			}
			else if (durationWaitTime == 0f)
			{
				SelectNextSequenceElement();
			}
		}

		private void SelectNextSequenceElement()
		{
			if (currentActionIndex == actionSequence.Count - 1)
			{
				currentActionIndex = 0;
			}
			else
			{
				currentActionIndex++;
			}
			characterActions = actionSequence[currentActionIndex].action;
			durationWaitTime = actionSequence[currentActionIndex].duration;
		}

		private void OnWallHit(Contact contact)
		{
			if (actionSequence[currentActionIndex].sequenceType == SequenceType.OnWallHit && !(wallHitWaitTime > 0f) && !(contact.gameObject.GetComponent<CharacterActor>() != null))
			{
				SelectNextSequenceElement();
				wallHitWaitTime = 0.5f;
			}
		}
	}
}
