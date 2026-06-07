using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RefiTools
{
	[RequireComponent(typeof(Image))]
	public class TweenUIImageSwap : TweenBase
	{
		[SerializeField]
		[Header("Image物件")]
		private Image image;

		[Header("要替換的圖片清單")]
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
