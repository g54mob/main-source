using UnityEngine;

namespace GRP
{
	public class BevelGearPartView : PartView<BevelGearPartViewable>, ICreatedDrag
	{
		public BevelGearVisual gearVisual;

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
