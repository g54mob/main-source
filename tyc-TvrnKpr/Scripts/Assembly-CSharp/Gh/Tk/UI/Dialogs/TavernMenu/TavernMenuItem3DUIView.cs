using System;
using System.Runtime.CompilerServices;
using Gh.Tk.UI.Dialogs.MealDesigner;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.TavernMenu
{
	public abstract class TavernMenuItem3DUIView : BaseInteractable3DUIView
	{
		[SerializeField]
		protected TextMeshProI18n _nameText;

		[SerializeField]
		protected TextMeshProI18n _statusText;

		[SerializeField]
		protected Stars3DUIView _stars;

		[SerializeField]
		protected Button3DUIView _onOffMenuButton;

		[SerializeField]
		protected TextButton3DUIView _deleteButton;

		[SerializeField]
		protected GameItemPriceSlider3DUIView _priceSlider;

		[SerializeField]
		protected PatronGameItemRatingContainer3DUIView _patronRatings;

		[SerializeField]
		protected Transform _modelSlot;

		[SerializeField]
		protected TraitsContainer3DUIView _traitsContainer;

		[SerializeField]
		protected Transform _pawnFillSocket;

		[SerializeField]
		protected GameItemDemand3DUIView _itemDemandVisual;

		protected GameController _gc;

		[SerializeField]
		protected BaseInteractable3DUIView tooltipSource;

		[DropDownChoice(new string[] { "dissolve", "dissolve3box" })]
		public string materialDissolveBankId;

		public event EventHandler SettingsChanged
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

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Slider_PriceChanged(object s, EventArgs e)
		{
		}

		protected virtual void OnPriceChanged()
		{
		}

		protected void RaiseSettingsChanged()
		{
		}

		protected virtual void UpdateRatingInfo()
		{
		}

		public void Invalidate()
		{
		}

		protected void InvalidateTooltips()
		{
		}

		[ContextMenu("UpdateMaterialsForMenuDissolve")]
		protected void UpdateMaterialsForMenuDissolve()
		{
		}

		private void UpdateDissolveMaterials(GameObject obj)
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}
	}
}
