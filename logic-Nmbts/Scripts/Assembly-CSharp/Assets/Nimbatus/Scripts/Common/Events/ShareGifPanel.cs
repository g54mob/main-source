using System;
using System.IO;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using SFB;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Events
{
	public class ShareGifPanel : MonoBehaviour
	{
		public int FramesPerSecond;

		public UITexture GifTexture;

		public UITexture Background;

		private Texture[] _frames;

		private string _originalPath;

		public void Init(string gifPath, Texture[] frames)
		{
			_frames = frames;
			_originalPath = gifPath;
			RuntimeGlobals.FreezeGame = true;
		}

		public void Update()
		{
			if (_frames != null)
			{
				int num = (int)(Time.realtimeSinceStartup * (float)FramesPerSecond % (float)_frames.Length);
				Background.width = Mathf.Max(_frames[num].width + 30, 300);
				GifTexture.mainTexture = _frames[num];
				GifTexture.material.mainTexture = _frames[num];
				GifTexture.width = _frames[num].width;
				GifTexture.height = _frames[num].height;
				GifTexture.SetDirty();
			}
		}

		public void Close()
		{
			base.gameObject.SetActive(false);
			RuntimeGlobals.FreezeGame = false;
		}

		public void SaveToFile()
		{
			DateTime dateTime = DateTime.UtcNow;
			try
			{
				dateTime = DateTime.Now;
			}
			catch (TimeZoneNotFoundException)
			{
			}
			StandaloneFileBrowser.SaveFilePanelAsync(LocalizationManager.GetTermTranslation("MainScene/SaveGif"), "", "Drone_" + dateTime.ToString("yyyyMMddHHmmss"), "gif", SaveGif);
		}

		private void SaveGif(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return;
			}
			try
			{
				File.Copy(_originalPath, path, true);
				Close();
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
		}
	}
}
