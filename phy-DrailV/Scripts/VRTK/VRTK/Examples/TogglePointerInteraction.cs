using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;

namespace VRTK.Examples
{
	public class TogglePointerInteraction : MonoBehaviour
	{
		public enum OptionType
		{
			InteractWithObjects = 0,
			GrabToPointerTip = 1
		}

		public OptionType optionType;

		public VRTK_Pointer[] pointers = new VRTK_Pointer[0];

		public VRTK_BaseControllable controllable;

		public Text displayText;

		public string maxText;

		public string minText;

		protected virtual void OnEnable()
		{
			controllable = ((controllable == null) ? GetComponent<VRTK_BaseControllable>() : controllable);
			if (controllable != null)
			{
				controllable.MaxLimitReached += MaxLimitReached;
				controllable.MinLimitReached += MinLimitReached;
			}
		}

		protected virtual void OnDisable()
		{
			if (controllable != null)
			{
				controllable.MaxLimitReached -= MaxLimitReached;
				controllable.MinLimitReached -= MinLimitReached;
			}
		}

		protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
		{
			SetOption(value: true, maxText);
		}

		protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
		{
			SetOption(value: false, minText);
		}

		protected virtual void SetOption(bool value, string text)
		{
			if (displayText != null)
			{
				displayText.text = text;
			}
			VRTK_Pointer[] array = pointers;
			foreach (VRTK_Pointer vRTK_Pointer in array)
			{
				vRTK_Pointer.enabled = false;
				vRTK_Pointer.pointerRenderer.enabled = false;
				switch (optionType)
				{
				case OptionType.InteractWithObjects:
					vRTK_Pointer.interactWithObjects = value;
					break;
				case OptionType.GrabToPointerTip:
					vRTK_Pointer.grabToPointerTip = value;
					break;
				}
				vRTK_Pointer.pointerRenderer.enabled = true;
				vRTK_Pointer.enabled = true;
			}
		}
	}
}
