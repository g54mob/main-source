using System;
using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class Names : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<string> firstNamesMale;

		[SerializeField]
		private List<string> firstNamesFemale;

		[SerializeField]
		private List<string> lastNames;

		public List<string> FirstNamesMale => firstNamesMale;

		public List<string> FirstNamesFemale => firstNamesFemale;

		public List<string> LastNames => lastNames;

		public override string GetID()
		{
			return id;
		}
	}
}
