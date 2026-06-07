using System.Collections.Generic;
using System.Linq.Expressions;
using ModApi.Craft.Parts;
using ModApi.Craft.Propulsion;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class EmptyFuelSource : IFuelSource
	{
		private static Dictionary<FuelType, EmptyFuelSource> _cache = new Dictionary<FuelType, EmptyFuelSource>();

		public FuelTransferMode FuelTransferMode { get; set; }

		public FuelType FuelType { get; }

		public bool IsDestroyed => false;

		public bool IsEmpty => !Game.InfiniteFuelEnabled;

		public Vector3 Position => Vector3.zero;

		public int Priority => 0;

		public int SubPriority => 0;

		public bool SupportsFuelTransfer => false;

		public double TotalCapacity
		{
			get
			{
				return 0.0;
			}
			set
			{
				Expression.Empty();
			}
		}

		public double TotalFuel
		{
			get
			{
				return 0.0;
			}
			set
			{
				Expression.Empty();
			}
		}

		private EmptyFuelSource(FuelType fuelType)
		{
			FuelType = fuelType;
		}

		private EmptyFuelSource()
		{
		}

		public static EmptyFuelSource GetOrCreate(FuelType fuelType)
		{
			if (!_cache.ContainsKey(fuelType))
			{
				_cache[fuelType] = new EmptyFuelSource(fuelType);
			}
			return _cache[fuelType];
		}

		public double AddFuel(double amount)
		{
			return 0.0;
		}

		public double RemoveFuel(double amount)
		{
			return 0.0;
		}
	}
}
