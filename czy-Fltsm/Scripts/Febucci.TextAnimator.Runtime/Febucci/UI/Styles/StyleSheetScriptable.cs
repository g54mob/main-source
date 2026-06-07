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
				if (!string.IsNullOrEmpty(value.styleTag))
				{
					if (dictionary.ContainsKey(value.styleTag))
					{
						Debug.LogError("[TextAnimator] StyleSheetScriptable: duplicated style tag '" + value.styleTag, this);
					}
					else
					{
						dictionary.Add(value.styleTag, value);
					}
				}
			}
		}

		public void ForceBuildRefresh()
		{
			built = false;
			BuildOnce();
		}

		public bool TryGetStyle(string tag, out Style result)
		{
			BuildOnce();
			return dictionary.TryGetValue(tag, out result);
		}
	}
}
