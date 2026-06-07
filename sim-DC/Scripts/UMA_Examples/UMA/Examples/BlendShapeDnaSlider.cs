using UnityEngine;
using UnityEngine.UI;

namespace UMA.Examples
{
	public class BlendShapeDnaSlider : MonoBehaviour
	{
		public int dnaTypeHash;

		public string dnaName;

		public Text statusText;

		protected UMAData data;

		protected UMADnaBase dna;

		private int dnaEntryIndex;

		public void OnCharacterCreated(UMAData umaData)
		{
		}

		public void SetMorph(float value)
		{
		}

		public void BakeMorph(bool isBaked)
		{
		}
	}
}
