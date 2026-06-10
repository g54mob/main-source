using System.Collections.Generic;
using NSEipix;

namespace NSMedieval.StatsSystem
{
	public class ModifierInstanceStack
	{
		private readonly ModifierType type;

		private readonly List<ModifierInstance> instances = new List<ModifierInstance>();

		public ModifierType Type => type;

		public List<ModifierInstance> Instances => instances;

		public ModifierInstanceStack(ModifierType type)
		{
			this.type = type;
		}

		public void Add(ModifierInstance instance)
		{
			instances.Add(instance);
		}

		public ModifierInstance GetByTag(string tag)
		{
			return instances.Find((ModifierInstance item) => item.Tag.Equals(tag));
		}

		public void Init(StatsInstance instance)
		{
			foreach (var (modifierInstance, index) in instances.IterateInReverseDynamicWithIndex())
			{
				if (!modifierInstance.IsInitialized)
				{
					if (!modifierInstance.PreInitChecks(instance, this))
					{
						instances.RemoveAt(index);
					}
					else
					{
						modifierInstance.Init(instance);
					}
				}
			}
		}

		public void Update(float stepTime, StatsInstance instance)
		{
			foreach (var (modifierInstance, index) in instances.IterateInReverseDynamicWithIndex())
			{
				modifierInstance.Update(stepTime);
				if (modifierInstance.HasExpired())
				{
					instances.RemoveAt(index);
				}
				else
				{
					modifierInstance.Apply();
				}
			}
		}

		public void EndNow(bool hasDisposed = false)
		{
			foreach (ModifierInstance instance in instances)
			{
				instance.EndNow(hasDisposed);
			}
			if (hasDisposed)
			{
				instances.Clear();
			}
		}

		public ModifierInstance Remove(string tag)
		{
			ModifierInstance result = null;
			foreach (var (modifierInstance, index) in instances.IterateInReverseDynamicWithIndex())
			{
				if (string.IsNullOrEmpty(tag) || !((!(modifierInstance?.Tag?.Equals(tag))) ?? false))
				{
					modifierInstance?.EndNow();
					result = modifierInstance;
					instances.RemoveAt(index);
				}
			}
			return result;
		}
	}
}
