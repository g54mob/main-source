public class AsyncRequestHandle
{
	public static readonly AsyncRequestHandle CompletedRequestHandle = new AsyncRequestHandle();

	public bool IsActive { get; private set; } = true;

	public void Cancel()
	{
		IsActive = false;
	}
}
