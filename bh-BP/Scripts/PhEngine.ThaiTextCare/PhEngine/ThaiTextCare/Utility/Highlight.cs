using UnityEngine;

namespace PhEngine.ThaiTextCare.Utility
{
	[DisallowMultipleComponent]
	public abstract class Highlight : MonoBehaviour
	{
		[SerializeField]
		private WordHit word;

		public WordHit Word => null;

		public void SetWord(WordHit value)
		{
		}

		public abstract Highlight Clone(WordHit word);

		public abstract void Dispose();

		public abstract void PlaceAt(WordHit word);
	}
}
