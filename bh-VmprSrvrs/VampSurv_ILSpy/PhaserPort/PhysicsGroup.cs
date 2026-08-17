public class PhysicsGroup : Group
{
	public PhysicsGroup(int capacity)
		: base(capacity)
	{
		_physicsType = PhysicsType.DYNAMIC_BODY;
	}
}
