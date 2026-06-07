using System.Linq.Expressions;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class EmptyFuelSource : IFuelSource
	{
		private static EmptyFuelSource _cache;

		public bool IsDestroyed => false;

		public bool IsEmpty => true;

		public Vector3 Position => Vector3.zero;

		public int Priority => 0;

		public int SubPriority => 0;

		public float TotalCapacity
		{
			get
			{
				return 0f;
			}
			set
			{
				Expression.Empty();
			}
		}

		public float TotalFuel
		{
			get
			{
				return 0f;
			}
			set
			{
				Expression.Empty();
			}
		}

		private EmptyFuelSource()
		{
		}

		public static EmptyFuelSource GetOrCreate()
		{
			if (_cache == null)
			{
				_cache = new EmptyFuelSource();
			}
			return _cache;
		}

		public void RemoveFuel(float amount)
		{
		}
	}
}
