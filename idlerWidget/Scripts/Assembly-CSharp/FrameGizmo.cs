using Assets.Source.World;
using UnityEngine;

public class FrameGizmo : MonoBehaviour
{
	[SerializeField]
	private WorldAnchorType _buttonType;

	[SerializeField]
	private int _slot;

	public WorldAnchor Anchor => new WorldAnchor(_buttonType, _slot);

	private void Awake()
	{
		ActiveWorldAnchor componentInParent = GetComponentInParent<ActiveWorldAnchor>();
		GetComponentInParent<ActiveWorldFrame>()?.AddGizmo(this, componentInParent?.Anchor ?? Anchor);
	}

	public virtual void OnStartGizmo()
	{
	}

	public virtual void OnStopGizmo()
	{
	}

	public virtual void OnClickGizmo(float progress)
	{
	}
}
