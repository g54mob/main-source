using System;
using DG.Tweening;
using Presentation.FactoryFloor.ParticleSystemPool;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews
{
	public class FactoryObjectPlacementVisuals : MonoBehaviour
	{
		[SerializeField]
		private FactoryObjectView _objectView;

		[SerializeField]
		private Transform _modelParent;

		[SerializeField]
		private ParticleSystemPoolLocator _particleSystemPoolLocator;

		[SerializeField]
		private Transform _normalParent;

		[Header("Punch Variables")]
		[SerializeField]
		private float _punchScale = 0.25f;

		[SerializeField]
		private float _punchDuration = 0.1f;

		[SerializeField]
		private int _punchVibrato = 2;

		[SerializeField]
		private float _punchElasticity = 1f;

		private void Awake()
		{
			if ((bool)_objectView)
			{
				_objectView.OnShowView += ViewInitialized;
				_objectView.OnHideView += ViewHidden;
			}
		}

		private void OnDestroy()
		{
			if ((bool)_objectView)
			{
				_objectView.OnShowView -= ViewInitialized;
				_objectView.OnHideView -= ViewHidden;
			}
		}

		private void ViewHidden(bool wasPreview)
		{
			if (!wasPreview)
			{
				_particleSystemPoolLocator.Pool.PlayDestroyBuildingVFX(base.transform.position, base.transform.parent);
			}
		}

		private void ViewInitialized(bool isLoading)
		{
			if (isLoading || _objectView.FactoryObject == null)
			{
				return;
			}
			if (_particleSystemPoolLocator.Pool != null)
			{
				foreach (Vector3Int occupiedPosition in _objectView.FactoryObject.OccupiedPositions)
				{
					_particleSystemPoolLocator.Pool.PlayPlaceBuildingVFX(occupiedPosition + new Vector3(0.5f, 0f, 0.5f), base.transform.parent);
				}
			}
			Tweener tweener = _modelParent.transform.DOPunchScale(Vector3.one * _punchScale, _punchDuration, _punchVibrato, _punchElasticity);
			tweener.onKill = (TweenCallback)Delegate.Combine(tweener.onKill, new TweenCallback(OnPunchScaleKill));
		}

		private void OnPunchScaleKill()
		{
			if ((bool)_normalParent)
			{
				_normalParent.transform.localScale = Vector3.one;
			}
			_modelParent.transform.localScale = Vector3.one;
		}
	}
}
