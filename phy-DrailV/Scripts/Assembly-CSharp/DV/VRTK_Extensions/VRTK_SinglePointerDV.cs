using DV.Utils;
using UnityEngine;
using VRTK;

namespace DV.VRTK_Extensions
{
	public class VRTK_SinglePointerDV : MonoBehaviour
	{
		public VRTK_UIPointer relatedPointer;

		public VRTK_ControllerEvents controllerEvents;

		private void OnEnable()
		{
			controllerEvents.TriggerPressed += TriggerPressed;
			SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.Register(this);
		}

		private void OnDisable()
		{
			if (controllerEvents != null)
			{
				controllerEvents.TriggerPressed -= TriggerPressed;
			}
			if (SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance != null)
			{
				SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.Unregister(this);
			}
		}

		public void TogglePointer(bool on)
		{
			relatedPointer.gameObject.SetActive(on);
		}

		private void TriggerPressed(object sender, ControllerInteractionEventArgs e)
		{
			VRTK_SinglePointerControllerDV instance = SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance;
			if (instance.PointerRequested)
			{
				instance.MakeActive(this);
			}
		}
	}
}
