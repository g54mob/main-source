using System;
using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class VillageNames : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<string> names;

		[SerializeField]
		private List<string> oldNames;

		public List<string> Names => names;

		public List<string> OldNames => oldNames;

		public override string GetID()
		{
			return id;
		}
	}
}
