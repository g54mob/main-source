using Motorways.Audio;
using UnityEngine;

namespace Motorways.Views
{
	public class TileMatrixView : MonoBehaviour
	{
		private TileMatrixInt _sourceMatrix;

		private int _minData = -1;

		private int _maxData = -1;

		private DebugTileDataViewer _debugViewer;

		public TileMatrixInt SourceMatrix
		{
			get
			{
				return _sourceMatrix;
			}
			set
			{
				_sourceMatrix = value;
			}
		}

		public void SetTileColors(int minData, int maxData)
		{
			_minData = minData;
			_maxData = maxData;
		}

		public void Awake()
		{
			_debugViewer = base.gameObject.AddComponent<DebugTileDataViewer>();
			_debugViewer.tileCoordinatesOn = false;
		}

		public void Update()
		{
			foreach (Vector2Int item in _sourceMatrix.Dimensions.allPositionsWithin)
			{
				int num = _sourceMatrix[item];
				if (num != int.MaxValue)
				{
					_debugViewer.stringData[item] = $"{num}";
					_debugViewer.squareTileData[item] = new Color(1f, 0f, 0f, Maf.Map(num, _minData, _maxData, 0f, 0.5f));
				}
			}
		}
	}
}
