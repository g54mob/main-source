using System;
using System.Collections.Generic;
using UnityEngine;

namespace Febucci.UI.Styles
{
	[Serializable]
	[CreateAssetMenu(fileName = "TextAnimator StyleSheet", menuName = "Text Animator/StyleSheet", order = 100)]
	public class StyleSheetScriptable : ScriptableObject
	{
		[SerializeField]
		private Style[] styles = Array.Empty<Style>();

		private bool built;

		private Dictionary<string, Style> dictionary;

		public Style[] Styles
		{
			get
			{
				return styles;
			}
			set
			{
				styles = value;
				built = false;
			}
		}

		public void BuildOnce()
		{
			if (built)
			{
				return;
			}
			built = true;
			if (dictionary != null)
			{
				dictionary.Clear();
			}
			else
			{
				dictionary = new Dictionary<string, Style>();
			}
			if (styles == null)
			{
				return;
			}
			Style[] array = styles;
			for (int i = 0; i < array.Length; i++)
			{
				Style value = array[i];
				string text = value.styleTag.ToLowerInvariant();
				if (!string.IsNullOrEmpty(text))
				{
					if (dictionary.ContainsKey(text))
					{
						Debug.LogError("[TextAnimator] StyleSheetScriptable: duplicated style tag '" + text, this);
					}
					else
					{
						dictionary.Add(text, value);
					}
				}
			}
		}

		public void ForceBuildRefresh()
		{
			built = false;
			BuildOnce();
		}

		public virtual bool TryGetStyle(string tag, out Style result)
		{
			BuildOnce();
			return dictionary.TryGetValue(tag, out result);
		}
	}
}
