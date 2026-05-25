using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

public class GetWorkshopHighlights : MonoBehaviour
{
	public class LinksJSON
	{
		public string[] Links;
	}

	public class Highlight
	{
		public Sprite sprite;

		public string title;

		public string link;

		public Highlight(Sprite sprite, string title, string link)
		{
			this.sprite = sprite;
			this.title = title;
			this.link = link;
		}
	}

	[SerializeField]
	private Sprite HFFVRPromoSprite;

	[SerializeField]
	private string HFFVRPromoTitle;

	[SerializeField]
	private string HFFVRPromoLink;

	[SerializeField]
	private bool isHFFVROnly;

	private List<Highlight> englishHighlights = new List<Highlight>();

	private List<Highlight> chineseHighlights = new List<Highlight>();

	private LinksJSON jsonLinks;

	private string englishJson = string.Format("{0}UIToast{1}workshopENG.json", Path.DirectorySeparatorChar, Path.DirectorySeparatorChar);

	private string chineseJson = string.Format("{0}UIToast{1}workshopSCH.json", Path.DirectorySeparatorChar, Path.DirectorySeparatorChar);

	private string jsonPath = string.Empty;

	public bool IsHFFVROnly
	{
		[CompilerGenerated]
		get
		{
			return isHFFVROnly;
		}
	}

	public static GetWorkshopHighlights Instance { get; private set; }

	public static List<Highlight> EnglishHighlights
	{
		[CompilerGenerated]
		get
		{
			return Instance.englishHighlights;
		}
	}

