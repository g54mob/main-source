using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class EnumFlagsTest : MonoBehaviour
	{
		[EnumFlags]
		public TestEnum flags0;

		public EnumFlagsNest1 nest1;
	}
}
