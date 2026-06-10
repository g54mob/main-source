using System;
using NSEipix.Base;
using Unity.Collections;

public class FireController : MonoSingleton<FireController>
{
	public event Action FirstFireLitEvent;

	public event Action LastFirePutOutEvent;

	public event Action<NativeParallelHashSet<int>> FireAddedEvent;

	public event Action<NativeParallelHashSet<int>> FireRemovedEvent;

	public void FirstFireLit()
	{
		this.FirstFireLitEvent?.Invoke();
	}

	public void LastFirePutOut()
	{
		this.LastFirePutOutEvent?.Invoke();
	}

	public void FireAdded(NativeParallelHashSet<int> positions)
	{
		this.FireAddedEvent?.Invoke(positions);
	}

	public void FireRemoved(NativeParallelHashSet<int> positions)
	{
		this.FireRemovedEvent?.Invoke(positions);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		this.FireAddedEvent = null;
		this.FireRemovedEvent = null;
		this.FirstFireLitEvent = null;
		this.LastFirePutOutEvent = null;
	}
}
