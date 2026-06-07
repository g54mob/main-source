using UnityEngine;

namespace RefiTools
{
	public class TweenPositionAndRotationByVector3 : TweenBase
	{
		[Header("開始位置")]
		[SerializeField]
		private Vector3 startPosition;

		[SerializeField]
		[Header("開始位置")]
		private Vector3 startRotation;

		[SerializeField]
		[Header("結束位置")]
		private Vector3 endPosition;

		[SerializeField]
		[Header("結束位置")]
		private Vector3 endRotation;

		[SerializeField]
		[Header("是否是Local")]
		private bool isLocal;

		[ContextMenu("儲存到開始位置")]
		private void SaveCurrentTransformAsStart()
		{
		}

		[ContextMenu("儲存到結束位置")]
		private void SaveCurrentTransformAsEnd()
		{
		}

		protected override void UpdateTween()
		{
		}
	}
}
