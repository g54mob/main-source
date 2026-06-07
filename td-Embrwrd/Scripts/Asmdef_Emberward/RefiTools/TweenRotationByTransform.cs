using UnityEngine;

namespace RefiTools
{
	public class TweenRotationByTransform : TweenBase
	{
		[Header("開始位置")]
		[SerializeField]
		private Transform startRotation;

		[SerializeField]
		[Header("結束位置")]
		private Transform endRotation;

		protected override void UpdateTween()
		{
		}
	}
}
