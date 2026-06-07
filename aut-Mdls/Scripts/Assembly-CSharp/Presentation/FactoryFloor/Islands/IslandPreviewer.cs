using Events;
using Events.FactoryFloor.Islands;
using UnityEngine;

namespace Presentation.FactoryFloor.Islands
{
	public class IslandPreviewer : MonoBehaviour
	{
		[SerializeField]
		private IslandConfigEvent _startIslandObjectPreviewEvent;

		[SerializeField]
		private IslandConfigEvent _updateIslandObjectPreviewEvent;

		[SerializeField]
		private BaseEvent _stopPreviewEvent;

		[SerializeField]
		private IslandView _islandView;

		private IslandView _environmentObjectView;

		private void Start()
		{
			_startIslandObjectPreviewEvent.Register(StartPreview);
			_updateIslandObjectPreviewEvent.Register(UpdatePreview);
			_stopPreviewEvent.Register(StopPreview);
		}

		private void OnDestroy()
		{
			_startIslandObjectPreviewEvent.UnRegister(StartPreview);
			_updateIslandObjectPreviewEvent.UnRegister(UpdatePreview);
			_stopPreviewEvent.UnRegister(StopPreview);
		}

		private void StartPreview(IslandConfig obj)
		{
			if ((bool)_environmentObjectView)
			{
				StopPreview();
			}
			_environmentObjectView = Object.Instantiate(_islandView);
			_environmentObjectView.SetConfig(obj);
		}

		private void UpdatePreview(IslandConfig obj)
		{
			_environmentObjectView.transform.SetPositionAndRotation(obj.Position, Quaternion.Euler(0f, obj.Rotation, 0f));
		}

		private void StopPreview()
		{
			if ((bool)_environmentObjectView)
			{
				Object.Destroy(_environmentObjectView.gameObject);
				_environmentObjectView = null;
			}
		}
	}
}
