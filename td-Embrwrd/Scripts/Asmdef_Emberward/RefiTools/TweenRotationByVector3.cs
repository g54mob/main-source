using UnityEngine;

namespace RefiTools
{
	public class TweenRotationByVector3 : TweenBase
	{
		[Header("開始位置")]
		[SerializeField]
		private Vector3 startRotation;

		[Header("結束位置")]
		[SerializeField]
		private Vector3 endRotation;

		protected override void UpdateTween()
		{
		}
	}
}
