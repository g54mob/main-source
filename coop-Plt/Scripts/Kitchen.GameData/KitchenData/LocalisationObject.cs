using System.Collections.Generic;
using System.Linq;
using Sirenix.Serialization;
using UnityEngine;

namespace KitchenData
{
	public class LocalisationObject<T> where T : Localisation
	{
		[OdinSerialize]
		private Dictionary<Locale, T> Dictionary;

		public LocalisationObject()
		{
			Dictionary = new Dictionary<Locale, T>();
		}

		public void Add(Locale l, T v)
		{
			if (Dictionary == null)
			{
				Dictionary = new Dictionary<Locale, T>();
			}
			if (Has(l))
			{
				Debug.LogError($"Overwriting {v.Parent.name} {l}");
			}
			Dictionary[l] = v;
		}

		public List<Locale> GetLocales()
		{
			return Dictionary.Keys.ToList();
		}

		public bool Has(Locale l)
		{
			if (Dictionary.TryGetValue(l, out var value))
			{
				return value != null;
			}
			return false;
		}

		public T Get(Locale l = Locale.Default)
		{
			if (l == Locale.Default)
			{
				l = Localisation.CurrentLocale;
			}
			if (Dictionary.TryGetValue(l, out var value) && value != null)
			{
				if (value.Locale != l)
				{
					Debug.LogWarning("Had to fix locale");
					value.Locale = l;
				}
				return value;
			}
			if (Dictionary.TryGetValue(Localisation.FallbackLocale, out var value2))
			{
				return value2;
			}
			return null;
		}

		public bool ContainsNulls()
		{
			foreach (T value in Dictionary.Values)
			{
				if (value == null)
				{
					return true;
				}
			}
			return false;
		}
	}
}
