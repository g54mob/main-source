using Assets.Nimbatus.Scripts.Animations;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Tutorial.TutorialScenes
{
	public class TutorialKeepTouchingTarget : MonoBehaviour
	{
		public bool Touched;

		public string ActivateSound;

		public string DeactivateSound;

		public Color ColorReachedA;

		public Color ColorReachedB;

		public Color ColorNotReachedA;

		public Color ColorNotReachedB;

		public SpriteSinusColorFader Fader;

		private int _numberOfOverlaps;

		private bool _previouslyTouched;

		private void Update()
		{
			_previouslyTouched = Touched;
			if (_numberOfOverlaps > 0)
			{
				Touched = true;
				if (!_previouslyTouched && ActivateSound != "")
				{
					AudioController.Play(ActivateSound);
				}
			}
			else
			{
				Touched = false;
				if (_previouslyTouched && DeactivateSound != "")
				{
					AudioController.Play(DeactivateSound);
				}
			}
			if (Fader != null)
			{
				if (Touched)
				{
					Fader.colorA = ColorReachedA;
					Fader.colorB = ColorReachedB;
				}
				else
				{
					Fader.colorA = ColorNotReachedA;
					Fader.colorB = ColorNotReachedB;
				}
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.layer == 9)
			{
				_numberOfOverlaps++;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.layer == 9)
			{
				_numberOfOverlaps--;
			}
		}
	}
}
