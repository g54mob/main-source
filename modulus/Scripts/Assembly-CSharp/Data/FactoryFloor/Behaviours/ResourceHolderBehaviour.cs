using System;
using System.Collections.Generic;
using Data.FactoryFloor.Resources;
using Data.Operator;
using Logic.Threading.Events;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	public abstract class ResourceHolderBehaviour : FactoryObjectBehaviour, IResourceHolder, FactoryObjectInputBuffer.IInputFreeEventReceiver
	{
		private FactoryObjectInputBuffer[] _inputBuffers = Array.Empty<FactoryObjectInputBuffer>();

		private FactoryObjectOutputBuffer[] _outputBuffers = Array.Empty<FactoryObjectOutputBuffer>();

		private bool _resetInputBuffersOnOutput;

		public MainThreadEvent OnOutputUpdated = new MainThreadEvent();

		public MainThreadEvent<Resource, int> OnOutputResource = new MainThreadEvent<Resource, int>();

		public FactoryObject.OutputFactoryObject[] OutputFactoryObjects => _factoryObject.OutputFactoryObjects;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			InitializeInputBuffers();
			UpdateOutput();
			factoryObject.OnRemovingOutput += OnRemovingOutput;
		}

		public override void UnInit()
		{
			ClearInputBuffers(callInputFreedEvents: false);
			StopTryingToOutput();
			if (_factoryObject != null)
			{
				_factoryObject.OnRemovingOutput -= OnRemovingOutput;
			}
			base.UnInit();
		}

		private void InitializeInputBuffers()
		{
			int count = _factoryObject.DataInputPositions.Count;
			_inputBuffers = new FactoryObjectInputBuffer[count];
			for (int i = 0; i < _inputBuffers.Length; i++)
			{
				_inputBuffers[i] = new FactoryObjectInputBuffer(null);
			}
		}

		private void OnRemovingOutput(int outputIndex)
		{
			FactoryObjectOutputBuffer factoryObjectOutputBuffer = _outputBuffers[outputIndex];
			if (factoryObjectOutputBuffer.HasResourceHolder && IsTryingToOutputAtIndex(outputIndex))
			{
				FactoryObjectData.InputData inputData = OutputFactoryObjects[outputIndex].InputData;
				factoryObjectOutputBuffer.ResourceHolder.UnRegisterOnInputFreeEvent(inputData.Index, GetHashCode());
				factoryObjectOutputBuffer.Reset();
			}
		}

		public virtual void UpdateOutput()
		{
			if (!_initialized)
			{
				return;
			}
			StopTryingToOutput();
			int count = _factoryObject.DataOutputPositions.Count;
			_outputBuffers = new FactoryObjectOutputBuffer[count];
			for (int i = 0; i < count; i++)
			{
				_outputBuffers[i] = new FactoryObjectOutputBuffer();
				if (OutputFactoryObjects[i] != null && OutputFactoryObjects[i].FactoryObject.TryGetResourceHolderBehaviour(out var resourceHolder))
				{
					_outputBuffers[i].SetOutputResourceHolder(resourceHolder);
				}
			}
			OnOutputUpdated.Fire();
		}

		public virtual IEnumerable<Resource> GetInputResources()
		{
			yield break;
		}

		public virtual IEnumerable<Resource> GetOutputResources()
		{
			yield break;
		}

		public virtual bool CanReceiveResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData), Vector3Int position = default(Vector3Int))
		{
			return _inputBuffers[inputData.Index].Resource == null;
		}

		public virtual void AddResource(Resource resource, FactoryObjectData.InputData inputData = default(FactoryObjectData.InputData))
		{
			_inputBuffers[inputData.Index].Resource = resource;
		}

		public virtual void ClearResources()
		{
			ClearInputBuffers(callInputFreedEvents: false);
		}

		public virtual void RemoveResource(Resource resource)
		{
			for (int i = 0; i < _inputBuffers.Length; i++)
			{
				if (GetResourceInInputBuffer(i) == resource)
				{
					TakeResourceFromInputBuffer(i);
					break;
				}
			}
		}

		public void RegisterOnInputFreeEvent(int inputIndex, int outputIndex, int instanceID, FactoryObjectInputBuffer.IInputFreeEventReceiver inputFreeEventReceiver)
		{
			_inputBuffers[inputIndex].RegisterOnInputFreeEvent(instanceID, inputFreeEventReceiver, outputIndex);
		}

		public void UnRegisterOnInputFreeEvent(int inputIndex, int instanceID)
		{
			_inputBuffers[inputIndex].UnRegisterOnInputFreeEvent(instanceID);
		}

		protected bool TryOutput(Resource resource, int outputIndex)
		{
			if (!_outputBuffers[outputIndex].HasResourceHolder || resource == null)
			{
				return false;
			}
			FactoryObjectData.InputData inputData = OutputFactoryObjects[outputIndex].InputData;
			IResourceHolder resourceHolder = _outputBuffers[outputIndex].ResourceHolder;
			if (!resourceHolder.CanReceiveResource(resource, inputData, base.Position))
			{
				_outputBuffers[outputIndex].SetTryingToOutput(resource);
				resourceHolder.RegisterOnInputFreeEvent(inputData.Index, outputIndex, GetHashCode(), this);
				return false;
			}
			_outputBuffers[outputIndex].OutputResource(resource, OutputFactoryObjects[outputIndex].InputData);
			HandleOutputResource(resource, outputIndex);
			if (_resetInputBuffersOnOutput)
			{
				StopTryingToOutput();
				ClearInputBuffers();
			}
			return true;
		}

		public virtual void HandleOutputResource(Resource resource, int outputIndex)
		{
			OnOutputResource.Fire(resource, outputIndex);
		}

		void FactoryObjectInputBuffer.IInputFreeEventReceiver.OnInputFreedUp(int inputIndex, int outputIndex)
		{
			TryOutput(_outputBuffers[outputIndex].ResourceTryingToOutput, outputIndex);
		}

		protected void CallClearedInputBufferEvent(int inputIndex)
		{
			FactoryObjectInputBufferSystem.QueueClearInputBuffer(_inputBuffers[inputIndex], inputIndex);
		}

		public void CallCanReceiveNewResources()
		{
			for (int i = 0; i < _inputBuffers.Length; i++)
			{
				CallClearedInputBufferEvent(i);
			}
		}

		public void StopTryingToOutput()
		{
			for (int i = 0; i < _outputBuffers.Length; i++)
			{
				StopTryingToOutputAtIndex(i);
			}
		}

		public void StopTryingToOutputAtIndex(int outputIndex)
		{
			FactoryObjectOutputBuffer factoryObjectOutputBuffer = _outputBuffers[outputIndex];
			if (factoryObjectOutputBuffer.HasResourceHolder && IsTryingToOutputAtIndex(outputIndex))
			{
				FactoryObjectData.InputData inputData = OutputFactoryObjects[outputIndex].InputData;
				factoryObjectOutputBuffer.ResourceHolder.UnRegisterOnInputFreeEvent(inputData.Index, GetHashCode());
			}
			_outputBuffers[outputIndex].StopTryingToOutput();
		}

		protected bool IsTryingToOutputAtIndex(int outputIndex)
		{
			return _outputBuffers[outputIndex].IsTryingToOutput;
		}

		protected bool IsTryingToOutput()
		{
			FactoryObjectOutputBuffer[] outputBuffers = _outputBuffers;
			for (int i = 0; i < outputBuffers.Length; i++)
			{
				if (outputBuffers[i].IsTryingToOutput)
				{
					return true;
				}
			}
			return false;
		}

		protected void SetShouldClearInputBufferOnOutput(bool clearOnOutput = true)
		{
			_resetInputBuffersOnOutput = clearOnOutput;
		}

		protected Resource TakeResourceFromInputBuffer(int inputIndex, bool callInputFreedEvent = true)
		{
			Resource resource = _inputBuffers[inputIndex].Resource;
			_inputBuffers[inputIndex].Resource = null;
			if (callInputFreedEvent)
			{
				CallClearedInputBufferEvent(inputIndex);
			}
			return resource;
		}

		protected void ClearInputBuffers(bool callInputFreedEvents = true)
		{
			for (int i = 0; i < _inputBuffers.Length; i++)
			{
				_inputBuffers[i].Resource = null;
				if (callInputFreedEvents)
				{
					CallClearedInputBufferEvent(i);
				}
			}
		}

		protected Resource GetResourceInInputBuffer(int inputIndex = 0)
		{
			return _inputBuffers[inputIndex].Resource;
		}

		protected bool IsInputBufferFull(int inputIndex = 0)
		{
			return _inputBuffers[inputIndex].Resource != null;
		}

		protected bool HasOutputResourceHolder(int outputIndex)
		{
			return _outputBuffers[outputIndex].HasResourceHolder;
		}

		protected bool AllInputBuffersFull()
		{
			for (int i = 0; i < _inputBuffers.Length; i++)
			{
				if (!IsInputBufferFull(i))
				{
					return false;
				}
			}
			return true;
		}

		protected bool AnyInputBufferIsFull()
		{
			for (int i = 0; i < _inputBuffers.Length; i++)
			{
				if (IsInputBufferFull(i))
				{
					return true;
				}
			}
			return false;
		}

		protected InputBufferSaveData GetInputBufferSaveData()
		{
			ResourceDto[] array = new ResourceDto[_inputBuffers.Length];
			for (int i = 0; i < _inputBuffers.Length; i++)
			{
				array[i] = new ResourceDto(_inputBuffers[i].Resource);
			}
			return new InputBufferSaveData(array);
		}

		protected void ApplyInputBufferSaveData(InputBufferSaveData inputBufferSaveData, ResourceFactory resourceFactory, ResourceDatabaseSO resourceDatabaseSO)
		{
			if (inputBufferSaveData.InputBufferResources != null)
			{
				for (int i = 0; i < inputBufferSaveData.InputBufferResources.Length && i < _inputBuffers.Length; i++)
				{
					Resource resource = inputBufferSaveData.InputBufferResources[i].ToResource(resourceFactory, resourceDatabaseSO);
					_inputBuffers[i] = new FactoryObjectInputBuffer(resource);
				}
			}
		}

		public override string ToString()
		{
			string text = "\n";
			FactoryObjectInputBuffer[] inputBuffers = _inputBuffers;
			foreach (FactoryObjectInputBuffer factoryObjectInputBuffer in inputBuffers)
			{
				bool flag = factoryObjectInputBuffer.Resource != null;
				string arg = (flag ? "#90D5FF" : "#FF0000");
				text = text + $"Input full: <color={arg}>{flag}</color>" + (flag ? $" - Resource: {factoryObjectInputBuffer.Resource}" : "") + "\n";
			}
			return base.ToString() + text;
		}
	}
}
