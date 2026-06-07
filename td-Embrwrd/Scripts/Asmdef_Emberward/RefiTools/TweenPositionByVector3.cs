using UnityEngine;

namespace RefiTools
{
	public class TweenPositionByVector3 : TweenBase
	{
		[Header("開始位置")]
		[SerializeField]
		private Vector3 startPosition;

		[Header("結束位置")]
		[SerializeField]
		private Vector3 endPosition;

		[Header("是否是Local")]
		[SerializeField]
		private bool isLocal;

		protected override void UpdateTween()
		{
		}

		[ContextMenu("儲存目前數值到開始位置")]
		private void SetCurrentAsStartPosition()
		{
		}

		[ContextMenu("儲存目前數值到結束位置")]
		private void SetCurrentAsEndPosition()
		{
		}

		[ContextMenu("讀取儲存的開始位置")]
		private void LoadStartPosition()
		{
		}

		[ContextMenu("讀取儲存的結束位置")]
		private void LoadEndPosition()
		{
		}
	}
}
