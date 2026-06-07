using DV.Interaction;
using DV.Utils;
using UnityEngine;

public class IgnitableUse : MonoBehaviour, IItemUseAnimated, IItemUse, IInteractionPointProvider
{
	protected IIgnitable ignitable;

	[SerializeField]
	protected bool allowClickIgniteOther = true;

	[SerializeField]
	protected bool allowClickIgniteSelf = true;

	public Transform InteractionPoint => ignitable?.InteractionPoint;

	private void Awake()
	{
		ignitable = GetComponent<IIgnitable>();
		if (ignitable == null)
		{
			Debug.LogError("'IgnitableUse' requires a valid 'IIgnitable' reference. Destroying self", base.gameObject);
			Object.Destroy(this);
		}
	}

	public virtual bool HandleUse(ItemUseTarget target)
	{
		IIgnitable ignitable = ((target != null) ? target.GetComponentInParent<IIgnitable>() : null);
		if (ignitable == null)
		{
			return false;
		}
		if (this.ignitable.Ignited == ignitable.Ignited)
		{
			return false;
		}
		bool num = this.ignitable.Ignited && ignitable.IgnitionAllowed && allowClickIgniteOther;
		bool flag = ignitable.Ignited && this.ignitable.IgnitionAllowed && allowClickIgniteSelf;
		if (num && ignitable.Ignite(1f))
		{
			return true;
		}
		if (flag)
		{
			return this.ignitable.Ignite(1f);
		}
		return false;
	}

	public bool IsHoverCompatible(ItemUseTarget target)
	{
		return IsUseCompatible(target);
	}

	public virtual bool IsUseCompatible(ItemUseTarget target)
	{
		IIgnitable ignitable = ((target != null) ? target.GetComponentInParent<IIgnitable>() : null);
		if (ignitable == null || this.ignitable.Ignited == ignitable.Ignited)
		{
			return false;
		}
		bool num = this.ignitable.Ignited && ignitable.IgnitionAllowed && allowClickIgniteOther;
		bool flag = ignitable.Ignited && this.ignitable.IgnitionAllowed && allowClickIgniteSelf;
		return num || flag;
	}

	public virtual bool HandleHover(ItemUseTarget target)
	{
		if (VRManager.IsVREnabled())
		{
			return false;
		}
		SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.Ignite);
		return true;
	}

	public (Vector3 pos, Quaternion rot) TargetPoint(ItemUseTarget target)
	{
		IIgnitable ignitable = ((target != null) ? target.GetComponentInParent<IIgnitable>() : null);
		if (ignitable != null)
		{
			return (pos: ignitable.InteractionPoint.position, rot: ignitable.InteractionPoint.rotation);
		}
		return default((Vector3, Quaternion));
	}
}
