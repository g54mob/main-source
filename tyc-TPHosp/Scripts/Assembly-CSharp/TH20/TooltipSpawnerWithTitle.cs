using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TooltipSpawnerWithTitle : TooltipSpawner
	{
		[SerializeField]
		private LocalisedString _titleLocalisedString;

		public TooltipSpawnerWithTitle()
		{
			SetDataProvider(TooltipDataProvider);
		}

		private void TooltipDataProvider(Tooltip tooltip)
		{
			TooltipWithTitle tooltipWithTitle = tooltip as TooltipWithTitle;
			if (tooltipWithTitle != null)
			{
				tooltipWithTitle.Text = base.TooltipLocText;
				tooltipWithTitle.Title.text = _titleLocalisedString.Translation;
			}
		}
	}
}
