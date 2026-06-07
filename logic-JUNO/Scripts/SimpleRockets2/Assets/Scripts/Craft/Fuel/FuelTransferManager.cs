using System.Collections.Generic;
using ModApi.Craft.Parts;
using ModApi.Craft.Propulsion;
using UnityEngine;

namespace Assets.Scripts.Craft.Fuel
{
	public class FuelTransferManager : IFuelTransferManager
	{
		private CraftScript _craftScript;

		public List<IFuelSource> FuelSources { get; private set; } = new List<IFuelSource>();

		public FuelTransferManager(CraftScript craftScript)
		{
			_craftScript = craftScript;
		}

		public void AddFuelSource(IFuelSource fuelSource)
		{
			if (!FuelSources.Contains(fuelSource))
			{
				FuelSources.Add(fuelSource);
			}
		}

		public void RemoveFuelSource(IFuelSource fuelSource)
		{
			if (FuelSources.Contains(fuelSource))
			{
				FuelSources.Remove(fuelSource);
			}
		}

		public void Update(float deltaTime)
		{
			if (FuelSources.Count <= 0)
			{
				return;
			}
			foreach (FuelType fuel in Game.Instance.PropulsionData.Fuels)
			{
				if (fuel.AllowFuelTransfer)
				{
					UpdateTransfer(fuel, deltaTime);
				}
			}
		}

		private void UpdateTransfer(FuelType fuelType, float deltaTime)
		{
			double num = 0.0;
			double num2 = 0.0;
			int num3 = 0;
			int num4 = 0;
			foreach (IFuelSource fuelSource in FuelSources)
			{
				if (fuelSource.FuelType == fuelType && fuelSource.FuelTransferMode == FuelTransferMode.Drain)
				{
					num += fuelSource.TotalFuel;
					num4++;
				}
				else if (fuelSource.FuelType == fuelType && fuelSource.FuelTransferMode == FuelTransferMode.Fill)
				{
					double num5 = Mathd.Clamp(fuelSource.TotalCapacity - fuelSource.TotalFuel, 0.0, fuelSource.TotalCapacity);
					num2 += num5;
					num3++;
				}
			}
			if (num3 <= 0 || num4 <= 0)
			{
				return;
			}
			double num6 = fuelType.FuelTransferRate * (float)num4 * deltaTime;
			double num7 = Mathd.Min(num2, num, num6);
			if (!(num7 > 0.0))
			{
				return;
			}
			double num8 = num7 / (double)num3;
			double a = num7 / (double)num4;
			double num9 = 0.0;
			foreach (IFuelSource fuelSource2 in FuelSources)
			{
				if (fuelSource2.FuelType == fuelType && fuelSource2.FuelTransferMode == FuelTransferMode.Fill)
				{
					double num10 = fuelSource2.TotalCapacity - fuelSource2.TotalFuel;
					if (num10 > num8)
					{
						num10 = num8;
					}
					num9 += fuelSource2.AddFuel(num10);
					(fuelSource2 as IFuelTransferredHandler)?.OnFuelTransferred();
				}
			}
			for (int i = 0; i < num4; i++)
			{
				foreach (IFuelSource fuelSource3 in FuelSources)
				{
					if (fuelSource3.FuelType == fuelType && fuelSource3.FuelTransferMode == FuelTransferMode.Drain)
					{
						double amount = Mathd.Min(a, num9);
						num9 -= fuelSource3.RemoveFuel(amount);
						(fuelSource3 as IFuelTransferredHandler)?.OnFuelTransferred();
						if (num9 <= 0.0)
						{
							i = num4;
							break;
						}
					}
				}
			}
		}
	}
}
