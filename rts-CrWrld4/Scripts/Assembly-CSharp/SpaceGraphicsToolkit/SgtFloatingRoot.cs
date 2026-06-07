using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtFloatingRoot : SgtLinkedBehaviour<SgtFloatingRoot>
	{
		public static Transform Root => null;

		public static Transform GetRoot()
		{
			return null;
		}

		protected override void OnEnable()
		{
		}
	}
}
