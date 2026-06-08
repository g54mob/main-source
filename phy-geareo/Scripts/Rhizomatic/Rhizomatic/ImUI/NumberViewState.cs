namespace Rhizomatic.ImUI
{
	public class NumberViewState : ImUIViewState
	{
		public float floatNumber;

		public int intNumber;

		public bool isInt;

		public float number => 0f;

		public NumberViewState(int number)
		{
		}

		public NumberViewState(float number)
		{
		}
	}
}
