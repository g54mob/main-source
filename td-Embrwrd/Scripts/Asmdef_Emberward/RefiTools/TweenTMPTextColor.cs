using TMPro;
using UnityEngine;

namespace RefiTools
{
	[RequireComponent(typeof(TMP_Text))]
	public class TweenTMPTextColor : TweenBase
	{
		[Header("Sprite Renderer物件")]
		[SerializeField]
		private TMP_Text text;

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
