using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Loxodon.Log;
using UnityEngine;
using UnityEngine.Networking;

namespace Loxodon.Framework.Localizations
{
	public class AssetBundleDataProvider : IDataProvider
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(AssetBundleDataProvider));

		private string assetBundleUrl;

		private IDocumentParser parser;

		public AssetBundleDataProvider(string assetBundleUrl)
			: this(assetBundleUrl, new XmlDocumentParser())
		{
		}

		public AssetBundleDataProvider(string assetBundleUrl, IDocumentParser parser)
		{
			if (string.IsNullOrEmpty(assetBundleUrl))
			{
				throw new ArgumentNullException("assetBundleUrl");
			}
			if (parser == null)
			{
				throw new ArgumentNullException("parser");
			}
			this.assetBundleUrl = assetBundleUrl;
			this.parser = parser;
		}

		public virtual async Task<Dictionary<string, object>> Load(CultureInfo cultureInfo)
		{
			Dictionary<string, object> dict = new Dictionary<string, object>();
			using UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(assetBundleUrl);
			await www.SendWebRequest();
			AssetBundle assetBundle = ((DownloadHandlerAssetBundle)www.downloadHandler).assetBundle;
			if (assetBundle == null)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("Failed to load Assetbundle from \"{0}\".", assetBundleUrl);
				}
				return dict;
			}
			try
			{
				List<string> list = new List<string>(assetBundle.GetAllAssetNames());
				List<string> paths = list.FindAll((string p) => p.Contains("/default/"));
				List<string> paths2 = list.FindAll((string p) => p.Contains($"/{cultureInfo.TwoLetterISOLanguageName}/"));
				List<string> paths3 = (cultureInfo.Name.Equals(cultureInfo.TwoLetterISOLanguageName) ? null : list.FindAll((string p) => p.Contains($"/{cultureInfo.Name}/")));
				FillData(dict, assetBundle, paths, cultureInfo);
				FillData(dict, assetBundle, paths2, cultureInfo);
				FillData(dict, assetBundle, paths3, cultureInfo);
			}
			finally
			{
				try
				{
					if (assetBundle != null)
					{
						assetBundle.Unload(unloadAllLoadedObjects: true);
					}
				}
				catch (Exception)
				{
				}
			}
			return dict;
		}

		private void FillData(Dictionary<string, object> dict, AssetBundle bundle, List<string> paths, CultureInfo cultureInfo)
		{
			try
			{
				if (paths == null || paths.Count <= 0)
				{
					return;
				}
				foreach (string path in paths)
				{
					try
					{
						using MemoryStream input = new MemoryStream(bundle.LoadAsset<TextAsset>(path).bytes);
						foreach (KeyValuePair<string, object> item in parser.Parse(input, cultureInfo))
						{
							dict[item.Key] = item.Value;
						}
					}
					catch (Exception ex)
					{
						if (log.IsWarnEnabled)
						{
							log.WarnFormat("An error occurred when loading localized data from \"{0}\".Error:{1}", path, ex);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
