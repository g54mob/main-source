using System.Collections.Generic;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews.Skyline
{
	public class SkylinePlatformView : MonoBehaviour
	{
		[SerializeField]
		private Transform _resourceViewParent;

		[SerializeField]
		private Transform _fullPlatform;

		[SerializeField]
		private Transform _emptyPlatform;

		[SerializeField]
		private List<Renderer> _renderers;

		private Vector3 _startPos;

		private Vector3 _direction;

		private bool _hasResourceView;

		private ResourceView _resourceView;

		public bool IsAvailable { get; private set; }

		public ResourceView ResourceView => _resourceView;

		public void Init(Vector3 startPos, Vector3 direction)
		{
			_startPos = startPos;
			_direction = direction;
			base.gameObject.SetActive(value: false);
			IsAvailable = true;
		}

		public void SetIsAvailable(bool isAvailable)
		{
			if (isAvailable && _hasResourceView)
			{
				ReturnResourceToPool();
			}
			IsAvailable = isAvailable;
		}

		public SkylinePlatformView SpawnPlatform(ResourceView resourceView, int startIndex = 0)
		{
			IsAvailable = false;
			base.transform.position = _startPos + _direction * startIndex;
			base.transform.localScale = Vector3.one;
			resourceView.transform.SetParent(_resourceViewParent);
			base.transform.localScale = Vector3.zero;
			resourceView.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			resourceView.Show(show: true);
			SetFullPlatform();
			base.gameObject.SetActive(value: true);
			_resourceView = resourceView;
			_hasResourceView = true;
			return this;
		}

		public void SetFullPlatform()
		{
			_fullPlatform.gameObject.SetActive(value: true);
			_emptyPlatform.gameObject.SetActive(value: false);
		}

		public void SetEmptyPlatform()
		{
			_fullPlatform.gameObject.SetActive(value: false);
			_emptyPlatform.gameObject.SetActive(value: true);
		}

		public void Clear()
		{
			StopAllCoroutines();
		}

		public void ReturnResourceToPool()
		{
			if (_hasResourceView)
			{
				ResourceViewManager.Instance.ReturnResourceToPool(_resourceView);
				_resourceView = null;
				_hasResourceView = false;
			}
		}

		public void SetForceRenderingOff(bool forceRenderingOff)
		{
			foreach (Renderer renderer in _renderers)
			{
				renderer.forceRenderingOff = forceRenderingOff;
			}
			if (_hasResourceView)
			{
				_resourceView.Show(!forceRenderingOff);
			}
		}
	}
}
