using System.Runtime.InteropServices;
using Unity.NetCode;

namespace Pug.ECS.Components.Generated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal struct ClientInputDataEventHelper : IInputEventHelper<ClientInputData>
	{
		public void DecrementEvents(ref ClientInputData input, in ClientInputData prevInput)
		{
		}

		public void IncrementEvents(ref ClientInputData input, in ClientInputData lastInput)
		{
		}

		void IInputEventHelper<ClientInputData>.DecrementEvents(ref ClientInputData inputData, in ClientInputData prevInputData)
		{
			DecrementEvents(ref inputData, in prevInputData);
		}

		void IInputEventHelper<ClientInputData>.IncrementEvents(ref ClientInputData inputData, in ClientInputData lastInputData)
		{
			IncrementEvents(ref inputData, in lastInputData);
		}
	}
}
