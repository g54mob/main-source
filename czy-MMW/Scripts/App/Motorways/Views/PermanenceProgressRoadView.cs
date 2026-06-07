using Motorways.Models;
using UnityEngine;

namespace Motorways.Views
{
	public class PermanenceProgressRoadView
	{
		private const int NoDebugZoneIndex = -1;

		private readonly MaterialPropertyBlock _materialPropertyBlock;

		private readonly Renderer _renderer;

		private readonly TileView _tileView;

		private bool _shouldShowPermanenceVisuals;

		private static readonly int TileCoordinatesWorldspace = Shader.PropertyToID("_TileCoordinatesWorldspace");

		private static readonly int PermanenceIndexTexture = Shader.PropertyToID("_PermanenceIndexTexture");

		private static readonly int PermanenceFadeTexture = Shader.PropertyToID("_PermanenceFadeTexture");

		private static readonly int PermanenceValues = Shader.PropertyToID("_PermanenceValues");

		private static readonly int DebugZoneIndex = Shader.PropertyToID("_DebugZoneIndex");

		private static readonly int ShouldShowPermanenceVisuals = Shader.PropertyToID("_ShouldShowPermanenceZones");

		private static readonly int RoundaboutCount = Shader.PropertyToID("_RoundaboutCount");

		private static readonly int RoundaboutCenterWorldspace = Shader.PropertyToID("_RoundaboutCenterWorldspace");

		private static readonly int RoundaboutPermanence = Shader.PropertyToID("_RoundaboutPermanence");

		private readonly PermanenceZoneTextureLibrary _permanenceZoneTextureLibrary;

		private static readonly int ShowDebugView = Shader.PropertyToID("_ShowDebugView");

		private readonly VisualConstantsData _visualConstants;

		public PermanenceProgressRoadView(MaterialPropertyBlock materialPropertyBlock, Renderer renderer, TileView tileView, PermanenceZoneTextureLibrary permanenceZoneTextureLibrary, VisualConstantsData visualConstants, bool shouldShowPermanenceVisuals)
		{
			_materialPropertyBlock = materialPropertyBlock;
			_renderer = renderer;
			_tileView = tileView;
			_permanenceZoneTextureLibrary = permanenceZoneTextureLibrary;
			_visualConstants = visualConstants;
			SetPermanenceVisibility(shouldShowPermanenceVisuals);
			Vector2 vector = (Vector3)TilemapModel.GetWorldPositionForCoordinates(_tileView.Coordinates);
			_renderer.GetPropertyBlock(_materialPropertyBlock);
			_materialPropertyBlock.SetVector(TileCoordinatesWorldspace, vector);
			_renderer.SetPropertyBlock(_materialPropertyBlock);
			UpdatePermanenceTexturesOnRenderer();
			permanenceZoneTextureLibrary.OnTexturesRecreated += UpdatePermanenceTexturesOnRenderer;
			UpdateDebugZoneIndex();
			tileView._visualConstants.OnExpertPermanenceDebugZoneIndexChanged += UpdateDebugZoneIndex;
			UpdateDebugViewOpacity(_tileView._visualConstants.PermanenceDebugViewOpacity);
			tileView._visualConstants.OnExpertPermanenceDebugViewOpacityChanged += delegate
			{
				UpdateDebugViewOpacity(_tileView._visualConstants.PermanenceDebugViewOpacity);
			};
		}

		private void UpdatePermanenceTexturesOnRenderer()
		{
			_renderer.GetPropertyBlock(_materialPropertyBlock);
			_materialPropertyBlock.SetTexture(PermanenceIndexTexture, _permanenceZoneTextureLibrary.PermanenceIndexTexture);
			_materialPropertyBlock.SetTexture(PermanenceFadeTexture, _permanenceZoneTextureLibrary.PermanenceFadeTexture);
			_renderer.SetPropertyBlock(_materialPropertyBlock);
		}

