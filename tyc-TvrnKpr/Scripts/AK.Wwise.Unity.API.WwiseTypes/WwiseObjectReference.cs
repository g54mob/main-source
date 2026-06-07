using System;
using UnityEngine;

public abstract class WwiseObjectReference : ScriptableObject
{
	[AkShowOnly]
	[SerializeField]
	private string objectName;

	[AkShowOnly]
	[SerializeField]
	private uint id;

	[AkShowOnly]
	[SerializeField]
	private string guid;

	public Guid Guid => default(Guid);

	public string ObjectName => null;

	public virtual string DisplayName => null;

	public uint Id => 0u;

	public abstract WwiseObjectType WwiseObjectType { get; }
}
