using UnityEngine;
using UnityEngine.UI;

namespace RefiTools
{
	[RequireComponent(typeof(Image))]
	public class TweenUIImageColor : TweenBase
	{
		[SerializeField]
		[Header("Image物件")]
		private Image image;

		[Header("顏色設定")]
		[SerializeField]
		private Gradient gradient;

		protected override void UpdateTween()
		{
		}

		protected override void Reset()
		{
		}

		protected override void OnValidate()
		{
		}
	}
}
