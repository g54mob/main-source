using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class DropdownTest : MonoBehaviour
	{
		[Dropdown("intValues")]
		public int intValue;

		private int[] intValues;

		public DropdownNest1 nest1;
	}
}
