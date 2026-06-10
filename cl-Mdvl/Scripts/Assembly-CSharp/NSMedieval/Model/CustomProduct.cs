using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Production;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class CustomProduct : NSEipix.Base.Model
	{
		[SerializeField]
		private string input;

		[SerializeField]
		private string whileProducingEffector;

		[SerializeField]
		private string onStartEffector;

		[SerializeField]
		private List<ProductModel> output;

		public List<ProductModel> Products => output;

		public string WhileProducingEffector => whileProducingEffector;

		public string OnStartEffector => onStartEffector;

		public override string GetID()
		{
			return input;
		}
	}
}
