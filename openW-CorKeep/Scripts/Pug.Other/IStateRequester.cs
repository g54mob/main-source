using Unity.Entities;

public interface IStateRequester
{
	bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c);

	void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo);
}
