using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace Heathen.SteamworksIntegration.API
{
	public static class Screenshots
	{
		public static class Client
		{
			private static ScreenshotReadyEvent eventScreenshotReady = new ScreenshotReadyEvent();

			private static UnityEvent eventScreenshotRequested = new UnityEvent();

			private static Callback<ScreenshotRequested_t> m_ScreenshotRequested_t;

			private static Callback<ScreenshotReady_t> m_ScreenshotReady_t;

			public static bool IsScreenshotsHooked
			{
				get
				{
					return SteamScreenshots.IsScreenshotsHooked();
				}
				set
				{
					SteamScreenshots.HookScreenshots(value);
				}
			}

			public static ScreenshotReadyEvent EventScreenshotReady
			{
				get
				{
					if (m_ScreenshotReady_t == null)
					{
						m_ScreenshotReady_t = Callback<ScreenshotReady_t>.Create(delegate(ScreenshotReady_t e)
						{
							eventScreenshotReady.Invoke(e);
						});
					}
					return eventScreenshotReady;
				}
			}

			public static UnityEvent EventScreenshotRequested
			{
				get
				{
					if (m_ScreenshotRequested_t == null)
					{
						m_ScreenshotRequested_t = Callback<ScreenshotRequested_t>.Create(delegate
						{
							eventScreenshotRequested.Invoke();
						});
					}
					return eventScreenshotRequested;
				}
			}

			[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
			private static void Init()
			{
				eventScreenshotReady = new ScreenshotReadyEvent();
				eventScreenshotRequested = new UnityEvent();
				m_ScreenshotRequested_t = null;
				m_ScreenshotReady_t = null;
			}

			public static ScreenshotHandle AddScreenshotToLibrary(string imageFilename, string thumbnailFileName, int width, int height)
			{
				return SteamScreenshots.AddScreenshotToLibrary(imageFilename, thumbnailFileName, width, height);
			}

			public static ScreenshotHandle AddVRScreenshotToLibrary(EVRScreenshotType type, string imageFilename, string vrFilename)
			{
				return SteamScreenshots.AddVRScreenshotToLibrary(type, imageFilename, vrFilename);
			}

			public static void HookScreenshots(bool hook)
			{
				SteamScreenshots.HookScreenshots(hook);
			}

			public static bool SetLocation(ScreenshotHandle handle, string location)
			{
				return SteamScreenshots.SetLocation(handle, location);
			}

			public static bool TagPublishedFile(ScreenshotHandle handle, PublishedFileId_t ugcFileId)
			{
				return SteamScreenshots.TagPublishedFile(handle, ugcFileId);
			}

			public static bool TagUser(ScreenshotHandle handle, CSteamID userId)
			{
				return SteamScreenshots.TagUser(handle, userId);
			}

			public static void TriggerScreenshot()
			{
				SteamScreenshots.TriggerScreenshot();
			}

			public static ScreenshotHandle WriteScreenshot(byte[] data, int width, int height)
			{
				return SteamScreenshots.WriteScreenshot(data, (uint)data.Length, width, height);
			}
		}
	}
}
