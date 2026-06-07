namespace Assets.Nimbatus.Scripts.ResourceCollection
{
	public interface IHasResourceHub
	{
		ResourceHub ResourceHub { get; }

		void ChangeParentHub(ResourceHub newParent);
	}
}
