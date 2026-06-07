using Assets.Nimbatus.Scripts.WorldObjects;

namespace Assets.Nimbatus.Scripts.Behaviours.Health
{
	public struct DamageInformation
	{
		public EDamageReason Reason;

		public NimbatusObject DamageSourceObject;

		public float DamageAmount;

		public DamageInformation(float amount, EDamageReason reason, NimbatusObject source = null)
		{
			DamageAmount = amount;
			Reason = reason;
			DamageSourceObject = source;
		}
	}
}
