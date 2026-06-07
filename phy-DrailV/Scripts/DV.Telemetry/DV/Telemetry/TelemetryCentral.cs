using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

namespace DV.Telemetry
{
	public class TelemetryCentral : SingletonBehaviour<TelemetryCentral>
	{
		private List<ITelemetryRecorder> everyFrameUpdates = new List<ITelemetryRecorder>();

		private List<ITelemetryRecorder> fixedFrameUpdates = new List<ITelemetryRecorder>();

		public int RecorderCount => everyFrameUpdates.Count + fixedFrameUpdates.Count;

		public new static string AllowAutoCreate()
		{
			return "[TelemetryCentral]";
		}

		protected override void Awake()
		{
			base.Awake();
			base.enabled = false;
		}

		private void Update()
		{
			if (!(Time.timeScale > 0f))
			{
				return;
			}
			for (int num = everyFrameUpdates.Count - 1; num >= 0; num--)
			{
				if (everyFrameUpdates[num] == null)
				{
					everyFrameUpdates.RemoveAt(num);
				}
				else
				{
					everyFrameUpdates[num].RecordTelemetry();
				}
			}
		}

		private void FixedUpdate()
		{
			if (!(Time.timeScale > 0f))
			{
				return;
			}
			for (int num = fixedFrameUpdates.Count - 1; num >= 0; num--)
			{
				if (fixedFrameUpdates[num] == null)
				{
					fixedFrameUpdates.RemoveAt(num);
				}
				else
				{
					fixedFrameUpdates[num].RecordTelemetry();
				}
			}
		}

		public void SaveAll(string prefix = "")
		{
			for (int num = everyFrameUpdates.Count - 1; num >= 0; num--)
			{
				if (everyFrameUpdates[num] == null)
				{
					everyFrameUpdates.RemoveAt(num);
				}
				else
				{
					everyFrameUpdates[num].SaveTelemetry(prefix);
				}
			}
			for (int num2 = fixedFrameUpdates.Count - 1; num2 >= 0; num2--)
			{
				if (fixedFrameUpdates[num2] == null)
				{
					fixedFrameUpdates.RemoveAt(num2);
				}
				else
				{
					fixedFrameUpdates[num2].SaveTelemetry(prefix);
				}
			}
		}

		public void ReleaseBuffers()
		{
			foreach (ITelemetryRecorder everyFrameUpdate in everyFrameUpdates)
			{
				everyFrameUpdate.ReleaseTelemetryBuffers();
			}
			foreach (ITelemetryRecorder fixedFrameUpdate in fixedFrameUpdates)
			{
				fixedFrameUpdate.ReleaseTelemetryBuffers();
			}
		}

		public void RegisterForEveryUpdate(ITelemetryRecorder recorder)
		{
			everyFrameUpdates.Add(recorder);
		}

		public void UnregisterFromEveryUpdate(ITelemetryRecorder recorder)
		{
			everyFrameUpdates.Remove(recorder);
		}

		public void RegisterForFixedUpdates(ITelemetryRecorder recorder)
		{
			fixedFrameUpdates.Add(recorder);
		}

		public void UnregisterFromFixedUpdates(ITelemetryRecorder recorder)
		{
			fixedFrameUpdates.Remove(recorder);
		}
	}
}
