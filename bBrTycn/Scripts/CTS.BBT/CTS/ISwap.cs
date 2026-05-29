namespace CTS
{
	public interface ISwap
	{
		void SwapByPercent(float percent);

		float GetCurrentPercent();

		float GetStartPercent();
	}
}
