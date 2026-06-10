using System.Collections.Generic;
using System.Linq;
using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class AnimalBaseRepository : DynamicJsonRepository<AnimalBaseRepository, Animal>
	{
		private bool animalsCanBeInPenInit;

		private List<Animal> animalsCanBeInPen;

		public List<Animal> AnimalsCanBeInPen
		{
			get
			{
				if (!animalsCanBeInPenInit)
				{
					animalsCanBeInPenInit = true;
					animalsCanBeInPen = new List<Animal>();
					IEnumerable<Animal> collection = repository.Where((Animal animal) => animal.CanBeInPen);
					animalsCanBeInPen.AddRange(collection);
				}
				return animalsCanBeInPen;
			}
		}

		protected override string JsonFile()
		{
			return "Animal/AnimalBase.json";
		}
	}
}
