using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class PriceModifiers
	{
		private readonly Dictionary<IPriceModifier, int> _modifiers;

		public PriceModifiers()
		{
			_modifiers = new Dictionary<IPriceModifier, int>();
		}

		public void SetModifier(IPriceModifier type, int value)
		{
			if (_modifiers.ContainsKey(type))
			{
				_modifiers[type] = value;
			}
			else
			{
				_modifiers.Add(type, value);
			}
		}

		public int GetModifier(IPriceModifier type)
		{
			if (_modifiers == null || !_modifiers.ContainsKey(type))
			{
				return 0;
			}
			return _modifiers[type];
		}

		public int Percent(IPriceModifier item, int price)
		{
			return Mathf.CeilToInt((float)GetModifier(item) * ((float)price / 100f));
		}

		public bool IsCorrupt()
		{
			return _modifiers == null;
		}
	}
}
