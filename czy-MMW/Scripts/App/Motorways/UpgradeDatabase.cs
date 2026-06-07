using System.Collections.Generic;
using Factory;
using Motorways.Models;

namespace Motorways
{
	public class UpgradeDatabase
	{
		public interface IObserver
		{
			void OnEditApplied(UpgradeDatabase database, TileEdit appliedEdit);

			void OnUpgradesChanged(UpgradeDatabase database);
		}

		public static readonly UpgradeType[] UpgradeTypes = new UpgradeType[6]
		{
			UpgradeType.Concrete,
			UpgradeType.Bridge,
			UpgradeType.Motorway,
			UpgradeType.TrafficLight,
			UpgradeType.Roundabout,
			UpgradeType.Tunnel
		};

		[Serialize(false, null)]
		private ObserverList<IObserver> _observers = new ObserverList<IObserver>();

		[Serialize(false, null)]
		public Dictionary<UpgradeType, int> numberOfTimesAnUpgradeIsPlaced = new Dictionary<UpgradeType, int>();

		protected int[] _totalUpgrades = new int[9];

		protected int[] _availableUpgrades = new int[9];

		protected int[] _mothballedUpgrades = new int[9];

		[Dependency]
		private GameBehaviourModel _behaviour;

		public virtual void Reset()
		{
			for (int i = 0; i < 9; i++)
			{
				_totalUpgrades[i] = 0;
				_availableUpgrades[i] = 0;
				_mothballedUpgrades[i] = 0;
			}
			numberOfTimesAnUpgradeIsPlaced.Clear();
		}

		public void AwardStartingPackages()
		{
			for (int i = 0; i < 9; i++)
			{
				_totalUpgrades[i] = _behaviour.GetAmountOfStartingUpgradesForType((UpgradeType)i);
				_availableUpgrades[i] = _totalUpgrades[i];
			}
		}

		public virtual int GetAvailableUpgradeCount(UpgradeType upgradeType)
		{
			return _availableUpgrades[(int)upgradeType];
		}

		public virtual int GetTotalUpgradeCount(UpgradeType upgradeType)
		{
			return _totalUpgrades[(int)upgradeType];
		}

		public virtual int GetUsedUpgradeCount(UpgradeType upgradeType)
		{
			return GetTotalUpgradeCount(upgradeType) - GetAvailableUpgradeCount(upgradeType);
		}

		public virtual bool HasUpgradeAvailable(UpgradeType upgradeType, int quantityRequired = 1)
		{
			if (_behaviour.HasUnlimitedOfUpgrade(upgradeType))
			{
				return true;
			}
			return GetAvailableUpgradeCount(upgradeType) >= quantityRequired;
		}

		public virtual bool AddUpgradeToTotal(UpgradeType upgradeType, int quantityToAdd = 1)
		{
			_totalUpgrades[(int)upgradeType] += quantityToAdd;
			return true;
		}

		public virtual bool ConsumeUpgrade(UpgradeType upgradeType, int quantityToConsume = 1)
		{
			if (HasUpgradeAvailable(upgradeType, quantityToConsume))
			{
				if (!numberOfTimesAnUpgradeIsPlaced.ContainsKey(upgradeType))
				{
					numberOfTimesAnUpgradeIsPlaced.Add(upgradeType, quantityToConsume);
				}
				else
				{
					numberOfTimesAnUpgradeIsPlaced[upgradeType] += quantityToConsume;
				}
				if (_behaviour.HasUnlimitedOfUpgrade(upgradeType))
				{
					_totalUpgrades[(int)upgradeType] += quantityToConsume;
				}
				else
				{
					_availableUpgrades[(int)upgradeType] -= quantityToConsume;
				}
				NotifyUpgradesChanged();
				return true;
			}
			return false;
		}

		public virtual bool MothballUpgrade(UpgradeType upgradeType, int quantityToMothball = 1)
		{
			int num = _totalUpgrades[(int)upgradeType] - _availableUpgrades[(int)upgradeType];
			if (!Diagnostics.Verify(_mothballedUpgrades[(int)upgradeType] + quantityToMothball <= num, "Mothballed more {0} upgrades than we have. Already mothballed {1} and tried to mothball {2} more, but max is {3}.", upgradeType, _mothballedUpgrades[(int)upgradeType], quantityToMothball, num))
			{
				_mothballedUpgrades[(int)upgradeType] = num;
				NotifyUpgradesChanged();
				return false;
			}
			_mothballedUpgrades[(int)upgradeType] += quantityToMothball;
			NotifyUpgradesChanged();
			return true;
		}

		public virtual bool UnmothballUpgrade(UpgradeType upgradeType, int quantityToUnmothball = 1)
		{
			if (!Diagnostics.Verify(_mothballedUpgrades[(int)upgradeType] >= quantityToUnmothball, $"Unmothballed more {upgradeType} upgrades than we have mothballed. Expected {_mothballedUpgrades[(int)upgradeType]}, but tried to unmothball {quantityToUnmothball}. "))
			{
				_mothballedUpgrades[(int)upgradeType] = 0;
				NotifyUpgradesChanged();
				return false;
			}
			_mothballedUpgrades[(int)upgradeType] -= quantityToUnmothball;
			NotifyUpgradesChanged();
			return true;
		}

		public virtual bool ReleaseMothballedUpgrade(UpgradeType upgradeType, int quantityToRelease = 1)
		{
			bool result = true;
			if (!Diagnostics.Verify(quantityToRelease <= _mothballedUpgrades[(int)upgradeType], "Tried to release more {0} than were mothballed.", upgradeType))
			{
				quantityToRelease = _mothballedUpgrades[(int)upgradeType];
				result = false;
			}
			_mothballedUpgrades[(int)upgradeType] -= quantityToRelease;
			if (_behaviour.HasUnlimitedOfUpgrade(upgradeType))
			{
				_totalUpgrades[(int)upgradeType] -= quantityToRelease;
			}
			else
			{
				_availableUpgrades[(int)upgradeType] += quantityToRelease;
			}
			NotifyUpgradesChanged();
			return result;
		}

		public virtual bool ApplyEdit(TileEdit edit, ITilemap tilemap)
		{
			NotifyEditApplied(edit);
			return edit.ApplyToUpgradeDatabase(this, tilemap);
		}

		public virtual void CloneInto(UpgradeDatabase cloneDatabase)
		{
			bool flag = false;
			for (int i = 0; i < 9; i++)
			{
				flag |= _totalUpgrades[i] != cloneDatabase._totalUpgrades[i];
				cloneDatabase._totalUpgrades[i] = _totalUpgrades[i];
				flag |= _availableUpgrades[i] != cloneDatabase._availableUpgrades[i];
				cloneDatabase._availableUpgrades[i] = _availableUpgrades[i];
				flag |= _mothballedUpgrades[i] != cloneDatabase._mothballedUpgrades[i];
				cloneDatabase._mothballedUpgrades[i] = _mothballedUpgrades[i];
			}
			if (flag)
			{
				cloneDatabase.NotifyUpgradesChanged();
			}
		}

		public void Subscribe(IObserver observer)
		{
			_observers.Subscribe(observer);
		}

		public bool Unsubscribe(IObserver observer)
		{
			return _observers.Unsubscribe(observer);
		}

		private void NotifyEditApplied(TileEdit edit)
		{
			ObserverList<IObserver>.Enumerator enumerator = _observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnEditApplied(this, edit);
			}
		}

		protected void NotifyUpgradesChanged()
		{
			ObserverList<IObserver>.Enumerator enumerator = _observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnUpgradesChanged(this);
			}
		}
	}
}
