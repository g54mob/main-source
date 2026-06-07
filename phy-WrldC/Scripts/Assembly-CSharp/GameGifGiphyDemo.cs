using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGifGiphyDemo : MonoBehaviour
{
	public Dropdown m_Dropdown;

	public InputField m_InputField;

	public InputField m_InputField_ID;

	private string _shareTitle = "This is a Title";

	private string _shareText = "This is a Message";

	private string _shareGifId = "";

	private string _shareGifBitlyUrl = "";

	private string _shareGifFullUrl = "";

	public void OnButtonShare()
	{
		Debug.Log("OnButtonShare - BitlyUrl: " + _shareGifBitlyUrl + " | Id: " + _shareGifId + " | FullUrl: " + _shareGifFullUrl);
		GifSocialShare gifSocialShare = new GifSocialShare();
		gifSocialShare.ShareTo(GifSocialShare.Social.Facebook, _shareTitle, _shareText, _shareGifBitlyUrl, _shareGifBitlyUrl);
		gifSocialShare.ShareTo(GifSocialShare.Social.Twitter, _shareTitle, _shareText, _shareGifId, _shareGifFullUrl);
		gifSocialShare.ShareTo(GifSocialShare.Social.MySpace, _shareTitle, _shareText, _shareGifFullUrl, _shareGifFullUrl);
		gifSocialShare.ShareTo(GifSocialShare.Social.Tumblr, _shareTitle, _shareText, _shareGifFullUrl, _shareGifFullUrl);
		gifSocialShare.ShareTo(GifSocialShare.Social.Skype, _shareTitle, _shareText, _shareGifFullUrl, _shareGifFullUrl);
	}

	public void OnButtonFB()
	{
		Debug.Log("OnButtonFB: " + _shareGifBitlyUrl);
		new GifSocialShare().ShareTo(GifSocialShare.Social.Facebook, _shareTitle, _shareText, _shareGifBitlyUrl, _shareGifBitlyUrl);
	}

	public void OnButtonTwitter()
	{
		Debug.Log("OnButtonTwitter: " + _shareGifId);
		new GifSocialShare().ShareTo(GifSocialShare.Social.Twitter, _shareTitle, _shareText, _shareGifId, _shareGifFullUrl);
	}

	public void OnButtonTwitter_Mobile()
	{
		Debug.Log("OnButtonTwitter_Mobile: " + _shareGifId);
		new GifSocialShare().ShareTo(GifSocialShare.Social.Twitter_Mobile, "hashtag", _shareText, "https://www.swanob2.com", _shareGifBitlyUrl);
	}

	public void OnButtonTumblr()
	{
		Debug.Log("OnButtonTumblr: " + _shareGifFullUrl);
		new GifSocialShare().ShareTo(GifSocialShare.Social.Tumblr, _shareTitle, _shareText, _shareGifFullUrl, _shareGifFullUrl);
	}

	public void OnButtonVK()
	{
		Debug.Log("OnButtonVK: " + _shareGifBitlyUrl);
		new GifSocialShare().ShareTo(GifSocialShare.Social.VK, _shareTitle, _shareText, _shareGifBitlyUrl, _shareGifBitlyUrl);
	}

	public void OnButtonPinterest()
	{
		Debug.Log("OnButtonPinterest: " + _shareGifFullUrl);
		new GifSocialShare().ShareTo(GifSocialShare.Social.Pinterest, _shareTitle, _shareText, _shareGifFullUrl, _shareGifFullUrl);
	}

	public void OnButtonLinkedIn()
	{
		Debug.Log("OnButtonPLinkedIn: " + _shareGifFullUrl);
		new GifSocialShare().ShareTo(GifSocialShare.Social.LinkedIn, _shareTitle, _shareText, _shareGifFullUrl, _shareGifFullUrl);
	}

	public void OnButtonOKRU()
	{
		Debug.Log("OnButtonOKRU: " + _shareGifBitlyUrl);
		new GifSocialShare().ShareTo(GifSocialShare.Social.Odnoklassniki, _shareTitle, _shareText, _shareGifBitlyUrl, _shareGifBitlyUrl);
	}

	public void OnButtonReddit()
	{
		Debug.Log("OnButtonReddit: " + _shareGifBitlyUrl);
		new GifSocialShare().ShareTo(GifSocialShare.Social.Reddit, _shareTitle, _shareText, _shareGifBitlyUrl, _shareGifBitlyUrl);
	}

	public void OnButtonGooglePlus()
	{
		Debug.Log("OnButtonGooglePlus: " + _shareGifBitlyUrl);
		new GifSocialShare().ShareTo(GifSocialShare.Social.GooglePlus, _shareTitle, _shareText, _shareGifBitlyUrl, _shareGifBitlyUrl);
	}

	public void OnButtonQQ()
	{
		Debug.Log("OnButtonQQ: " + _shareGifFullUrl);
		new GifSocialShare().ShareTo(GifSocialShare.Social.QQZone, _shareTitle, _shareText, _shareGifFullUrl, _shareGifFullUrl);
	}

	public void OnButtonWeibo()
	{
		Debug.Log("OnButtonWeibo: " + _shareGifBitlyUrl);
		new GifSocialShare().ShareTo(GifSocialShare.Social.Weibo, _shareTitle, _shareText, _shareGifBitlyUrl, _shareGifBitlyUrl);
	}

	public void OnButtonMySpace()
	{
		Debug.Log("OnButtonMySpace: " + _shareGifFullUrl);
		new GifSocialShare().ShareTo(GifSocialShare.Social.MySpace, _shareTitle, _shareText, _shareGifFullUrl, _shareGifFullUrl);
	}

	public void OnButtonLineMe()
	{
		Debug.Log("OnButtonLineMe: " + _shareGifBitlyUrl);
		new GifSocialShare().ShareTo(GifSocialShare.Social.LineMe, _shareTitle, _shareText, _shareGifBitlyUrl, _shareGifBitlyUrl);
	}

	public void OnButtonSkype()
	{
		Debug.Log("OnButtonSkype: " + _shareGifFullUrl);
		new GifSocialShare().ShareTo(GifSocialShare.Social.Skype, _shareTitle, _shareText, _shareGifFullUrl, _shareGifFullUrl);
	}

	public void OnButtonBaidu()
	{
		Debug.Log("OnButtonBaidu: " + _shareGifBitlyUrl);
		new GifSocialShare().ShareTo(GifSocialShare.Social.Baidu, _shareTitle, _shareText, _shareGifBitlyUrl, _shareGifBitlyUrl);
	}

	public void OnButtonSend()
	{
		Debug.Log("OnButtonSend: " + m_Dropdown.options[m_Dropdown.value].text);
		_GiphyApi(m_Dropdown.options[m_Dropdown.value].text);
	}

	private void _GiphyApi(string text)
	{
		string tempStr = "";
		if (text == "GetById")
		{
			Debug.Log("_GiphyApi > GetById");
			string gifId = m_InputField_ID.text;
			GiphyManager.Instance.GetById(gifId, delegate(GiphyGetById.Response result)
			{
				tempStr = "GetById - (Id = " + gifId + "): ";
				_shareGifBitlyUrl = result.data.bitly_gif_url;
				_shareGifFullUrl = result.data.images.original.url;
				_shareGifId = result.data.id;
				tempStr = tempStr + "\n\n_shareGifBitlyUrl: " + _shareGifBitlyUrl + "\n_shareGifFullUrl: " + _shareGifFullUrl + "\n_shareGifId: " + _shareGifId;
				Debug.Log(tempStr);
				m_InputField.text = tempStr;
			});
		}
	}

	public void UploadApi(string gifFilePath)
	{
		GiphyManager.Instance.Upload(gifFilePath, new List<string> { "GifTagTest", "SwanOB2", "AssetPackage" }, delegate(GiphyUpload.Response uploadResult)
		{
			Debug.Log("Upload response, Unique Gif Id: " + uploadResult.data.id);
			GiphyManager.Instance.GetById(uploadResult.data.id, delegate(GiphyGetById.Response getByIdResult)
			{
				Debug.Log("GetById response, gif short link: " + getByIdResult.data.bitly_gif_url);
			});
		}, delegate(float progress)
		{
			Debug.Log("Upload Progress: " + progress);
		});
	}
}
