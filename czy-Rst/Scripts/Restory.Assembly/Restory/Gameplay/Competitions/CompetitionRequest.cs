using System;
using Restory.Data.Devices;

namespace Restory.Gameplay.Competitions
{
	[Serializable]
	public struct CompetitionRequest
	{
		public DeviceInfo DeviceInfo;

		public float Progress;
	}
}
