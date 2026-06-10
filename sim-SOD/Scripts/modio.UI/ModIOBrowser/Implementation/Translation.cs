using System;
using ModIO.Util;
using TMPro;

namespace ModIOBrowser.Implementation
{
	internal class Translation : ITranslatable
	{
		public string reference;

		public Action<string> set;

		public string[] valueCache;

		private SimpleMessageUnsubscribeToken subscription;

		public string Identifier => null;

		public string TransformPath => null;

		public static void Get(Translation translation, string reference, Action<string> setter, params string[] values)
		{
		}

		public static void Get(Translation translation, string reference, TMP_Text text, params string[] values)
		{
		}

		private Translation(Action<string> set, string reference, params string[] values)
		{
		}

		public string GetReference()
		{
			return null;
		}

		public void MarkAsUntranslated()
		{
		}

		public void SetTranslation(string s)
		{
		}

		public void Clear()
		{
		}
	}
}
