using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class HorizontalLineTest : MonoBehaviour
	{
		[HorizontalLine(2f, EColor.Pink)]
		[HorizontalLine(2f, EColor.Black)]
		[Header("Black")]
		[HorizontalLine(2f, EColor.Blue)]
		[Header("Blue")]
		[HorizontalLine(2f, EColor.Gray)]
		[Header("Gray")]
		[HorizontalLine(2f, EColor.Green)]
		[Header("Green")]
		[HorizontalLine(2f, EColor.Indigo)]
		[Header("Orange")]
		[Header("Indigo")]
		[Header("Yellow")]
		[Header("Pink")]
		[HorizontalLine(2f, EColor.Red)]
		[Header("Red")]
		[HorizontalLine(2f, EColor.Orange)]
		[Header("Violet")]
		[HorizontalLine(2f, EColor.White)]
		[Header("White")]
		[HorizontalLine(2f, EColor.Yellow)]
		[HorizontalLine(2f, EColor.Violet)]
		[Header("Thick")]
		[HorizontalLine(10f, EColor.Gray)]
		public int line0;

		public HorizontalLineNest1 nest1;
	}
}
