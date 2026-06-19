using System.Collections.Generic;
using NaughtyAttributes;
using Pug.UnityExtensions;

public class ContentBundleDataBlock : ScriptableDataBlock
{
	public WorldCreationVersion createdForVersion = WorldCreationVersion.Ck121;

	public bool canBeActivatedByPlayer;

	[ShowIf("canBeActivatedByPlayer")]
	public int displayOrder;

	public bool automaticallyAddedToNewWorlds;

	public OptionalValue<string> enabledIfSeedContainsString;

	public List<DataBlockRef<ContentBundleDataBlock>> dependencies = new List<DataBlockRef<ContentBundleDataBlock>>();

	public static string GetBundleName(DataBlockAddress address)
	{
		if (ScriptableData.TryGetDataBlock<ContentBundleDataBlock>(address, out var dataBlock))
		{
			return dataBlock.name;
		}
		return $"UNKNOWN ({address})";
	}

	public static bool TryMapLegacyIDToDataBlockAddress(int id, out DataBlockAddress address)
	{
		address = id switch
		{
			0 => new DataBlockAddress("7507d88e-fd7a-7444-1b18-3816c6fbe382"), 
			1 => new DataBlockAddress("46418d34-550b-7504-7970-e202973b089b"), 
			2 => new DataBlockAddress("9632a455-aae3-4834-7a55-9d28b41f78e5"), 
			3 => new DataBlockAddress("df146c28-3ed5-5444-8a01-c0be1a1ec301"), 
			4 => new DataBlockAddress("b654232e-1ae7-0374-1bf2-f4a27ccd4e24"), 
			5 => new DataBlockAddress("c97f6929-9c21-1e14-28ef-db95d65ec989"), 
			6 => new DataBlockAddress("3f08abc0-eb8c-4cf4-b9b2-93d07247fcc7"), 
			7 => new DataBlockAddress("a4769d9e-aff8-c364-1818-4cc06acdeba0"), 
			9 => new DataBlockAddress("51840c7b-e20d-81c4-d95d-570d76c15cd7"), 
			10 => new DataBlockAddress("127afcf8-2687-9694-da13-4a0991b9d603"), 
			11 => new DataBlockAddress("c82d3432-9bd3-b104-dbd7-275b359afe13"), 
			12 => new DataBlockAddress("f28d7290-e168-9284-ab58-cc612916e7b8"), 
			13 => new DataBlockAddress("eea6c65c-f08e-6c54-f848-7cc3b481a21d"), 
			14 => new DataBlockAddress("357161fa-69fd-4814-886f-29c59a6a7087"), 
			15 => new DataBlockAddress("3ca34a75-d6e6-0ae4-ba9b-dae8fc6e8136"), 
			_ => DataBlockAddress.Empty, 
		};
		return address != DataBlockAddress.Empty;
	}
}
