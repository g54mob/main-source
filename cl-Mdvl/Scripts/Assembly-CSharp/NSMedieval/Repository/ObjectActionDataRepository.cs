using NSEipix.Repository;
using NSMedieval.UI;

namespace NSMedieval.Repository
{
	public class ObjectActionDataRepository : DynamicJsonRepository<ObjectActionDataRepository, SelectionInputActionData>
	{
		protected override string JsonFile()
		{
			return "Data/ObjectActionData.json";
		}

		public SelectionInputActionData Cancel()
		{
			return GetByID("cancel");
		}
	}
}
