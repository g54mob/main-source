using System;
using System.Collections;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MalbersAnimations
{
	[Serializable]
	public class Stat
	{
		public enum ResetTo
		{
			MinValue = 0,
			MaxValue = 1
		}

		[Tooltip("Enable/Disable the Stat. Disable Stats cannot be modified")]
		public bool active = true;

		[Tooltip("Key Idendifier for the Stat")]
		public StatID ID;

		[Tooltip("Current Value of the Stat")]
		public FloatReference value = new FloatReference(0f);

		[Tooltip("Maximun Value of the Stat")]
		public FloatReference maxValue = new FloatReference(100f);

		[Tooltip("Minimum Value of the Stat")]
		public FloatReference minValue = new FloatReference();

		[Tooltip("If the Stat is Empty it will be disabled to avoid future changes")]
		public BoolReference DisableOnEmpty = new BoolReference();

		[Tooltip("Round the Stat value to decimal values.\n0 will be set to integer\n-1 will ingore the round Logic")]
		public IntReference Round = new IntReference(-1);

		[SerializeField]
		internal FloatReference multiplier = new FloatReference(1f);

		[SerializeField]
		internal BoolReference regenerate = new BoolReference(value: false);

		public FloatReference RegenRate;

		public FloatReference RegenWaitTime = new FloatReference(0f);

		public FloatReference DegenWaitTime = new FloatReference(0f);

		[SerializeField]
		internal BoolReference degenerate = new BoolReference(value: false);

		public FloatReference DegenRate = new FloatReference();

		[FormerlySerializedAs("InmuneTime")]
		public FloatReference ImmuneTime = new FloatReference();

		[Tooltip("Set the Stat to be immune. The stat values cannot be changed when this value is true")]
		public BoolReference immune = new BoolReference();

		public ResetTo resetTo = ResetTo.MaxValue;

		[Tooltip("Reset the Stat when the Stat is Enabled")]
		public bool ResetOnEnable = true;

		private bool regenerate_LastValue;

		private bool degenerate_LastValue;

		private bool isBelow;

		private bool isAbove;

		public bool isPercent = true;

		public bool debug;

		public UnityEvent OnStatFull = new UnityEvent();

		public UnityEvent OnStatEmpty = new UnityEvent();

		public UnityEvent OnStat = new UnityEvent();

		public float Below;

		public float Above;

		public UnityEvent OnStatBelow = new UnityEvent();

		public UnityEvent OnStatAbove = new UnityEvent();

		public FloatEvent OnValueChangeNormalized = new FloatEvent();

		public FloatEvent OnValueChange = new FloatEvent();

		public FloatEvent OnMaxValueChange = new FloatEvent();

		public BoolEvent OnDegenerate = new BoolEvent();

		public BoolEvent OnRegenerate = new BoolEvent();

		public BoolEvent OnActive = new BoolEvent();

		[SerializeField]
		internal int EditorTabs;

		[NonSerialized]
		private WaitForSeconds InmuneWait;

		private IEnumerator I_Regeneration;

		private IEnumerator I_Degeneration;

		private IEnumerator I_ModifyPerTicks;

		private IEnumerator I_ModifySlow;

		private IEnumerator I_IsInmune;

		public float DefaultMaxValue { get; private set; }

		public float DefaultValue { get; private set; }

		public float DefaultMinValue { get; private set; }

		public float DefaultMultiplier { get; private set; }

		public float DefaultRegenRate { get; private set; }

		public float DefaultDegenRate { get; private set; }

		public bool Active
		{
			get
			{
				return active;
			}
			set
			{
				active = value;
				OnActive.Invoke(value);
				if (active && ResetOnEnable)
				{
					ResetValue();
				}
				Debbuging($"Active: {value}");
				if (value)
				{
					StartRegeneration();
				}
				else
				{
					StopRegeneration();
				}
			}
		}

		public string Name
		{
			get
			{
				if (ID != null)
				{
					return ID.name;
				}
				return string.Empty;
			}
		}

		public float Value
		{
			get
			{
				return value.Value;
			}
			set
			{
				SetValue(value);
			}
		}

		public bool IsFull => Value == MaxValue;

		public bool IsEmpty => Value == MinValue;

		public float Multiplier
		{
			get
			{
				return multiplier.Value;
			}
			set
			{
				multiplier.Value = value;
			}
		}

		public float NormalizedValue => Value / MaxValue;

		public bool IsImmune
		{
			get
			{
				return immune.Value;
			}
			set
			{
				immune.Value = value;
			}
		}

		public float MaxValue
		{
			get
			{
				return maxValue.Value;
			}
			set
			{
				maxValue.Value = value;
				OnMaxValueChange.Invoke(value);
				OnValueChangeNormalized.Invoke(NormalizedValue);
			}
		}

		public float MinValue
		{
			get
			{
				return minValue.Value;
			}
			set
			{
				minValue.Value = value;
			}
		}

		public bool IsRegenerating { get; private set; }

		public bool IsDegenerating { get; private set; }

		public bool Regenerate
		{
			get
			{
				return regenerate.Value;
			}
			set
			{
				regenerate.Value = value;
				regenerate_LastValue = regenerate;
				Debbuging($"Regenerating: {value}");
				if ((bool)regenerate)
				{
					degenerate.Value = false;
					StopDegeneration();
					StartRegeneration();
				}
				else
				{
					degenerate.Value = degenerate_LastValue;
					StopRegeneration();
					StartDegeneration();
				}
			}
		}

		public bool Degenerate
		{
			get
			{
				return degenerate.Value;
			}
			set
			{
				degenerate.Value = value;
				degenerate_LastValue = degenerate;
				Debbuging($"Degenerating: {value}");
				if ((bool)degenerate)
				{
					regenerate.Value = false;
					StartDegeneration();
					StopRegeneration();
				}
				else
				{
					regenerate.Value = regenerate_LastValue;
					StopDegeneration();
					StartRegeneration();
				}
			}
		}

		public Stats Owner { get; private set; }

		internal void InitializeStat(Stats holder)
		{
			isAbove = (isBelow = false);
			Owner = holder;
			if (value.Value >= Above)
			{
				isAbove = true;
			}
			else if (value.Value <= Below)
			{
				isBelow = true;
			}
			regenerate_LastValue = Regenerate;
			degenerate_LastValue = Degenerate;
			if (MaxValue < Value)
			{
				MaxValue = Value;
			}
			DefaultMaxValue = MaxValue;
			DefaultMinValue = MinValue;
			DefaultValue = Value;
			DefaultMultiplier = Multiplier;
			DefaultDegenRate = RegenRate.Value;
			DefaultRegenRate = DegenRate.Value;
			I_Regeneration = null;
			I_Degeneration = null;
			I_ModifyPerTicks = null;
			InmuneWait = new WaitForSeconds(ImmuneTime);
			if (Active)
			{
				Regenerate = regenerate.Value;
				Degenerate = degenerate.Value;
				holder.Delay_Action(2, delegate
				{
					ValueEvents();
				});
				OnMaxValueChange.Invoke(maxValue);
			}
			Debbuging("Initialized");
		}

		public void RestoreMultiplier()
		{
			Multiplier = DefaultMultiplier;
		}

		public void RestoreMax()
		{
			MaxValue = DefaultMaxValue;
		}

		public void RestoreMin()
		{
			MinValue = DefaultMinValue;
		}

		public void RestoreRegenRate()
		{
			RegenRate.Value = DefaultRegenRate;
		}

		public void RestoreDegenRate()
		{
			DegenRate.Value = DefaultDegenRate;
		}

		public void RestoreAll()
		{
			RestoreMax();
			RestoreMin();
			RestoreMultiplier();
			ResetValue();
			RestoreDegenRate();
			RestoreRegenRate();
			Debbuging("Restore Stat");
		}

		public void SetMultiplier(float value)
		{
			multiplier.Value = value;
		}

		public virtual void ValueEvents()
		{
			if (!Active)
			{
				return;
			}
			OnValueChangeNormalized.Invoke(NormalizedValue);
			OnValueChange.Invoke(value);
			if ((float)value <= minValue.Value)
			{
				value.Value = minValue.Value;
				OnStatEmpty.Invoke();
				if (DisableOnEmpty.Value)
				{
					SetActive(value: false);
					return;
				}
			}
			else if ((float)value >= maxValue.Value)
			{
				value.Value = maxValue.Value;
				OnStatFull.Invoke();
			}
			if (Is_Above(value) && !isAbove)
			{
				OnStatAbove.Invoke();
				isAbove = true;
				isBelow = false;
			}
			else if (Is_Below(value) && !isBelow)
			{
				OnStatBelow.Invoke();
				isBelow = true;
				isAbove = false;
			}
		}

		public bool Is_Below(float value)
		{
			if (isPercent)
			{
				return value / MaxValue * 100f <= Below;
			}
			return value <= Below;
		}

		public bool Is_Above(float value)
		{
			if (isPercent)
			{
				return value / MaxValue * 100f >= Above;
			}
			return value >= Above;
		}

		public virtual void SetValue(float value)
		{
			float num = Mathf.Clamp(value, MinValue, MaxValue);
			if (Active && this.value.Value != num)
			{
				if ((int)Round >= 0)
				{
					num = (float)Math.Round(num, Round.Value);
				}
				this.value.Value = num;
				Debbuging($"Value: {num}");
				ValueEvents();
			}
		}

		public void SetActive(bool value)
		{
			Active = value;
		}

		public void SetRegeneration(bool value)
		{
			if (Active)
			{
				Regenerate = value;
			}
		}

		public void SetDegeneration(bool value)
		{
			if (Active)
			{
				Degenerate = value;
			}
		}

		public void SetImmune(bool value)
		{
			if (Active)
			{
				IsImmune = value;
				Debbuging($"Is Inmune: {value}");
			}
		}

		public virtual void Modify(float newValue)
		{
			if (!IsImmune && Active)
			{
				Value += newValue * Multiplier;
				StartRegeneration();
				if (!Regenerate)
				{
					StartDegeneration();
				}
				SetInmune();
			}
		}

		public virtual void UpdateStat()
		{
			SetValue(value);
			StartRegeneration();
			if (!Regenerate)
			{
				StartDegeneration();
			}
		}

		public virtual void Modify(float newValue, float time)
		{
			if (!IsImmune && Active)
			{
				StopSlowModification();
				Owner.StartCoroutine(out I_ModifySlow, C_SmoothChangeValue(newValue, time));
				SetInmune();
			}
		}

		public virtual void Modify(float newValue, int ticks, float timeBetweenTicks)
		{
			if (Active)
			{
				StopCoroutine(I_ModifyPerTicks);
				Owner.StartCoroutine(out I_ModifyPerTicks, C_ModifyTicksValue(newValue, ticks, timeBetweenTicks));
			}
		}

		public virtual void ModifyMAX(float newValue)
		{
			if (Active)
			{
				MaxValue += newValue;
				StartRegeneration();
			}
		}

		public virtual void SetMAX(float newValue)
		{
			if (Active)
			{
				MaxValue = newValue;
				StartRegeneration();
			}
		}

		public virtual void ModifyRegenRate(float newValue)
		{
			if (Active)
			{
				RegenRate.Value += newValue;
				StartRegeneration();
			}
		}

		public virtual void SetRegenerationWait(float newValue)
		{
			if (Active)
			{
				RegenWaitTime.Value = newValue;
				if ((float)RegenWaitTime < 0f)
				{
					RegenWaitTime.Value = 0f;
				}
			}
		}

		public virtual void SetRegenerationRate(float newValue)
		{
			if (Active)
			{
				RegenRate.Value = newValue;
			}
		}

		public virtual void ResetValue()
		{
			Value = ((resetTo == ResetTo.MaxValue) ? MaxValue : MinValue);
		}

		public virtual void Reset_to_Max()
		{
			Value = MaxValue;
		}

		public virtual void Reset_to_Min()
		{
			Value = MinValue;
		}

		internal void CleanRoutines()
		{
			StopDegeneration();
			StopRegeneration();
			StopTickDamage();
			StopSlowModification();
		}

		public virtual void RegenerateOverTime(float time)
		{
			if (time <= 0f)
			{
				StartRegeneration();
			}
			else
			{
				Owner.StartCoroutine(C_RegenerateOverTime(time));
			}
		}

		protected virtual void SetInmune()
		{
			if ((float)ImmuneTime > 0f)
			{
				StopCoroutine(I_IsInmune);
				if (Owner != null && Owner.enabled && Owner.gameObject.activeInHierarchy)
				{
					Owner.StartCoroutine(out I_IsInmune, C_InmuneTime());
				}
			}
		}

		private void StopCoroutine(IEnumerator Cor)
		{
			if (Cor != null)
			{
				Owner.StopCoroutine(Cor);
			}
		}

		protected virtual void StartRegeneration()
		{
			StopRegeneration();
			if ((float)RegenRate != 0f && Regenerate)
			{
				Owner.StartCoroutine(out I_Regeneration, C_Regenerate());
			}
		}

		protected virtual void StartDegeneration()
		{
			StopDegeneration();
			if ((float)DegenRate != 0f && Degenerate)
			{
				Owner.StartCoroutine(out I_Degeneration, C_Degenerate());
			}
		}

		protected virtual void StopRegeneration()
		{
			if (I_Regeneration != null)
			{
				StopCoroutine(I_Regeneration);
				OnRegenerate.Invoke(arg0: false);
			}
			I_Regeneration = null;
			IsRegenerating = false;
		}

		protected virtual void StopDegeneration()
		{
			if (I_Degeneration != null)
			{
				StopCoroutine(I_Degeneration);
				OnDegenerate.Invoke(arg0: false);
			}
			I_Degeneration = null;
			IsDegenerating = false;
		}

		protected virtual void StopTickDamage()
		{
			StopCoroutine(I_ModifyPerTicks);
			I_ModifyPerTicks = null;
		}

		protected virtual void StopSlowModification()
		{
			StopCoroutine(I_ModifySlow);
			I_ModifySlow = null;
		}

		public void Modify(float Value, StatOption modify)
		{
			switch (modify)
			{
			case StatOption.AddValue:
				Modify(Value);
				break;
			case StatOption.SetValue:
				this.Value = Value;
				break;
			case StatOption.SubstractValue:
				Modify(0f - Value);
				break;
			case StatOption.ModifyMaxValue:
				ModifyMAX(Value);
				break;
			case StatOption.SetMaxValue:
				MaxValue = Value;
				break;
			case StatOption.Degenerate:
				if (Value > 0f)
				{
					DegenRate = Value;
				}
				Degenerate = true;
				break;
			case StatOption.DegenerateOff:
				Degenerate = false;
				break;
			case StatOption.Regenerate:
				if (Value > 0f)
				{
					Regenerate = true;
				}
				RegenRate = Value;
				break;
			case StatOption.RegenerateOff:
				Regenerate = false;
				break;
			case StatOption.Reset:
				ResetValue();
				break;
			case StatOption.ReduceByPercent:
				Modify(0f - MaxValue * Value / 100f);
				break;
			case StatOption.IncreaseByPercent:
				Modify(MaxValue * Value / 100f);
				break;
			case StatOption.Multiplier:
				Multiplier = Value;
				break;
			case StatOption.ResetToMax:
				Reset_to_Max();
				break;
			case StatOption.ResetToMin:
				Reset_to_Min();
				break;
			case StatOption.Enable:
				SetActive(Value != 0f);
				break;
			case StatOption.Inmune:
				SetImmune(Value != 0f);
				break;
			case StatOption.RegenerateOn:
				Regenerate = true;
				break;
			case StatOption.DegenerateOn:
				Degenerate = true;
				break;
			case StatOption.RestoreRegeneration:
				RestoreRegenRate();
				break;
			case StatOption.RestoreDegeneration:
				RestoreDegenRate();
				break;
			case StatOption.RestoreValue:
				Value = DefaultValue;
				break;
			case StatOption.RestoreMax:
				RestoreMax();
				break;
			case StatOption.RestoreMin:
				RestoreMin();
				break;
			case StatOption.RestoreMultiplier:
				RestoreMultiplier();
				break;
			case StatOption.MultiplierModify:
				SetMultiplier(Multiplier + Value);
				break;
			case StatOption.None:
				break;
			}
		}

		protected IEnumerator C_RegenerateOverTime(float time)
		{
			float ReachValue = (((float)RegenRate > 0f) ? MaxValue : MinValue);
			bool Positive = (float)RegenRate > 0f;
			float currentTime = Time.time;
			while (Value != ReachValue || currentTime > time)
			{
				Value += (float)RegenRate * Time.deltaTime;
				if (Positive && Value > MaxValue)
				{
					Value = MaxValue;
				}
				else if (!Positive && Value < 0f)
				{
					Value = MinValue;
				}
				currentTime += Time.deltaTime;
				yield return null;
			}
			yield return null;
		}

		protected IEnumerator C_InmuneTime()
		{
			IsImmune = true;
			yield return InmuneWait;
			IsImmune = false;
		}

		protected IEnumerator C_Regenerate()
		{
			yield return null;
			if ((float)RegenWaitTime > 0f)
			{
				yield return new WaitForSeconds(RegenWaitTime);
			}
			IsRegenerating = true;
			OnRegenerate.Invoke(arg0: true);
			while (Regenerate && Value < MaxValue)
			{
				Value += (float)RegenRate * Time.deltaTime;
				yield return null;
			}
			IsRegenerating = false;
			OnRegenerate.Invoke(arg0: false);
			yield return null;
		}

		protected IEnumerator C_Degenerate()
		{
			yield return null;
			if ((float)DegenWaitTime > 0f)
			{
				yield return new WaitForSeconds(DegenWaitTime);
			}
			IsDegenerating = true;
			OnDegenerate.Invoke(arg0: true);
			while (Degenerate && Value > MinValue)
			{
				Value -= (float)DegenRate * Time.deltaTime;
				yield return null;
			}
			IsDegenerating = false;
			OnDegenerate.Invoke(arg0: false);
			yield return null;
		}

		protected IEnumerator C_ModifyTicksValue(float value, int Ticks, float time)
		{
			WaitForSeconds WaitForTicks = new WaitForSeconds(time);
			for (int i = 0; i < Ticks; i++)
			{
				Value += value;
				if (Value <= MinValue)
				{
					Value = MinValue;
					break;
				}
				yield return WaitForTicks;
			}
			yield return null;
			StartRegeneration();
		}

		protected IEnumerator C_SmoothChangeValue(float newvalue, float time)
		{
			StopRegeneration();
			float currentTime = 0f;
			float currentValue = Value;
			newvalue = Value + newvalue;
			yield return null;
			while (currentTime <= time)
			{
				Value = Mathf.Lerp(currentValue, newvalue, currentTime / time);
				currentTime += Time.deltaTime;
				yield return null;
			}
			Value = newvalue;
			yield return null;
			StartRegeneration();
		}

		internal void Debbuging(string value)
		{
		}
	}
}
