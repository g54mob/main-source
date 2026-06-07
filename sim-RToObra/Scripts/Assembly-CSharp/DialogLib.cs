using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogLib : ScriptableObject, ISerializationCallbackReceiver
{
	[Serializable]
	public class Page
	{
		public string speakerId;

		public string textId;

		public float startTime;

		public float endTime;

		public string screenplayText
		{
			get
			{
				return Lang.TranslateActionNames(Lang.Get(textId));
			}
		}

		public string captionText
		{
			get
			{
				return Lang.Get("quote_open") + Lang.Get(textId) + Lang.Get("quote_close");
			}
		}

		public string GetCardText(Manifest.Gender gender = Manifest.Gender.None, string customString = "")
		{
			string text = Lang.Get(textId);
			if (customString.HasValue())
			{
				text = text.Replace("[CUSTOMDIALOG]", customString);
			}
			text = Lang.TranslateActionNames(text);
			text = Manifest.ApplyGender(text, gender, gender);
			if (text.Contains("|"))
			{
				text = text.Replace(" |", "|").Replace("| ", "|");
				text = text.Replace("|", "\n<size=18>") + "</size>";
			}
			return text;
		}
	}

	[Serializable]
	public class Spec
	{
		public string id;

		public string audioFilename;

		public float duration;

		public bool alignTop;

		public bool wantWiggle = true;

		public bool wantBlackFramesAfter;

		public List<Page> pages = new List<Page>();

		public bool manualPaging
		{
			get
			{
				return duration == 0f;
			}
		}
	}

	public List<Spec> specs;

	public Dictionary<string, Spec> specsDict;

	public Spec Find(string specId)
	{
		Spec value = null;
		if (!specsDict.TryGetValue(specId, out value))
		{
			Debug.LogWarning("Dialog not found: [" + specId + "]");
		}
		return value;
	}

	public void OnBeforeSerialize()
	{
	}

	public void OnAfterDeserialize()
	{
		specsDict = new Dictionary<string, Spec>();
		foreach (Spec spec in specs)
		{
			specsDict.Add(spec.id, spec);
		}
	}
}
