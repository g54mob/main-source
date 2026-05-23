using Data.FactoryFloor.Resources;
using Data.Operator;

public struct ProductionGraphDatabases
{
	public ResourceDatabaseSO ResourceDatabase { get; }

	public FactoryObjectDatabase FactoryObjectDatabase { get; }

	public ProductionGraphDatabases(ResourceDatabaseSO resourceDatabase = null, FactoryObjectDatabase factoryObjectDatabase = null)
	{
		ResourceDatabase = resourceDatabase;
		FactoryObjectDatabase = factoryObjectDatabase;
	}
}
