using UnityEngine;

public class DrawerBehaviour : MonoBehaviour
{
	public Drawer drawer { get; protected set; }

	public virtual void Init(Drawer drawer)
	{
	}

	public virtual void OnDrawerOpen()
	{
	}

	public virtual void OnDrawerClose()
	{
	}
}
