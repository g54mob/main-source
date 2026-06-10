using System;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.Production
{
	[Serializable]
	public class ProductModel : NSEipix.Base.Model
	{
		[SerializeField]
		private string blueprintID;

		[SerializeField]
		private int amount;

		[SerializeField]
		private AttributeType modifyingAttribute;

		public int Amount => amount;

		public AttributeType ModifyingAttribute => modifyingAttribute;

		public Resource Product => Repository<ResourceRepository, Resource>.Instance.GetByID(blueprintID);

		public override string GetID()
		{
			return blueprintID;
		}
	}
}
