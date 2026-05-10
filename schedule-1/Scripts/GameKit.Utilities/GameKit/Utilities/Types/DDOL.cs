using System;
using UnityEngine;

namespace GameKit.Utilities.Types
{
	public class DDOL : MonoBehaviour
	{
		private static DDOL _instance;

		[Obsolete("Use GetDDOL().")]
		public static DDOL Instance => null;

		public static DDOL GetDDOL()
		{
			return null;
		}
	}
}
