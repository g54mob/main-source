using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		[CustomClassObfuscation]
		[CustomObfuscation]
		public interface INewEventWrapper : IDisposable
		{
			LowLevelInputEvent Event { get; set; }
		}

		private class qjCeXQTSsQbsvgqjSrpEhvvEouys : LockedObject<LowLevelInputEvent>, IDisposable, INewEventWrapper
		{
			public LowLevelInputEvent Event
			{
				get
				{
					return default(LowLevelInputEvent);
				}
				set
				{
				}
			}

			public qjCeXQTSsQbsvgqjSrpEhvvEouys(object lockObject)
			{
			}
		}

		private readonly LowLevelInputEventQueue gVpKlGqYlXOuSjdFnfYDRWLcsmF;

		private readonly LowLevelInputEventQueue FNmvrUMNSPboUtNzlhZqVTBqPqg;

		private readonly object zAthyNiMwUvoDIWGKbreghicIhd;

		private uint CrheYEzmXDhkmLNCJOuRuulniKN;

		private bool uLpydcuzddHyAJsegHpqjMfuHEy;

		private int GhcJaRldNOHfwityInfdpQZYDeJ;

		private int PtqNMtMGMyTCjFQkwjdPDZGJygD;

		private qjCeXQTSsQbsvgqjSrpEhvvEouys CINDzZhlMtZCJskKHTRUqQBKddlB;

		public LowLevelInputEvent currentEvent;

		private bool CGIHxiLUHgNfmOBOdViTruIZZWF;

		public uint lastProcessedEventId => 0u;

		public int count => 0;

		public DualThreadLowLevelInputEventQueue(int capacity, int buttonCount, int axisCount, int hatCount)
		{
		}

		public INewEventWrapper T_CreateEvent()
		{
			return null;
		}

		public void Update()
		{
		}

		public void Clear()
		{
		}

		public bool ProcessNewEvents()
		{
			return false;
		}

		public void StopProcessingEvents()
		{
		}

		public void ImportAll(DualThreadLowLevelInputEventQueue other)
		{
		}

		public void Dispose()
		{
		}

		~DualThreadLowLevelInputEventQueue()
		{
		}

		protected void Dispose(bool disposing)
		{
		}
	}
}
