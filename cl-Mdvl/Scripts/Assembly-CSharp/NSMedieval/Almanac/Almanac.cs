using System;
using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Almanac
{
	[Serializable]
	public class Almanac : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string path;

		[SerializeField]
		private List<string> subGroupIDs;

		[SerializeField]
		private int depth;

		public string Path => path;

		public List<string> SubGroupIDs => subGroupIDs;

		public int Depth => depth;

		public override string GetID()
		{
			return id;
		}
	}
}
