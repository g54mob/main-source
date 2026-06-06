using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine;

public class SteamNewsStore : RemoteNewsSource
{
	private string extractedImageURL;

	public override void Initalize(Action<GenericNews> onSuccess)
	{
		genericNews = new GenericNews();
		onSuccessActions.Add(onSuccess);
	}

	public override void GetNews()
	{
		GetNewsFromRemoteRequest("https://api.steampowered.com/ISteamNews/GetNewsForApp/v2/?appid=933820&count=999");
	}

	protected override void FormatNewsSource(string body)
	{
		try
		{
			foreach (NewsItem newsitem in JsonConvert.DeserializeObject<SteamNews>(body).appnews.newsitems)
			{
				if (newsitem.gid == "3657415303184638894")
				{
					genericNews.title = newsitem.title;
					genericNews.urlToClick = newsitem.url;
					excerpt = ExtractExcerpt(newsitem);
					ExtractImageURL(excerpt);
					SetImage();
					CleanUp();
					genericNews.content = excerpt;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			Debug.Log(ex.Message);
			SetFallBackSource();
		}
	}

	public override void CleanUp()
	{
		excerpt = Regex.Replace(excerpt, "\\[img](.*?)\\[/img]", "");
		excerpt = excerpt.Replace("[h3]", "<b><size=25>");
		excerpt = excerpt.Replace("[/h3]", "</size></b>");
		excerpt = excerpt.Replace("[b]", "<b>");
		excerpt = excerpt.Replace("[/b]", "</b>");
		excerpt = excerpt.Replace("[i]", "<i>");
		excerpt = excerpt.Replace("[/i]", "</i>");
		excerpt = excerpt.Replace("[u]", "<u>");
		excerpt = excerpt.Replace("[/u]", "</u>");
		excerpt = Regex.Replace(excerpt, "\\[[^]]+\\]", "");
		excerpt = Regex.Replace(excerpt, "[\r\n]+", "\n\n");
	}

	public void ExtractImageURL(string content)
	{
		foreach (Match item in Regex.Matches(content, "\\[img](.*?)\\[/img]"))
		{
			string value = item.Groups[1].Value;
			value = value.Replace("{STEAM_CLAN_IMAGE}", "https://cdn.akamai.steamstatic.com/steamcommunity/public/images/clans");
			extractedImageURL = value;
		}
	}

	protected override async void SetImage()
	{
		try
		{
			byte[] bytes = await new HttpClient().GetByteArrayAsync(extractedImageURL);
			genericNews.newsSprite = GetSpriteFromByteArray(bytes);
			foreach (Action<GenericNews> onSuccessAction in onSuccessActions)
			{
				onSuccessAction?.Invoke(genericNews);
			}
		}
		catch (Exception ex)
		{
			Debug.Log(ex.Message);
		}
	}

	private string ExtractExcerpt(NewsItem item)
	{
		int num = item.contents.IndexOf("~~~");
		_ = item.contents;
		if (num >= 0)
		{
			return item.contents.Substring(0, num);
		}
		Debug.LogError("Cant find '~~~'");
		return null;
	}
}
