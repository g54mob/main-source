using System.Collections.Generic;
using ModApi.Craft.Parts;
using ModApi.Craft.Propulsion;
using UnityEngine;

namespace Assets.Scripts.Craft.Fuel
{
	public class FuelSourceGroup : IFuelSource, IFuelSourceCollection
	{
		private List<IFuelSource> _fuelSources = new List<IFuelSource>();

		private FuelTransferMode _fuelTransferMode;

		public int Count => _fuelSources.Count;

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
				foreach (IFuelSource fuelSource in _fuelSources)
				{
					fuelSource.FuelTransferMode = value;
				}
				_fuelTransferMode = value;
			}
		}

		public FuelType FuelType { get; private set; }

		public bool IsDestroyed => false;

		public bool IsEmpty
		{
			get
			{
				if (Game.InfiniteFuelEnabled)
				{
					return false;
				}
				foreach (IFuelSource fuelSource in _fuelSources)
				{
					if (!fuelSource.IsEmpty)
					{
						return false;
					}
				}
				return true;
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

		public int Priority { get; private set; }

		public int SubPriority { get; private set; }

		public bool SupportsFuelTransfer => false;

		public double TotalCapacity
		{
			get
			{
				double num = 0.0;
				foreach (IFuelSource fuelSource in _fuelSources)
				{
					num += fuelSource.TotalCapacity;
				}
				return num;
			}
		}

		public double TotalFuel
		{
			get
			{
				double num = 0.0;
				foreach (IFuelSource fuelSource in _fuelSources)
				{
					num += fuelSource.TotalFuel;
				}
				return num;
			}
		}

		public FuelSourceGroup(int priority, int subPriority, FuelType fuelType)
		{
			Priority = priority;
			SubPriority = subPriority;
			FuelType = fuelType;
		}

		public double AddFuel(double amount)
		{
			double num = 0.0;
			if (_fuelSources.Count == 1)
			{
				num = _fuelSources[0].AddFuel(amount);
			}
			else
			{
				int num2 = 0;
				foreach (IFuelSource fuelSource in _fuelSources)
				{
					if (fuelSource.TotalFuel < fuelSource.TotalCapacity)
					{
						num2++;
					}
				}
				while (amount > 0.0 && num2 > 0)
				{
					double amount2 = amount / (double)num2;
					num2 = 0;
					for (int i = 0; i < _fuelSources.Count; i++)
					{
						double num3 = _fuelSources[i].AddFuel(amount2);
						if (num3 > 0.0)
						{
							num2++;
							num += num3;
							amount -= num3;
						}
					}
				}
			}
			return num;
		}

		public void AddFuelSource(IFuelSource fuelSource)
		{
			_fuelSources.Add(fuelSource);
		}

		public bool ContainsFuelSource(IFuelSource fuelSource)
		{
			return _fuelSources.Contains(fuelSource);
		}

		public double RemoveFuel(double amount)
		{
			double num = 0.0;
			if (_fuelSources.Count == 1)
			{
				num = _fuelSources[0].RemoveFuel(amount);
			}
			else
			{
				int num2 = 0;
				foreach (IFuelSource fuelSource in _fuelSources)
				{
					if (fuelSource.TotalFuel > 0.0)
					{
						num2++;
					}
				}
				while (amount > 0.0 && num2 > 0)
				{
					double amount2 = amount / (double)num2;
					num2 = 0;
					for (int i = 0; i < _fuelSources.Count; i++)
					{
						double num3 = _fuelSources[i].RemoveFuel(amount2);
						if (num3 > 0.0)
						{
							num2++;
							num += num3;
							amount -= num3;
						}
					}
				}
			}
			return num;
		}

		public void RemoveFuelSource(IFuelSource fuelSource)
		{
			_fuelSources.Remove(fuelSource);
		}
	}
}
