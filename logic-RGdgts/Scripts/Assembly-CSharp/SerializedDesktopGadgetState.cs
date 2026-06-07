using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SerializedDesktopGadgetState
{
	public DateTime lastViewDate;

	public List<Vector2> motherboardPositions;

	public Dictionary<ModuleId, ModuleId> connections;

	public SerializedDesktopGadgetState()
	{
	}

	public SerializedDesktopGadgetState(Gadget gadget)
	{
	}

	public void Apply(Gadget gadget, Sequence sequence = null)
	{
	}
}
