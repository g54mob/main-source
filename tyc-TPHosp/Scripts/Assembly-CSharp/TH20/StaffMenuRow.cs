using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffMenuRow : StaffMenuRowBase
	{
		[Header("Status")]
		[SerializeField]
		private Image StatusIcon;

		[SerializeField]
		private TooltipSpawner StatusIconTooltip;

		[Header("Happiness")]
		[SerializeField]
		private ProgressBarMaskable _happinessProgressBar;

		[SerializeField]
		private TooltipSpawner _happinessTooltip;

		[Header("Energy")]
		[SerializeField]
		private ProgressBarMaskable _energyProgressBar;

		[SerializeField]
		private TooltipSpawner _energyTooltip;

		public override void Setup(Staff staff, List<JobDescription> jobs, StaffMenu staffMenu)
		{
			base.Setup(staff, jobs, staffMenu);
			if (staff != null)
			{
				if (StatusIconTooltip != null)
				{
					StatusIconTooltip.SetDataProvider(delegate(Tooltip tooltip)
					{
						tooltip.Text = base.Staff.GetStatusText();
					});
				}
				if (_happinessTooltip != null)
				{
					_happinessTooltip.SetDataProvider(delegate(Tooltip tooltip)
					{
						tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_Happiness_CS, StringUtils.FormatPercentageValue((base.Staff.Happiness != null) ? (base.Staff.Happiness.Value() / 100f) : 0f));
					});
				}
				if (_energyTooltip != null)
				{
					_energyTooltip.SetDataProvider(delegate(Tooltip tooltip)
					{
						tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_Energy_CS, StringUtils.FormatPercentageValue((base.Staff.Energy != null) ? (base.Staff.Energy.Value() / 100f) : 0f));
					});
				}
			}
			else
			{
				if (StatusIconTooltip != null)
				{
					StatusIconTooltip.SetDataProvider(null);
				}
				if (_happinessTooltip != null)
				{
					_happinessTooltip.SetDataProvider(null);
				}
				if (_energyTooltip != null)
				{
					_energyTooltip.SetDataProvider(null);
				}
			}
			Refresh();
		}

		public override void Refresh(bool instant = false)
		{
			base.Refresh(instant);
			Sprite sprite = base.Staff?.GetStatusSprite();
			if (sprite == null)
			{
				StatusIcon.transform.localScale = Vector3.zero;
			}
			else
			{
				StatusIcon.transform.localScale = Vector3.one;
				StatusIcon.sprite = sprite;
			}
			if (base.Staff != null)
			{
				if (instant)
				{
					_happinessProgressBar.Progress = ((base.Staff.Happiness != null) ? (base.Staff.Happiness.Value() / 100f) : 0f);
					_energyProgressBar.Progress = base.Staff.Energy.Value() / 100f;
				}
				else
				{
					_happinessProgressBar.SetProgressSmooth((base.Staff.Happiness != null) ? (base.Staff.Happiness.Value() / 100f) : 0f);
					_energyProgressBar.SetProgressSmooth(base.Staff.Energy.Value() / 100f);
				}
			}
		}
	}
}
