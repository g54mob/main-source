using System;
using System.Runtime.CompilerServices;
using Gh.Tk;
using TMPro;
using UnityEngine;

namespace I18n
{
	public class TextMeshProI18n : TextMeshPro, IDisplaysText, IAutoFontSizeElement, ITextChanged, IRegistersFont
	{
		private const string NOT_SET = "$NOTSET$";

		private string _currentTextKeyString;

		private bool _dirty;

		private string _gender;

		[SerializeField]
		public string ContentOverrideForHash;

		private bool _didInit;

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

		public void RaiseTextChangedEvent()
		{
		}

		public void ForceMeshUpdate()
		{
		}

		protected override void Start()
		{
		}

		public void EnsureInit()
		{
		}

		private void Init()
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

		public FontData GetFontData()
		{
			return null;
		}

		public void ReregisterFontWith(Material material)
		{
		}
	}
}
