namespace ParadoxNotion.Design
{
	public class DimIfDefaultAttribute : DrawerAttribute
	{
		public override bool isDecorator => false;

		public override int priority => 0;
	}
}
