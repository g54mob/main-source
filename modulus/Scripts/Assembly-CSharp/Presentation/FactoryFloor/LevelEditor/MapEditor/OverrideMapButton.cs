using Logic.Factory.Map;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.LevelEditor.MapEditor
{
	public class OverrideMapButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private MapOverrider _mapOverrider;

		private void Start()
		{
			_button.onClick.AddListener(OnClicked);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(OnClicked);
		}

		private void OnClicked()
		{
			_mapOverrider.EditorOverrideMap();
		}
	}
}
