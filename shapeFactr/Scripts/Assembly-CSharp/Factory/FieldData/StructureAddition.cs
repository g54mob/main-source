using System;
using Libs;
using Models;
using UnityEngine;

namespace Factory.FieldData
{
	[Serializable]
	public class StructureAddition
	{
		public int minionNum;

		public bool isEliteMinion;

		[SerializeField]
		private Vector2Int inputRouteAddr;

		[SerializeField]
		private Vector2Int outputRouteAddr;

		[SerializeField]
		public Dir.DirFlag pipeLinkDir;

		public StructureAddr? InputRouteAddr
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public StructureAddr? OutputRouteAddr
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsDefault => false;
	}
}
