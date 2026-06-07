using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public class Poise
	{
		[field: NonSerialized]
		public float Maximum { get; private set; }

		[field: NonSerialized]
		public float Current { get; private set; }

		public bool IsBroken
		{
			get
			{
				if (Maximum > 0f)
				{
					return Current <= 0f;
				}
				return false;
			}
		}

		public float Ratio
		{
			get
			{
				if (!(Maximum > 0f))
				{
					return 1f;
				}
				return Mathf.Clamp01(Current / Maximum);
			}
		}

		public event Action EventChange;

		public event Action EventPoiseBreak;

		public Poise()
		{
			Maximum = 1f;
			Current = 1f;
		}

		public void Reset(float value)
		{
			Maximum = value;
			Current = value;
			this.EventChange?.Invoke();
		}

		public void Set(float value)
		{
			Current = Math.Clamp(value, 0f, Maximum);
		}

		public bool Damage(float value)
		{
			Current -= Math.Min(Current, value);
			this.EventChange?.Invoke();
			if (Current > 0f)
			{
				return false;
			}
			this.EventPoiseBreak?.Invoke();
			return true;
		}
	}
}
