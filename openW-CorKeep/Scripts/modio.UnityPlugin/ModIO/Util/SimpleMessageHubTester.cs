using System.Collections;
using UnityEngine;

namespace ModIO.Util
{
	internal class SimpleMessageHubTester : SelfInstancingMonoSingleton<SimpleMessageHubTester>
	{
		private SimpleMessageUnsubscribeToken subToken;

		public void RunTest()
		{
			subToken = SelfInstancingMonoSingleton<SimpleMessageHub>.Instance.Subscribe(delegate(MessagePoke x)
			{
				Debug.Log($"I got a message! {x.number}");
			});
			StartCoroutine(PokeMessages());
		}

		private IEnumerator PokeMessages()
		{
			for (int i = 0; i < 10; i++)
			{
				SelfInstancingMonoSingleton<SimpleMessageHub>.Instance.Publish(new MessagePoke
				{
					number = i
				});
				yield return new WaitForSeconds(0.5f);
			}
			Debug.Log("Unsubscribing!");
			subToken.Unsubscribe();
			SelfInstancingMonoSingleton<SimpleMessageHub>.Instance.Publish(new MessagePoke
			{
				number = 99
			});
		}
	}
}
