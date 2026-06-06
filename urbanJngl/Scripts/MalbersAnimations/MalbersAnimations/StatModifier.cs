using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	public class StatModifier
	{
		public StatID ID;

		public StatOption modify;

		public FloatReference MinValue = new FloatReference(10f);

		public FloatReference MaxValue = new FloatReference(10f);

		public BoolReference enable = new BoolReference(value: true);

		public float Value
		{
			get
			{
				return UnityEngine.Random.Range(MinValue, MaxValue);
			}
			set
			{
				MinValue = new FloatReference(value);
				MaxValue = new FloatReference(value);
			}
		}

		public bool IsNull => ID == null;

		public StatModifier()
		{
			ID = null;
			modify = StatOption.None;
			MinValue = new FloatReference(10f);
			MinValue = new FloatReference(1f);
			enable = new BoolReference(value: true);
		}

		public StatModifier(StatModifier mod)
		{
			ID = mod.ID;
			modify = mod.modify;
			MinValue = new FloatReference(mod.MinValue.Value);
			MaxValue = new FloatReference(mod.MaxValue.Value);
			enable = new BoolReference(value: true);
		}

		public bool ModifyStat(Stats stats)
		{
			if ((bool)stats && stats.enabled && !IsNull)
			{
				return ModifyStat(stats.Stat_Get(ID));
			}
			return false;
		}

		public bool ModifyStat(Stat s)
		{
			if (s != null)
			{
				if (modify == StatOption.Inmune || modify == StatOption.Enable)
				{
					s.Modify(enable.Value ? 1 : 0, modify);
				}
				else
				{
					s.Modify(UnityEngine.Random.Range(MinValue, MaxValue), modify);
				}
				return true;
			}
			return false;
		}

		public bool ModifyStat(Stat s, float Normalized)
		{
			if (s != null)
			{
				if (modify == StatOption.Inmune || modify == StatOption.Enable)
				{
					s.Modify(enable.Value ? 1 : 0, modify);
					return true;
				}
				s.Modify(Mathf.Lerp(MinValue, MaxValue, Normalized), modify);
				return true;
			}
			return false;
		}

		public float GetValue(float Normalized)
		{
			return Mathf.Lerp(MinValue, MaxValue, Normalized);
		}

		public float GetValue()
		{
			return UnityEngine.Random.Range(MinValue, MaxValue);
		}
	}
}
