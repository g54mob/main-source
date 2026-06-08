using System.Collections.Generic;
using Timberborn.BlueprintSystem;
using Timberborn.Characters;
using Timberborn.EntitySystem;
using Timberborn.LifeSystem;
using Timberborn.SingletonSystem;
using Timberborn.TemplateInstantiation;
using Timberborn.TemplateSystem;
using UnityEngine;

namespace Timberborn.Beavers
{
	public class BeaverFactory : ILoadableSingleton
	{
		private readonly TemplateService _templateService;

		private readonly EntityService _entityService;

		private readonly LifeService _lifeService;

		private readonly TemplateInstantiator _templateInstantiator;

		private readonly List<IChildhoodInfluenced> _componentsToInfluence = new List<IChildhoodInfluenced>();

		private Blueprint _adultTemplate;

		private Blueprint _childTemplate;

		public BeaverFactory(TemplateService templateService, EntityService entityService, LifeService lifeService, TemplateInstantiator templateInstantiator)
		{
			_templateService = templateService;
			_entityService = entityService;
			_lifeService = lifeService;
			_templateInstantiator = templateInstantiator;
		}

		public void Load()
		{
			_adultTemplate = _templateService.GetSingle<AdultSpec>().Blueprint;
			_childTemplate = _templateService.GetSingle<ChildSpec>().Blueprint;
			_templateInstantiator.CacheInstance(_adultTemplate);
			_templateInstantiator.CacheInstance(_childTemplate);
		}

		public void CreateAdult(Vector3 position, float adulthoodProgress)
		{
			float lifeProgress = _lifeService.AdulthoodProgressToLifeProgress(adulthoodProgress);
			CreateAndInitialize(_adultTemplate, position, lifeProgress);
		}

		public Beaver CreateChild(Vector3 position, float childhoodProgress)
		{
			float lifeProgress = _lifeService.ChildhoodProgressToLifeProgress(childhoodProgress);
			Beaver beaver = CreateAndInitialize(_childTemplate, position, lifeProgress);
			beaver.GetComponent<Child>().FastForwardGrowthProgress(childhoodProgress);
			return beaver;
		}

		public Beaver CreateNewbornAdult(Vector3 position)
		{
			return CreateAndInitialize(_adultTemplate, position, 0f);
		}

		public Beaver CreateNewbornChild(Vector3 position)
		{
			return CreateChild(position, 0f);
		}

		public Beaver CreateAdultFromChild(Child child)
		{
			Character component = child.GetComponent<Character>();
			Beaver beaver = CreateNewBeaver(_adultTemplate, child.Transform.position);
			InfluenceAdultWithChildhood(beaver, component);
			return beaver;
		}

		private Beaver CreateAndInitialize(Blueprint template, Vector3 position, float lifeProgress)
		{
			Beaver beaver = CreateNewBeaver(template, position);
			beaver.GetComponent<Character>().DayOfBirth = _lifeService.CalculateDayOfBirth(lifeProgress);
			beaver.GetComponent<LifeProgressor>().LifeProgress = lifeProgress;
			return beaver;
		}

		private Beaver CreateNewBeaver(Blueprint template, Vector3 position)
		{
			EntityComponent entityComponent = _entityService.Instantiate(template);
			entityComponent.Transform.position = position;
			return entityComponent.GetComponent<Beaver>();
		}

		private void InfluenceAdultWithChildhood(Beaver adult, Character child)
		{
			adult.GetComponents(_componentsToInfluence);
			foreach (IChildhoodInfluenced item in _componentsToInfluence)
			{
				item.InfluenceByChildhood(child);
			}
			_componentsToInfluence.Clear();
		}
	}
}
