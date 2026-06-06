namespace MalbersAnimations.Utilities
{
	public enum EventBehaviorType
	{
		VoidEvent = 1,
		BoolEvent = 2,
		FloatEvent = 4,
		IntEvent = 8,
		StringEvent = 0x10,
		Vector3Event = 0x20,
		Vector2Event = 0x40,
		GameObjectEvent = 0x80,
		TransformEvent = 0x100,
		ComponentEvent = 0x200,
		SpriteEvent = 0x400
	}
}
