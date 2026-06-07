namespace ParadoxNotion.Design
{
	public class RequiredFieldAttribute : DrawerAttribute
	{
		public override bool isDecorator => false;

		public override int priority => 0;
	}
}
