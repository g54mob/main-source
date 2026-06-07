using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public class AtmosphereHeatMapGenerator : MonoBehaviour
	{
		public bool drawingEnabled;

		private string _effectName;

		private bool _showEquilibrium;

		public List<HeatMapGeneratorData> heatMapGeneratorData;

		private Dictionary<string, HeatMapGeneratorData> _heatMapGeneratorDataDictionary;

		private Texture2D _lowResHeatMapTexture;

		private Material _lowResHeatMapMaterial;

		private MeshRenderer _meshRenderer;

		private GridController _gridController;

		private AtmosphereController _atmosphereController;

		private Vector3 _gridOffsets;

		private Vector3 _meshPosition;

		private int _texSideDimension;

		private Vector3 _meshSize;

		private Tweener _alphaTweenIn;

		private Tweener _alphaTweenOut;

		private Color _alphaTweenBaseColour;

		private int _previousDataId;

		private int _previousDataIdSecondaryEffect;

		private string _previousEffect;

		private static Color _transparent;

		public string EffectName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool ShowEquilibrium
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void GenerateLowResHeatMapTextureIfNeeded()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void ChangeHeatmapIfNeeded()
		{
		}

		private void OnDestroy()
		{
		}

		public void SetupHeatMap()
		{
		}

		public void ResetHeatTexture()
		{
		}

		private bool IsSameDataAsBefore()
		{
			return false;
		}

		private bool IsDataIdSameAsLastTime(string effect, bool isSecondary)
		{
			return false;
		}

		public void GenerateLowResHeatMapTexture()
		{
		}

		private Color GetColorForTile(TileData tile, HeatMapGeneratorData generatorData)
		{
			return default(Color);
		}

		private void OnGenerationComplete(object sender, EventArgs<string> e)
		{
		}

		private void MakePixelsTransparent(Texture2D texture)
		{
		}
	}
}
