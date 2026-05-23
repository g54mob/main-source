using System.Collections.Generic;
using DG.Tweening;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Drones;
using Data.Variables;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class HarvesterPadView : FactoryResourceHolderView<HarvesterPadBehaviour>
	{
		[SerializeField]
		private IntVariableSO _globalUpdateMultiplier;

		[SerializeField]
		private HarvesterPadDroneViewPool _harvesterPadDroneViewPool;

		[SerializeField]
		private Transform _droneDropOffPoint;

		[SerializeField]
		private Vector3 _dronePickUpOffset;

		[SerializeField]
		private Transform _droneLandingPlatform;

		[SerializeField]
		private float _droneLandingPlatformOffset;

		[SerializeField]
		private float _boxFallTime = 0.1f;

		private readonly List<HarvesterPadDroneView> _drones = new List<HarvesterPadDroneView>();

		private Vector3 _topDroneLandingPlatformPosition;

		private Vector3 _bottomDroneLandingPlatformPosition;

		public Vector3 TopDroneLandingPlatformPosition => _topDroneLandingPlatformPosition;

		public Vector3 BottomDroneLandingPlatformPosition => _bottomDroneLandingPlatformPosition;

		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
			_behaviour.OnCreatedDroneMainThread += CreateDroneView;
			foreach (HarvestPadDroneBehaviour droneInstance in _behaviour.DroneInstances)
			{
				if (!droneInstance.IsHidden)
				{
					CreateDroneView(droneInstance);
				}
			}
			_topDroneLandingPlatformPosition = _droneLandingPlatform.position;
			_bottomDroneLandingPlatformPosition = _topDroneLandingPlatformPosition + Vector3.up * _droneLandingPlatformOffset;
			if ((float)_globalUpdateMultiplier.Value > 0f)
			{
				_droneLandingPlatform.position = _bottomDroneLandingPlatformPosition;
				AnimatePlatformUp(0.35f);
			}
		}

		protected override void ResetFactoryObject()
		{
			if (_behaviour != null)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
				_behaviour.OnCreatedDroneMainThread -= CreateDroneView;
			}
			ReturnToPoolAllDroneViews();
			base.ResetFactoryObject();
		}

		private void CreateDroneView(HarvestPadDroneBehaviour droneBehaviour)
		{
			HarvesterPadDroneView orCreateDroneView = _harvesterPadDroneViewPool.GetOrCreateDroneView(droneBehaviour, this, _droneDropOffPoint.position, _dronePickUpOffset);
			orCreateDroneView.OnDeliveredResources += DeliveredResources;
			_drones.Add(orCreateDroneView);
		}

		private void ReturnToPoolAllDroneViews()
		{
			for (int num = _drones.Count - 1; num >= 0; num--)
			{
				_drones[num].ReturnToPool();
			}
			_drones.Clear();
		}

		public void DestroyDroneView(HarvesterPadDroneView harvesterPadDroneView)
		{
			harvesterPadDroneView.OnDeliveredResources -= DeliveredResources;
			_drones.Remove(harvesterPadDroneView);
		}

		private void DeliveredResources(HarvesterPadDroneView harvesterPadDroneView, float seconds, float delay, Ease ease)
		{
			_droneLandingPlatform.DOKill();
			_droneLandingPlatform.position = _topDroneLandingPlatformPosition;
			_droneLandingPlatform.DOMove(_bottomDroneLandingPlatformPosition, seconds).SetDelay(delay).SetEase(ease)
				.OnComplete(AnimatePlatformUp);
		}

		private void AnimatePlatformUp()
		{
			AnimatePlatformUp(0f);
		}

		private void AnimatePlatformUp(float delay)
		{
			if (_globalUpdateMultiplier.Value > 0)
			{
				_droneLandingPlatform.DOMove(_topDroneLandingPlatformPosition, 0.25f / (float)_globalUpdateMultiplier.Value).SetDelay(delay);
			}
		}
	}
}
