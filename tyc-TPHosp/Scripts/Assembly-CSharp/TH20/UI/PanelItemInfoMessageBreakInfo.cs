using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PanelItemInfoMessageBreakInfo : PanelItemInfoMessageStaffBreak
	{
		[SerializeField]
		[FormerlySerializedAs("_messageSourceSpecific")]
		private InfoMessageSourceBreakInfo _messageSource;

		public override InfoMessageSource MessageSource => _messageSource;
	}
}
