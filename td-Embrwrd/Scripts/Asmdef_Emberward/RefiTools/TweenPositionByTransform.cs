using UnityEngine;

namespace RefiTools
{
	public class TweenPositionByTransform : TweenBase
	{
		[SerializeField]
		[Header("開始位置")]
		private Transform startPosition;

		[SerializeField]
		[Header("結束位置")]
		private Transform endPosition;

		protected override void UpdateTween()
		{
		}
	}
}
