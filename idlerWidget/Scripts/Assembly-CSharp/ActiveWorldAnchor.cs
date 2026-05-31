using Assets.Source.World;
using UnityEngine;

public class ActiveWorldAnchor : MonoBehaviour
{
	private WorldAnchor _anchor;

	[field: SerializeField]
	public WorldAnchorType ButtonType { get; private set; } = WorldAnchorType.Uninitialized;

	[field: SerializeField]
	public int Slot { get; private set; }

	public WorldAnchor Anchor
	{
		get
		{
			if (_anchor == null)
			{
				_anchor = new WorldAnchor(ButtonType, Slot);
			}
			return _anchor;
		}
	}

	private void Awake()
	{
		_updateAnchor();
	}

	public void SetAnchor(WorldAnchorType type, int slot)
	{
		ButtonType = type;
		Slot = slot;
		_updateAnchor();
	}

	private void _updateAnchor()
	{
		if (ButtonType != WorldAnchorType.Uninitialized)
		{
			_anchor = null;
			GetComponentInParent<ActiveWorldFrame>().AddWorldAnchor(this);
		}
	}

	public static implicit operator WorldAnchor(ActiveWorldAnchor self)
	{
		return self.Anchor;
	}
}
