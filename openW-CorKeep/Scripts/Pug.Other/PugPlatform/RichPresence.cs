using System.Collections.Generic;
using UnityEngine;

namespace PugPlatform
{
	public static class RichPresence
	{
		private class Forwarder : IRichPresence
		{
			private List<IRichPresence> _backends = new List<IRichPresence>();

			public void AddBackend(IRichPresence instance)
			{
				_backends.Add(instance);
			}

			public void RemoveBackend(IRichPresence instance)
			{
				_backends.Remove(instance);
			}

			public void StartSession(RichPresenceSessionTypes type)
			{
				foreach (IRichPresence backend in _backends)
				{
					backend.StartSession(type);
				}
			}

			public void EndSession()
			{
				foreach (IRichPresence backend in _backends)
				{
					backend.EndSession();
				}
			}

			public void SetPartySize(int size)
			{
				if (CensorActivity())
				{
					Debug.Log(string.Format("{0}: Censored SetPartySize({1})", "RichPresence", size));
					return;
				}
				foreach (IRichPresence backend in _backends)
				{
					backend.SetPartySize(size);
				}
			}

			public void SetCurrentBiome(string biome)
			{
				if (CensorActivity())
				{
					Debug.Log("RichPresence: Censored SetCurrentBiome(" + biome + ")");
					return;
				}
				foreach (IRichPresence backend in _backends)
				{
					backend.SetCurrentBiome(biome);
				}
			}

			public void SetCurrentTask(string task)
			{
				if (CensorActivity())
				{
					Debug.Log("RichPresence: Censored SetCurrentTask(" + task + ")");
					return;
				}
				foreach (IRichPresence backend in _backends)
				{
					backend.SetCurrentTask(task);
				}
			}

			public void SetSessionKey(string sessionKey)
			{
				foreach (IRichPresence backend in _backends)
				{
					backend.SetSessionKey(sessionKey);
				}
			}

			private static bool CensorActivity()
			{
				return false;
			}
		}

		private static Forwarder _forwarder = new Forwarder();

		public static IRichPresence Instance => _forwarder;

		public static void AddBackend(IRichPresence backend)
		{
			_forwarder.AddBackend(backend);
		}

		public static void RemoveBackend(IRichPresence backend)
		{
			_forwarder.RemoveBackend(backend);
		}
	}
}
