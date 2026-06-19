using NaughtyAttributes;
using UnityEngine;

[DisallowMultipleComponent]
public class EvolveStateAuthoring : MonoBehaviour
{
	public ObjectID toEvolveInto;

	[HideIf("toEvolveInto", ObjectID.None)]
	public int foodAmountToEvolve = 1;
}
