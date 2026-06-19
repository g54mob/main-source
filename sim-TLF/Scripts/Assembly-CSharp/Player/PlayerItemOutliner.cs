using MyBox;
using Services.Missions;
using Services.Save.Player;
using UI.HUD;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

namespace Player
{
	public class PlayerItemOutliner : MonoBehaviour
	{
		[SerializeField]
		private RaycasterInfo _playerDescriberViewInfo;

		[SerializeField]
		[ReadOnly(new string[] { })]
		private Collider _outlinedObject;

		[SerializeField]
		[ReadOnly(new string[] { })]
		private bool _objectSetFromOutside;

		[Inject]
		private PlayerHUDView _hudView;

		[Inject]
		private PlayerSaveService _playerSaveService;

		[Inject]
		private MissionEventBus _missionEventBus;

		private WorldUIOutliner _worldUIOutliner;

		private void Awake()
		{
			_worldUIOutliner = _hudView.WorldUIHighlighter;
		}

		private void OnEnable()
		{
			RenderPipelineManager.beginCameraRendering += DrawHighlight;
		}

		private void OnDisable()
		{
			RenderPipelineManager.beginCameraRendering -= DrawHighlight;
		}

		private void Update()
		{
			if (!_objectSetFromOutside)
			{
				TrySetOtlinedObjectInternally();
			}
		}

		private void DrawHighlight(ScriptableRenderContext context, Camera camera)
		{
			if (!(_worldUIOutliner == null) && camera.CompareTag("MainCamera"))
			{
				if (_outlinedObject != null)
				{
					_worldUIOutliner.EnableHighlight();
					_worldUIOutliner.UpdateFrame(_outlinedObject.bounds, camera);
				}
				else
				{
					_worldUIOutliner.DisableHighlight();
				}
			}
		}

		public void SetOutlinedObject(Collider collider)
		{
			_outlinedObject = collider;
			_objectSetFromOutside = true;
		}

		public void ClearOutlinedObject()
		{
			_outlinedObject = null;
			_objectSetFromOutside = false;
		}

		private void TrySetOtlinedObjectInternally()
		{
			if (_playerDescriberViewInfo.Hit.transform != null)
			{
				_outlinedObject = _playerDescriberViewInfo.Hit.collider;
			}
			else
			{
				_outlinedObject = null;
			}
		}
	}
}
