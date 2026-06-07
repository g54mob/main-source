using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.App.UI.Bestiary
{
	public class UIBigFuzz : MonoBehaviour
	{
		[SerializeField]
		private Image body;

		[SerializeField]
		private Image head;

		[SerializeField]
		private Image leftHand;

		[SerializeField]
		private Image rightHand;

		[SerializeField]
		private Image leftDoor;

		[SerializeField]
		private Image rightDoor;

		private MultiTargetTween doorOpenTween;

		private Timer rightHandTimer;

		private Timer leftHandTimer;

		private Timer doorTimer;

		public float doorOffset;

		public float handOffset;

		private void Start()
		{
		}

		private void OpenDoors()
		{
		}

		protected void Update()
		{
		}
	}
}
