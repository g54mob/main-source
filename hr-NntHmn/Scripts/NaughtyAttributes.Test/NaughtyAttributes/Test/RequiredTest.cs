using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class RequiredTest : MonoBehaviour
	{
		[Required(null)]
		public Transform trans0;

		public RequiredNest1 nest1;
	}
}
