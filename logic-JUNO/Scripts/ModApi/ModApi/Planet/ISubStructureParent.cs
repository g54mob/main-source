namespace ModApi.Planet
{
	public interface ISubStructureParent
	{
		StructureNodeData StructureNodeData { get; }

		void AddSubStructure(SubStructure subStructure, SubStructure insertBefore);

		void RemoveSubStructure(SubStructure subStructure);
	}
}
