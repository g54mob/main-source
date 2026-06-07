using DG.Tweening;
using Data.FactoryFloor.Resources;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews
{
	public class ResourceProjectorWidgetView : MonoBehaviour
	{
		[SerializeField]
		private Transform _anchor;

		private Resource _currentResource;

		private ResourceView _resourceView;

		public void ShowResource(Resource resource)
		{
			if (resource == null)
			{
				Reset();
			}
			else if (resource != _currentResource && (!(resource is ShapeResource shapeResource) || _currentResource == null || !(_currentResource is ShapeResource shapeResource2) || !(shapeResource.ShapeData.VoxelHash == shapeResource2.ShapeData.VoxelHash)) && (_currentResource == null || resource is ShapeResource || !(resource.Data == _currentResource.Data)))
			{
				_currentResource = resource;
				DestroyCurrentResourceView();
				_resourceView = ResourceViewManager.Instance.CreateNewResourceView(resource);
				_resourceView.transform.parent = _anchor;
				_resourceView.transform.localPosition = Vector3.zero;
				_resourceView.transform.localScale = Vector3.zero;
				_resourceView.transform.DOScale(_resourceView.Resource.TargetScale, 0.5f).SetEase(Ease.OutBack);
			}
		}

		private void DestroyCurrentResourceView()
		{
			if (_resourceView != null)
			{
				_resourceView.transform.DOKill();
				Object.Destroy(_resourceView.gameObject);
			}
			_resourceView = null;
		}

		public void Reset()
		{
			_currentResource = null;
			DestroyCurrentResourceView();
		}
	}
}
