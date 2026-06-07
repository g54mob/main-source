using System.Collections.Generic;

public class Factory
{
	private World _world;

	private PhaserScene _scene;

	public Factory(World world)
	{
	}

	public Collider collider(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback = null, ArcadePhysicsCallback processCallback = null, CallbackContext callbackContext = null)
	{
		return null;
	}

	public Collider overlap(ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback = null, ArcadePhysicsCallback processCallback = null, CallbackContext callbackContext = null)
	{
		return null;
	}

	public PhaserGameObject existing(PhaserGameObject gameObject, bool isStatic = false)
	{
		return null;
	}

	public StaticPhysicsGroup staticGroup(List<PhaserGameObject> children = null, PhysicsGroupConfig config = null)
	{
		return null;
	}

	public PhysicsGroup group(List<PhaserGameObject> children = null, PhysicsGroupConfig config = null, bool allowRTreeQueries = true, int capacity = 10)
	{
		return null;
	}

	public void destroy()
	{
	}
}
