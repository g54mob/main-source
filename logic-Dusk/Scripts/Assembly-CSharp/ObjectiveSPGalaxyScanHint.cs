using UnityEngine;

public class ObjectiveSPGalaxyScanHint : BaseMessageHint
{
	public ObjectiveSPGalaxyScanHint(int number)
		: base("///[JIL]: stargate successfully mapped, {0}\nmore required for triangulation of 'PX30'", number, 30f, true, new Color(0.384f, 0.867f, 0.976f))
	{
	}

	public override IHintState Completed()
	{
		return base.Completed();
	}
}
