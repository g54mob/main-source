using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class ValidateInputTest : MonoBehaviour
	{
		[ValidateInput("NotZero0", "int0 must not be zero")]
		public int int0;

		public ValidateInputNest1 nest1;

		public ValidateInputInheritedNest inheritedNest;

		private bool NotZero0(int value)
		{
			return value != 0;
		}
	}
}
