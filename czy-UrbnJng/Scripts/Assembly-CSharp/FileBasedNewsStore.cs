using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine;

public class FileBasedNewsStore : NewsStoreBase
{
	private string fileDomain = Application.streamingAssetsPath;

	private string filename;

	public override void Initalize(Action<GenericNews> onSuccess)
	{
		genericNews = new GenericNews();
		onSuccessActions.Add(onSuccess);
	}

	public override void GetNews()
	{
		string responseBody = File.ReadAllText(Path.Combine(fileDomain, "News/News.json"));
		FormatNewsSource(responseBody);
		foreach (Action<GenericNews> onSuccessAction in onSuccessActions)
		{
			onSuccessAction?.Invoke(genericNews);
		}
	}

	protected override void FormatNewsSource(string body)
	{
		try
		{
			foreach (Entries entry in JsonConvert.DeserializeObject<GentlymadAPINews>(body).entries)
			{
				if (entry.pinned && entry.tags.Contains("STEAM"))
				{
					if (entry.defines != null)
					{
						entry.defines.Contains(null);
					}
					excerpt = entry.GetLocalizedExcerpt(language);
					genericNews.title = entry.GetLocalizedTitle(language);
					genericNews.urlToClick = entry.url;
					CleanUp();
					genericNews.content = excerpt;
					filename = Path.GetFileName(entry.image.path);
					filename = Path.Combine("News/", filename);
					SetImage(filename);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError(ex.Message);
		}
	}

	public override void CleanUp()
	{
		excerpt = excerpt.Replace("<a href=", "<style=DefaultLink\"><link=");
		excerpt = excerpt.Replace("<ul>", "");
		excerpt = excerpt.Replace("<ol>", "");
		excerpt = excerpt.Replace("</ul>", "");
		excerpt = excerpt.Replace("</ol>", "");
		excerpt = excerpt.Replace("<li>", "<style=\"List\">");
		excerpt = excerpt.Replace("</li>", "</style>");
		excerpt = excerpt.Replace("</a>", "</link></style>");
		excerpt = excerpt.Replace("<strong>", "<b>");
		excerpt = excerpt.Replace("</strong>", "</b>");
		excerpt = excerpt.Replace("<em>", "<i>");
		excerpt = excerpt.Replace("</em>", "</i>");
		excerpt = excerpt.Replace("<h3>", "<size=25>");
		excerpt = excerpt.Replace("</h3>", "</size>");
		excerpt = Regex.Replace(excerpt, "\\[[^]]+\\]", "");
		excerpt = Regex.Replace(excerpt, "[\r\n]+", "\n\n");
		excerpt = Regex.Replace(excerpt, "^\\s*$\\n|\\r", string.Empty, RegexOptions.Multiline).TrimEnd();
		excerpt = excerpt.Replace("<br><br>", "");
		excerpt = excerpt.Replace("<br>", "");
	}

	protected void SetImage(string filename)
	{
		Texture2D texture2D = new Texture2D(2, 2);
		try
		{
			texture2D.LoadImage(File.ReadAllBytes(Path.Combine(fileDomain, filename)));
		}
		catch (Exception ex)
		{
			Debug.LogWarning(ex.Message);
			texture2D.LoadImage(File.ReadAllBytes(Path.Combine(fileDomain, "News/", "NewsImage.jpg")));
		}
		Rect rect = new Rect(0f, 0f, texture2D.width, texture2D.height);
		Sprite newsSprite = Sprite.Create(texture2D, rect, new Vector2(0.5f, 0.5f), 100f);
		genericNews.newsSprite = newsSprite;
	}

	protected override void SetImage()
	{
		SetImage(filename);
	}

	public void RerouteActions(List<Action<GenericNews>> onSuccessActions, string language)
	{
		Debug.Log("Set Fallback News");
		base.onSuccessActions = onSuccessActions;
		genericNews = new GenericNews();
		base.language = language;
	}

	public override void GetNews(string language)
	{
		SetLanguage(language);
		GetNews();
	}
}
