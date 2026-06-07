using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtFloatingLight : SgtLinkedBehaviour<SgtFloatingLight>
	{
		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		private void PreCull(Camera camera)
		{
		}
	}
}
