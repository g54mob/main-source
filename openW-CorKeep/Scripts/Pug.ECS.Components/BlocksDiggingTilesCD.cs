using Unity.Entities;
using Unity.NetCode;
using UnityEngine.Scripting;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public class BlocksDiggingTilesCD : IComponentData, IQueryTypeParameter
{
	[Preserve]
	public BlocksDiggingTilesCD()
	{
	}
}
