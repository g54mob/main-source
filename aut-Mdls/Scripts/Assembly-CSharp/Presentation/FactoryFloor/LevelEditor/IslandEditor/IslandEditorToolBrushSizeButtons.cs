using Data.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.LevelEditor.IslandEditor
{
	public class IslandEditorToolBrushSizeButtons : MonoBehaviour
	{
		private const int MaxBrushSize = 9;

		private const int MinBrushSize = 0;

		[SerializeField]
		private Button _increaseButton;

		[SerializeField]
		private Button _decreaseButton;

		[SerializeField]
		private IntVariableSO _islandEditorBrushSize;

		private void Start()
		{
			_increaseButton.onClick.AddListener(IncreaseButtonPressed);
			_decreaseButton.onClick.AddListener(DecreaseButtonPressed);
		}

		private void OnDestroy()
		{
			_increaseButton.onClick.RemoveListener(IncreaseButtonPressed);
			_decreaseButton.onClick.RemoveListener(DecreaseButtonPressed);
		}

		private void IncreaseButtonPressed()
		{
			int value = Mathf.Min(_islandEditorBrushSize.Value + 1, 9);
			_islandEditorBrushSize.SetValue(value);
		}

		private void DecreaseButtonPressed()
		{
			int value = Mathf.Max(_islandEditorBrushSize.Value - 1, 0);
			_islandEditorBrushSize.SetValue(value);
		}
	}
}
