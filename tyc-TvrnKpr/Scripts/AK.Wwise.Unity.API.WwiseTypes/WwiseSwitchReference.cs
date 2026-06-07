using UnityEngine;

public class WwiseSwitchReference : WwiseGroupValueObjectReference
{
	[AkShowOnly]
	[SerializeField]
	private WwiseSwitchGroupReference WwiseSwitchGroupReference;

	public override WwiseObjectType WwiseObjectType => default(WwiseObjectType);

	public override WwiseObjectReference GroupObjectReference
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public override WwiseObjectType GroupWwiseObjectType => default(WwiseObjectType);
}
