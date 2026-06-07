using UnityEngine;

public class WwiseStateReference : WwiseGroupValueObjectReference
{
	[AkShowOnly]
	[SerializeField]
	private WwiseStateGroupReference WwiseStateGroupReference;

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
