using Logic.Factory.Map;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.LevelEditor.MapEditor
{
	public class ExportMapButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private Toggle _isZenMode;

		[SerializeField]
		private MapExporter _mapExporter;

		private void Start()
		{
			_button.onClick.AddListener(ExportMap);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(ExportMap);
		}

		private void ExportMap()
		{
			_mapExporter.ExportCurrentMap(_isZenMode.isOn);
		}
	}
}
