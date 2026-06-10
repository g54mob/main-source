using System;
using NSEipix.Repository;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	[FVSerializableKey("StatThresholdTrigger", "")]
	public class StatThresholdTrigger : IFVSerializable
	{
		[SerializeField]
		private string name;

		[SerializeField]
		private int trigger;

		[SerializeField]
		private string[] effectors;

		[SerializeField]
		private string[] bannedEffectors;

		[SerializeField]
		private string[] allowedEffectors;

		[SerializeField]
		private string[] perks;

		public int Trigger => trigger;

		public string[] Effectors => effectors;

		public string Name => name;

		public string[] BannedEffectors => bannedEffectors ?? Array.Empty<string>();

		public string[] AllowedEffectors => allowedEffectors ?? Array.Empty<string>();

		public string[] Perks => perks;

		public StatThresholdTrigger()
		{
		}

		public void StartEffects(StatsInstance instance)
		{
			if (effectors != null && instance != null)
			{
				string[] array = effectors;
				foreach (string effectorId in array)
				{
					instance?.StartEffector(effectorId);
				}
			}
		}

		public void EndEffects(StatsInstance instance, bool skipDurationEffectors)
		{
			if (effectors == null || instance == null)
			{
				return;
			}
			string[] array = effectors;
			foreach (string text in array)
			{
				if (skipDurationEffectors)
				{
					int firstIndexOfEffector = instance.GetFirstIndexOfEffector(text);
					if (firstIndexOfEffector != -1 && (double?)instance.GetEffectorByIndex(firstIndexOfEffector).Blueprint?.Duration >= 0.01)
					{
						continue;
					}
				}
				instance.EndEffector(text);
			}
		}

		public void RestartEffectors(StatsInstance instance)
		{
			if (effectors == null || instance == null)
			{
				return;
			}
			string[] array = effectors;
			foreach (string text in array)
			{
				if (!instance.IsEffectorActive(text))
				{
					StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(text);
					if ((object)byID != null && !byID.IsInstant)
					{
						instance.StartEffector(text);
					}
				}
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("name", name);
			serializer.Write("trigger", trigger);
			serializer.Write("effectors", effectors);
		}

		public StatThresholdTrigger(FVDeserializer deserializer)
		{
			name = deserializer.ReadString("name");
			trigger = deserializer.ReadInt("trigger");
			effectors = deserializer.ReadStringArray("effectors");
		}
	}
}
