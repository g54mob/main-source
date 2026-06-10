using NSEipix.Repository;

namespace NSMedieval.StatsSystem
{
	public class AttributeRepository : DynamicJsonRepository<AttributeRepository, Attribute>
	{
		protected override string JsonFile()
		{
			return "StatsSystem/Attributes.json";
		}

		public Attribute GetByType(AttributeType attributeType)
		{
			return GetFirst((Attribute item) => item.Type.Equals(attributeType));
		}
	}
}
