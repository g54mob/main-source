using Unity.Entities;

public struct CustomSceneTableCD : IComponentData, IQueryTypeParameter
{
	public BlobAssetReference<CustomSceneTableBlob> Value;
}
