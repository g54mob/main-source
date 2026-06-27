using DG.Tweening;
using UnityEngine;

namespace Restory.Data.Disassemble.StateMachine
{
	[CreateAssetMenu(menuName = "Restory/Disassemble/StateMachine/TransitionFromCleaningConfig", fileName = "TransitionFromCleaningConfig")]
	public class TransitionFromCleaningConfig : ScriptableObject
	{
		[SerializeField]
		private float transitionDuration = 1f;

		[SerializeField]
		private Ease transitionEase = Ease.InQuad;

		public float TransitionDuration => transitionDuration;

		public Ease TransitionEase => transitionEase;
	}
}
