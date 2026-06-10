using System;
using System.Collections.Generic;
using NSMedieval.Enums;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class AnimalAttackGroupEntry
	{
		[SerializeField]
		private string type;

		[SerializeField]
		private List<string> values;

		[SerializeField]
		private bool wild;

		[SerializeField]
		private bool domestic;

		[SerializeField]
		private bool pet;

		[SerializeField]
		private int priority;

		[SerializeField]
		private float priorityPerDistanceUnit;

		[NonSerialized]
		private AnimalAttackGroupEntryType typeCache;

		[NonSerialized]
		private bool isTypeInitialized;

		[NonSerialized]
		private HashSet<string> valuesHashSet;

		[NonSerialized]
		private bool valuesHashSetInit;

		public bool Wild => wild;

		public bool Domestic => domestic;

		public bool Pet => pet;

		public int Priority => priority;

		public float PriorityPerDistanceUnit => priorityPerDistanceUnit;

		public HashSet<string> Values
		{
			get
			{
				if (!valuesHashSetInit)
				{
					valuesHashSetInit = true;
					valuesHashSet = new HashSet<string>(values);
				}
				return valuesHashSet;
			}
		}

		public AnimalAttackGroupEntryType Type
		{
			get
			{
				if (!isTypeInitialized)
				{
					isTypeInitialized = true;
					typeCache = (AnimalAttackGroupEntryType)Enum.Parse(typeof(AnimalAttackGroupEntryType), type);
				}
				return typeCache;
			}
		}

		public bool CanTargetAnimal(AnimalType animalType, Animal blueprint)
		{
			if (Type != AnimalAttackGroupEntryType.Animals)
			{
				return false;
			}
			if ((domestic && (animalType == AnimalType.Domestic || animalType == AnimalType.DomesticNpc)) || (wild && (animalType == AnimalType.Wild || animalType == AnimalType.WildAggressive)) || (pet && animalType == AnimalType.Pet))
			{
				return Values.Contains(blueprint.GetID());
			}
			return false;
		}
	}
}
