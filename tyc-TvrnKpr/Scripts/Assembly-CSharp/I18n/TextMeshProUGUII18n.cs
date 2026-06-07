using System;
using System.Runtime.CompilerServices;
using Gh.Tk;
using TMPro;
using UnityEngine;

namespace I18n
{
	public class TextMeshProUGUII18n : TextMeshProUGUI, IDisplaysText, IAutoFontSizeElement, ITextChanged, IRegistersFont
	{
		private const string NOT_SET = "$NOTSET$";

		private string _currentTextKeyString;

		private bool _dirty;

		private string _gender;

		[SerializeField]
		public string ContentOverrideForHash;

		public TextStyleId textStyleId;

		private int _fontIndex;

		public bool EnableAutoSizing
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float FontSize
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float FontSizeWithoutScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MaxFontSizeWithoutScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int FontIndex => 0;

		public event EventHandler TextChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void OnEnable()
		{
		}

		public void DisplayText(string keyString, string gender = "male")
		{
		}

		public string GetCurrentTextKeyString()
		{
			return null;
		}

		protected override void Start()
		{
		}

		private void UpdateText()
		{
		}

		private void OnLanguageChanged(object sender, EventArgs e)
		{
		}

		protected override void OnDestroy()
		{
		}

		public void RaiseTextChangedEvent()
		{
		}

		public void ForceMeshUpdate()
		{
		}

		public FontData GetFontData()
		{
			return null;
		}

		public void ReregisterFontWith(Material material)
		{
		}
	}
}
