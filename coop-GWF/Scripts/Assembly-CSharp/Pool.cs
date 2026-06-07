using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pool
{
	public SlotType slot;

	[TextArea(2, 8)]
	public List<string> items = new List<string>();
}
