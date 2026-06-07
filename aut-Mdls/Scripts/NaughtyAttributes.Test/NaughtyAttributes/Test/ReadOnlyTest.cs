using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class ReadOnlyTest : MonoBehaviour
	{
		[ReadOnly]
		public int readOnlyInt = 5;

		public ReadOnlyNest1 nest1;
	}
}
