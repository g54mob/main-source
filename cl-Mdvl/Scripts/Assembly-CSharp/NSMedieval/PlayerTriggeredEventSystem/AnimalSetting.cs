using System;
using NSEipix.Base;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	[Serializable]
	public class AnimalSetting : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private AnimalType animalType;

		public AnimalType AnimalType => animalType;

		public override string GetID()
		{
			return id;
		}
	}
}
