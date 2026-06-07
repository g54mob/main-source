using System.Collections.Generic;
using UnityEngine;

namespace RefiTools
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class TweenSpriteSwap : TweenBase
	{
		[SerializeField]
		[Header("Sprite Renderer物件")]
		private SpriteRenderer spriteRenderer;

		[Header("反向播放")]
		[SerializeField]
		private bool isReverse;

		[Header("圖片清單")]
		[SerializeField]
		private List<Sprite> list_Sprites;

		private int lastIndex;

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
