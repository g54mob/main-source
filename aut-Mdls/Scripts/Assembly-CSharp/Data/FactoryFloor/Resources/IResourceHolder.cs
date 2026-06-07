using System.Collections.Generic;
using Data.Operator;
using UnityEngine;

namespace Data.FactoryFloor.Resources
{
	public interface IResourceHolder
	{
		void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData));

		bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int));

		void RemoveResource(Resource resource);

		void UpdateOutput();

		IEnumerable<Resource> GetInputResources();

		IEnumerable<Resource> GetOutputResources();

		void ClearResources();

		void RegisterOnInputFreeEvent(int inputIndex, int outputIndex, int createdId, FactoryObjectInputBuffer.IInputFreeEventReceiver inputFreeEventReceiver);

		void UnRegisterOnInputFreeEvent(int inputIndex, int instanceID);
	}
}
