public class Anger : NeedBase
{
	private float _maxValue = 1f;

	private float _minValue;

	private float _decayValue = 0.0005f;

	private float _idealValue = 1f;

	private float _startValue = 1f;

	protected override float startValue => _startValue;

	protected override float maxValue => _maxValue;

	protected override float minValue => _minValue;

	protected override float decayValue => _decayValue;

	protected override float idealValue => _idealValue;

	public override bool DoesValueSolveForNeed(float val)
	{
		return val > 0f;
	}

	public override bool IsValuePositiveForNeed(float val)
	{
		return val < 0f;
	}
}
