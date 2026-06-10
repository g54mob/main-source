using System;
using System.Collections.Generic;

namespace NSMedieval.StatsSystem
{
	public abstract class EffectorBase
	{
		private EffectorType type;

		[NonSerialized]
		private StatEffector parent;

		public EffectorType Type => type;

		public StatEffector Parent => parent;

		public virtual bool DontRestartAfterDeserialization => false;

		public EffectorBase(EffectorType type, StatEffector parent)
		{
			this.type = type;
			this.parent = parent;
		}

		public abstract void InitParameters(Dictionary<string, string> data);

		public abstract void Start(StatsInstance instance);

		public abstract void Stack(StatsInstance instance, float multiplier);

		public abstract void End(StatsInstance instance);
	}
}
