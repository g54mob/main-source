using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class PropertyGetInteger : PropertyGetDecimal
	{
		public PropertyGetInteger()
			: base(new GetDecimalInteger())
		{
		}

		public PropertyGetInteger(PropertyTypeGetDecimal defaultType)
			: base(defaultType)
		{
		}

		public PropertyGetInteger(int value)
			: base(new GetDecimalInteger(value))
		{
		}

		public override double Get(Args args)
		{
			return Math.Floor(base.Get(args));
		}

		public override double Get(GameObject target)
		{
			return Math.Floor(base.Get(target));
		}

		public override double Get(Component component)
		{
			return Math.Floor(base.Get(component));
		}
	}
}
