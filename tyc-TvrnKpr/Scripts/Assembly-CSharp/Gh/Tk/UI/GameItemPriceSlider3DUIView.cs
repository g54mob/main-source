using System;
using System.Runtime.CompilerServices;
using TMPro;

namespace Gh.Tk.UI
{
	public class GameItemPriceSlider3DUIView : BaseInteractable3DUIView
	{
		public TextMeshPro headerLabel;

		public TextMeshPro priceLabel;

		public Slider3DUIView sliderElement;

		private IPriceConfigurable _targetItem;

		public IPriceConfigurable TargetItem
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override bool IsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event EventHandler PriceChanged
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

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnSliderElementOnValueChanged(object s, EventArgs e)
		{
		}

		private void Invalidate()
		{
		}
	}
}
