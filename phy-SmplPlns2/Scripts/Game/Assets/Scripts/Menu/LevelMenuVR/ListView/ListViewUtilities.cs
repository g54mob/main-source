using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using Jundroo.Common.Coroutines;
using UnityEngine;

namespace Assets.Scripts.Menu.LevelMenuVR.ListView
{
	public static class ListViewUtilities
	{
		public static IEnumerator LoadBytes(ResourceLocation location, string path, YieldRequest<byte[]> request)
		{
			if (location == ResourceLocation.Resource)
			{
				TextAsset textAsset = Resources.Load(path) as TextAsset;
				if (textAsset != null)
				{
					request.Complete(textAsset.bytes);
				}
				else
				{
					request.Error("Could not find file in resources at " + path + ".");
				}
				yield break;
			}
			byte[] bytes = null;
			switch (location)
			{
			case ResourceLocation.File:
				try
				{
					bytes = File.ReadAllBytes(path);
				}
				catch (Exception)
				{
					request.Error("Could not read file at path " + path);
				}
				break;
			case ResourceLocation.Web:
			{
				WebYieldRequest<byte[]> webRequest = Game.Instance.WebCache.GetBinary(path, 0);
				while (!webRequest.Done)
				{
					yield return new WaitForEndOfFrame();
				}
				if (webRequest.Success)
				{
					bytes = webRequest.Data;
				}
				else
				{
					Debug.LogError(webRequest.ErrorMessage);
				}
				break;
			}
			}
			if (bytes != null)
			{
				try
				{
					request.Complete(bytes);
				}
				catch (Exception)
				{
					request.Error($"Could not load bytes from {location} at {path}");
				}
			}
		}

		public static IEnumerator LoadText(ResourceLocation location, string path, YieldRequest<string> request, int expirationInMinutes = 0)
		{
			if (location == ResourceLocation.Resource)
			{
				TextAsset textAsset = Resources.Load(path) as TextAsset;
				if (textAsset != null)
				{
					request.Complete(textAsset.text);
				}
				else
				{
					request.Error("Could not find file in resources at " + path + ".");
				}
				yield break;
			}
			string text = null;
			switch (location)
			{
			case ResourceLocation.File:
				try
				{
					text = File.ReadAllText(path);
				}
				catch (Exception)
				{
					request.Error("Could not read file at path " + path);
				}
				break;
			case ResourceLocation.Web:
			{
				WebYieldRequest<string> webRequest = Game.Instance.WebCache.GetText(path, expirationInMinutes);
				while (!webRequest.Done)
				{
					yield return new WaitForEndOfFrame();
				}
				if (webRequest.Success)
				{
					text = webRequest.Data;
				}
				else
				{
					Debug.LogError(webRequest.ErrorMessage);
				}
				break;
			}
			}
			if (text != null)
			{
				try
				{
					request.Complete(text);
				}
				catch (Exception)
				{
					request.Error($"Could not load text from {location} at {path}");
				}
			}
		}

		public static IEnumerator LoadTexture(ResourceLocation location, string path, YieldRequest<Texture2D> request)
		{
			if (location == ResourceLocation.Resource)
			{
				Texture2D texture2D = Resources.Load(path) as Texture2D;
				if (texture2D != null)
				{
					request.Complete(texture2D);
				}
				else
				{
					request.Error("Could not find texture in resources at " + path + ".");
				}
				yield break;
			}
			byte[] bytes = null;
			switch (location)
			{
			case ResourceLocation.File:
				try
				{
					bytes = File.ReadAllBytes(path);
				}
				catch (Exception)
				{
					request.Error("Could not read texture from file path " + path);
				}
				break;
			case ResourceLocation.Web:
			{
				WebYieldRequest<byte[]> webRequest = Game.Instance.WebCache.GetBinary(path, 0);
				while (!webRequest.Done)
				{
					yield return new WaitForEndOfFrame();
				}
				if (webRequest.Success)
				{
					bytes = webRequest.Data;
				}
				else
				{
					Debug.LogError("Web request failed: " + path + "\n" + webRequest.ErrorMessage);
				}
				break;
			}
			}
			if (bytes != null)
			{
				try
				{
					Texture2D texture2D2 = new Texture2D(1, 1);
					texture2D2.LoadImage(bytes);
					request.Complete(texture2D2);
				}
				catch (Exception)
				{
					request.Error($"Could not load texture from {location} at {path}");
				}
			}
		}

		public static string StripHTML(string input)
		{
			return Regex.Replace(input, "<.*?>", string.Empty);
		}
	}
}
