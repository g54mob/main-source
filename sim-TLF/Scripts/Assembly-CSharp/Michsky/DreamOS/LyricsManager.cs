using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace Michsky.DreamOS
{
	public class LyricsManager : MonoBehaviour
	{
		[Serializable]
		public class LineItem
		{
			public int lrcMinute;

			public float lrcSeconds;

			public string lrcLine;
		}

		[Header("Resources")]
		public MusicPlayerManager mpManager;

		public GameObject lyricItem;

		public Transform lyricParent;

		[Header("Settings")]
		public string subPath = "Lyrics";

		public string fileExtension = ".lrc";

		private string fullPath;

		[Header("Events")]
		public UnityEvent onLyricFound;

		public UnityEvent onLyricMissing;

		public bool lyricFound;

		private float secondsToNext;

		private int currentLine;

		private LyricsLine currentLyricItem;

		private LyricsLine upcomingLyricItem;

		public List<LineItem> lines = new List<LineItem>();

		private void CheckForDataFile()
		{
			string dataPath = Application.dataPath;
			dataPath = dataPath.Replace(Application.productName + "_Data", "");
			fullPath = dataPath + subPath + "/";
		}

		public void ReadLyricData(string songName)
		{
			CheckForDataFile();
			if (!File.Exists(fullPath + songName + fileExtension))
			{
				lyricFound = false;
				onLyricMissing.Invoke();
				return;
			}
			currentLine = 0;
			currentLyricItem = null;
			upcomingLyricItem = null;
			lyricFound = true;
			lines.Clear();
			foreach (Transform item in lyricParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			foreach (string item2 in File.ReadLines(fullPath + songName + fileExtension))
			{
				string text = null;
				int lrcMinute;
				float lrcSeconds;
				try
				{
					lrcMinute = int.Parse(item2[2].ToString());
					lrcSeconds = float.Parse(item2[4].ToString() + item2[5] + "." + item2[7] + item2[8]);
				}
				catch
				{
					continue;
				}
				int num = item2.IndexOf("]", 1);
				text = item2.Substring(num + 1);
				LineItem lineItem = new LineItem();
				lineItem.lrcMinute = lrcMinute;
				lineItem.lrcSeconds = lrcSeconds;
				lineItem.lrcLine = text;
				lines.Add(lineItem);
			}
			onLyricFound.Invoke();
			Continue();
			UpdateCurrentLyric();
		}

		public void CheckLyricsState(string lyricsTitle)
		{
			if (lyricFound)
			{
				Continue();
			}
			else
			{
				ReadLyricData(lyricsTitle);
			}
		}

		public void Continue()
		{
			if (lyricFound && currentLine < lines.Count - 1)
			{
				CheckForLyricItems();
				if (lines[currentLine].lrcSeconds < lines[currentLine + 1].lrcSeconds)
				{
					secondsToNext = lines[currentLine + 1].lrcSeconds - lines[currentLine].lrcSeconds;
				}
				else
				{
					secondsToNext = 60f - lines[currentLine].lrcSeconds + lines[currentLine + 1].lrcSeconds;
				}
				StartCoroutine("ShowLyrics", secondsToNext);
			}
		}

		private void CheckForLyricItems()
		{
			if (upcomingLyricItem != null)
			{
				currentLyricItem = upcomingLyricItem;
				currentLyricItem.SetCurrent();
			}
			else if (currentLyricItem == null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(lyricItem, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(lyricParent, worldPositionStays: false);
				currentLyricItem = gameObject.GetComponent<LyricsLine>();
				currentLyricItem.textObject.text = lines[currentLine].lrcLine;
				currentLyricItem.SetCurrent();
			}
			if (currentLine + 1 < lines.Count - 1)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(lyricItem, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject2.transform.SetParent(lyricParent, worldPositionStays: false);
				upcomingLyricItem = gameObject2.GetComponent<LyricsLine>();
				upcomingLyricItem.textObject.text = lines[currentLine + 1].lrcLine;
				upcomingLyricItem.SetIn();
			}
		}

		private void UpdateLyricItems()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(lyricItem, new Vector3(0f, 0f, 0f), Quaternion.identity);
			gameObject.transform.SetParent(lyricParent, worldPositionStays: false);
			currentLyricItem = gameObject.GetComponent<LyricsLine>();
			currentLyricItem.textObject.text = lines[currentLine].lrcLine;
			currentLyricItem.SetCurrent();
			if (currentLine + 1 < lines.Count - 1)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(lyricItem, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject2.transform.SetParent(lyricParent, worldPositionStays: false);
				upcomingLyricItem = gameObject2.GetComponent<LyricsLine>();
				upcomingLyricItem.textObject.text = lines[currentLine + 1].lrcLine;
				upcomingLyricItem.SetIn();
			}
		}

		public void Pause()
		{
			StopCoroutine("ShowLyrics");
		}

		public void UpdateCurrentLyric()
		{
			StopCoroutine("ShowLyrics");
			if (!lyricFound)
			{
				Continue();
			}
			foreach (Transform item in lyricParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < lines.Count; i++)
			{
				if (lines[i].lrcMinute == mpManager.minutes && lines[i].lrcSeconds >= mpManager.secondsRaw && mpManager.secondsRaw >= 0f)
				{
					currentLine = i - 1;
					if (currentLine < 0)
					{
						currentLine = 0;
					}
					UpdateLyricItems();
					secondsToNext = lines[currentLine + 1].lrcSeconds - mpManager.secondsRaw;
					StartCoroutine("ShowLyrics", secondsToNext);
					break;
				}
			}
		}

		private IEnumerator ShowLyrics(float time)
		{
			yield return new WaitForSeconds(time);
			if (currentLyricItem != null)
			{
				currentLyricItem.SetOut();
			}
			currentLine++;
			Continue();
		}
	}
}
