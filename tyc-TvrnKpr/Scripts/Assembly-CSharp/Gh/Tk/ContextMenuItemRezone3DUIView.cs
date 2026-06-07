using System;
using System.Runtime.CompilerServices;
using Gh.Tk.UI;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class ContextMenuItemRezone3DUIView : BuyButton3DUIView, IDisplaysText, IAutoFontSizeElement, ITextChanged
	{
		[SerializeField]
		private Transform _icon;

		[SerializeField]
		private TextMeshProI18n _price;

		private int _priceAmount;

		[SerializeField]
		private Color _priceColor;

		[SerializeField]
		private Color _priceCantAffordColor;

		[SerializeField]
		private TextBlock3DUIView _text;

		public override bool CanAfford
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

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

		public Transform GetIconTransform()
		{
			return null;
		}

		public void SetPrice(int price)
		{
		}

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnMoneyChanged(object sender, EventArgs<int> e)
		{
		}

		private void UpdatePriceColor()
		{
		}

		public void SetIcon(string zoneName)
		{
		}

		public void DisplayText(string keyString, string gender = "male")
		{
		}

		public string GetCurrentTextKeyString()
		{
			return null;
		}

		public FontData GetFontData()
		{
			return null;
		}

		public void RaiseTextChangedEvent()
		{
		}

		public void ForceMeshUpdate()
		{
		}
	}
}
