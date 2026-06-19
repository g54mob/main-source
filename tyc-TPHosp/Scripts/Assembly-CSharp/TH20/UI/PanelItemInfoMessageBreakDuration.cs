using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PanelItemInfoMessageBreakDuration : PanelItemInfoMessageStaffBreak
	{
		[SerializeField]
		[FormerlySerializedAs("_messageSourceSpecific")]
		private InfoMessageSourceBreakDuration _messageSource;

		public override InfoMessageSource MessageSource => _messageSource;
	}
}
