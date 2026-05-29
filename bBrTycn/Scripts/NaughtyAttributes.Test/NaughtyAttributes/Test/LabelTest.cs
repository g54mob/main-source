using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class LabelTest : MonoBehaviour
	{
		[Label("Label 0")]
		public int int0;

		public LabelNest1 nest1;
	}
}
