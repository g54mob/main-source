using UnityEngine;

public class StaterPropDelegate : StaterProp
{
	public delegate StaterVariant Get();

	public delegate void Set(StaterVariant v);

	private Set set_;

	private Get get_;

	public override StaterVariant val
	{
		get
		{
			return (get_ == null) ? ((StaterVariant)Vector4.zero) : get_();
		}
		set
		{
			if (set_ != null)
			{
				set_(value);
			}
		}
	}

	public StaterPropDelegate(Set set__, Get get__)
	{
		set_ = set__;
		get_ = get__;
	}
}
