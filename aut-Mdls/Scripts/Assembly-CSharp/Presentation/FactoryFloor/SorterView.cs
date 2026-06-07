using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Shapes;
using FMODUnity;
using Presentation.FactoryFloor.FactoryObjectViews.OperatorViews;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class SorterView : FactoryResourceHolderView<SorterBehavior>
	{
		[SerializeField]
		private Animator _sortAnimator;

		[SerializeField]
		private EventReference _sortSFX;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabaseSO;

		[SerializeField]
		private ShapesDatabase _shapesDatabaseSO;

		[SerializeField]
		private ResourceProjectorWidgetView _resourceProjectorWidgetView;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		private Resource _currentlyShownResource;

		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
			_behaviour.OnOutputResource.RegisterMainThread(ResourcePassed);
			_behaviour.OnSkippedResource.RegisterMainThread(ResourceSkipped);
			_behaviour.OnItemPushedAside.RegisterMainThread(AnimatePushingItemToSide);
			_behaviour.OnItemAssigned.RegisterMainThread(AssignCurrentFilteredItemIcon);
			_behaviour.OnResourceAdded.RegisterMainThread(ResourceAdded);
			_behaviour.OnResourcesCleared.RegisterMainThread(ResourceCleared);
			Resource currentOrFilteredResource = GetCurrentOrFilteredResource();
			AssignCurrentFilteredItemIcon(currentOrFilteredResource);
		}

		private Resource GetCurrentOrFilteredResource()
		{
			if (_behaviour.IsFilterSet)
			{
				return _behaviour.Filter.ToResource(_resourceFactory, _resourceDatabaseSO);
			}
			if (_behaviour.HasResource)
			{
				return _behaviour.CurrentResource;
			}
			return null;
		}

		protected override void ResetFactoryObject()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
				_behaviour.OnOutputResource.UnRegisterMainThread(ResourcePassed);
				_behaviour.OnSkippedResource.UnRegisterMainThread(ResourceSkipped);
				_behaviour.OnItemPushedAside.UnRegisterMainThread(AnimatePushingItemToSide);
				_behaviour.OnItemAssigned.UnRegisterMainThread(AssignCurrentFilteredItemIcon);
				_behaviour.OnResourceAdded.UnRegisterMainThread(ResourceAdded);
				_behaviour.OnResourcesCleared.UnRegisterMainThread(ResourceCleared);
			}
			base.ResetFactoryObject();
		}

		private void AnimatePushingItemToSide()
		{
			_sortAnimator.SetTrigger("Sort");
			_audioManagerLocator.AudioManager.PlayFactoryBehaviourViewOneShot(_sortSFX, _objectView.transform.position, _objectView.FactoryObject.FactoryObjectData.ObjectSize);
		}

		private void ResourceAdded(Resource resource)
		{
			if (!_behaviour.IsFilterSet)
			{
				UpdateProjectorWidget(resource);
			}
		}

		private void ResourcePassed(Resource resource, int outputIndex)
		{
			if (!_behaviour.IsFilterSet)
			{
				UpdateProjectorWidget(null);
			}
		}

		private void ResourceCleared()
		{
			ResourcePassed(null, 0);
		}

		private void ResourceSkipped(int outputIndex)
		{
			UpdateProjectorWidget(_behaviour.CurrentResource);
		}

		private void AssignCurrentFilteredItemIcon(Resource resource)
		{
			UpdateProjectorWidget(resource);
		}

		private void UpdateProjectorWidget(Resource newResource)
		{
			if (newResource != _currentlyShownResource)
			{
				if (newResource != null)
				{
					_currentlyShownResource = newResource;
					_resourceProjectorWidgetView.ShowResource(newResource);
				}
				else
				{
					_currentlyShownResource = null;
					_resourceProjectorWidgetView.Reset();
				}
			}
		}
	}
}
