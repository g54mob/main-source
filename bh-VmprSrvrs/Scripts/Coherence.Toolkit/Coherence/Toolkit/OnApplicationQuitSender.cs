using UnityEngine;

namespace Coherence.Toolkit
{
	[DefaultExecutionOrder(1000)]
	internal class OnApplicationQuitSender : MonoBehaviour
	{
		[RuntimeInitializeOnLoadMethod]
		internal static void InstantiateSender()
		{
		}

		private void OnApplicationQuit()
		{
		}
	}
}
