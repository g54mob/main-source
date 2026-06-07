namespace Febucci.TextAnimatorCore
{
	public interface IEffectCurve
	{
		int BakeResolution { get; }

		float Evaluate01(float time);

		float EvaluateRange(float time);

		void Initialize();
	}
}
