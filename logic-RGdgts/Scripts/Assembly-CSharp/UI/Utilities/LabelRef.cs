using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace UI.Utilities
{
	[Serializable]
	public struct LabelRef
	{
		public TextMeshProUGUI tmPro;

		public RetroUIText retroText;

		public Dictionary<TextAlignmentOptions, LabelRefTextAlignement> aDic;

		public TextComponentType textType => default(TextComponentType);

		public string text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Color color
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public TMP_FontAsset font
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsNull()
		{
			return false;
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public void SetActive(bool active)
		{
		}

		public RectTransform GetRectTransform()
		{
			return null;
		}

		public LocalizeStringEvent GetLocalizedStringEvent()
		{
			return null;
		}

		public void SetLocalization(string tableRef, string entryRef)
		{
		}

		public void SetADictionary()
		{
		}

		public LabelRefTextAlignement GetTextAlignment()
		{
			return null;
		}
	}
}
