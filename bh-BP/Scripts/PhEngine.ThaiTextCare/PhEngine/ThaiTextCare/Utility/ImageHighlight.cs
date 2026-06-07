using UnityEngine;
using UnityEngine.UI;

namespace PhEngine.ThaiTextCare.Utility
{
	public class ImageHighlight : Highlight
	{
		[Header("Components")]
		[SerializeField]
		private Image image;

		[Header("Settings")]
		[SerializeField]
		private float positionOffsetY;

		[SerializeField]
		private float sizeOffsetY;

		public override Highlight Clone(WordHit word)
		{
			return null;
		}

		public override void Dispose()
		{
		}

		public override void PlaceAt(WordHit word)
		{
		}
	}
}
