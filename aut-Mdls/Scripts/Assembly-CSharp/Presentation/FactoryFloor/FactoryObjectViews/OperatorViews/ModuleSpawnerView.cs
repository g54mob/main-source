using DG.Tweening;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews
{
	public class ModuleSpawnerView : FactoryResourceHolderView<ModuleSpawnerBehaviour>
	{
		[SerializeField]
		private float _rotateSpeed = 1f;

		[SerializeField]
		private Transform _resourceParentTransform;

		[SerializeField]
		private float _resourceScale = 1f;

		[SerializeField]
		private float _resourceScaleUpAnimTime = 0.25f;

		private bool _isShowingResource;

		private ResourceView _resourceView;

		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
			_behaviour.OnChangeResource += ChangeResource;
			ChangeResource(_behaviour.Resource);
		}

		private void Update()
		{
			_resourceParentTransform.transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
		}

		private void ResetView()
		{
			if (_behaviour != null)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
				_behaviour.OnChangeResource -= ChangeResource;
			}
			DestroyCurrentResourceView();
		}

		private void ChangeResource(Resource resource)
		{
			DestroyCurrentResourceView();
			SpawnNewResourceView(resource);
		}

		private void DestroyCurrentResourceView()
		{
			if (_isShowingResource)
			{
				_resourceView.DOKill();
				_isShowingResource = false;
				if ((bool)ResourceViewManager.Instance.transform)
				{
					_resourceView.transform.SetParent(ResourceViewManager.Instance.transform);
					ResourceViewManager.Instance.ReturnResourceToPool(_resourceView);
				}
			}
		}

		private void SpawnNewResourceView(Resource resource)
		{
			if (!_isShowingResource)
			{
				_resourceView = ResourceViewManager.Instance.CreateNewResourceView(resource);
				_resourceView.transform.SetParent(_resourceParentTransform);
				_resourceView.transform.localPosition = Vector3.zero;
				_resourceView.transform.localScale = Vector3.zero;
				_resourceView.transform.DOScale(Vector3.one * _resourceScale, _resourceScaleUpAnimTime).SetEase(Ease.OutBounce);
				_isShowingResource = true;
			}
		}

		protected override void ResetFactoryObject()
		{
			ResetView();
			base.ResetFactoryObject();
		}
	}
}
