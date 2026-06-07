using UnityEngine;
using UnityEngine.UI;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnScrollRectValueChangedMessageListener : MessageListener
	{
		private void Start()
		{
			GetComponent<ScrollRect>()?.onValueChanged?.AddListener(delegate(Vector2 value)
			{
				EventBus.Trigger("OnScrollRectValueChanged", base.gameObject, value);
			});
		}
	}
}
