using System;
using CTS.Core.Pooling;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace CTS
{
	public class BarVisualObject : MonoBehaviour, IPoolable
	{
		[SerializeField]
		private RoomObject _roomObject;

		[SerializeField]
		private bool _autoRefresh = true;

		[SerializeField]
		private Renderer[] _renderers;

		[SerializeField]
		private Collider[] _colliders;

		[SerializeField]
		private Light[] _lights;

		[SerializeField]
		private DecalProjector[] _decals;

		[SerializeField]
		private AudioSource[] _audioSource;

		[SerializeField]
		private Canvas[] _canvas;

		[SerializeField]
		private bool _debug;

		public BuildingRoomContainer CurrentFloor => _roomObject.CurrentFloor;

		PoolGuid IPoolable.PoolGuid { get; set; }

		public event Action<Room> OnRoomChanged;

		private RoomObject GetRoomObject()
		{
			if (!_roomObject)
			{
				_roomObject = GetComponent<RoomObject>();
			}
			return _roomObject;
		}

		private void Awake()
		{
			RoomObject roomObject = GetRoomObject();
			roomObject.CurrentRoomChangingVisibility += SetVisible;
			roomObject.CurrentFloorChanged += OnCurrentFloorChanged;
			if (_autoRefresh)
			{
				RefreshComponents();
			}
			else
			{
				SetVisible(roomObject.IsVisible);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void RefreshComponents()
		{
			_renderers = GetComponentsInChildren<Renderer>(includeInactive: true);
			_colliders = GetComponentsInChildren<Collider>(includeInactive: true);
			_lights = GetComponentsInChildren<Light>(includeInactive: true);
			_decals = GetComponentsInChildren<DecalProjector>(includeInactive: true);
			_audioSource = GetComponentsInChildren<AudioSource>(includeInactive: true);
			_canvas = GetComponentsInChildren<Canvas>(includeInactive: true);
			SetVisible(GetRoomObject().IsVisible);
		}

		private void OnDestroy()
		{
			_roomObject.CurrentRoomChangingVisibility -= SetVisible;
			_roomObject.CurrentFloorChanged -= OnCurrentFloorChanged;
		}

		public void SetVisible(bool p_visible)
		{
			Renderer[] renderers = _renderers;
			foreach (Renderer renderer in renderers)
			{
				if ((bool)renderer)
				{
					renderer.enabled = p_visible;
				}
			}
			Collider[] colliders = _colliders;
			foreach (Collider collider in colliders)
			{
				if ((bool)collider)
				{
					collider.enabled = p_visible;
				}
			}
			Light[] lights = _lights;
			foreach (Light light in lights)
			{
				if ((bool)light)
				{
					light.enabled = p_visible;
				}
			}
			DecalProjector[] decals = _decals;
			foreach (DecalProjector decalProjector in decals)
			{
				if ((bool)decalProjector)
				{
					decalProjector.enabled = p_visible;
				}
			}
			AudioSource[] audioSource = _audioSource;
			foreach (AudioSource audioSource2 in audioSource)
			{
				if ((bool)audioSource2)
				{
					audioSource2.mute = !p_visible;
				}
			}
			Canvas[] canvas = _canvas;
			foreach (Canvas canvas2 in canvas)
			{
				if ((bool)canvas2)
				{
					canvas2.enabled = p_visible;
				}
			}
		}

		private void OnCurrentFloorChanged()
		{
			SetVisible(_roomObject.IsVisible);
		}
	}
}
