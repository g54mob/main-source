namespace GRP
{
	public class EmptyShape : SimShape
	{
		public override float GetVolume()
		{
			return 0f;
		}

		private void Reset()
		{
		}
	}
}
