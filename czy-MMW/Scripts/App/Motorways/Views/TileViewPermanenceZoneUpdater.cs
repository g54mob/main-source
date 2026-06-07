using System.Collections.Generic;
using Client;
using Easing;
using UnityEngine;

namespace Motorways.Views
{
	public class TileViewPermanenceZoneUpdater
	{
		private readonly TileView _tileView;

		private readonly SolidZone[] _solidZones;

		private readonly float[] _shaderSolidZonePermanenceValues;

		private readonly Dictionary<int, TweenFloat> _animatedPermanenceZoneValues;

		private readonly VisualConstantsData _visualConstants;

		private readonly PermanenceTextureMappingDatabase _permanenceTextureMappingDatabase;

		private readonly SolidZone _centerSolidZone;

		private readonly ViewClient _viewClient;

		private readonly List<TileView> _adjacentTileViewsToUpdate = new List<TileView>();

		private bool _shouldUpdatePhantomZones;

		private readonly List<int> _animationsToRemove = new List<int>(10);

		public SolidZone[] SolidZones => _solidZones;

		public float[] ShaderSolidZonePermanenceValues => _shaderSolidZonePermanenceValues;

		public TileViewPermanenceZoneUpdater(TileView tileView, VisualConstantsData visualConstants, PermanenceTextureMappingDatabase permanenceTextureMappingDatabase, ViewClient viewClient)
		{
			_visualConstants = visualConstants;
			_tileView = tileView;
			_permanenceTextureMappingDatabase = permanenceTextureMappingDatabase;
			_viewClient = viewClient;
			_shaderSolidZonePermanenceValues = new float[permanenceTextureMappingDatabase.ShaderSolidZoneCount];
			_solidZones = new SolidZone[permanenceTextureMappingDatabase.ShaderSolidZoneCount];
			PermanenceTextureMappingDatabase.ZoneAddress zoneAddress = permanenceTextureMappingDatabase.solidZoneShaderIndices[0];
			_centerSolidZone = new SolidZone(zoneAddress, 0);
			_solidZones[0] = _centerSolidZone;
			for (int i = 1; i < permanenceTextureMappingDatabase.solidZoneShaderIndices.Length; i++)
			{
				PermanenceTextureMappingDatabase.ZoneAddress zoneAddress2 = permanenceTextureMappingDatabase.solidZoneShaderIndices[i];
				_solidZones[i] = new SolidZone(zoneAddress2, i, _centerSolidZone);
			}
			_animatedPermanenceZoneValues = new Dictionary<int, TweenFloat>();
		}

		private int GetZoneIndexFromAddress(PermanenceTextureMappingDatabase.ZoneAddress zoneAddress)
		{
			return _permanenceTextureMappingDatabase.FindShaderSolidZoneIndex(zoneAddress);
		}

		public SolidZone GetSolidZoneInDirection(TileDirection direction, PermanenceTextureMappingDatabase.ZoneSharing sharingStatus)
		{
			return GetSolidZone(direction, TileDirection.None, sharingStatus);
		}

		public SolidZone GetSolidZone(TileDirection direction, TileDirection insideDirection, PermanenceTextureMappingDatabase.ZoneSharing sharingStatus)
		{
			PermanenceTextureMappingDatabase.ZoneAddress zoneAddress = new PermanenceTextureMappingDatabase.ZoneAddress(TileDirection.None, direction, insideDirection, sharingStatus);
			return _solidZones[GetZoneIndexFromAddress(zoneAddress)];
		}

		private SolidZone GetPermanenceSourceForZone(PermanenceTextureMappingDatabase.ZoneAddress zoneAddress)
		{
			return _solidZones[GetZoneIndexFromAddress(zoneAddress)];
		}

