public struct ReinforcementRequest
{
	public string _property;

	public float _oldPercentage;

	public float _newPercentage;

	public ReinforcementRequest(string property, float oldPercentage, float newPercentage)
	{
		_property = property;
		_oldPercentage = oldPercentage;
		_newPercentage = newPercentage;
	}
}
