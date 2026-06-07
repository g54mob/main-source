using UnityEngine;

public class MiscObjectIdentifier : MonoBehaviour
{
	public enum MiscObjectIdentity
	{
		Bed = 0,
		RadioButton_Power = 1,
		RadioButton_Station = 2
	}

	public MiscObjectIdentity identity;
}
