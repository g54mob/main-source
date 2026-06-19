using Unity.Entities;
using Unity.NetCode;

public struct RevealWholeMapProgressUpdate : IRpcCommand, IComponentData, IQueryTypeParameter
{
	public int SubmapsUpdated;

	public int TotalSubMapsToUpdate;
}
