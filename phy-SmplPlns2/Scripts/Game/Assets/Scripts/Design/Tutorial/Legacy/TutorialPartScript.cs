using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Legacy
{
	public class TutorialPartScript : MonoBehaviour
	{
		public TutorialStep TutorialStep { get; set; }

		protected virtual void OnDestroy()
		{
			TutorialStep.OnPartDestroyed();
		}
	}
}
