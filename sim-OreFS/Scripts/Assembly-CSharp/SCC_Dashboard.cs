using UnityEngine;

[AddComponentMenu("BoneCracker Games/Simple Car Controller/SCC Dashboard")]
public class SCC_Dashboard : MonoBehaviour
{
	public SCC_Drivetrain car;

	private float rpm;

	private float kmh;

	public RectTransform RPMNeedle;

	public RectTransform KMHNeedle;

	public float RPMNeedleMultiplier = 1.2f;

	public float KMHNeedleMultiplier = 1.2f;

	private float orgRPMNeedleAngle;

	private float orgKMHNeedleAngle;

	private void Awake()
	{
		orgRPMNeedleAngle = RPMNeedle.transform.localEulerAngles.z;
		orgKMHNeedleAngle = KMHNeedle.transform.localEulerAngles.z;
	}

	private void Update()
	{
		if (!car)
		{
			rpm = 0f;
			kmh = 0f;
		}
		else
		{
			rpm = car.currentEngineRPM * RPMNeedleMultiplier;
			kmh = car.speed * KMHNeedleMultiplier;
		}
		Quaternion b = Quaternion.Euler(0f, 0f, orgKMHNeedleAngle - kmh);
		KMHNeedle.rotation = Quaternion.Slerp(KMHNeedle.rotation, b, Time.deltaTime * 2f);
		Quaternion b2 = Quaternion.Euler(0f, 0f, orgRPMNeedleAngle - rpm / 40f);
		RPMNeedle.rotation = Quaternion.Slerp(RPMNeedle.rotation, b2, Time.deltaTime * 2f);
	}
}
