using DV.Utils;
using UnityEngine;

namespace DV.DopplerEffects
{
	public class DopplerStopRequests : SingletonBehaviour<DopplerStopRequests>
	{
		public int SkipFramesLate;

		public int SkipFramesFixed;

		private RequestSystem blockSkipRequests = new RequestSystem(0f);

		public int SkipFrames
		{
			set
			{
				SkipFramesLate = Mathf.Max(SkipFramesLate, value);
				SkipFramesFixed = Mathf.Max(SkipFramesFixed, value);
			}
		}

		public bool SkipBlocked => blockSkipRequests.Value > 0.5f;

		public new static string AllowAutoCreate()
		{
			return "[DopplerStopRequests]";
		}

		public void AddBlockRequest(object caller)
		{
			blockSkipRequests.RequestValue(caller, 1f);
		}

		public void RemoveBlockRequest(object caller)
		{
			blockSkipRequests.RemoveValue(caller);
		}
	}
}
