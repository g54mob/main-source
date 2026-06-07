using UnityEngine;

namespace RefiTools
{
	public class TweenScaleByVector3 : TweenBase
	{
		[Header("開始尺寸")]
		[SerializeField]
		private Vector3 startScale;

		[Header("結束尺寸")]
		[SerializeField]
		private Vector3 endScale;

		protected override void UpdateTween()
		{
		}
	}
}
