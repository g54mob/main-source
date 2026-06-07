using UnityEngine;

public abstract class ABaseNode : MonoBehaviour, IMapElement
{
	[SerializeField]
	protected eMapNodeState state;

	public virtual string GetName()
	{
		return null;
	}

	public virtual void OnElementSelected()
	{
	}
}
