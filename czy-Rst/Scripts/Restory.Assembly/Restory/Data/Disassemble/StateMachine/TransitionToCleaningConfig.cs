using DG.Tweening;
using UnityEngine;

namespace Restory.Data.Disassemble.StateMachine
{
	[CreateAssetMenu(menuName = "Restory/Disassemble/StateMachine/TransitionToCleaningConfig", fileName = "TransitionToCleaningConfig")]
	public class TransitionToCleaningConfig : ScriptableObject
	{
		[SerializeField]
		private float transitionDuration = 1f;

		[SerializeField]
		private Ease transitionEase = Ease.InQuad;

		public float TransitionDuration => transitionDuration;

		public Ease TransitionEase => transitionEase;
	}
}
