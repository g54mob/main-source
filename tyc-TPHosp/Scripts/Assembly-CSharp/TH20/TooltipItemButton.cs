using JetBrains.Annotations;
using TMPro;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TooltipItemButton : Tooltip
	{
		public TMP_Text StaffRequired;

		public TMP_Text Description;

		public TMP_Text FunctionalDescription;

		public TMP_Text CurrentCount;

		public TMP_Text UGC;
	}
}
