using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers;
using ModApi.Craft.Parts;
using ModApi.Craft.Propulsion;
using UnityEngine;

namespace Assets.Scripts.Craft.Fuel
{
	public class CraftFuelSource : IFuelSource, IFuelSourceCollection
	{
		private FuelSourceGroup _crossFeedPullSources;

		private int _currentDrainIndex;

		private int _currentFillIndex;

		private double _fuelAdded;

		private double _fuelRemoved;

		private List<IFuelSource> _fuelSources;

		private FuelTransferMode _fuelTransferMode;

		private bool _recalculateSubPriority;

		public int Count
		{
			get
			{
				int num = 0;
				foreach (IFuelSource fuelSource in _fuelSources)
				{
					num = ((!(fuelSource is IFuelSourceCollection fuelSourceCollection)) ? (num + 1) : (num + fuelSourceCollection.Count));
				}
				return num;
			}
		}

		public IFuelTransferManager FuelTransferManager { get; set; }

		public FuelTransferMode FuelTransferMode
		{
			get
			{
				return _fuelTransferMode;
			}
			set
			{
				if (_fuelTransferMode == value)
				{
					return;
				}
				if (FuelTransferMode == FuelTransferMode.None && value != FuelTransferMode.None)
				{
					if (SupportsFuelTransfer)
					{
						foreach (IFuelSource fuelSource in _fuelSources)
						{
							fuelSource.FuelTransferMode = FuelTransferMode.None;
						}
						FuelTransferManager.AddFuelSource(this);
						_fuelTransferMode = value;
					}
					else
					{
						Debug.LogError("Cannot enable fuel transfer on a disconnected fuel source");
					}
				}
				else if (FuelTransferMode != FuelTransferMode.None && value == FuelTransferMode.None)
				{
					FuelTransferManager.RemoveFuelSource(this);
					_fuelTransferMode = value;
				}
				else
				{
					_fuelTransferMode = value;
				}
			}
		}

		public FuelType FuelType { get; private set; }

		public int Id { get; set; }

		public bool IsDead => Count == 0;

		public bool IsDestroyed => false;

		public bool IsEmpty
		{
			get
			{
				if (TotalFuel <= 9.999999747378752E-05)
				{
					return !Game.InfiniteFuelEnabled;
				}
				return false;
			}
		}

		public Vector3 Position
		{
			get
			{
				Vector3 zero = Vector3.zero;
				float num = 0f;
				foreach (IFuelSource fuelSource in _fuelSources)
				{
					zero += fuelSource.Position * (float)fuelSource.TotalCapacity;
					num += (float)fuelSource.TotalCapacity;
				}
				if (num > 0f)
				{
					return zero / num;
				}
				return Vector3.zero;
			}
		}

		public int Priority => 0;

		public bool ReverseSubPriority { get; set; }

		public int SubPriority => 0;

		public bool SupportsFuelTransfer { get; set; } = true;

		public double TotalCapacity { get; private set; }

		public double TotalFuel { get; private set; }

		public CraftFuelSource(IFuelTransferManager fuelTransferManager, int id, FuelType fuelType)
		{
			FuelTransferManager = fuelTransferManager;
			Id = id;
			_fuelSources = new List<IFuelSource>();
			FuelType = fuelType;
			_recalculateSubPriority = Game.InDesignerScene;
		}

		public void AddCrossFeedPullSource(IFuelSource fuelSource)
		{
			if (_crossFeedPullSources == null)
			{
				_crossFeedPullSources = new FuelSourceGroup(0, 0, FuelType);
			}
			_crossFeedPullSources.AddFuelSource(fuelSource);
		}

		public double AddFuel(double amount)
		{
			double num = TotalCapacity - TotalFuel;
			double num2;
			if (amount < num)
			{
				num2 = amount;
				TotalFuel += amount;
			}
			else
			{
				num2 = num;
				TotalFuel = TotalCapacity;
			}
			_fuelAdded += num2;
			return num2;
		}

