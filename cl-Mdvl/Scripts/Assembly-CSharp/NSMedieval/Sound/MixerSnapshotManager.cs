using System;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;

namespace NSMedieval.Sound
{
	public class MixerSnapshotManager : MonoSingleton<MixerSnapshotManager>
	{
		private Dictionary<string, EventInstance> snapshots = new Dictionary<string, EventInstance>();

		private string previousSnapshot;

		private string currentSnapshot;

		public void ActivateSnapshot(Snapshot snapshot)
		{
			ActivateSnapshot(snapshot.ToString());
		}

		public void ActivatePreviousSnapshot()
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\MixerSnapshotManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ActivatePreviousSnapshot ");
				messageBuilder.AppendFormatted(previousSnapshot);
			}
			Log.Trace(messageBuilder);
			ActivateSnapshot(previousSnapshot);
		}

		private void ActivateSnapshot(string snapshot)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(17, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\MixerSnapshotManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ActivateSnapshot ");
				messageBuilder.AppendFormatted(snapshot);
			}
			Log.Debug(messageBuilder);
			string text = currentSnapshot;
			if (text == "None" || text == "BattleSnapshot")
			{
				previousSnapshot = currentSnapshot;
			}
			currentSnapshot = snapshot;
			foreach (KeyValuePair<string, EventInstance> snapshot2 in snapshots)
			{
				if (snapshot2.Key == snapshot)
				{
					snapshot2.Value.start();
				}
				else
				{
					snapshot2.Value.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
				}
			}
		}

		private void Start()
		{
			string[] names = Enum.GetNames(typeof(Snapshot));
			foreach (string text in names)
			{
				if (!(text == "None"))
				{
					EventInstance value = RuntimeManager.CreateInstance("snapshot:/" + text);
					snapshots.Add(text, value);
				}
			}
			currentSnapshot = "None";
			previousSnapshot = "None";
		}
	}
}
