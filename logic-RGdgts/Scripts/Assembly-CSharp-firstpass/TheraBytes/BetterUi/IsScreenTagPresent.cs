using System;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class IsScreenTagPresent : IScreenTypeCheck, IIsActive
	{
		[SerializeField]
		private string screenTag;

		[SerializeField]
		private bool isActive;

		public string ScreenTag
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsActive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsScreenType()
		{
			return false;
		}
	}
}
