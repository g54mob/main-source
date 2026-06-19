using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PanelItemInfoMessageLongQueue : PanelItemInfoMessage
	{
		[SerializeField]
		[FormerlySerializedAs("_messageSourceSpecific")]
		private InfoMessageSourceLongQueue _messageSource;

		public override InfoMessageSource MessageSource => _messageSource;
	}
}
