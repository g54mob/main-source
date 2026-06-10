using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class DropdownNest2
	{
		[Dropdown("GetVectorValues")]
		public Vector3 vectorValue;

		private DropdownList<Vector3> GetVectorValues()
		{
			return null;
		}
	}
}
