namespace tripolygon.UModeler
{
	public class UModelerMigrator
	{
		public static UModelerMigrationData UModelerMigration(UModeler modeler)
		{
			if (modeler != null)
			{
				using (new ActiveModelerHolder(modeler))
				{
					return new UModelerMigrationData(modeler);
				}
			}
			return null;
		}
	}
}
