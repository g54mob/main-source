using System;
using System.Collections.Generic;

namespace Motorways.Views
{
	public class SolidZone
	{
		public PermanenceTextureMappingDatabase.ZoneAddress zoneAddress;

		public readonly int shaderIndex;

		private PermanenceSourceType _sourceType;

		private PermanenceSourceUpdateOrder _permanenceSourceUpdateOrder = PermanenceSourceUpdateOrder.Secondary;

		private TileView _sourceTileView;

		private TileDirection _sourcePermanenceDirection = TileDirection.None;

		private float _sourceFixedValue;

		private readonly List<SolidZone> _solidZoneSources = new List<SolidZone>();

		private SolidZoneTieBreaker? _sourceTieBreaker;

		private readonly SolidZone _defaultSolidZone;

		public PermanenceSourceUpdateOrder PermanenceSourceUpdateOrder => _permanenceSourceUpdateOrder;

		public PermanenceSourceType SourceType => _sourceType;

		public TileDirection SourceDirection => _sourcePermanenceDirection;

		public TileView SourceTileView => _sourceTileView;

		private bool IsDefaultZone => _defaultSolidZone == null;

		public float SourcePermanence
		{
			get
			{
				switch (_sourceType)
				{
				case PermanenceSourceType.TileAndDirection:
					return _sourceTileView.GetVisualNodePermanenceProgress(_sourcePermanenceDirection);
				case PermanenceSourceType.FixedValue:
					return _sourceFixedValue;
				case PermanenceSourceType.Default:
					if (!IsDefaultZone)
					{
						return _solidZoneSources[0].SourcePermanence;
					}
					return 0f;
				case PermanenceSourceType.SolidZone:
					return _solidZoneSources[0].SourcePermanence;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public List<string> DebugStrings
		{
			get
			{
				List<string> list = new List<string> { $"({SourceType} - {PermanenceSourceUpdateOrder})" };
				if (_sourceTileView != null)
				{
					list.Add("Tile: " + _sourceTileView.name + " - Direction: " + _sourcePermanenceDirection.ToShortString());
				}
				if (SourceType == PermanenceSourceType.FixedValue)
				{
					list.Add($"Fixed Value: {_sourceFixedValue}");
				}
				else if (SourceType == PermanenceSourceType.SolidZone)
				{
					list.Add($"Source Count: {_solidZoneSources.Count}");
					list.Add("First Entry: " + _solidZoneSources[0].zoneAddress.ToString());
				}
				return list;
			}
		}

		public SolidZone(PermanenceTextureMappingDatabase.ZoneAddress zoneAddress, int shaderIndex, SolidZone defaultSolidZone = null)
		{
			this.zoneAddress = zoneAddress;
			this.shaderIndex = shaderIndex;
			_defaultSolidZone = defaultSolidZone;
			ResetToDefaultSource();
		}

		public void ResetToDefaultSource()
		{
			_sourceType = PermanenceSourceType.Default;
			_permanenceSourceUpdateOrder = PermanenceSourceUpdateOrder.Secondary;
			_solidZoneSources.Clear();
			if (_defaultSolidZone != null)
			{
				_solidZoneSources.Add(_defaultSolidZone);
			}
			_sourceTileView = null;
			_sourceTieBreaker = null;
			_sourcePermanenceDirection = TileDirection.None;
		}

		public void SetTileAndDirectionSource(TileView tileView, TileDirection tileDirection)
		{
			_permanenceSourceUpdateOrder = PermanenceSourceUpdateOrder.Primary;
			_sourceTileView = tileView;
			_sourcePermanenceDirection = tileDirection;
			_sourceType = PermanenceSourceType.TileAndDirection;
			_solidZoneSources.Clear();
			_sourceTieBreaker = SolidZoneTieBreaker.FirstWins;
		}

		public void SetFixedValueSource(TileView tileView, TileDirection tileDirection, float permanenceValue)
		{
			_permanenceSourceUpdateOrder = PermanenceSourceUpdateOrder.Primary;
			_sourceTileView = tileView;
			_sourcePermanenceDirection = tileDirection;
			_sourceFixedValue = permanenceValue;
			_sourceType = PermanenceSourceType.FixedValue;
			_solidZoneSources.Clear();
			_sourceTieBreaker = SolidZoneTieBreaker.FirstWins;
		}

		public void OfferSolidZoneSource(SolidZone solidZone, SolidZoneTieBreaker tieBreaker, PermanenceSourceUpdateOrder updateOrder = PermanenceSourceUpdateOrder.Secondary)
		{
			if (solidZone == this)
			{
				Diagnostics.FailAssert("SolidZone cannot be its own source!");
				return;
			}
			if (tieBreaker == SolidZoneTieBreaker.FirstWins && _sourceTieBreaker.HasValue)
			{
				Diagnostics.Log.Error("SolidZone", "Multiple solid zones offered for with a 'First' tiebreaker");
			}
			if (_sourceType != PermanenceSourceType.SolidZone)
			{
				_solidZoneSources.Clear();
			}
			_sourceTileView = null;
			_sourcePermanenceDirection = TileDirection.None;
			_sourceType = PermanenceSourceType.SolidZone;
			SolidZoneTieBreaker valueOrDefault = _sourceTieBreaker.GetValueOrDefault();
			if (!_sourceTieBreaker.HasValue)
			{
				valueOrDefault = tieBreaker;
				_sourceTieBreaker = valueOrDefault;
			}
			_solidZoneSources.Add(solidZone);
			_permanenceSourceUpdateOrder = updateOrder;
		}

		public bool UsesSameSourceAs(SolidZone otherSolidZone)
		{
			if (SourceType != otherSolidZone.SourceType)
			{
				return false;
			}
			if (SourceType == PermanenceSourceType.SolidZone)
			{
				SolidZone solidZone = FindBaseSolidZone();
				SolidZone solidZone2 = otherSolidZone.FindBaseSolidZone();
				return solidZone == solidZone2;
			}
			if (SourceType == PermanenceSourceType.TileAndDirection)
			{
				if (_sourceTileView == otherSolidZone._sourceTileView)
				{
					return _sourcePermanenceDirection == otherSolidZone._sourcePermanenceDirection;
				}
				return false;
			}
			return false;
		}

		public SolidZone FindBaseSolidZone()
		{
			if (_solidZoneSources.Count == 0)
			{
				return this;
			}
			SolidZone solidZone = _solidZoneSources[0];
			while (solidZone.SourceType == PermanenceSourceType.SolidZone && !solidZone.IsDefaultZone && solidZone._solidZoneSources.Count > 0)
			{
				solidZone = solidZone._solidZoneSources[0];
			}
			return solidZone;
		}

		public void RemoveFixedSourcesIfOtherSourcesHaveBeenOffered()
		{
			bool flag = false;
			foreach (SolidZone solidZoneSource in _solidZoneSources)
			{
				if (solidZoneSource.SourceType != PermanenceSourceType.FixedValue)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return;
			}
			for (int num = _solidZoneSources.Count - 1; num >= 0; num--)
			{
				if (_solidZoneSources[num].SourceType == PermanenceSourceType.FixedValue)
				{
					_solidZoneSources.RemoveAt(num);
				}
			}
		}

		public void OfferSolidZoneSource(TileView tileView, TileDirection tileDirection, SolidZoneTieBreaker tieBreaker)
		{
			if (_permanenceSourceUpdateOrder != PermanenceSourceUpdateOrder.Primary)
			{
				SolidZone solidZoneInDirection = tileView.tileViewPermanenceZoneUpdater.GetSolidZoneInDirection(tileDirection, PermanenceTextureMappingDatabase.ZoneSharing.Local);
				OfferSolidZoneSource(solidZoneInDirection, tieBreaker);
			}
		}

		public void DecideSolidZoneSourceWinner()
		{
			if (_solidZoneSources.Count > 1)
			{
				SolidZone item = FindWinningSolidZone();
				_solidZoneSources.Clear();
				_solidZoneSources.Add(item);
			}
		}

		private SolidZone FindWinningSolidZone()
		{
			SolidZone solidZone = _solidZoneSources[0];
			if (_sourceTieBreaker == SolidZoneTieBreaker.FirstWins)
			{
				return solidZone;
			}
			for (int i = 1; i < _solidZoneSources.Count; i++)
			{
				SolidZone solidZone2 = _solidZoneSources[i];
				if (_sourceTieBreaker == SolidZoneTieBreaker.LeastPermanent && solidZone2.SourcePermanence < solidZone.SourcePermanence)
				{
					solidZone = solidZone2;
				}
				if (_sourceTieBreaker == SolidZoneTieBreaker.MostPermanent && solidZone2.SourcePermanence > solidZone.SourcePermanence)
				{
					solidZone = solidZone2;
				}
			}
			return solidZone;
		}
	}
}
