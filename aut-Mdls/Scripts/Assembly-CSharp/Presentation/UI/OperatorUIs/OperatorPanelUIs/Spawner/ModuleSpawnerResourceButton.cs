using Data.Shapes;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.OperatorPanelUIs.Spawner
{
	public class ModuleSpawnerResourceButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private GameObject _selectedUI;

		[SerializeField]
		private SettableResourceImage _originalResourceImage;

		[SerializeField]
		private ModuleSpawnerUI _moduleSpawnerUI;

		private int _index;

		private void Awake()
		{
			_button.onClick.AddListener(OnButtonClick);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			_moduleSpawnerUI.SetIndex(_index);
		}

		public void SetShapeData(ShapeData shapeData, int index)
		{
			_index = index;
			_originalResourceImage.SetShapeData(shapeData);
		}

		public void SetIsSelected(bool selected)
		{
			_selectedUI.SetActive(selected);
		}
	}
}
