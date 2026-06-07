using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class InfoBoxTest : MonoBehaviour
	{
		[InfoBox("Normal", EInfoBoxType.Normal)]
		public int normal;

		public InfoBoxNest1 nest1;
	}
}
