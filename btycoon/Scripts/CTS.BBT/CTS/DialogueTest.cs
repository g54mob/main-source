using System.Collections;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class DialogueTest : MonoBehaviour
	{
		private IEnumerator Start()
		{
			yield return new WaitForSeconds(2f);
			MonoSingleton<FeedbackHandler>.Instance.ShowFeedback("Test");
			yield return new WaitForSeconds(2f);
			MonoSingleton<FeedbackHandler>.Instance.ShowFeedback("Test 2");
			yield return new WaitForSeconds(2f);
			MonoSingleton<FeedbackHandler>.Instance.HideFeedback();
			yield return new WaitForSeconds(0.1f);
			MonoSingleton<FeedbackHandler>.Instance.ShowFeedback("Test 3");
		}
	}
}