		public void UpdateSolidZonePermanenceSources()
		{
			SolidZone[] solidZones = _solidZones;
			for (int i = 0; i < solidZones.Length; i++)
			{
				solidZones[i].ResetToDefaultSource();
			}
			TileDirectionBitfield.Enumerator enumerator = _tileView.ActiveConnectionDirections.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				SolidZone solidZoneInDirection = GetSolidZoneInDirection(current, PermanenceTextureMappingDatabase.ZoneSharing.Local);
				if (_tileView.ShouldDisplayDirectionAsPermanent(current))
				{
					solidZoneInDirection.SetFixedValueSource(_tileView, current, 1f);
				}
				else
				{
					solidZoneInDirection.SetTileAndDirectionSource(_tileView, current);
				}
			}
			solidZones = _solidZones;
			foreach (SolidZone solidZone in solidZones)
			{
				if (solidZone.SourceType == PermanenceSourceType.TileAndDirection || solidZone.SourceType == PermanenceSourceType.FixedValue)
				{
					_centerSolidZone.OfferSolidZoneSource(solidZone, SolidZoneTieBreaker.MostPermanent, PermanenceSourceUpdateOrder.Primary);
				}
			}
			_centerSolidZone.RemoveFixedSourcesIfOtherSourcesHaveBeenOffered();
			enumerator = _tileView.ActiveConnectionDirections.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current2 = enumerator.Current;
				SolidZoneTieBreaker tieBreaker = (TileUtilities.IsDirectionDiagonal(current2) ? SolidZoneTieBreaker.MostPermanent : SolidZoneTieBreaker.LeastPermanent);
				TileDirection rotatedDirection = TileUtilities.GetRotatedDirection(current2, -1);
				TileDirection rotatedDirection2 = TileUtilities.GetRotatedDirection(current2, 1);
				SolidZone solidZoneInDirection2 = GetSolidZoneInDirection(rotatedDirection, PermanenceTextureMappingDatabase.ZoneSharing.Local);
				SolidZone solidZoneInDirection3 = GetSolidZoneInDirection(rotatedDirection2, PermanenceTextureMappingDatabase.ZoneSharing.Local);
				solidZoneInDirection2.OfferSolidZoneSource(_tileView, current2, tieBreaker);
				solidZoneInDirection3.OfferSolidZoneSource(_tileView, current2, tieBreaker);
			}
			for (int j = 0; j < _permanenceTextureMappingDatabase.solidZoneShaderIndices.Length; j++)
			{
				PermanenceTextureMappingDatabase.ZoneAddress zoneAddress = _permanenceTextureMappingDatabase.solidZoneShaderIndices[j];
				if (zoneAddress.tile != TileDirection.None)
				{
					TileView tileView = _tileView.TilemapView.GetTileView(TileUtilities.GetAdjacentCoordinates(_tileView.Coordinates, zoneAddress.tile));
					if (tileView != null && (tileView.ActiveConnectionDirections[zoneAddress.section] || zoneAddress.section == TileDirection.None))
					{
						_solidZones[j].OfferSolidZoneSource(tileView, zoneAddress.section, SolidZoneTieBreaker.FirstWins);
					}
				}
			}
			DecideSolidZoneSourceWinners();
			RemoveHarshAngles();
			UpdateSharedSolidZones();
			DecideSolidZoneSourceWinners();
			StartPrimaryZonePermanenceAnimations();
		}

		private void UpdateSharedSolidZones(bool shouldUpdateAdjacentZones = true)
		{
			TileDirectionBitfield.Enumerator enumerator = _tileView.ActiveConnectionDirections.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				if (!TileUtilities.IsDirectionDiagonal(current))
				{
					continue;
				}
				SolidZone solidZoneInDirection = GetSolidZoneInDirection(current, PermanenceTextureMappingDatabase.ZoneSharing.Shared);
				solidZoneInDirection.OfferSolidZoneSource(_tileView, current, SolidZoneTieBreaker.MostPermanent);
				TileDirection rotatedDirection = TileUtilities.GetRotatedDirection(current, -1);
				TileView tileView = _tileView.TilemapView.GetTileView(TileUtilities.GetAdjacentCoordinates(_tileView.Coordinates, rotatedDirection));
				if (!(tileView != null))
				{
					continue;
				}
				TileDirection rotatedDirection2 = TileUtilities.GetRotatedDirection(current, 2);
				if (tileView.ActiveConnectionDirections[rotatedDirection2])
				{
					solidZoneInDirection.OfferSolidZoneSource(tileView, rotatedDirection2, SolidZoneTieBreaker.MostPermanent);
					if (shouldUpdateAdjacentZones)
					{
						_adjacentTileViewsToUpdate.Add(tileView);
					}
				}
			}
			if (shouldUpdateAdjacentZones)
			{
				enumerator = _tileView.PreviouslyActiveConnectionDirections.GetEnumerator();
				while (enumerator.MoveNext())
				{
					TileDirection rotatedDirection3 = TileUtilities.GetRotatedDirection(enumerator.Current, -1);
					TileView tileView2 = _tileView.TilemapView.GetTileView(TileUtilities.GetAdjacentCoordinates(_tileView.Coordinates, rotatedDirection3));
					if (tileView2 != null)
					{
						_adjacentTileViewsToUpdate.Add(tileView2);
					}
				}
			}
			_shouldUpdatePhantomZones = true;
		}

		private void RemoveHarshAngles()
		{
			TileDirectionBitfield.Enumerator enumerator = _tileView.ActiveConnectionDirections.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				if (TileUtilities.IsDirectionDiagonal(current))
				{
					TileDirection rotatedDirection = TileUtilities.GetRotatedDirection(current, -1);
					TileDirection rotatedDirection2 = TileUtilities.GetRotatedDirection(current, 1);
					SolidZone permanenceSourceForZone = GetPermanenceSourceForZone(PermanenceTextureMappingDatabase.ZoneAddress.LocalDirection(rotatedDirection));
					SolidZone permanenceSourceForZone2 = GetPermanenceSourceForZone(PermanenceTextureMappingDatabase.ZoneAddress.LocalDirection(rotatedDirection2));
					if (Mathf.Approximately(permanenceSourceForZone.SourcePermanence, permanenceSourceForZone2.SourcePermanence) && permanenceSourceForZone.UsesSameSourceAs(permanenceSourceForZone2))
					{
						permanenceSourceForZone2.ResetToDefaultSource();
					}
				}
			}
		}

		private void StartAnimatingTowardsPermanenceValueForZoneIndex(int zoneIndex, float permanenceValue)
		{
			float start = _shaderSolidZonePermanenceValues[zoneIndex];
			if (_animatedPermanenceZoneValues.ContainsKey(zoneIndex))
			{
				_animatedPermanenceZoneValues[zoneIndex] = new TweenFloat();
			}
			else
			{
				_animatedPermanenceZoneValues.Add(zoneIndex, new TweenFloat());
			}
			_animatedPermanenceZoneValues[zoneIndex].Start(start, permanenceValue, _visualConstants.ExpertPermanentRoadsFadeDuration, Easings.Functions.Linear);
		}

		private void ImmediatelyUpdatePermanenceForSolidZoneAtIndex(int zoneIndex, float permanence)
		{
			_shaderSolidZonePermanenceValues[zoneIndex] = permanence;
		}

		private void StartPrimaryZonePermanenceAnimations()
		{
			if (_viewClient.OnFirstFrame)
			{
				return;
			}
			SolidZone[] solidZones = _solidZones;
			foreach (SolidZone solidZone in solidZones)
			{
				if (solidZone.PermanenceSourceUpdateOrder == PermanenceSourceUpdateOrder.Primary)
				{
					StartAnimatingTowardsPermanenceValueForZoneIndex(solidZone.shaderIndex, solidZone.SourcePermanence);
				}
			}
		}

		public void Tick(float deltaTime)
		{
			UpdateAnimatingPrimarySolidZones(deltaTime);
			UpdateNonAnimatingPrimarySolidZones();
		}

		public void LateTick(float deltaTime)
		{
			foreach (TileView item in _adjacentTileViewsToUpdate)
			{
				item.tileViewPermanenceZoneUpdater.ClearSharedSolidZones();
				item.tileViewPermanenceZoneUpdater.UpdateSharedSolidZones(shouldUpdateAdjacentZones: false);
				item.tileViewPermanenceZoneUpdater.DecideSolidZoneSourceWinners();
			}
			_adjacentTileViewsToUpdate.Clear();
			if (_shouldUpdatePhantomZones)
			{
				UpdatePhantomSolidZones();
				_shouldUpdatePhantomZones = false;
			}
			UpdateNonPrimarySolidZones();
		}

		private void UpdatePhantomSolidZones()
		{
			TileDirectionBitfield.Enumerator enumerator = _tileView.ActiveConnectionDirections.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				if (!TileUtilities.IsDirectionDiagonal(current))
				{
					continue;
				}
				SolidZone solidZone = GetSolidZoneInDirection(current, PermanenceTextureMappingDatabase.ZoneSharing.Shared).FindBaseSolidZone();
				if (solidZone.SourceTileView == null)
				{
					continue;
				}
				TileDirection sourceDirection = solidZone.SourceDirection;
				if (TileUtilities.IsDirectionDiagonal(sourceDirection))
				{
					TileDirection oppositeDirection = TileUtilities.GetOppositeDirection(sourceDirection);
					TileDirection rotatedDirection = TileUtilities.GetRotatedDirection(oppositeDirection, -1);
					TileDirection rotatedDirection2 = TileUtilities.GetRotatedDirection(oppositeDirection, 1);
					TileDirection oppositeDirection2 = TileUtilities.GetOppositeDirection(rotatedDirection2);
					TileDirection oppositeDirection3 = TileUtilities.GetOppositeDirection(rotatedDirection);
					SolidZone solidZone2 = GetSolidZone(current, rotatedDirection, PermanenceTextureMappingDatabase.ZoneSharing.Phantom);
					SolidZone solidZone3 = GetSolidZone(current, rotatedDirection2, PermanenceTextureMappingDatabase.ZoneSharing.Phantom);
					solidZone2.OfferSolidZoneSource(solidZone.SourceTileView, oppositeDirection2, SolidZoneTieBreaker.FirstWins);
					solidZone3.OfferSolidZoneSource(solidZone.SourceTileView, oppositeDirection3, SolidZoneTieBreaker.FirstWins);
					TileView tileViewInDirection = solidZone.SourceTileView.GetTileViewInDirection(sourceDirection);
					if (!(tileViewInDirection == null))
					{
						TileDirection oppositeDirection4 = TileUtilities.GetOppositeDirection(rotatedDirection);
						TileDirection oppositeDirection5 = TileUtilities.GetOppositeDirection(rotatedDirection2);
						SolidZone solidZone4 = GetSolidZone(current, oppositeDirection4, PermanenceTextureMappingDatabase.ZoneSharing.Phantom);
						SolidZone solidZone5 = GetSolidZone(current, oppositeDirection5, PermanenceTextureMappingDatabase.ZoneSharing.Phantom);
						TileDirection oppositeDirection6 = TileUtilities.GetOppositeDirection(oppositeDirection5);
						TileDirection oppositeDirection7 = TileUtilities.GetOppositeDirection(oppositeDirection4);
						solidZone4.OfferSolidZoneSource(tileViewInDirection, oppositeDirection6, SolidZoneTieBreaker.FirstWins);
						solidZone5.OfferSolidZoneSource(tileViewInDirection, oppositeDirection7, SolidZoneTieBreaker.FirstWins);
					}
				}
			}
		}

		private void UpdateAnimatingPrimarySolidZones(float deltaTime)
		{
			foreach (KeyValuePair<int, TweenFloat> animatedPermanenceZoneValue in _animatedPermanenceZoneValues)
			{
				int key = animatedPermanenceZoneValue.Key;
				if (_solidZones[key].PermanenceSourceUpdateOrder == PermanenceSourceUpdateOrder.Primary)
				{
					TweenFloat tweenFloat = _animatedPermanenceZoneValues[key];
					if (tweenFloat.IsActive)
					{
						tweenFloat.Tick(deltaTime);
					}
					else
					{
						_animationsToRemove.Add(animatedPermanenceZoneValue.Key);
					}
					ImmediatelyUpdatePermanenceForSolidZoneAtIndex(key, tweenFloat.Value);
				}
			}
			foreach (int item in _animationsToRemove)
			{
				_animatedPermanenceZoneValues.Remove(item);
			}
			_animationsToRemove.Clear();
		}

		private void UpdateNonAnimatingPrimarySolidZones()
		{
			SolidZone[] solidZones = _solidZones;
			foreach (SolidZone solidZone in solidZones)
			{
				if (solidZone.PermanenceSourceUpdateOrder == PermanenceSourceUpdateOrder.Primary && !_animatedPermanenceZoneValues.ContainsKey(solidZone.shaderIndex))
				{
					ImmediatelyUpdatePermanenceForSolidZoneAtIndex(solidZone.shaderIndex, solidZone.SourcePermanence);
				}
			}
		}

		private void UpdateNonPrimarySolidZones()
		{
			SolidZone[] solidZones = _solidZones;
			foreach (SolidZone solidZone in solidZones)
			{
				if (solidZone.PermanenceSourceUpdateOrder != PermanenceSourceUpdateOrder.Primary)
				{
					_shaderSolidZonePermanenceValues[solidZone.shaderIndex] = solidZone.SourcePermanence;
				}
			}
		}

		private void DecideSolidZoneSourceWinners()
		{
			SolidZone[] solidZones = _solidZones;
			for (int i = 0; i < solidZones.Length; i++)
			{
				solidZones[i].DecideSolidZoneSourceWinner();
			}
		}

		private void ClearSharedSolidZones()
		{
			TileDirection[] diagonalDirections = TileUtilities.DiagonalDirections;
			foreach (TileDirection direction in diagonalDirections)
			{
				GetSolidZoneInDirection(direction, PermanenceTextureMappingDatabase.ZoneSharing.Shared).ResetToDefaultSource();
				TileDirection[] nonDiagonalDirections = TileUtilities.NonDiagonalDirections;
				foreach (TileDirection insideDirection in nonDiagonalDirections)
				{
					GetSolidZone(direction, insideDirection, PermanenceTextureMappingDatabase.ZoneSharing.Phantom).ResetToDefaultSource();
				}
			}
		}
	}
}
