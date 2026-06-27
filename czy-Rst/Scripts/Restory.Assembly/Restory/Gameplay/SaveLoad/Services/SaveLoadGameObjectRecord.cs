using System;
using Restory.Data.Identifications;
using UnityEngine;

namespace Restory.Gameplay.SaveLoad.Services
{
	[Serializable]
	public record SaveLoadGameObjectRecord
	{
		public GameObject GameObject;

		public SaveableEntity SaveableEntity;

		public Identificator Identificator;

		public string Name;
	}
}
