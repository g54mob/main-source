using TMPro;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	public class UiTranslatorTest : MonoBehaviour
	{
		public TMP_Text testText;

		private Translation reference;

		private void Awake()
		{
		}

		[ExposeMethodInEditor]
		public void PokeTranslator()
		{
		}
	}
}
