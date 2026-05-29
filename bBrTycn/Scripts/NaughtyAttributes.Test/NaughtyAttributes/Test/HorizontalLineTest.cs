using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class HorizontalLineTest : MonoBehaviour
	{
		[HorizontalLine(2f, EColor.Black)]
		[Header("Black")]
		[HorizontalLine(2f, EColor.Blue)]
		[Header("Blue")]
		[HorizontalLine(2f, EColor.Gray)]
		[Header("Gray")]
		[HorizontalLine(2f, EColor.Green)]
		[Header("Green")]
		[HorizontalLine(2f, EColor.Indigo)]
		[Header("Indigo")]
		[HorizontalLine(2f, EColor.Orange)]
		[Header("Orange")]
		[HorizontalLine(2f, EColor.Pink)]
		[Header("Pink")]
		[HorizontalLine(2f, EColor.Red)]
		[Header("Red")]
		[HorizontalLine(2f, EColor.Violet)]
		[Header("Violet")]
		[HorizontalLine(2f, EColor.White)]
		[Header("White")]
		[HorizontalLine(2f, EColor.Yellow)]
		[Header("Yellow")]
		[HorizontalLine(10f, EColor.Gray)]
		[Header("Thick")]
		public int line0;

		public HorizontalLineNest1 nest1;
	}
}
