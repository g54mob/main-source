using UI.Apps;
using UnityEngine;

public abstract class MultitoolService : MonoBehaviour
{
	protected MultiTool multitool;

	protected MultitoolCanvas canvas;

	protected RectTransform rectTransform;

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	public virtual void Init(MultiTool multitool)
	{
	}

	public virtual void OnSelectModule(Module module)
	{
	}

	public virtual void Enable()
	{
	}

	public virtual void Disable()
	{
	}

	public virtual void OnGadgetTurnOn()
	{
	}

	public virtual void OnGadgetTurnOff()
	{
	}

	public virtual void OnMultitoolAppStart(MultiToolAppInfo appInfo)
	{
	}

	public virtual void OnMultitoolAppStop(MultiToolAppInfo appIndo)
	{
	}

	public virtual void OnGadgetEndEdit()
	{
	}
}
