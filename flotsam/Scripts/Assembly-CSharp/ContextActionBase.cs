public abstract class ContextActionBase<T> : ActionBase
{
	public T Context { get; protected set; }

	public override bool IsInteractable => Context != null;

	public virtual void SetContext(T context)
	{
		Context = context;
	}

	public virtual void Clear()
	{
		Context = default(T);
	}
}
