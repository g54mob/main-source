public interface IRecyclableObject
{
	string ObjectTypeId { get; set; }

	void OnInstantiation();

	void OnUnistantiation();
}
