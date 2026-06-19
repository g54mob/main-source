using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

public struct ModInfoRPC : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public long modId;

	public Hash128 modGuid;

	public FixedString32Bytes modName;

	public bool required;

	public bool lastMod;
}
