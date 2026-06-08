using System;
using System.Collections.Generic;
using System.ComponentModel;
using MLAPI.Exceptions;

namespace MLAPI.LagCompensation
{
	public static class LagCompensationManager
	{
		public static readonly List<TrackedObject> SimulationObjects = new List<TrackedObject>();

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use SimulationObjects instead", false)]
		public static List<TrackedObject> simulationObjects => SimulationObjects;

		public static void Simulate(float secondsAgo, Action action)
		{
			Simulate(secondsAgo, SimulationObjects, action);
		}

		public static void Simulate(float secondsAgo, IList<TrackedObject> simulatedObjects, Action action)
		{
			if (!NetworkingManager.Singleton.IsServer)
			{
				throw new NotServerException("Only the server can perform lag compensation");
			}
			for (int i = 0; i < simulatedObjects.Count; i++)
			{
				simulatedObjects[i].ReverseTransform(secondsAgo);
			}
			action();
			for (int j = 0; j < simulatedObjects.Count; j++)
			{
				simulatedObjects[j].ResetStateTransform();
			}
		}

		public static void Simulate(ulong clientId, Action action)
		{
			if (!NetworkingManager.Singleton.IsServer)
			{
				throw new NotServerException("Only the server can perform lag compensation");
			}
			float num = (float)NetworkingManager.Singleton.NetworkConfig.NetworkTransport.GetCurrentRtt(clientId) / 2f;
			Simulate(num * 1000f, action);
		}

		internal static void AddFrames()
		{
			for (int i = 0; i < SimulationObjects.Count; i++)
			{
				SimulationObjects[i].AddFrame();
			}
		}
	}
}
