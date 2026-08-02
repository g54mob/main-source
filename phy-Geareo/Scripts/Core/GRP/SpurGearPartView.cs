using UnityEngine;

namespace GRP
{
	public class SpurGearPartView : PartView<SpurGearPartViewable>, ICreatedDrag
	{
		public SpurGearVisual gearVisual;

		public Transform top;

		public Transform bottom;

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}

		public void CreatedDrag(CreatedPartContainer createdPart)
		{
		}
	}
}
