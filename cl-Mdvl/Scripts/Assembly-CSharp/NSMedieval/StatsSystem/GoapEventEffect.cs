using System.Collections.Generic;
using System.Linq;

namespace NSMedieval.StatsSystem
{
	public class GoapEventEffect : EffectorBase
	{
		public class GoapStatEventData
		{
			public string Name { get; set; }

			public string Value { get; set; }

			public bool IsStart { get; set; }
		}

		private GoapStatEventData data = new GoapStatEventData();

		public GoapEventEffect(StatEffector parent)
			: base(EffectorType.GoapEvent, parent)
		{
		}

		public override void InitParameters(Dictionary<string, string> data)
		{
			KeyValuePair<string, string> keyValuePair = data.First();
			this.data.Name = keyValuePair.Key;
			this.data.Value = keyValuePair.Value;
		}

		public override void Start(StatsInstance instance)
		{
			data.IsStart = true;
			instance.Controller.FireEvent(StatEventType.GoapEvent, data);
		}

		public override void Stack(StatsInstance instance, float multiplier)
		{
		}

		public override void End(StatsInstance instance)
		{
			data.IsStart = false;
			instance.Controller.FireEvent(StatEventType.GoapEvent, data);
		}
	}
}
