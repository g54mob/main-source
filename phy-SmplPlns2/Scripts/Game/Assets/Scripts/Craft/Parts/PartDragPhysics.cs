namespace Assets.Scripts.Craft.Parts
{
	public class PartDragPhysics : IPartDragPhysics
	{
		private BodyDragPhysics _dragPhysics;

		private PartScript _part;

		public PartDragPhysics(PartScript part, BodyDragPhysics dragPhysics)
		{
			_part = part;
			_dragPhysics = dragPhysics;
		}

		public void FixedUpdate()
		{
		}

		public void Update(float estimateOfUnderwaterPercent)
		{
		}
	}
}
