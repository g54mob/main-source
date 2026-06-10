using NSEipix.Model;
using NSEipix.Repository;

namespace NSMedieval.Repository
{
	public class StringRepository : MonoRepository<StringRepository, KeyStringPair>
	{
		public string GetString(string name)
		{
			KeyStringPair byID = GetByID(name);
			if (byID == null || byID.Value == string.Empty)
			{
				return string.Empty;
			}
			return byID.Value;
		}
	}
}
