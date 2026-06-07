using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public abstract class SensorPart : BindableDronePart
	{
		internal List<EventKeyBinding> EventBindings;

		protected override void Awake()
		{
			base.Awake();
			EventBindings = GetEventBindings();
		}

		public abstract List<EventKeyBinding> GetEventBindings();

		public override NimbatusItemData CreateData()
		{
			return new SensorPartData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			SensorPartData sensorPartData = data as SensorPartData;
			if (sensorPartData == null || EventBindings == null)
			{
				return;
			}
			sensorPartData.EventBindings = new List<KeyBindingData>();
			foreach (EventKeyBinding eventBinding in EventBindings)
			{
				sensorPartData.EventBindings.Add(eventBinding.GetSaveData());
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			SensorPartData sensorPartData = data as SensorPartData;
			if (sensorPartData == null)
			{
				return;
			}
			EventBindings = GetEventBindings();
			if (sensorPartData.EventBindings == null)
			{
				return;
			}
			foreach (KeyBindingData kb in sensorPartData.EventBindings)
			{
				EventKeyBinding eventKeyBinding = EventBindings.FirstOrDefault((EventKeyBinding k) => k.Name == kb.Name);
				if (eventKeyBinding != null)
				{
					eventKeyBinding.Load(kb);
				}
			}
		}
	}
}
