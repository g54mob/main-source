using ModIO.Util;
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
			Translation.Get(reference, "Subscribed", delegate(string s)
			{
				Debug.Log("setting " + s);
				testText.text = s;
				testText.ForceMeshUpdate(ignoreActiveState: true);
			});
		}

		[ExposeMethodInEditor]
		public void PokeTranslator()
		{
			SelfInstancingMonoSingleton<SimpleMessageHub>.Instance.Publish(new MessageUpdateTranslations());
		}
	}
}
