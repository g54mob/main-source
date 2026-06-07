namespace LitMotion
{
	public interface IMotionAdapter<TValue, TOptions> where TValue : unmanaged where TOptions : unmanaged, IMotionOptions
	{
		TValue Evaluate(ref TValue startValue, ref TValue endValue, ref TOptions options, in MotionEvaluationContext context);
	}
}
