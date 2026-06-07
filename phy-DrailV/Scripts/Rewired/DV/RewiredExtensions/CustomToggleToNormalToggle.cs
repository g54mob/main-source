using Rewired.UI.ControlMapper;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RewiredExtensions
{
	public class CustomToggleToNormalToggle : MonoBehaviour
	{
		public CustomToggle from;

		public Toggle to;

		private void Awake()
		{
			from.onValueChanged.AddListener(delegate(bool on)
			{
				to.SetIsOnWithoutNotify(on);
			});
		}
	}
}
