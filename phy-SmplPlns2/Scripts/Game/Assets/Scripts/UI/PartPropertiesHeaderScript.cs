using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Symmetry;
using Jundroo.Common.Pool;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI
{
	public class PartPropertiesHeaderScript : HeaderScript
	{
		private PartModifierData _modifier;

		private Widget _toggleSymmetry;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_toggleSymmetry = widget.FindWidget("toggle-modifier-symmetry");
		}

		public void SetPartModifier(PartModifierData modifier)
		{
			_modifier = modifier;
			UpdateSymmetryButton();
		}

		private void ToggleSymmetryClicked(Widget widget)
		{
			if (_modifier == null || !_modifier.AllowDisableSymmetry)
			{
				return;
			}
			_modifier.SymmetryDisabled = !_modifier.SymmetryDisabled;
			List<PartModifierData> value;
			using (CollectionPool<List<PartModifierData>, PartModifierData>.Get(out value))
			{
				SymmetryUtility.GetSymmetricModifiers(_modifier, includeCurrentModifier: false, value);
				foreach (PartModifierData item in value)
				{
					item.SymmetryDisabled = _modifier.SymmetryDisabled;
				}
				UpdateSymmetryButton();
				base.Widget.Context.ShowTooltip(null);
			}
		}

		private void UpdateSymmetryButton()
		{
			if (_modifier != null)
			{
				_toggleSymmetry.Visible = _modifier.AllowDisableSymmetry;
				_toggleSymmetry.EnableClass("symmetry-disabled", _modifier.SymmetryDisabled);
			}
			else
			{
				_toggleSymmetry.Visible = false;
			}
		}
	}
}
