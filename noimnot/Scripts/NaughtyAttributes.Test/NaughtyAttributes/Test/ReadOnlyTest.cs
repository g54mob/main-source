using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class ReadOnlyTest : MonoBehaviour
	{
		[ReadOnly]
		public int readOnlyInt;

		public ReadOnlyNest1 nest1;
	}
}
