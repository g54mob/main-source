namespace ParadoxNotion.Design
{
	public class HeaderAttribute : DrawerAttribute
	{
		public readonly string title;

		public override bool isDecorator => false;

		public HeaderAttribute(string title)
		{
		}
	}
}
