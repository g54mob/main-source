namespace Assets.Scripts.Inventory__Items__Pickups.Stats;

public class StatComponents
{
	public bool hasModifications;

	private float _003CbaseValue_003Ek__BackingField;

	private float _003CadditiveValue_003Ek__BackingField;

	private float _003CmultiplicativeValue_003Ek__BackingField;

	public float baseValue
	{
		get
		{
			return _003CbaseValue_003Ek__BackingField;
		}
		private set
		{
			_003CbaseValue_003Ek__BackingField = value;
		}
	}

	public float additiveValue
	{
		get
		{
			return _003CadditiveValue_003Ek__BackingField;
		}
		private set
		{
			_003CadditiveValue_003Ek__BackingField = value;
		}
	}

	public float multiplicativeValue
	{
		get
		{
			return _003CmultiplicativeValue_003Ek__BackingField;
		}
		private set
		{
			_003CmultiplicativeValue_003Ek__BackingField = value;
		}
	}

	public void Recycle()
	{
		_003CmultiplicativeValue_003Ek__BackingField = 1f;
		_003CbaseValue_003Ek__BackingField = 0f;
		hasModifications = false;
	}

	public void SetValues(float baseValues, float additiveValues, float multiplicativeValues)
	{
		_003CbaseValue_003Ek__BackingField = baseValues;
		_003CadditiveValue_003Ek__BackingField = additiveValues;
		_003CmultiplicativeValue_003Ek__BackingField = multiplicativeValues;
	}

	public float GetFinalValue(StatComponents other)
	{
		float num = _003CadditiveValue_003Ek__BackingField + other._003CadditiveValue_003Ek__BackingField;
		float num2 = _003CbaseValue_003Ek__BackingField + other._003CbaseValue_003Ek__BackingField;
		float num3 = _003CmultiplicativeValue_003Ek__BackingField * other._003CmultiplicativeValue_003Ek__BackingField;
		float num4 = num * num2;
		return num4 * num3;
	}

	public void AddMultiplier(float value)
	{
		float num = value * _003CmultiplicativeValue_003Ek__BackingField;
		hasModifications = true;
		_003CmultiplicativeValue_003Ek__BackingField = num;
	}

	public void AddAdditive(float value)
	{
		float num = value + _003CadditiveValue_003Ek__BackingField;
		hasModifications = true;
		_003CadditiveValue_003Ek__BackingField = num;
	}

	public void AddFlat(float value)
	{
		float num = value + _003CbaseValue_003Ek__BackingField;
		hasModifications = true;
		_003CbaseValue_003Ek__BackingField = num;
	}
}
