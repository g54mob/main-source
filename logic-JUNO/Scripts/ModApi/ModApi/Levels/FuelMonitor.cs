using System;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Propulsion;

namespace ModApi.Levels
{
	public class FuelMonitor : IDisposable
	{
		private ICraftScript _craftScript;

		private double _fuelUsed;

		private double _fuelUsedKG;

		public double FrameFuelUsedKG { get; private set; }

		public float FuelUsed => (float)_fuelUsed;

		public float FuelUsedInKG => (float)_fuelUsedKG;

		public bool OutOfFuel { get; private set; }

		public FuelMonitor(ICraftScript craftScript)
		{
			_craftScript = craftScript;
			_craftScript.FuelSources.FuelUsed += OnFuelUsed;
		}

		public void Dispose()
		{
			if (_craftScript != null)
			{
				_craftScript.FuelSources.FuelUsed -= OnFuelUsed;
				_craftScript = null;
			}
		}

		public void LateUpdate()
		{
			FrameFuelUsedKG = 0.0;
		}

		public void Update()
		{
			OutOfFuel = true;
			foreach (IFuelSource fuelSource in _craftScript.FuelSources.FuelSources)
			{
				if (!fuelSource.IsEmpty)
				{
					OutOfFuel = false;
					break;
				}
			}
		}

		private void OnFuelUsed(double fuel, FuelType fuelType)
		{
			if (fuelType.Density > 0f)
			{
				FrameFuelUsedKG = fuel / (double)fuelType.Density;
				_fuelUsedKG += FrameFuelUsedKG;
				_fuelUsed += fuel;
			}
		}
	}
}
