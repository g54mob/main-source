using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Loxodon.Log;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	[AddComponentMenu("Loxodon/Localization/LocalizationSource")]
	[DefaultExecutionOrder(-100)]
	public class LocalizationSourceBehaviour : MonoBehaviour
	{
		protected class MultilingualSourceDataProvider : IDataProvider
		{
			private static readonly ILog log = LogManager.GetLogger(typeof(MultilingualSourceDataProvider));

			protected string name;

			protected MultilingualSource source;

			public MultilingualSourceDataProvider(MultilingualSource source)
				: this("", source)
			{
			}

			public MultilingualSourceDataProvider(string name, MultilingualSource source)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				this.name = name;
				this.source = source;
			}

			public virtual Task<Dictionary<string, object>> Load(CultureInfo cultureInfo)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				try
				{
					if (source.Languages == null || source.Entries == null || source.Languages.Count <= 0 || source.Entries.Count <= 0)
					{
						return Task.FromResult(dictionary);
					}
					List<string> languages = source.Languages;
					List<MultilingualEntry> entries = source.Entries;
					string item = "default";
					string twoLetterISOLanguageName = cultureInfo.TwoLetterISOLanguageName;
					string item2 = cultureInfo.Name;
					if (!languages.Contains(item))
					{
						item = languages[0];
					}
					int num = languages.IndexOf(item);
					if (num >= 0)
					{
						FillData(dictionary, entries, num);
					}
					int num2 = languages.IndexOf(twoLetterISOLanguageName);
					if (num2 >= 0 && num2 != num)
					{
						FillData(dictionary, entries, num2);
					}
					int num3 = languages.IndexOf(item2);
					if (num3 >= 0 && num3 != num && num3 != num2)
					{
						FillData(dictionary, entries, num3);
					}
					return Task.FromResult(dictionary);
				}
				catch (Exception ex)
				{
					if (log.IsWarnEnabled)
					{
						log.WarnFormat("An error occurred when loading localized data from LocalizationSource \"{0}\".Error:{1}", name, ex);
					}
					return Task.FromException<Dictionary<string, object>>(ex);
				}
			}

			private void FillData(Dictionary<string, object> dict, List<MultilingualEntry> entries, int index)
			{
				try
				{
					foreach (MultilingualEntry entry in entries)
					{
						string key = entry.Key;
						object value = entry.GetValue(index);
						if (!string.IsNullOrEmpty(key) && value != null)
						{
							dict[key] = value;
						}
					}
				}
				catch (Exception ex)
				{
					if (log.IsWarnEnabled)
					{
						log.WarnFormat("An error occurred when loading localized data from LocalizationSource \"{0}\".Error:{1}", name, ex);
					}
				}
			}
		}

		[SerializeField]
		public MultilingualSource Source = new MultilingualSource();

		[NonSerialized]
		protected MultilingualSourceDataProvider provider;

		protected virtual async void OnEnable()
		{
			if (provider == null)
			{
				provider = new MultilingualSourceDataProvider(base.name, Source);
			}
			await Localization.Current.AddDataProvider(provider);
		}

		protected virtual void OnDisable()
		{
			if (provider != null)
			{
				Localization.Current.RemoveDataProvider(provider);
			}
		}
	}
}
