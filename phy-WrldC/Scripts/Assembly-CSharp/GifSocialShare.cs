using UnityEngine;

public class GifSocialShare
{
	public enum Social
	{
		Facebook = 0,
		Twitter = 1,
		Twitter_Mobile = 2,
		Tumblr = 3,
		VK = 4,
		Pinterest = 5,
		LinkedIn = 6,
		Odnoklassniki = 7,
		Reddit = 8,
		GooglePlus = 9,
		QQZone = 10,
		Weibo = 11,
		Baidu = 12,
		MySpace = 13,
		LineMe = 14,
		Skype = 15
	}

	private string facebookTemplate = "https://www.facebook.com/sharer/sharer.php?u={3}";

	private string twitterTemplate = "https://giphy.com/gifs/{2}/tweet";

	private string twitterMobileTemplate = "https://twitter.com/intent/tweet?url={3}&text={1}&via={2}&hashtags={0}";

	private string tumblrTemplate = "https://www.tumblr.com/widgets/share/tool?canonicalUrl={3}&title={0}&caption={1}";

	private string vkTemplate = "http://vk.com/share.php?title={0}&description={1}&image={2}&url={3}";

	private string pinterestTemplate = "https://pinterest.com/pin/create/button/?url={3}&media={2}&description={1}";

	private string linkedInTemplate = "https://www.linkedin.com/shareArticle?mini=true&url={3}&title={0}&summary={1}";

	private string odnoklassnikiTemplate = "http://www.odnoklassniki.ru/dk?st.cmd=addShare&st.s=1&st._surl={3}&st.comments={1}";

	private string redditTemplate = "https://reddit.com/submit?url={3}&title={0}";

	private string googlePlusTemplate = "https://plus.google.com/share?url={3}";

	private string qqTemplate = "http://sns.qzone.qq.com/cgi-bin/qzshare/cgi_qzshare_onekey?url={3}&title{0}&description={1}";

	private string weiboTemplate = "http://service.weibo.com/share/share.php?url={3}&appkey=&title={1}";

	private string baiduTemplate = "http://cang.baidu.com/do/add?it={1}&iu={3}";

	private string mySpaceTemplate = "https://myspace.com/post?u={3}&t={0}&c={1}";

	private string lineMeTemplate = "https://lineit.line.me/share/ui?url={3}";

	private string skypeTemplate = "https://web.skype.com/share?url={3}";

	private string _MakeUrl(Social social, string title = "", string description = "", string image = "", string shareUrl = "")
	{
		string empty = string.Empty;
		switch (social)
		{
		case Social.Facebook:
			empty = facebookTemplate;
			break;
		case Social.Twitter:
			empty = twitterTemplate;
			break;
		case Social.Twitter_Mobile:
			empty = twitterMobileTemplate;
			break;
		case Social.Tumblr:
			empty = tumblrTemplate;
			break;
		case Social.VK:
			empty = vkTemplate;
			break;
		case Social.Pinterest:
			empty = pinterestTemplate;
			break;
		case Social.LinkedIn:
			empty = linkedInTemplate;
			break;
		case Social.Odnoklassniki:
			empty = odnoklassnikiTemplate;
			break;
		case Social.Reddit:
			empty = redditTemplate;
			break;
		case Social.GooglePlus:
			empty = googlePlusTemplate;
			break;
		case Social.QQZone:
			empty = qqTemplate;
			break;
		case Social.Weibo:
			empty = weiboTemplate;
			break;
		case Social.Baidu:
			empty = baiduTemplate;
			break;
		case Social.MySpace:
			empty = mySpaceTemplate;
			break;
		case Social.LineMe:
			empty = lineMeTemplate;
			break;
		case Social.Skype:
			empty = skypeTemplate;
			break;
		}
		return string.Format(empty, _EscapeURL(title), _EscapeURL(description), _EscapeURL(image), _EscapeURL(shareUrl));
	}

	public void ShareTo(Social socialNetwork, string title = "", string description = "", string image = "", string shareUrl = "")
	{
		string url = _MakeUrl(socialNetwork, title, description, image, shareUrl);
		_Publish(url);
	}

	public void SendEmail(string toMailAddress, string subject, string body)
	{
		string url = "mailto:" + toMailAddress + "?subject=" + _EscapeURL(subject) + "&body=" + _EscapeURL(body);
		_Publish(url);
	}

	private string _EscapeURL(string url)
	{
		return WWW.EscapeURL(url).Replace("+", "%20");
	}

	private void _Publish(string url)
	{
		Application.OpenURL(url);
	}
}
