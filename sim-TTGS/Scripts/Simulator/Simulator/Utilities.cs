namespace Simulator
{
	public static class Utilities
	{
		public static int Mod(int a, int b)
		{
			return (a % b + b) % b;
		}
	}
}
