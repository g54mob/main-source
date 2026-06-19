using JetBrains.Annotations;
using TMPro;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TooltipQualification : Tooltip
	{
		public TMP_Text Description;

		public TMP_Text Info;

		public ProgressBar ProgressBar;
	}
}
