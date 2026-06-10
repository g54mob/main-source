using System;
using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class AnimalName : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<string> namesMale;

		[SerializeField]
		private List<string> namesFemale;

		public List<string> NamesMale => namesMale;

		public List<string> NamesFemale => namesFemale;

		public override string GetID()
		{
			return id;
		}
	}
}
