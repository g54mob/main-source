using System.Collections.Generic;
using Data.FactoryFloor.Resources;

namespace Data.FactoryFloor
{
	public class FactoryObjectInputBuffer
	{
		public interface IInputFreeEventReceiver
		{
			void OnInputFreedUp(int inputIndex, int outputIndex);
		}

		private struct InputFreeEventData
		{
			public int InstanceID;

			public IInputFreeEventReceiver Receiver;

			public int OutputIndex;
		}

		private List<InputFreeEventData> OnInputFreeEvents { get; set; }

		public Resource Resource { get; set; }

		public FactoryObjectInputBuffer(Resource resource)
		{
			Resource = resource;
			OnInputFreeEvents = new List<InputFreeEventData>();
		}

		public void UnRegisterOnInputFreeEvent(int instanceID)
		{
			for (int num = OnInputFreeEvents.Count - 1; num >= 0; num--)
			{
				if (instanceID == OnInputFreeEvents[num].InstanceID)
				{
					OnInputFreeEvents.RemoveAt(num);
					break;
				}
			}
		}

		public void RegisterOnInputFreeEvent(int instanceID, IInputFreeEventReceiver inputFreeEventReceiver, int outputIndex)
		{
			InputFreeEventData item = new InputFreeEventData
			{
				InstanceID = instanceID,
				Receiver = inputFreeEventReceiver,
				OutputIndex = outputIndex
			};
			OnInputFreeEvents.Add(item);
		}

		public void CallClearedInputBufferEvent(int inputIndex)
		{
			if (OnInputFreeEvents.Count > 0)
			{
				InputFreeEventData inputFreeEventData = OnInputFreeEvents[0];
				OnInputFreeEvents.RemoveAt(0);
				inputFreeEventData.Receiver.OnInputFreedUp(inputIndex, inputFreeEventData.OutputIndex);
			}
		}
	}
}
