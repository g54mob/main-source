using System;
using NSMedieval.Roles;
using UnityEngine;

namespace NSMedieval.State
{
	[Serializable]
	public class RoleEffectorData
	{
		[SerializeField]
		private string effectorId;

		[SerializeField]
		private RoleInstance roleInstance;

		public string EffectorId => effectorId;

		public RoleInstance RoleInstance
		{
			get
			{
				return roleInstance;
			}
			set
			{
				roleInstance = value;
			}
		}

		public RoleEffectorData(string effectorId, RoleInstance roleInstance)
		{
			this.effectorId = effectorId;
			RoleInstance = roleInstance;
		}
	}
}
