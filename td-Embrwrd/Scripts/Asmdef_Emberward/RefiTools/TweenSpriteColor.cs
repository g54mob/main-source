using UnityEngine;

namespace RefiTools
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class TweenSpriteColor : TweenBase
	{
		[Header("Sprite Renderer物件")]
		[SerializeField]
		private SpriteRenderer spriteRenderer;

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
