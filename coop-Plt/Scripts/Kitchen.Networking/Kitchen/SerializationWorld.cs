using Unity.Entities;

namespace Kitchen
{
	public static class SerializationWorld
	{
		private static World _World;

		public static World Get
		{
			get
			{
				if (_World == null)
				{
					_World = Create();
				}
				return _World;
			}
		}

		public static World Create()
		{
			World world = new World("SerializationWorld");
			DefaultWorldInitialization.AddSystemsToRootLevelSystemGroups(world, typeof(WorldSerializer));
			ScriptBehaviourUpdateOrder.AddWorldToCurrentPlayerLoop(world);
			return world;
		}
	}
}
