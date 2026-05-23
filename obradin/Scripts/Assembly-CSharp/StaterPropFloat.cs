public class StaterPropFloat : StaterProp
{
	public float f;

	public override StaterVariant val
	{
		get
		{
			return f;
		}
		set
		{
			f = value.f;
		}
	}

	public StaterPropFloat(float f_ = 0f)
	{
		f = f_;
	}
}
