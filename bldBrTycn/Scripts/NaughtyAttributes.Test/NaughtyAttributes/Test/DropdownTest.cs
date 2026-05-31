using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class DropdownTest : MonoBehaviour
	{
		[Dropdown("intValues")]
		public int intValue;

		private int[] intValues = new int[3] { 1, 2, 3 };

		public DropdownNest1 nest1;
	}
}
