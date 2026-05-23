using System;

public class PrepSceneAttribute : Attribute
{
	public int order;

	public PrepSceneAttribute()
	{
	}

	public PrepSceneAttribute(int order_)
	{
		order = order_;
	}
}
