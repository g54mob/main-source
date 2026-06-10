using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class HitEffectorGroup : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private HitEffector[] hitEffectors;

		public HitEffector[] HitEffectors => hitEffectors;

		public override string GetID()
		{
			return id;
		}
	}
}
