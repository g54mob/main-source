using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Loxodon.Log;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	public class DefaultDataProvider : IDataProvider
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(DefaultDataProvider));

		private string root;

		private IDocumentParser parser;

		public DefaultDataProvider(string root)
			: this(root, new XmlDocumentParser())
		{
		}

		public DefaultDataProvider(string root, IDocumentParser parser)
		{
			if (string.IsNullOrEmpty(root))
			{
				throw new ArgumentNullException("root");
			}
			if (parser == null)
			{
				throw new ArgumentNullException("parser");
			}
			this.root = root;
			this.parser = parser;
		}

		protected string GetDefaultPath()
		{
			return GetPath("default");
		}

		protected string GetPath(string dir)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(root);
			if (!root.EndsWith("/"))
			{
				stringBuilder.Append("/");
			}
			stringBuilder.Append(dir);
			return stringBuilder.ToString();
		}

		public virtual Task<Dictionary<string, object>> Load(CultureInfo cultureInfo)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			try
			{
				TextAsset[] texts = Resources.LoadAll<TextAsset>(GetDefaultPath());
				TextAsset[] texts2 = Resources.LoadAll<TextAsset>(GetPath(cultureInfo.TwoLetterISOLanguageName));
				TextAsset[] texts3 = (cultureInfo.Name.Equals(cultureInfo.TwoLetterISOLanguageName) ? null : Resources.LoadAll<TextAsset>(GetPath(cultureInfo.Name)));
				FillData(dictionary, texts, cultureInfo);
				FillData(dictionary, texts2, cultureInfo);
				FillData(dictionary, texts3, cultureInfo);
				return Task.FromResult(dictionary);
			}
			catch (Exception exception)
			{
				return Task.FromException<Dictionary<string, object>>(exception);
			}
		}

		private void FillData(Dictionary<string, object> dict, TextAsset[] texts, CultureInfo cultureInfo)
		{
			try
			{
				if (texts == null || texts.Length == 0)
				{
					return;
				}
				foreach (TextAsset textAsset in texts)
				{
					try
					{
						using MemoryStream input = new MemoryStream(textAsset.bytes);
						foreach (KeyValuePair<string, object> item in parser.Parse(input, cultureInfo))
						{
							dict[item.Key] = item.Value;
						}
					}
					catch (Exception ex)
					{
						if (log.IsWarnEnabled)
						{
							log.WarnFormat("An error occurred when loading localized data from \"{0}\".Error:{1}", textAsset.name, ex);
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
