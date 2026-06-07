namespace LitMotion
{
	internal interface IUpdateRunner
	{
		IMotionStorage Storage { get; }

		void Update(double time, double unscaledTime, double realtime);

		void Reset();
	}
}
