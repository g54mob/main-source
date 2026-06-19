public class Hunger : NeedBase
{
	private float _maxValue = 1f;

	private float _minValue;

	private float _decayValue = -0.0018f;

	private float _maxDecayValue = -0.001f;

	private float _idealValue = 1f;

	private float _startValue = 1f;

	protected override float startValue => _startValue;

	protected override float maxValue => _maxValue;

	protected override float minValue => _minValue;

	protected override float decayValue => MathUtil.GetValueOfRangePercentage(brainRef.GetAncientPercentage(), _decayValue, _maxDecayValue);

	protected override float idealValue => _idealValue;

	public bool IsMaxValue()
	{
		return currentValue >= _maxValue;
	}

	public override bool DoesValueSolveForNeed(float val)
	{
		return val > 0f;
	}

	public override bool IsValuePositiveForNeed(float val)
	{
		return val < 0f;
	}
}