	public static List<Highlight> ChineseHighlights
	{
		[CompilerGenerated]
		get
		{
			return Instance.chineseHighlights;
		}
	}

	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		Instance = this;
		if (Application.isEditor)
		{
			jsonPath = Application.dataPath;
		}
		else
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
			jsonPath = directoryInfo.Parent.FullName;
		}
		englishHighlights.Add(new Highlight(HFFVRPromoSprite, HFFVRPromoTitle, HFFVRPromoLink));
		if (!isHFFVROnly)
		{
			GetHighlightLinks(jsonPath + englishJson, true);
			GetHighlightLinks(jsonPath + chineseJson, false);
		}
	}

	private void GetHighlightLinks(string fullJsonPath, bool worldWide)
	{
		if (!File.Exists(fullJsonPath))
		{
			if (Application.isEditor)
			{
				Debug.LogError(string.Format("Unable to find highlight json at {0}", fullJsonPath));
			}
			return;
		}
		string[] array = File.ReadAllLines(fullJsonPath);
		string text = string.Empty;
		if (array != null && array.Length > 0)
		{
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				text += text2;
			}
		}
		if (text != string.Empty)
		{
			jsonLinks = JsonUtility.FromJson<LinksJSON>(text);
			for (int j = 0; j < jsonLinks.Links.Length; j++)
			{
				StartCoroutine(GetHighlight(jsonLinks.Links[j], worldWide, j));
			}
		}
	}

	private IEnumerator GetHighlight(string link, bool worldWide, int index)
	{
		if (link == null || link == string.Empty)
		{
			yield break;
		}
		using (UnityWebRequest request = UnityWebRequest.Get(link))
		{
			request.redirectLimit = 32;
			request.downloadHandler = new DownloadHandlerBuffer();
			request.timeout = 10;
			yield return request.SendWebRequest();
			if (request.isNetworkError)
			{
				Debug.LogError(string.Format("workshop request to {0} failed with network or system error: {1}", link, request.error));
				if (!worldWide)
				{
					LoadFallbackChineseImage(index);
				}
			}
			else if (request.isHttpError)
			{
				Debug.LogError(string.Format("workshop request to {0} failed with http error: {1}", link, request.responseCode));
				if (!worldWide)
				{
					LoadFallbackChineseImage(index);
				}
			}
			else
			{
				yield return DownloadWorkshopImage(link, index, request.downloadHandler.text, worldWide);
			}
		}
	}

	private IEnumerator DownloadWorkshopImage(string link, int index, string pageText, bool worldWide = true)
	{
		string levelName = string.Empty;
		string imageUrl = string.Empty;
		bool complete = false;
		StringReader textReader = new StringReader(pageText);
		bool foundImage = false;
		bool isImageKeyValuePairExpected = false;
		do
		{
			string line = textReader.ReadLine();
			if (line == null)
			{
				complete = true;
			}
			else if (line.Contains("<div class=\"workshopItemTitle\">"))
			{
				int num = line.IndexOf("\">");
				line = line.Substring(num + 2);
				levelName = line.Substring(0, line.IndexOf("<"));
			}
			else if (line.Contains("class=\"workshopItemPreviewImageEnlargeable\""))
			{
				int num2 = line.IndexOf("https://steamuserimages");
				if (num2 >= 0)
				{
					line = line.Substring(num2);
					imageUrl = line.Substring(0, line.IndexOf("\""));
					foundImage = true;
					complete = true;
				}
			}
			else if (line.Contains("var rgScreenshotURLs"))
			{
				isImageKeyValuePairExpected = true;
			}
			else if (isImageKeyValuePairExpected)
			{
				isImageKeyValuePairExpected = false;
				int num3 = line.IndexOf("https://steamuserimages");
				if (num3 >= 0)
				{
					line = line.Substring(num3);
					imageUrl = line.Substring(0, line.IndexOf("'"));
					imageUrl = imageUrl.Replace("letterbox=true", "letterbox=false");
					foundImage = true;
					complete = true;
				}
			}
		}
		while (!complete);
		textReader.Close();
		if (!foundImage)
		{
			yield break;
		}
		using (UnityWebRequest imageRequest = UnityWebRequest.Get(imageUrl))
		{
			DownloadHandlerTexture textureDownloadHandler = (DownloadHandlerTexture)(imageRequest.downloadHandler = new DownloadHandlerTexture());
			imageRequest.redirectLimit = 32;
			imageRequest.timeout = 10;
			yield return imageRequest.SendWebRequest();
			if (imageRequest.isNetworkError)
			{
				Debug.LogError(string.Format("workshop image request to {0} failed with network or system error: {1}", imageUrl, imageRequest.error));
				if (!worldWide)
				{
					LoadFallbackChineseImage(index);
				}
				yield break;
			}
			if (imageRequest.isHttpError)
			{
				Debug.LogError(string.Format("workshop image request to {0} failed with http error: {1}", imageUrl, imageRequest.responseCode));
				if (!worldWide)
				{
					LoadFallbackChineseImage(index);
				}
				yield break;
			}
			Texture2D texture2D = textureDownloadHandler.texture;
			Sprite levelImage = Sprite.Create(texture2D, new Rect(new Vector2(0f, 0f), new Vector2(texture2D.width, texture2D.height)), Vector2.zero);
			if (worldWide)
			{
				englishHighlights.Add(new Highlight(levelImage, levelName, link));
			}
			else
			{
				chineseHighlights.Add(new Highlight(levelImage, levelName, link));
			}
		}
	}

	private void LoadFallbackChineseImage(int imageIndex)
	{
		string text = string.Format("{0}/UIToast/WorkshopImages", jsonPath);
		string[] files = Directory.GetFiles(text, "*.png");
		if (files.Length < imageIndex)
		{
			Debug.LogError("No corresponding image for index " + imageIndex);
			return;
		}
		string fileName = Path.GetFileName(files[imageIndex]);
		byte[] data = File.ReadAllBytes(string.Format("{0}{1}{2}", text, Path.DirectorySeparatorChar, fileName));
		Texture2D texture2D = new Texture2D(1, 1);
		texture2D.LoadImage(data);
		Sprite sprite = Sprite.Create(texture2D, new Rect(new Vector2(0f, 0f), new Vector2(texture2D.width, texture2D.height)), Vector2.zero);
		chineseHighlights.Add(new Highlight(sprite, string.Empty, string.Empty));
	}
}
