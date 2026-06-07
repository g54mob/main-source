using UnityEngine;

namespace ScheduleOne
{
	public class InputDescriptor : MonoBehaviour
	{
		[Tooltip("Assign a InputDescriptorData scriptableObject. The scriptableObject should be placed in Assets/CustomUI/InputDescriptor")]
		[SerializeField]
		private InputDescriptorData data;

		[Tooltip("Assign the UITrigger component that suppose to detect and receive input when the input action from the InputDescriptorData is fired")]
		[SerializeField]
		private UITrigger uiTrigger;

		public void DetectTriggerInput()
		{
		}

		public void OnReset()
		{
		}

		public bool GetInputTriggered()
		{
			return false;
		}

		public T GetInputValue<T>() where T : struct
		{
			return default(T);
		}
	}
}
