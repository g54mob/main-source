using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Loxodon.Log;
using UnityEngine;
using UnityEngine.Networking;

namespace Loxodon.Framework.Localizations
{
	public class AssetBundleLocalizationSourceDataProvider : IDataProvider
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(AssetBundleLocalizationSourceDataProvider));

		protected string[] filenames;

		protected string assetBundleUrl;

		public AssetBundleLocalizationSourceDataProvider(string assetBundleUrl, params string[] filenames)
		{
			if (string.IsNullOrEmpty(assetBundleUrl))
			{
				throw new ArgumentNullException("assetBundleUrl");
			}
			this.assetBundleUrl = assetBundleUrl;
			this.filenames = filenames;
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
				string[] array = filenames;
				foreach (string filename in array)
				{
					try
					{
						string path = list.Find((string p) => p.Contains($"/default/{filename}"));
						string path2 = list.Find((string p) => p.Contains($"/{cultureInfo.TwoLetterISOLanguageName}/{filename}"));
						string path3 = (cultureInfo.Name.Equals(cultureInfo.TwoLetterISOLanguageName) ? null : list.Find((string p) => p.Contains($"/{cultureInfo.Name}/{filename}")));
						FillData(dict, assetBundle, path);
						FillData(dict, assetBundle, path2);
						FillData(dict, assetBundle, path3);
					}
					catch (Exception ex)
					{
						if (log.IsWarnEnabled)
						{
							log.WarnFormat("An error occurred when loading localized data from \"{0}\".Error:{1}", filename, ex);
						}
					}
				}
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

		private void FillData(Dictionary<string, object> dict, AssetBundle bundle, string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return;
			}
			LocalizationSourceAsset localizationSourceAsset = bundle.LoadAsset<LocalizationSourceAsset>(path);
			if (localizationSourceAsset == null)
			{
				return;
			}
			MonolingualSource source = localizationSourceAsset.Source;
			if (source == null)
			{
				return;
			}
			foreach (KeyValuePair<string, object> datum in source.GetData())
			{
				dict[datum.Key] = datum.Value;
			}
		}
	}
}
