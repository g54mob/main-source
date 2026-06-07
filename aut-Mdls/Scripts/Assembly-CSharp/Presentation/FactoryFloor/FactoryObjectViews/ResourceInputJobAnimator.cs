using System.Collections.Generic;
using Data.FactoryFloor;
using Data.Operator;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews
{
	public class ResourceInputJobAnimator : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _offset = new Vector3(0.5f, 0.275f, 0.5f);

		[SerializeField]
		private FactoryObjectView _objectView;

		[SerializeField]
		private FactoryObjectViewCullingController _cullingController;

		private IResourceHolderView _resourceHolderView;

		private readonly List<ResourceJobContainer> _inputJobContainers = new List<ResourceJobContainer>();

		private bool _resourceHolderViewSet;

		private bool _factoryObjectSet;

		private void Start()
		{
			_objectView.FactoryObjectSet += OnFactoryObjectSet;
			_objectView.FactoryObjectReset += ResetFactoryObj;
			if (_objectView.FactoryObject != null)
			{
				OnFactoryObjectSet(_objectView.FactoryObject, isGameLoading: false);
			}
		}

		private void OnDestroy()
		{
			_objectView.FactoryObjectSet -= OnFactoryObjectSet;
			_objectView.FactoryObjectReset -= ResetFactoryObj;
			_factoryObjectSet = false;
			_resourceHolderViewSet = false;
		}

		private void OnFactoryObjectSet(FactoryObject factoryObject, bool isGameLoading)
		{
			foreach (ResourceJobContainer inputJobContainer in _inputJobContainers)
			{
				inputJobContainer.Dispose();
			}
			_inputJobContainers.Clear();
			for (int i = 0; i < factoryObject.DataInputPositions.Count; i++)
			{
				FactoryObjectData.InputData inputData = factoryObject.DataInputPositions[i];
				Vector3 startPosition = factoryObject.DataPosToWorldPos(inputData.Position - inputData.Direction) + _offset;
				Vector3 endPosition = factoryObject.DataPosToWorldPos(inputData.Position) + _offset;
				ResourceJobContainer item = new ResourceJobContainer(startPosition, endPosition, ResourceJobContainer.ScalingMode.ScaleDown, returnResourceToPoolAfter: true, _cullingController);
				_inputJobContainers.Add(item);
			}
			_factoryObjectSet = true;
			TrySubscribeToReceiveResourceView();
		}

		public void SetResourceHolderView(IResourceHolderView resourceHolderView)
		{
			_resourceHolderView = resourceHolderView;
			_resourceHolderViewSet = true;
			TrySubscribeToReceiveResourceView();
		}

		private void TrySubscribeToReceiveResourceView()
		{
			if (_resourceHolderViewSet && _factoryObjectSet)
			{
				_resourceHolderView.AddReceiveResourceViewListener(_objectView.FactoryObject.CreatedId, ReceiveResourceView);
			}
		}

		private void ResetFactoryObj(FactoryObjectView _)
		{
			_factoryObjectSet = false;
			_resourceHolderViewSet = false;
			foreach (ResourceJobContainer inputJobContainer in _inputJobContainers)
			{
				inputJobContainer.Dispose();
			}
			_inputJobContainers.Clear();
			if (_resourceHolderView != null && _objectView.FactoryObject != null)
			{
				_resourceHolderView.RemoveReceiveResourceViewListener(_objectView.FactoryObject.CreatedId, ReceiveResourceView);
			}
		}

		private void ReceiveResourceView(ResourceView resourceView, int inputIndex, Vector3 targetPos)
		{
			_inputJobContainers[inputIndex].PlayAnimation(resourceView);
		}
	}
}
