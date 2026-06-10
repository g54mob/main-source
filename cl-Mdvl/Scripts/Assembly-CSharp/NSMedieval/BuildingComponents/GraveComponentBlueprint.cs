using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Components.Base;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class GraveComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Grave;

		[SerializeField]
		private string id;

		[SerializeField]
		private bool diggable;

		[SerializeField]
		private List<string> validGround = new List<string>();

		[SerializeField]
		private StorageBase graveStorage;

		public BuildingType ComponentType => componentType;

		public bool Diggable => diggable;

		public List<string> ValidGround => validGround;

		public StorageBase GraveStorage => graveStorage;

		public override string GetID()
		{
			return id;
		}
	}
}
