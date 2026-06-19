using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlatformElementIdentifierBlacklist
{
	[field: SerializeField]
	public PlatformFlags Platform { get; private set; }

	[field: SerializeField]
	public List<int> ElementIdentifierIds { get; private set; }

	[field: SerializeField]
	public List<string> ElementIdentifierNames { get; private set; }
}
