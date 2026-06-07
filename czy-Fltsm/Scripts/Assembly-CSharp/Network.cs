using System.IO;
using System.Net;
using UnityEngine;

public class Network : MonoBehaviour
{
	private static string GetHtmlFromUri(string resource)
	{
		string text = string.Empty;
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(resource);
		try
		{
			using HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			if (httpWebResponse.StatusCode < (HttpStatusCode)299 && httpWebResponse.StatusCode >= HttpStatusCode.OK)
			{
				using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
				char[] array = new char[80];
				streamReader.Read(array, 0, array.Length);
				char[] array2 = array;
				foreach (char c in array2)
				{
					text += c;
				}
			}
		}
		catch
		{
			return "";
		}
		return text;
	}

	public static bool ConnectedToInternet()
	{
		string htmlFromUri = GetHtmlFromUri("http://google.com");
		if (htmlFromUri == "")
		{
			return false;
		}
		if (!htmlFromUri.Contains("schema.org/WebPage"))
		{
			return false;
		}
		return true;
	}
}
