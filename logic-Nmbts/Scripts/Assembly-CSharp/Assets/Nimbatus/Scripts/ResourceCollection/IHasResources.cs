namespace Assets.Nimbatus.Scripts.ResourceCollection
{
	public interface IHasResources
	{
		float GetRechargePerSecond(EResourceType resourceType);

		float GetResourceCapacity(EResourceType resourceType);

		float GetResourceAmount(EResourceType resourceType);

		void SetResourceAmount(EResourceType resourceType, float value);

		void ChangeResourceHub(ResourceHub oldHub, ResourceHub newHub);
	}
}
