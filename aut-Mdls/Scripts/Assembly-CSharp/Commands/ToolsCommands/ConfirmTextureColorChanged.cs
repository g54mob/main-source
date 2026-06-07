using System.Collections.Generic;
using Data.FactoryFloor.Islands;
using UnityEngine;

namespace Commands.ToolsCommands
{
	public class ConfirmTextureColorChanged : ICommandUndo, ICommand
	{
		private Dictionary<Vector3Int, Color32> _previousColors = new Dictionary<Vector3Int, Color32>();

		private IslandData _islandData;

		private bool _undoDone;

		public ConfirmTextureColorChanged(Dictionary<Vector3Int, Color32> previousColors, IslandData islandData)
		{
			_previousColors = previousColors;
			_islandData = islandData;
		}

		public bool TryDo()
		{
			if (_undoDone)
			{
				return TryUnDo();
			}
			return true;
		}

		public bool TryReDo()
		{
			return TryDo();
		}

		public bool TryUnDo()
		{
			_undoDone = true;
			Dictionary<Vector3Int, Color32> dictionary = new Dictionary<Vector3Int, Color32>();
			foreach (KeyValuePair<Vector3Int, Color32> previousColor2 in _previousColors)
			{
				if (_islandData.PaintTexture(previousColor2.Key, previousColor2.Value, out var previousColor))
				{
					dictionary.Add(previousColor2.Key, previousColor);
				}
			}
			_previousColors = dictionary;
			return true;
		}
	}
}
