using UnityEngine;

public abstract class ISelectableActionBase<T> : SelectionLinkActionBase where T : Object, ISelectable
{
	public T Selectable { get; private set; }

	public override bool IsInteractable => Selectable;

	public override void SetContext(SelectionLink context)
	{
		base.SetContext(context);
		if ((bool)context)
		{
			SetSelectable(context.ReturnSelectable<T>());
		}
	}

	public virtual void SetSelectable(T selectable)
	{
		Selectable = selectable;
	}

	public override void Clear()
	{
		base.Clear();
		Selectable = null;
	}
}
