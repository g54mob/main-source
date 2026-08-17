namespace VampireSurvivors.Framework.Platforms;

public class PlatformAuthToken
{
	private string _003CToken_003Ek__BackingField;

	private string _003CSignature_003Ek__BackingField;

	private int _003CIssuerId_003Ek__BackingField;

	public string Token
	{
		get
		{
			return _003CToken_003Ek__BackingField;
		}
		set
		{
			_003CToken_003Ek__BackingField = value;
		}
	}

	public string Signature
	{
		get
		{
			return _003CSignature_003Ek__BackingField;
		}
		set
		{
			_003CSignature_003Ek__BackingField = value;
		}
	}

	public int IssuerId
	{
		get
		{
			return _003CIssuerId_003Ek__BackingField;
		}
		set
		{
			_003CIssuerId_003Ek__BackingField = value;
		}
	}
}
