public class Energy : NeedBase
{
	private float _maxValue = 1f;

	private float _minValue;

	private float _decayValue = -0.0017f;

	private float _maxDecayValue = -0.0034f;

	private float _idealValue = 1f;

	private float _startValue = 1f;

	protected override float startValue => _startValue;

	protected override float maxValue => _maxValue;

	protected override float minValue => _minValue;

	protected override float decayValue => 0f - MathUtil.GetValueOfRangePercentage(brainRef.GetAncientPercentage(), 0f - _decayValue, 0f - _maxDecayValue);

	protected override float idealValue => _idealValue;

	public override bool DoesValueSolveForNeed(float val)
	{
		return val > 0f;
	}

	public override bool IsValuePositiveForNeed(float val)
	{
		return val > 0f;
	}
}
