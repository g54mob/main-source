using Models;

namespace Factory.FieldData
{
	public class Belt
	{
		internal readonly FactoryMap factoryMap;

		private Structure[] _belStructures;

		private double mechSpeed;

		public Belt(FactoryMap factoryMap)
		{
		}

		public void UpdateCircuitData(bool updateAttachment = false, bool recalcStream = false)
		{
		}

		private Structure GetStructure(StructureAddr a)
		{
			return null;
		}

		public void Update(double deltaSpeedParTile)
		{
		}
	}
}
