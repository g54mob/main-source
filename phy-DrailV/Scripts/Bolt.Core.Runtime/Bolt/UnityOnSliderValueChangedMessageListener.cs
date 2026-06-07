using UnityEngine;
using UnityEngine.UI;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnSliderValueChangedMessageListener : MessageListener
	{
		private void Start()
		{
			GetComponent<Slider>()?.onValueChanged?.AddListener(delegate(float value)
			{
				EventBus.Trigger("OnSliderValueChanged", base.gameObject, value);
			});
		}
	}
}
