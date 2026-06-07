public class OverridablePropertyModel : BaseModel
{
	public const string ValueChangeEvent = "OverridablePropertyModel.ValueChangeEvent";

	private string value;

	public BlockBodyModel ParentBlockBodyModel { get; set; }

	public string Key { get; private set; }

	public string Value
	{
		get
		{
			return value;
		}
		set
		{
			this.value = value;
			NotifyChange("OverridablePropertyModel.ValueChangeEvent", this);
		}
	}

	public bool ValueAsBool => bool.Parse(Value);

	public int ValueAsInt => int.Parse(Value);

	public float ValueAsFloat => float.Parse(Value);

	public OverridablePropertyModel(string key, string value)
	{
		Key = key;
		Value = value;
	}
}
