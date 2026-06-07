using System;
using System.Collections.Generic;
using Factory;
using Factory.Pools;
using Motorways.Models;
using Motorways.Views;

namespace Motorways
{
	public class ClientUpgradeDatabase : UpgradeDatabase, UpgradeDatabase.IObserver, IReleasedFromScopeHandler, IReusable
	{
		private UpgradeDatabaseModel _model;

		private bool _dirty;

		private int[] _availableOrDraftUpgrades = new int[9];

		private HashSet<ClientTileEdit> _clientTileEdits = new HashSet<ClientTileEdit>();

		[Dependency]
		private TilemapView _tilemapView;

		public void Initialize(UpgradeDatabaseModel model)
		{
			_model = model;
			_model.Subscribe(this);
			_dirty = true;
		}

		public override void Reset()
		{
			base.Reset();
			_clientTileEdits.Clear();
			_model = null;
			_dirty = false;
			for (int i = 0; i < 9; i++)
			{
				_availableOrDraftUpgrades[i] = 0;
			}
		}

		public int GetAvailableOrDraftUpgradeCount(UpgradeType upgradeType)
		{
			UpdateDatabase();
			return _availableOrDraftUpgrades[(int)upgradeType];
		}

		public override int GetAvailableUpgradeCount(UpgradeType upgradeType)
		{
			UpdateDatabase();
			return base.GetAvailableUpgradeCount(upgradeType);
		}

		public override bool HasUpgradeAvailable(UpgradeType upgradeType, int quantityRequired = 1)
		{
			UpdateDatabase();
			return base.HasUpgradeAvailable(upgradeType, quantityRequired);
		}

		public override bool ConsumeUpgrade(UpgradeType upgradeType, int quantityToConsume = 1)
		{
			UpdateDatabase();
			return base.ConsumeUpgrade(upgradeType, quantityToConsume);
		}

		public override bool MothballUpgrade(UpgradeType upgradeType, int quantityToMothball = 1)
		{
			UpdateDatabase();
			return base.MothballUpgrade(upgradeType, quantityToMothball);
		}

		public override bool UnmothballUpgrade(UpgradeType upgradeType, int quantityToUnmothball = 1)
		{
			UpdateDatabase();
			return base.UnmothballUpgrade(upgradeType, quantityToUnmothball);
		}

		public override bool ReleaseMothballedUpgrade(UpgradeType upgradeType, int quantityToRelease = 1)
		{
			UpdateDatabase();
			return base.ReleaseMothballedUpgrade(upgradeType, quantityToRelease);
		}

		public override bool ApplyEdit(TileEdit edit, ITilemap tilemap)
		{
			UpdateDatabase();
			return base.ApplyEdit(edit, tilemap);
		}

		public override void CloneInto(UpgradeDatabase cloneDatabase)
		{
			UpdateDatabase();
			base.CloneInto(cloneDatabase);
		}

		public void AddTileEdit(ClientTileEdit tileEdit)
		{
			_clientTileEdits.Add(tileEdit);
			_dirty = true;
		}

		public void RemoveTileEdit(ClientTileEdit tileEdit)
		{
			_clientTileEdits.Remove(tileEdit);
			_dirty = true;
		}

		public void OnDraftEditsScheduled()
		{
			_dirty = true;
		}

		public void OnEditApplied(UpgradeDatabase database, TileEdit tileEdit)
		{
			foreach (ClientTileEdit clientTileEdit in _clientTileEdits)
			{
				if (clientTileEdit.edit == tileEdit)
				{
					_clientTileEdits.Remove(clientTileEdit);
					_dirty = true;
					break;
				}
			}
		}

		public void OnUpgradesChanged(UpgradeDatabase database)
		{
			_dirty = true;
		}

		private void UpdateDatabase()
		{
			if (!_dirty)
			{
				return;
			}
			_dirty = false;
			_model.CloneInto(this);
			foreach (ClientTileEdit clientTileEdit in _clientTileEdits)
			{
				if (!clientTileEdit.isDraft)
				{
					ApplyEdit(clientTileEdit.edit, _tilemapView);
				}
			}
			Array.Copy(_availableUpgrades, _availableOrDraftUpgrades, _availableUpgrades.Length);
			foreach (ClientTileEdit clientTileEdit2 in _clientTileEdits)
			{
				if (clientTileEdit2.isDraft)
				{
					ApplyEdit(clientTileEdit2.edit, _tilemapView);
				}
			}
		}

		public void OnReleasedFromScope(IScope scope)
		{
			if (_model != null)
			{
				_model.Unsubscribe(this);
				_model = null;
			}
		}
	}
}
