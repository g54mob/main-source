using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/SFX Manager", order = 1106)]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SFXManagerConfig : ScriptableObjectWithID
	{
		[Header("Payment Amounts")]
		public int MinSmallPaymentAmount;

		public int MinMediumPaymentAmount;

		public int MinLargePaymentAmount;
	}
}
