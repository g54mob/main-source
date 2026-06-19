using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Michsky.DreamOS
{
	[CreateAssetMenu(fileName = "New Web Library", menuName = "DreamOS/New Web Library")]
	public class WebBrowserLibrary : ScriptableObject
	{
		[Serializable]
		public class WebPage
		{
			public string pageTitle = "Web Page Title";

			public string pageURL = "www.example.com";

			public Sprite pageIcon;

			public GameObject pageContent;

			public bool IsUp = true;

			[Range(0.1f, 100f)]
			public float pageSize = 10f;

			[Header("Localization")]
			public string titleKey;
		}

		[Serializable]
		public class DownloadableFiles
		{
			public string fileName = "Title";

			public Sprite fileIcon;

			public float fileSize = 5f;

			[Space(20f)]
			public FileType fileType;

			public AudioClip musicReference;

			public Sprite photoReference;

			public VideoClip videoReference;

			[TextArea(1, 8)]
			public string noteReference;
		}

		public enum FileType
		{
			Other = 0,
			Music = 1,
			Note = 2,
			Photo = 3,
			Video = 4
		}

		public WebPage homePage;

		public WebPage notFoundPage;

		public WebPage noConnectionPage;

		public List<WebPage> webPages = new List<WebPage>();

		public List<DownloadableFiles> dlFiles = new List<DownloadableFiles>();
	}
}
