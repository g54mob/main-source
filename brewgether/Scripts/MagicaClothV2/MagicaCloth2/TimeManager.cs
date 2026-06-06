using System;
using System.Text;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public class TimeManager : IManager, IDisposable, IValid
	{
		public enum UpdateLocation
		{
			AfterLateUpdate = 0,
			BeforeLateUpdate = 1
		}

		internal int simulationFrequency;

		internal int maxSimulationCountPerFrame;

		internal UpdateLocation updateLocation;

		private bool isValid;

		internal float GlobalTimeScale;

		internal int FixedUpdateCount { get; private set; }

		internal float SimulationDeltaTime { get; private set; }

		internal float MaxDeltaTime { get; private set; }

		internal float4 SimulationPower { get; private set; }

		public void Dispose()
		{
		}

		public void EnterdEditMode()
		{
		}

		public void Initialize()
		{
		}

		public bool IsValid()
		{
			return false;
		}

		private void AfterFixedUpdate()
		{
		}

		private void AfterRenderring()
		{
		}

		internal void FrameUpdate()
		{
		}

		public void InformationLog(StringBuilder allsb)
		{
		}
	}
}
