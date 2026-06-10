using System;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Controllers
{
	public class AnimalController : MonoSingleton<AnimalController>
	{
		public delegate void AnimalHandler(AnimalInstance animalInstance);

		public delegate void AnimalLifePhaseChangeHandler(AnimalInstance animalInstance, AnimalLifePhase previousLifePhase);

		public delegate void AnimalOrderTypeHandler(AnimalOrderType orderType, AnimalInstance animalInstance);

		public delegate void AnimalAtPositionHandler(AnimalInstance animalInstance, Vector3 position);

		public event AnimalAtPositionHandler FaceObjectEvent;

		public event AnimalHandler HealthDepletedEvent;

		public event AnimalHandler SpawnAnimalEvent;

		public event AnimalHandler RemovedAnimalEvent;

		public event AnimalOrderTypeHandler MarkForOrderEvent;

		public event AnimalHandler DieFormStarvationEvent;

		public event AnimalHandler HungerEvent;

		public event AnimalHandler OrderGivenFromAnimalUIEvent;

		public event AnimalHandler OnAnimalTypeChangedEvent;

		public event Action<AnimalInstance, CreatureBase> PetOwnerChangedEvent;

		public event Action<AnimalInstance> AnimalNameChangedEvent;

		public event Action<AnimalInstance, ResourcePileInstance> AnimalKilledByHunterEvent;

		public event AnimalLifePhaseChangeHandler OnLifePhaseChangedEvent;

		public void LifePhaseChanged(AnimalInstance animalInstance, AnimalLifePhase previousLifePhase)
		{
			if (!MonoSingleton<AnimalManager>.IsApplicationIsQuitting())
			{
				this.OnLifePhaseChangedEvent?.Invoke(animalInstance, previousLifePhase);
			}
		}

		public void FaceObject(AnimalInstance animal, Vector3 objectPosition)
		{
			this.FaceObjectEvent?.Invoke(animal, objectPosition);
		}

		public void DepletedHealth(AnimalInstance animal)
		{
			this.HealthDepletedEvent?.Invoke(animal);
		}

		public void OnSpawnAnimal(AnimalInstance instance)
		{
			this.SpawnAnimalEvent?.Invoke(instance);
		}

		public void OnAnimalRemoved(AnimalInstance instance)
		{
			this.RemovedAnimalEvent?.Invoke(instance);
		}

		public void MarkForOrder(AnimalOrderType orderType, AnimalInstance animal)
		{
			this.MarkForOrderEvent?.Invoke(orderType, animal);
		}

		public void OrderGivenFromAnimalUI(AnimalInstance animalInstance)
		{
			this.OrderGivenFromAnimalUIEvent?.Invoke(animalInstance);
		}

		public void OnAnimalTypeChanged(AnimalInstance instance)
		{
			this.OnAnimalTypeChangedEvent?.Invoke(instance);
		}

		private void DieFromStarvation(StatsInstance instance)
		{
			if (instance.Owner is AnimalInstance animalInstance)
			{
				this.DieFormStarvationEvent?.Invoke(animalInstance);
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage("Animal " + animalInstance.GetFullName() + " died of starvation");
			}
		}

		public void OnHungerChange(AnimalInstance animal)
		{
			this.HungerEvent?.Invoke(animal);
		}

		private void Start()
		{
			MonoSingleton<LifeController>.Instance.DieFromStarvationEvent += DieFromStarvation;
		}

		public void PetOwnerChanged(AnimalInstance animalInstance, CreatureBase petOwner)
		{
			this.PetOwnerChangedEvent?.Invoke(animalInstance, petOwner);
		}

		public void AnimalNameChanged(AnimalInstance animal)
		{
			this.AnimalNameChangedEvent?.Invoke(animal);
		}

		public void AnimalKilledByHunter(AnimalInstance animal, ResourcePileInstance carcass)
		{
			this.AnimalKilledByHunterEvent?.Invoke(animal, carcass);
		}
	}
}
