using UnityEngine;
using UnityEngine.UI;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnButtonClickMessageListener : MessageListener
	{
		private void Start()
		{
			GetComponent<Button>()?.onClick?.AddListener(delegate
			{
				EventBus.Trigger("OnButtonClick", base.gameObject);
			});
		}
	}
}
