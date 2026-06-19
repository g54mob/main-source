using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TH20
{
	public class OnlineScreenshotData : OnlineManager.IOnlineSerializable
	{
		public class Screenshot
		{
			public readonly byte[] Data;

			public readonly int Width;

			public readonly int Height;

			public readonly string Caption;

			public readonly int Day;

			public readonly OnlinePlayerID playerID;

			public Screenshot(byte[] data, int width, int height, string caption, int day)
			{
				Data = data;
				Width = width;
				Height = height;
				Caption = caption;
				Day = day;
				playerID = (OnlineManager.IsInitializedAndLoggedOn() ? OnlineManager.GetLocalPlayerID() : OnlinePlayerID.Nil);
			}

			public Texture2D GetTexture()
			{
				if (Data == null)
				{
					return null;
				}
				Texture2D texture2D = new Texture2D(Width, Height, TextureFormat.RGB24, mipChain: false);
				texture2D.LoadImage(Data);
				return texture2D;
			}
		}

		[SerializeField]
		private readonly Dictionary<int, Screenshot> _screenshotData = new Dictionary<int, Screenshot>();

		public const int MaxScreenshots = 3;

		public Screenshot AddScreenshotData(RenderToTexture rtt, string caption, int day, int quality = 75)
		{
			if (!CanTakeScreenshotToday(day))
			{
				return null;
			}
			Screenshot screenshot = new Screenshot(rtt.RenderToJpg(quality), rtt.Width, rtt.Height, caption, day);
			_screenshotData[day] = screenshot;
			return screenshot;
		}

		public bool CanTakeScreenshotToday(int day)
		{
			if (_screenshotData.Count >= 3)
			{
				return false;
			}
			if (_screenshotData.ContainsKey(day))
			{
				return false;
			}
			return true;
		}

		public Screenshot GetScreenshot(int day)
		{
			_screenshotData.TryGetValue(day, out var value);
			return value;
		}

		public Screenshot GetMostRecentScreenshot()
		{
			if (_screenshotData.Count <= 0)
			{
				return null;
			}
			List<int> list = _screenshotData.Keys.ToList();
			list.Sort();
			_screenshotData.TryGetValue(list.Last(), out var value);
			return value;
		}

		public int NumScreenshotRemaining()
		{
			return Mathf.Max(3 - _screenshotData.Count, 0);
		}

		public void PrepareForUpload()
		{
		}

		public void RestoreAfterDownload()
		{
		}

		public void OnUploadCompleted(uint uploadTime)
		{
		}
	}
}
