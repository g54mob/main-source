using System;
using System.Collections.Generic;
using Restory.Data.Locations;

namespace Restory.Infrastructure.ProjectServices
{
	public class LoadPresetListHistory
	{
		private const int STORY_SIZE = 10;

		private readonly Queue<PresetHistoryRecord> records = new Queue<PresetHistoryRecord>();

		public IReadOnlyCollection<PresetHistoryRecord> Records => records;

		public event Action OnEnqueued;

		public void Enqueue(GameScenesPreset preset)
		{
			if (!(preset == null))
			{
				records.Enqueue(new PresetHistoryRecord
				{
					PresetType = preset.PresetType,
					GameplayMode = preset.GameplayMode,
					GameplaySubtype = preset.GameplaySubtype,
					PresetName = preset.name,
					Preset = preset
				});
				if (records.Count >= 10)
				{
					records.Dequeue();
				}
				this.OnEnqueued?.Invoke();
			}
		}
	}
}
