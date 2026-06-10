using NSMedieval.Model;

namespace NSMedieval.UI
{
	public class TraderStockResource
	{
		public Animal Animal { get; }

		public Resource Resource { get; }

		public bool IsPrisoner { get; }

		public string PrisonerFactionId { get; private set; }

		public override string ToString()
		{
			if (Animal != null)
			{
				return Animal.GetID() + " : Animal";
			}
			if (Resource != null)
			{
				return Resource.GetID() + " : Resource";
			}
			return "Empty";
		}

		public TraderStockResource(Animal animal)
		{
			Animal = animal;
			Resource = null;
		}

		public TraderStockResource(Resource resource)
		{
			Animal = null;
			Resource = resource;
		}

		public TraderStockResource(string prisonerFactionId)
		{
			PrisonerFactionId = prisonerFactionId;
			IsPrisoner = true;
		}
	}
}
