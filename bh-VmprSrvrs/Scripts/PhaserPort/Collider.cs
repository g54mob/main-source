public class Collider
{
	protected string _name;

	protected World _world;

	public bool _active;

	protected bool _overlapOnly;

	protected ArcadeColliderType _object1;

	protected ArcadeColliderType _object2;

	protected ArcadePhysicsCallback _collideCallback;

	protected ArcadePhysicsCallback _processCallback;

	protected CallbackContext _callbackContext;

	public Collider(World world, bool overlapOnly, ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback, ArcadePhysicsCallback processCallback, CallbackContext callbackContext)
	{
	}

	public Collider setName(string name)
	{
		return null;
	}

	public virtual void update()
	{
	}

	public void destroy()
	{
	}

	public void SetColliderRunPosition(int position)
	{
	}
}
