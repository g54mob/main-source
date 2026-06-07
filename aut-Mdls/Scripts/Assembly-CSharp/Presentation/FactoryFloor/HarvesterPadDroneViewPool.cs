using System.Collections.Generic;
using Data.FactoryFloor.Drones;
using Unity.Collections;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	[CreateAssetMenu(fileName = "HarvesterPadDroneViewPool", menuName = "Factory/HarvesterPadDroneViewPool")]
	public class HarvesterPadDroneViewPool : ScriptableObject
	{
		[SerializeField]
		private HarvesterPadDroneView _droneViewPrefab;

		private GameObject _parent;

		private readonly List<HarvesterPadDroneView> _freeDroneViews = new List<HarvesterPadDroneView>(64);

		public HarvesterPadDroneView GetOrCreateDroneView(HarvestPadDroneBehaviour droneBehaviour, HarvesterPadView harvesterPadView, Vector3 droneDropOffPos, Vector3 dronePickUpOffset)
		{
			HarvesterPadDroneView harvesterPadDroneView;
			if (_freeDroneViews.Count == 0)
			{
				harvesterPadDroneView = Object.Instantiate(_droneViewPrefab, GetParent());
			}
			else
			{
				harvesterPadDroneView = _freeDroneViews[0];
				_freeDroneViews.RemoveAtSwapBack(0);
			}
			harvesterPadDroneView.Init(droneBehaviour, harvesterPadView, droneDropOffPos, dronePickUpOffset);
			harvesterPadDroneView.gameObject.SetActive(value: true);
			return harvesterPadDroneView;
		}

		public void ReturnToPool(HarvesterPadDroneView harvesterPadDroneView)
		{
			if (!_freeDroneViews.Contains(harvesterPadDroneView))
			{
				_freeDroneViews.Add(harvesterPadDroneView);
				harvesterPadDroneView.gameObject.SetActive(value: false);
				harvesterPadDroneView.UnInit();
			}
		}

		public void RemoveFromPool(HarvesterPadDroneView harvesterPadDroneView)
		{
			_freeDroneViews.Remove(harvesterPadDroneView);
		}

		private Transform GetParent()
		{
			if (_parent == null)
			{
				_parent = new GameObject("HarvesterPadDroneViewPool");
			}
			return _parent.transform;
		}
	}
}
