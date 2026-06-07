using System.Collections.Generic;
using System.Linq;
using Commands;
using Commands.ToolsCommands;
using Data.FactoryFloor.Islands;
using Data.Variables;
using Events;
using Events.FactoryFloor;
using Events.Generic;
using Logic.Factory.Blueprint;
using Presentation.Locators;
using UnityEngine;

namespace Logic.FactoryTools.IslandEditor
{
	[CreateAssetMenu(menuName = "Factory/Tools/Islands/PaintTextureTool", fileName = "PaintTextureTool", order = 0)]
	public class PaintTextureTool : FactoryTool
	{
		[SerializeField]
		private CurrentEditingIsland _currentEditingIsland;

		[SerializeField]
		private CommandManager _commandManager;

		[SerializeField]
		private IntVariableSO _islandEditorBrushSize;

		[SerializeField]
		private BoxEvent _updateBoxSize;

		[SerializeField]
		private BaseEvent _disableBox;

		[SerializeField]
		private ColorEvent _updateSelectionBoxColor;

		[SerializeField]
		private GridLocator _gridLocator;

		private bool _pressed;

		private Color _colour;

		private readonly List<Vector3Int> _brushPositions = new List<Vector3Int>();

		private Dictionary<Vector3Int, Color32> _previousColors;

		public override bool CanAutoSwapAwayFrom => true;

		public void SetColour(Color colour)
		{
			_colour = colour;
		}

		public override void SelectTool(Blueprint blueprint)
		{
			base.SelectTool(blueprint);
			_pressed = false;
			_previousColors = new Dictionary<Vector3Int, Color32>();
			_islandEditorBrushSize.ValueChanged += CalculateBrushPositions;
			CalculateBrushPositions(_islandEditorBrushSize.Value);
			_updateSelectionBoxColor.Fire(_colour);
		}

		public override void DeSelectTool()
		{
			CancelAction();
			_islandEditorBrushSize.ValueChanged -= CalculateBrushPositions;
			base.DeSelectTool();
		}

		private void CalculateBrushPositions(int brushSize)
		{
			_brushPositions.Clear();
			int num = brushSize / 2;
			int num2 = ((brushSize % 2 == 0) ? (-num) : (-num - 1));
			for (int i = num2; i <= num; i++)
			{
				for (int j = num2; j <= num; j++)
				{
					_brushPositions.Add(new Vector3Int(i, 0, j));
				}
			}
		}

		public override void UpdateTool(Vector3Int gridPos, Vector3 mousePos)
		{
			if (_pressed && !_currentEditingIsland.Empty)
			{
				foreach (Vector3Int brushPosition in _brushPositions)
				{
					if (!_previousColors.ContainsKey(gridPos + brushPosition) && _currentEditingIsland.PaintTexture(gridPos + brushPosition, _colour, out var previousColor))
					{
						_previousColors.Add(gridPos + brushPosition, previousColor);
					}
				}
			}
			_updateBoxSize.Fire(new BoxSize(_brushPositions.First() + gridPos, _brushPositions.Last() + gridPos));
		}

		public override void OnActionIntent(Vector3Int gridPos, Vector3 mousePos)
		{
			_pressed = true;
		}

		public override void DoAction(Vector3Int gridPos, Vector3 mousePos)
		{
			if (_pressed && !_currentEditingIsland.Empty)
			{
				foreach (Vector3Int brushPosition in _brushPositions)
				{
					if (!_previousColors.ContainsKey(gridPos + brushPosition) && _currentEditingIsland.PaintTexture(gridPos + brushPosition, _colour, out var previousColor))
					{
						_previousColors.Add(gridPos + brushPosition, previousColor);
					}
				}
			}
			_pressed = false;
			_commandManager.DoCommand(new ConfirmTextureColorChanged(_previousColors, _currentEditingIsland.IslandData));
			_previousColors = new Dictionary<Vector3Int, Color32>();
		}

		public override void CancelAction()
		{
			_pressed = false;
			if (_pressed)
			{
				_commandManager.DoCommand(new ConfirmTextureColorChanged(_previousColors, _currentEditingIsland.IslandData));
				_previousColors = new Dictionary<Vector3Int, Color32>();
			}
			_disableBox.Fire();
		}
	}
}
