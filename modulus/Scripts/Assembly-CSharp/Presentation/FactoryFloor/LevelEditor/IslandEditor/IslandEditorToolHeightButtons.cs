using Events.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.LevelEditor.IslandEditor
{
	public class IslandEditorToolHeightButtons : MonoBehaviour
	{
		[SerializeField]
		private Button _playOnFloor;

		[SerializeField]
		private GameObject _playOnFloorClicked;

		[SerializeField]
		private Button _playOnHeight;

		[SerializeField]
		private GameObject _playOnHeightClicked;

		[SerializeField]
		private BoolEvent _islandEditorHeightEvent;

		private void Start()
		{
			_playOnFloor.onClick.AddListener(DisableHeight);
			_playOnHeight.onClick.AddListener(EnableHeight);
			_playOnFloorClicked.SetActive(value: true);
			_playOnHeightClicked.SetActive(value: false);
		}

		private void OnDestroy()
		{
			_playOnFloor.onClick.RemoveListener(DisableHeight);
			_playOnHeight.onClick.RemoveListener(EnableHeight);
		}

		private void EnableHeight()
		{
			_islandEditorHeightEvent.Fire(data: true);
			_playOnFloorClicked.SetActive(value: false);
			_playOnHeightClicked.SetActive(value: true);
		}

		private void DisableHeight()
		{
			_islandEditorHeightEvent.Fire(data: false);
			_playOnFloorClicked.SetActive(value: true);
			_playOnHeightClicked.SetActive(value: false);
		}
	}
}
