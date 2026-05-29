public abstract class ScaleController
{
	protected readonly Scale m_Scale;

	public virtual void OnAdded()
	{
	}

	public virtual void OnRemoved()
	{
	}

	public ScaleController(Scale scale)
	{
	}

	public abstract void OnStateIdle();

	public abstract void OnStateControl();

	public abstract void OnStateBarcode();

	public abstract void OnStatePlacement();

	public virtual void OnStateChanged()
	{
	}
}
