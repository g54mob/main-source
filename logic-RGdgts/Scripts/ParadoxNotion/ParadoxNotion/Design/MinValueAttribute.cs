namespace ParadoxNotion.Design
{
	public class MinValueAttribute : DrawerAttribute
	{
		public readonly float min;

		public override int priority => 0;

		public MinValueAttribute(float min)
		{
		}

		public MinValueAttribute(int min)
		{
		}
	}
}
