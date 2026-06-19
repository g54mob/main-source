using OUSystems.Basics.UI;

public class ObjectTooltipTrigger<T> : HoverListener
{
	private bool Shown;

	private T _object;

	public T Object
	{
		get
		{
			return default(T);
		}
		set
		{
		}
	}

	public override void OnHover()
	{
	}

	public override void OnHoverEnd()
	{
	}

	public void Show()
	{
	}

	public void Hide()
	{
	}
}
