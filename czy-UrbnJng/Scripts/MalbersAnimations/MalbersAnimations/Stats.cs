using System;
using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Stats/Stats")]
	public class Stats : MonoBehaviour, IAnimatorListener, IRestart
	{
		[SerializeField]
		private int Selected_StatIndex;

		public List<Stat> stats = new List<Stat>();

		private Dictionary<int, Stat> stats_D;

		public Stat PinnedStat;

		Transform IAnimatorListener.transform => base.transform;

		public Dictionary<int, Stat> Stats_Dictionary()
		{
			return stats_D;
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}

		public void Initialize()
		{
			StopAllCoroutines();
			stats_D = new Dictionary<int, Stat>();
			foreach (Stat stat in stats)
			{
				if (stat.ID == null)
				{
					Debug.LogError("One of the Stats has an Empty ID", base.gameObject);
					break;
				}
				stats_D[stat.ID] = stat;
			}
		}

		private void Awake()
		{
			Initialize();
		}

		private void OnEnable()
		{
			foreach (KeyValuePair<int, Stat> item in stats_D)
			{
				if (item.Value.ID == null)
				{
					Debug.LogError("One of the Stats has an Empty ID", base.gameObject);
					break;
				}
				item.Value.InitializeStat(this);
			}
		}

		public virtual void Restart()
		{
			StopAllCoroutines();
			foreach (KeyValuePair<int, Stat> item in stats_D)
			{
				item.Value.Active = true;
				item.Value.ResetValue();
			}
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}

		public virtual void Stats_Update()
		{
			foreach (Stat stat in stats)
			{
				stat.UpdateStat();
			}
		}

		public virtual void Stats_Update(StatID ID)
		{
			Stats_Update(ID.ID);
		}

		public virtual void Stats_Update(int ID)
		{
			Stat_Get(ID)?.UpdateStat();
		}

		public virtual void Stat_Reset_to_Max(StatID ID)
		{
			Stat_Get(ID)?.Reset_to_Max();
		}

		public virtual void Stat_Reset_to_Min(StatID ID)
		{
			Stat_Get(ID)?.Reset_to_Min();
		}

		public virtual void Stat_Disable(StatID ID)
		{
			Stat_Get(ID)?.SetActive(value: false);
		}

		public virtual void Stat_Degenerate_Off(StatID ID)
		{
			Stat_Get(ID)?.SetDegeneration(value: false);
		}

		public virtual void Stat_Degenerate_On(StatID ID)
		{
			Stat_Get(ID)?.SetDegeneration(value: true);
		}

		public virtual void Stat_Regenerate_Off(StatID ID)
		{
			Stat_Get(ID)?.SetRegeneration(value: false);
		}

		public virtual void Stat_Regenerate_On(StatID ID)
		{
			Stat_Get(ID)?.SetRegeneration(value: true);
		}

		public virtual void Stat_Enable(StatID iD)
		{
			Stat_Get(iD)?.SetActive(value: true);
		}

		public virtual void Stat_Pin(StatID ID)
		{
			Stat_Get(ID.ID);
		}

		public virtual Stat Stat_Get(StatID ID)
		{
			return Stat_Get(ID.ID);
		}

		public virtual void Stat_Immune_Activate(StatID ID)
		{
			Stat_Get(ID)?.SetImmune(value: true);
		}

		public virtual void Stat_Immune_Deactivate(StatID ID)
		{
			Stat_Get(ID)?.SetImmune(value: false);
		}

		public virtual void Stat_Pin(string name)
		{
			Stat_Get(name);
		}

		public virtual void Stat_Pin(int ID)
		{
			Stat_Get(ID);
		}

		public virtual Stat Stat_Get(string Name)
		{
			return PinnedStat = stats.Find((Stat item) => item.Name == Name);
		}

		public virtual Stat Stat_Get(int ID)
		{
			if (stats_D != null && stats_D.TryGetValue(ID, out PinnedStat))
			{
				return PinnedStat;
			}
			return null;
		}

		public virtual Stat Stat_Get(IntVar ID)
		{
			return Stat_Get(ID.Value);
		}

		public virtual float Stat_GetValue(StatID ID)
		{
			return Stat_Get(ID).Value;
		}

		public virtual float Stat_GetValue(string name)
		{
			return Stat_Get(name).Value;
		}

		public virtual void Stat_SetValue(StatID ID, float Value)
		{
			Stat_Get(ID)?.SetValue(Value);
		}

		public virtual void Stat_SetValue(int ID, float Value)
		{
			Stat_Get(ID)?.SetValue(Value);
		}

		public virtual void Stat_SetValue(string Name, float Value)
		{
			Stat_Get(Name)?.SetValue(Value);
		}

		public virtual void Stat_ModifyValue(StatID ID, float Value)
		{
			Stat_Get(ID)?.Modify(Value);
		}

		public virtual void Stat_ModifyValue(int ID, float Value)
		{
			Stat_Get(ID)?.Modify(Value);
		}

		public virtual void Stat_ModifyValue(string Name, float Value)
		{
			Stat_Get(Name)?.Modify(Value);
		}

		public virtual void Stat_ModifyValue(StatID ID, float Value, StatOption Type)
		{
			Stat_Get(ID)?.Modify(Value, Type);
		}

		public virtual void Stat_ModifyValue(string Name, float Value, StatOption Type)
		{
			Stat_Get(Name)?.Modify(Value, Type);
		}

		public virtual void Stat_Pin_ModifyValue(float Value)
		{
			PinnedStat?.Modify(Value);
		}

		public virtual void Stat_Pin_ModifyValue(FloatVar Value)
		{
			PinnedStat?.Modify(Value.Value);
		}

		public virtual void Stat_Pin_SetMult(float value)
		{
			PinnedStat?.SetMultiplier(value);
		}

		public virtual void Stat_Pin_SetMult(FloatVar value)
		{
			PinnedStat?.SetMultiplier(value.Value);
		}

		public virtual void Stat_Pin_ModifyValue(float value, float time)
		{
			PinnedStat?.Modify(value, time);
		}

		public virtual void Stat_Pin_ModifyValue_1Sec(float value)
		{
			PinnedStat?.Modify(value, 1f);
		}

		public virtual void Stat_Pin_SetValue(float value)
		{
			PinnedStat.SetValue(value);
		}

		public virtual void Stat_Pin_ModifyMaxValue(float value)
		{
			PinnedStat?.ModifyMAX(value);
		}

		public virtual void Stat_Pin_SetMaxValue(float value)
		{
			PinnedStat?.SetMAX(value);
		}

		public virtual void Stat_Pin_Modify_RegenRate(float value)
		{
			PinnedStat?.ModifyRegenRate(value);
		}

		public virtual void Stat_Pin_Degenerate(bool value)
		{
			PinnedStat?.SetDegeneration(value);
		}

		public virtual void Stat_Pin_DegenerateOn(float value)
		{
			if (PinnedStat != null)
			{
				PinnedStat.DegenRate.Value = value;
				PinnedStat.SetDegeneration(value: true);
			}
		}

		public virtual void Stat_Pin_RegenerateOn(float value)
		{
			if (PinnedStat != null)
			{
				PinnedStat.RegenRate.Value = value;
				PinnedStat.SetRegeneration(value: true);
			}
		}

		public virtual void Stat_Pin_SetInmune(bool value)
		{
			PinnedStat?.SetImmune(value);
		}

		public virtual void Stat_Pin_Regenerate(bool value)
		{
			PinnedStat?.SetRegeneration(value);
		}

		public virtual void Stat_Pin_Enable(bool value)
		{
			PinnedStat?.SetActive(value);
		}

		public virtual void Stat_Pin_ModifyValue(float newValue, int ticks, float timeBetweenTicks)
		{
			PinnedStat?.Modify(newValue, ticks, timeBetweenTicks);
		}

		public virtual void Stat_Pin_CleanCoroutines()
		{
			PinnedStat?.CleanRoutines();
		}

		[Obsolete("Use Stat_Degenerate_Off instead")]
		public virtual void DegenerateOff(StatID ID)
		{
			Stat_Degenerate_Off(ID);
		}

		[Obsolete("Use Stat_Degenerate_On instead")]
		public virtual void DegenerateOn(StatID ID)
		{
			Stat_Degenerate_On(ID);
		}
	}
}
