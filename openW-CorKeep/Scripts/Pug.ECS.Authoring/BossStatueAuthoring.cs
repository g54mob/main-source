using Pug.UnityExtensions;
using UnityEngine;

public class BossStatueAuthoring : MonoBehaviour
{
	public ObjectID acceptsCrystalID;

	public bool doneLoadingUp;

	public bool hasCrystal;

	public float electricityLoadUpTimer;

	public ThreadSafeTimerSimple delayedActivationTimer;
}
