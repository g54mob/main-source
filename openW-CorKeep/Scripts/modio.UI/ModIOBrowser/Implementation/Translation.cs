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

		public string Identifier => "TranslationUpdateable for: " + reference;

		public string TransformPath => "N/A memory object";

		public static void Get(Translation translation, string reference, Action<string> setter, params string[] values)
		{
			translation?.Clear();
			translation = new Translation(setter, reference, values);
		}

		public static void Get(Translation translation, string reference, TMP_Text text, params string[] values)
		{
			translation = new Translation(delegate(string s)
			{
				text.text = s;
			}, reference, values);
		}

		private Translation(Action<string> set, string reference, params string[] values)
		{
			Translation translation = this;
			this.set = set;
			this.reference = reference;
			valueCache = values;
			this.set(SelfInstancingMonoSingleton<TranslationManager>.Instance.Get(reference, valueCache));
			subscription = SelfInstancingMonoSingleton<SimpleMessageHub>.Instance.Subscribe<MessageUpdateTranslations>(delegate
			{
				set(SelfInstancingMonoSingleton<TranslationManager>.Instance.Get(reference, translation.valueCache));
			});
		}

		public string GetReference()
		{
			return reference;
		}

		public void MarkAsUntranslated()
		{
			set("<color=\"red\">" + reference + "</color>");
		}

		public void SetTranslation(string s)
		{
			set(s);
		}

		public void Clear()
		{
			subscription.Unsubscribe();
		}
	}
}