		public void SetPermanenceVisibility(bool shouldShowPermanenceVisuals)
		{
			_shouldShowPermanenceVisuals = shouldShowPermanenceVisuals;
			_renderer.GetPropertyBlock(_materialPropertyBlock);
			_materialPropertyBlock.SetFloat(ShouldShowPermanenceVisuals, shouldShowPermanenceVisuals ? 1f : 0f);
			_renderer.SetPropertyBlock(_materialPropertyBlock);
		}

		private float GetVisualPermanence(float permanence)
		{
			return _visualConstants.DryingRoadFalloff.Evaluate(permanence);
		}

		public void UpdatePermanenceValues()
		{
			if (!_shouldShowPermanenceVisuals || _tileView.tileViewPermanenceZoneUpdater == null)
			{
				return;
			}
			int num = 0;
			Vector2 vector = new Vector2(0f, 0f);
			Vector4 value = new Vector4(0f, 0f, 0f, 0f);
			Tile tile = _tileView.Tile;
			ITilemap tilemap = tile.Tilemap;
			RoadTileConnection roundaboutConnection = tile.GetRoundaboutConnection(RoadState.VisiblyActive);
			if (roundaboutConnection != RoadTileConnection.InvalidConnection)
			{
				Vector2Int coordinatesOffsetForConnection = Roundabout.GetCoordinatesOffsetForConnection(roundaboutConnection);
				Tile tile2 = tilemap.GetTile(_tileView.Tile.Coordinates - coordinatesOffsetForConnection);
				if (tile2 != null)
				{
					num = 1;
					vector.x = GetVisualPermanence((float)tile2.RoundaboutPermanenceProgress);
					value = (Vector2)TilemapModel.GetWorldPositionForCoordinates(tile.Coordinates - coordinatesOffsetForConnection);
				}
			}
			TileDirection[] diagonalDirections = TileUtilities.DiagonalDirections;
			foreach (TileDirection direction in diagonalDirections)
			{
				Vector2Int adjacentCoordinates = TileUtilities.GetAdjacentCoordinates(tile.Coordinates, direction);
				Tile tile3 = tilemap.GetTile(adjacentCoordinates);
				if (tile3 != null && tile3.IsCenterOfRoundabout)
				{
					float visualPermanence = GetVisualPermanence((float)tile3.RoundaboutPermanenceProgress);
					Vector2 vector2 = (Vector2)TilemapModel.GetWorldPositionForCoordinates(adjacentCoordinates);
					if (num != 0)
					{
						vector.y = visualPermanence;
						value.z = vector2.x;
						value.w = vector2.y;
						num = 2;
						break;
					}
					vector.x = visualPermanence;
					value.x = vector2.x;
					value.y = vector2.y;
					num = 1;
				}
			}
			_renderer.GetPropertyBlock(_materialPropertyBlock);
			_materialPropertyBlock.SetInt(RoundaboutCount, num);
			if (num > 0)
			{
				_materialPropertyBlock.SetVector(RoundaboutCenterWorldspace, value);
				_materialPropertyBlock.SetVector(RoundaboutPermanence, vector);
			}
			_materialPropertyBlock.SetFloatArray(PermanenceValues, _tileView.tileViewPermanenceZoneUpdater.ShaderSolidZonePermanenceValues);
			_renderer.SetPropertyBlock(_materialPropertyBlock);
		}

		private void UpdateDebugZoneIndex()
		{
			if (_shouldShowPermanenceVisuals)
			{
				_renderer.GetPropertyBlock(_materialPropertyBlock);
				Diagnostics.Log.Info("PermanenceProgressRoadView", "Updating debug index to {0}", _tileView._visualConstants.PermanenceDebugViewZoneIndex);
				_materialPropertyBlock.SetInt(DebugZoneIndex, _tileView._visualConstants.PermanenceDebugViewZoneIndex);
				_renderer.SetPropertyBlock(_materialPropertyBlock);
			}
		}

		private void UpdateDebugViewOpacity(float debugViewOpacity)
		{
			if (_shouldShowPermanenceVisuals)
			{
				_renderer.GetPropertyBlock(_materialPropertyBlock);
				_materialPropertyBlock.SetFloat(ShowDebugView, debugViewOpacity);
				_renderer.SetPropertyBlock(_materialPropertyBlock);
			}
		}
	}
}
