using I2.Loc;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	public class DynamoEffect : DroneEffect
	{
		public float MinSpeed;

		public float Enhancement;

		public override EEffectType EffectType
		{
			get
			{
				return EEffectType.Dynamo;
			}
		}

		public override string GetDescription()
		{
			string translation = base.GetDescription();
			LocalizationManager.ApplyLocalizationParams(ref translation, "Speed", MinSpeed.ToString("F0"));
			return translation;
		}
	}
}
