using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Kitchen
{
	public class ImageFromURL : MonoBehaviour
	{
		public static Dictionary<string, Texture2D> Cache = new Dictionary<string, Texture2D>();

		public Renderer Renderer;

		public string Property;

		private void Attempt(string url)
		{
			StartCoroutine(LoadURL(url));
		}

		private IEnumerator LoadURL(string url)
		{
			if (Cache.TryGetValue(url, out var value))
			{
				Debug.Log("Cache hit");
				SetImage(value);
				yield break;
			}
			if (Application.internetReachability == NetworkReachability.NotReachable)
			{
				yield return null;
			}
			using UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url);
			yield return uwr.SendWebRequest();
			if (uwr.result != UnityWebRequest.Result.Success)
			{
				Debug.Log(uwr.error);
				yield break;
			}
			Debug.Log("Success");
			Texture2D content = DownloadHandlerTexture.GetContent(uwr);
			Cache[url] = content;
			SetImage(content);
		}

		private void SetImage(Texture2D texture)
		{
			Renderer.material.SetTexture(Property, texture);
		}
	}
}