		public void AddFuelTank(FuelTankScript fuelTank)
		{
			bool flag = false;
			fuelTank.CraftFuelSource = this;
			if (_recalculateSubPriority)
			{
				fuelTank.CalculateSubPriority(ReverseSubPriority);
			}
			for (int i = 0; i < _fuelSources.Count; i++)
			{
				if (fuelTank.Data.Priority > _fuelSources[i].Priority)
				{
					_fuelSources.Insert(i, fuelTank);
					flag = true;
					break;
				}
				if (fuelTank.Data.Priority == _fuelSources[i].Priority)
				{
					if (fuelTank.Data.Priority != 0)
					{
						GetOrCreateFuelSourceGroupAtIndex(i).AddFuelSource(fuelTank);
						flag = true;
						break;
					}
					if (fuelTank.Data.SubPriority > _fuelSources[i].SubPriority)
					{
						_fuelSources.Insert(i, fuelTank);
						flag = true;
						break;
					}
					if (fuelTank.Data.SubPriority == _fuelSources[i].SubPriority)
					{
						GetOrCreateFuelSourceGroupAtIndex(i).AddFuelSource(fuelTank);
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				_fuelSources.Add(fuelTank);
			}
			TotalCapacity += fuelTank.Data.Capacity;
			TotalFuel += fuelTank.Data.Fuel;
			_currentFillIndex = _fuelSources.Count - 1;
		}

		public void ClearCrossFeeds()
		{
			_crossFeedPullSources = null;
		}

		public bool ContainsFuelSource(IFuelSource fuelSource)
		{
			foreach (IFuelSource fuelSource2 in _fuelSources)
			{
				if (fuelSource == fuelSource2)
				{
					return true;
				}
				IFuelSourceCollection obj = fuelSource2 as IFuelSourceCollection;
				if (obj != null && obj.ContainsFuelSource(fuelSource))
				{
					return true;
				}
			}
			return false;
		}

		public int GetFuelSourceOrderInSet(IFuelSource fuelSource)
		{
			int num = 0;
			while (num < _fuelSources.Count)
			{
				if (fuelSource != _fuelSources[num])
				{
					FuelSourceGroup obj = _fuelSources[num] as FuelSourceGroup;
					if (obj == null || !obj.ContainsFuelSource(fuelSource))
					{
						num++;
						continue;
					}
				}
				return num + 1;
			}
			return -1;
		}

		public void RecalculateFuel()
		{
			double num = 0.0;
			double num2 = 0.0;
			foreach (IFuelSource fuelSource in _fuelSources)
			{
				num += fuelSource.TotalCapacity;
				num2 += fuelSource.TotalFuel;
			}
			TotalCapacity = num;
			TotalFuel = num2;
			_currentFillIndex = _fuelSources.Count - 1;
			_currentDrainIndex = 0;
		}

		public double RemoveFuel(double amount)
		{
			double num = 0.0;
			if (TotalFuel > amount)
			{
				num = amount;
				TotalFuel -= amount;
			}
			else if (TotalFuel > 0.0)
			{
				num = TotalFuel;
				TotalFuel = 0.0;
			}
			_fuelRemoved += num;
			return num;
		}

		public void RemoveFuelSource(IFuelSource fuelSource)
		{
			UpdateFuel();
			bool flag = false;
			for (int i = 0; i < _fuelSources.Count; i++)
			{
				if (fuelSource == _fuelSources[i])
				{
					_fuelSources.RemoveAt(i);
					flag = true;
					break;
				}
				if (_fuelSources[i] is IFuelSourceCollection fuelSourceCollection && fuelSourceCollection.ContainsFuelSource(fuelSource))
				{
					fuelSourceCollection.RemoveFuelSource(fuelSource);
					flag = true;
					if (fuelSourceCollection.Count == 0)
					{
						_fuelSources.RemoveAt(i);
						break;
					}
				}
			}
			if (flag)
			{
				if (_fuelSources.Count == 0)
				{
					SupportsFuelTransfer = false;
					FuelTransferMode = FuelTransferMode.None;
					TotalCapacity = 0.0;
					TotalFuel = 0.0;
					_currentFillIndex = 0;
					_currentDrainIndex = 0;
				}
				else
				{
					TotalCapacity -= fuelSource.TotalCapacity;
					TotalFuel -= fuelSource.TotalFuel;
					_currentFillIndex = _fuelSources.Count - 1;
					_currentDrainIndex = 0;
				}
			}
			else
			{
				Debug.LogErrorFormat("Could not remove fuel source with fuel type {0}", fuelSource.FuelType.Name);
			}
		}

		public void UpdateCrossFeeds(float deltaTime)
		{
			if (_crossFeedPullSources != null)
			{
				double b = TotalCapacity - TotalFuel;
				double a = FuelType.FuelTransferRate * (float)_crossFeedPullSources.Count * deltaTime;
				a = Mathd.Min(a, b);
				double amount = _crossFeedPullSources.RemoveFuel(a);
				AddFuel(amount);
			}
		}

		public double UpdateFuel()
		{
			double num = _fuelAdded - _fuelRemoved;
			_fuelAdded = (_fuelRemoved = 0.0);
			if (num > 0.0)
			{
				double num2 = num;
				if (_currentFillIndex > _fuelSources.Count - 1)
				{
					_currentFillIndex = _fuelSources.Count - 1;
				}
				while (num2 > 9.999999747378752E-05 && _currentFillIndex >= 0)
				{
					num2 -= _fuelSources[_currentFillIndex].AddFuel(num2);
					if (num2 > 9.999999747378752E-05)
					{
						_currentFillIndex--;
					}
				}
				if (_currentDrainIndex > _currentFillIndex)
				{
					_currentDrainIndex = _currentFillIndex;
				}
			}
			else if (num < 0.0)
			{
				double num3 = 0.0 - num;
				if (_currentDrainIndex < 0)
				{
					_currentDrainIndex = 0;
				}
				while (num3 > 9.999999747378752E-05 && _currentDrainIndex < _fuelSources.Count)
				{
					num3 -= _fuelSources[_currentDrainIndex].RemoveFuel(num3);
					if (num3 > 9.999999747378752E-05)
					{
						_currentDrainIndex++;
					}
				}
				if (_currentFillIndex < _currentDrainIndex)
				{
					_currentFillIndex = _currentDrainIndex;
				}
			}
			return num;
		}

		private FuelSourceGroup GetOrCreateFuelSourceGroupAtIndex(int index)
		{
			IFuelSource fuelSource = _fuelSources[index];
			FuelSourceGroup fuelSourceGroup = fuelSource as FuelSourceGroup;
			if (fuelSourceGroup == null)
			{
				fuelSourceGroup = new FuelSourceGroup(fuelSource.Priority, fuelSource.SubPriority, fuelSource.FuelType);
				fuelSourceGroup.AddFuelSource(fuelSource);
				_fuelSources[index] = fuelSourceGroup;
			}
			return fuelSourceGroup;
		}
	}
}
