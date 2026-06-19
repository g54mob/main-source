namespace TH20
{
	public interface RoomModifier
	{
		void Apply(RoomItem roomItem, FloorPlan floorPlan);

		void Remove(RoomItem roomItem, FloorPlan floorPlan);

		string Description();

		RoomModifierCondition GetModifierCondition();
	}
}
