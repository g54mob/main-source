using System.Linq;
using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Almanac
{
	public class LinkRepository : DynamicJsonRepository<LinkRepository, Links>
	{
		protected override string JsonFile()
		{
			return "Almanac/Links.json";
		}

		public string GetLinkIdByKey(string key)
		{
			if (string.IsNullOrEmpty(key) || repository == null)
			{
				return string.Empty;
			}
			Links first = GetFirst((Links l) => l.LinkKeys.Contains(key));
			if (!(first == null))
			{
				return first.GetID();
			}
			return string.Empty;
		}
	}
}
