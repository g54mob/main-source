public class EventMenuItem : MenuItem
{
	public ClickEvent itemEvent;

	public override void OnClick()
	{
		if (!(base.transform.localScale.y < 0.2f))
		{
			itemEvent.Invoke();
		}
	}
}
