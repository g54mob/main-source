using System;

namespace Coherence;

[Serializable]
public abstract class BaseDefinition(string name)
{
	public int id;

	public string name = name;
}
