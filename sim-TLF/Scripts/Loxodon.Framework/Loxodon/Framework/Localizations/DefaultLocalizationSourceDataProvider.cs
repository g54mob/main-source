using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Loxodon.Log;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	public class DefaultLocalizationSourceDataProvider : IDataProvider
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(DefaultLocalizationSourceDataProvider));

		protected string[] filenames;

		protected string root;

		public DefaultLocalizationSourceDataProvider(string root, params string[] filenames)
		{
			this.root = root;
			this.filenames = filenames;
		}

		protected string GetDefaultPath(string filename)
		{
			return GetPath("default", filename);
		}

		protected string GetPath(string dir, string filename)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(root);
			if (!root.EndsWith("/"))
			{
				stringBuilder.Append("/");
			}
			stringBuilder.Append(dir).Append("/").Append(filename.Replace(".asset", ""));
			return stringBuilder.ToString();
		}

		public virtual async Task<Dictionary<string, object>> Load(CultureInfo cultureInfo)
		{
			Dictionary<string, object> dict = new Dictionary<string, object>();
			List<Task> list = new List<Task>();
			string[] array = filenames;
			foreach (string filename in array)
			{
				list.Add(Load(dict, filename, cultureInfo));
			}
			await Task.WhenAll(list);
			return dict;
		}

		protected virtual async Task Load(Dictionary<string, object> dict, string filename, CultureInfo cultureInfo)
		{
			LocalizationSourceAsset defaultSourceAsset = (LocalizationSourceAsset)(await Resources.LoadAsync<LocalizationSourceAsset>(GetDefaultPath(filename)));
			LocalizationSourceAsset twoLetterISOSourceAsset = (LocalizationSourceAsset)(await Resources.LoadAsync<LocalizationSourceAsset>(GetPath(cultureInfo.TwoLetterISOLanguageName, filename)));
			LocalizationSourceAsset localizationSourceAsset = ((!cultureInfo.Name.Equals(cultureInfo.TwoLetterISOLanguageName)) ? ((LocalizationSourceAsset)(await Resources.LoadAsync<LocalizationSourceAsset>(GetPath(cultureInfo.Name, filename)))) : null);
			LocalizationSourceAsset localizationSourceAsset2 = localizationSourceAsset;
			if (defaultSourceAsset == null && twoLetterISOSourceAsset == null && localizationSourceAsset2 == null)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("Not found the localized file \"{0}\".", filename);
				}
				return;
			}
			if (defaultSourceAsset != null)
			{
				FillData(dict, defaultSourceAsset.Source);
			}
			if (twoLetterISOSourceAsset != null)
			{
				FillData(dict, twoLetterISOSourceAsset.Source);
			}
			if (localizationSourceAsset2 != null)
			{
				FillData(dict, localizationSourceAsset2.Source);
			}
		}

		private void FillData(Dictionary<string, object> dict, MonolingualSource source)
		{
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
