public class BooleanPropertyModel : OverridablePropertyModel
{
	public BooleanPropertyModel(string key, bool value)
		: base(key, value.ToString())
	{
	}

	public void SetValue(bool value)
	{
		base.Value = value.ToString();
	}
}
