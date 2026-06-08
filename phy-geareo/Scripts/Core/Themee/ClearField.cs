namespace Themee
{
	public class ClearField : Field
	{
		public override bool clear => false;

		public override object GetValue()
		{
			return null;
		}
	}
}
