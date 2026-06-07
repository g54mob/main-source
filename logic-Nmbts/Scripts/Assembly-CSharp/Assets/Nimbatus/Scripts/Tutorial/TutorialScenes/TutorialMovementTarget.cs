using Assets.Nimbatus.Scripts.Animations;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Tutorial.TutorialScenes
{
	public class TutorialMovementTarget : MonoBehaviour
	{
		public enum EMovementTargetState
		{
			Deactivated = 0,
			ActiveTurnedOff = 1,
			ActiveTurnedOn = 2
		}

		[HideInInspector]
		public EMovementTargetState State;

		public SpriteSinusColorFader Fader;

		public string ActivateSound;

		public GameObject DeactivateSprite;

		public Color ColorActiveTurnedOnA;

		public Color ColorActiveTurnedOnB;

		public Color ColorActiveTurnedOffA;

		public Color ColorActiveTurnedOffB;

		private void OnAwake()
		{
			State = EMovementTargetState.Deactivated;
		}

		private void Update()
		{
			if (Fader != null)
			{
				if (State == EMovementTargetState.ActiveTurnedOn)
				{
					Fader.colorA = ColorActiveTurnedOnA;
					Fader.colorB = ColorActiveTurnedOnB;
				}
				else
				{
					Fader.colorA = ColorActiveTurnedOffA;
					Fader.colorB = ColorActiveTurnedOffB;
				}
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (State == EMovementTargetState.ActiveTurnedOff && other.gameObject.layer == 9)
			{
				State = EMovementTargetState.ActiveTurnedOn;
				if (ActivateSound != "")
				{
					AudioController.Play(ActivateSound);
				}
			}
		}

		public void ActivateTarget()
		{
			DeactivateSprite.SetActive(false);
			Fader.gameObject.SetActive(true);
			State = EMovementTargetState.ActiveTurnedOff;
		}
	}
}
