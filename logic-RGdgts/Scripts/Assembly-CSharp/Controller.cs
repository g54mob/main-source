using Sirenix.OdinInspector;

public abstract class Controller : SerializedMonoBehaviour
{
	public abstract void Init();

	public virtual void OnLevelLoaded(object storage = null)
	{
	}

	public virtual void OnLevelSaved(object storage)
	{
	}
}
