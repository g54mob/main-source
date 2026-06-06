using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableBaseEnum : ScriptableObject
{
	public abstract List<string> Entries { get; }

	public virtual string Import => string.Empty;
}
