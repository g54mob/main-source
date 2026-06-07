using System;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public abstract class TabletopProductData : ProductData
	{
		[SerializeField]
		protected ELicense m_license;

		[SerializeField]
		protected EProductType m_productType;

		public EProductType Type => m_productType;

		public ELicense License => m_license;

		public override string DataNamePrefix
		{
			get
			{
				return Type.ToString() + "/" + License;
			}
			set
			{
				throw new Exception("Can't set Product Data prefix");
			}
		}
	}
}
