using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class DecayModifiersRepository : DynamicJsonRepository<DecayModifiersRepository, DecayModifiers>
	{
		protected override string JsonFile()
		{
			return "Resources/DecayModifiers.json";
		}
	}
}
