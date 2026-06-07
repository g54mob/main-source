namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades
{
	public class EnumAttributeUpgrade<T> : AttributeUpgrade
	{
		public T Value;

		public override string GetToolTip()
		{
			return "";
		}
	}
}
