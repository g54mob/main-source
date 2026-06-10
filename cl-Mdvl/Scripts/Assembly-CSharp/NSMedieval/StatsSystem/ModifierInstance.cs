using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;

namespace NSMedieval.StatsSystem
{
	public abstract class ModifierInstance
	{
		public delegate void ModifierEndedDelegate(ModifierInstance instance);

		private readonly StatEffector effector;

		private ModifierType type;

		private float timePassedSinceStart;

		private string tag;

		private List<AttributeInstance> affectedAttributes = new List<AttributeInstance>();

		private bool isInitialized;

		private bool hasEnded;

		private float stackMultiplier = 1f;

		private StatsInstance owner;

		public ModifierType Type => type;

		public float TimePassedSinceStart => timePassedSinceStart;

		public string Tag => tag;

		public List<AttributeInstance> AffectedAttributes => affectedAttributes;

		public bool IsInitialized => isInitialized;

		public float StackMultiplier => stackMultiplier;

		public StatsInstance Owner => owner;

		public StatEffector Effector => effector;

		public event ModifierEndedDelegate OnExpiredCallbackEvent;

		public ModifierInstance(ModifierType type)
		{
			this.type = type;
		}

		public ModifierInstance(ModifierType type, string tag)
		{
			this.type = type;
			this.tag = tag;
			if (!string.IsNullOrEmpty(tag))
			{
				StatEffectorWound model2;
				if (Repository<EffectorRepository, StatEffector>.Instance.TryGetValue(this.tag, out var model))
				{
					effector = model;
				}
				else if (Repository<WoundsRepository, StatEffectorWound>.Instance.TryGetValue(this.tag, out model2))
				{
					effector = model2;
				}
			}
		}

		public virtual bool PreInitChecks(StatsInstance instance, ModifierInstanceStack stack)
		{
			return true;
		}

		public virtual void Init(StatsInstance instance)
		{
			isInitialized = true;
			owner = instance;
		}

		public abstract void Apply();

		public virtual bool HasExpired()
		{
			return hasEnded;
		}

		public virtual void Update(float deltaTime)
		{
			timePassedSinceStart += deltaTime;
			if (HasExpired())
			{
				OnExpired();
			}
		}

		public virtual List<string> GetInfo()
		{
			return new List<string>();
		}

		public virtual bool IsHidden()
		{
			return false;
		}

		internal void SetStackMultiplier(float multiplier)
		{
			bool num = Math.Abs(stackMultiplier - multiplier) > 0.001f;
			stackMultiplier = multiplier;
			if (num)
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
				{
					Owner?.Controller?.FireEvent(StatEventType.AttributeModiferStackChanged, this);
				});
			}
		}

		internal virtual void EndNow(bool hasDisposed = false)
		{
			hasEnded = true;
			if (hasDisposed)
			{
				OnExpired();
			}
		}

		protected virtual void OnExpired()
		{
			this.OnExpiredCallbackEvent?.Invoke(this);
			owner = null;
			foreach (AttributeInstance affectedAttribute in affectedAttributes)
			{
				affectedAttribute?.Dispose();
			}
			affectedAttributes.Clear();
			affectedAttributes = null;
		}

		protected void SetTag(string tag)
		{
			this.tag = tag;
		}
	}
}
