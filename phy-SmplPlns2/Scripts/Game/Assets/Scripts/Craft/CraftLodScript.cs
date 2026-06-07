using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Cameras;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Settings;
using Jundroo.Common.Settings.Events;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class CraftLodScript : MonoBehaviour
	{
		private CameraManagerScript _cameraManager;

		private AircraftScript _craft;

		private BoolSetting _craftCullingSetting;

		[SerializeField]
		private float _minimumScreenSize = 0.015f;

		public float MinimumScreenSize
		{
			get
			{
				return _minimumScreenSize;
			}
			set
			{
				_minimumScreenSize = value;
			}
		}

		protected virtual void LateUpdate()
		{
			Camera mainCamera = _cameraManager.MainCamera;
			bool isFirstPerson = _cameraManager.Controller.IsFirstPerson;
			foreach (BodyScript body in _craft.Bodies)
			{
				if (body.LodTree != null && body.LodTree.Parent == null)
				{
					body.LodTree.UpdateFromCamera(mainCamera, isFirstPerson, _minimumScreenSize);
				}
			}
		}

		protected virtual void OnDestroy()
		{
			_craftCullingSetting.Changed -= OnCraftCullingSettingChanged;
		}

		protected virtual void OnDisable()
		{
			if (_craft != null)
			{
				if (_craft.RemoteAircraft)
				{
					_craft.BodyCreated -= OnBodyCreated;
				}
				DestroyLodTrees();
			}
		}

		protected virtual async void OnEnable()
		{
			_cameraManager = FlightSceneScript.Instance.CameraScript;
			if (_craftCullingSetting == null)
			{
				_craftCullingSetting = Game.Instance.Settings.Quality.Craft.CraftCulling;
				_craftCullingSetting.Changed += OnCraftCullingSettingChanged;
				UpdateFromSettings();
			}
			if (base.enabled)
			{
				_craft = GetComponent<AircraftScript>();
				for (int i = 0; i < 5; i++)
				{
					await UniTask.Yield();
				}
				CreateLodTrees();
			}
		}

		private void CreateLodTrees()
		{
			foreach (BodyScript body in _craft.Bodies)
			{
				PartMeshLodTreeScript.CreateTreeForBodyScript(body, _craft.IsPrimaryLocalPlayer);
			}
			foreach (BodyScript body2 in _craft.Bodies)
			{
				if (body2.SyncData.ParentBody?.LodTree != null)
				{
					body2.LodTree.SetParent(body2.SyncData.ParentBody.LodTree);
				}
			}
			_craft.BodyCreated += OnBodyCreated;
		}

		private void DestroyLodTrees()
		{
			foreach (BodyScript body in _craft.Bodies)
			{
				if (body != null && body.LodTree != null)
				{
					Object.Destroy(body.LodTree);
					body.LodTree = null;
				}
			}
		}

		private void OnBodyCreated(BodyScript body)
		{
			PartMeshLodTreeScript.CreateTreeForBodyScript(body, _craft.IsPrimaryLocalPlayer);
		}

		private void OnCraftCullingSettingChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			UpdateFromSettings();
		}

		private void UpdateFromSettings()
		{
			base.enabled = _craftCullingSetting.Value;
		}
	}
}
