using System;
using System.Runtime.CompilerServices;
using Gh.Tk.UI;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk
{
	public class TextButton3DUIView : Button3DUIView, IDisplaysText, IAutoFontSizeElement, ITextChanged, IRegistersFont
	{
		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private TextBlock3DUIView _richTextBlock;

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

		public void DisplayText(string text, string gender = "male")
		{
		}

		private void RefreshFont()
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

		public FontData GetFontData()
		{
			return null;
		}

		public void ReregisterFontWith(Material material)
		{
		}
	}
}
