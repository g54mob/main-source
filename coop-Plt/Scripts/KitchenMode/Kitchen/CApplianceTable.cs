using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CApplianceTable : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public bool IsIndividualTable;

		public bool IsWaitingTable;

		public bool PreventSittingUp;

		public bool PreventSittingDown;

		public bool PreventSittingLeft;

		public bool PreventSittingRight;

		public Orientation ActiveChairs;

		public int MaxSeats => ((!PreventSittingDown) ? 1 : 0) + ((!PreventSittingUp) ? 1 : 0) + ((!PreventSittingLeft) ? 1 : 0) + ((!PreventSittingRight) ? 1 : 0);

		public bool PreventsSitting(Orientation o)
		{
			return o switch
			{
				Orientation.Right => PreventSittingRight, 
				Orientation.Down => PreventSittingDown, 
				Orientation.Left => PreventSittingLeft, 
				Orientation.Up => PreventSittingUp, 
				_ => false, 
			};
		}
	}
}
