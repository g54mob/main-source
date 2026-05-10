using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class ResizableTextAreaTest : MonoBehaviour
	{
		[ResizableTextArea]
		public string text0;

		public ResizableTextAreaNest1 nest1;
	}
}
