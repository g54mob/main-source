using DV.CabControls.Spec;
using DV.Utils;

public abstract class ControlsInstantiatorBase : SingletonBehaviour<ControlsInstantiatorBase>
{
	public new static string AllowAutoCreate()
	{
		return null;
	}

	public abstract void Spawn(ControlSpec controlSpec);
}
