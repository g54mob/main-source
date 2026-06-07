using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class EnableOnGadgetPower : MonoBehaviour
	{
		public GameObject enableOnPower;

		public MonoBehaviour enableOnPowerComponent;

		public LampControl lampOnPower;

		private GadgetBase gadget;

		private void Awake()
		{
			gadget = GetComponent<GadgetBase>();
			gadget.PowerStateChanged += StateChanged;
			StateChanged(gadget, gadget.PowerState);
		}

		private void StateChanged(object _, bool state)
		{
			if (enableOnPower != null)
			{
				enableOnPower.SetActive(state);
			}
			if (enableOnPowerComponent != null)
			{
				enableOnPowerComponent.enabled = state;
			}
			if (lampOnPower != null)
			{
				lampOnPower.SetLampState(state ? LampControl.LampState.On : LampControl.LampState.Off);
			}
		}
	}
}
