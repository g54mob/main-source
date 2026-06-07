using UnityEngine;

public class Recoil : MonoBehaviour
{
	[Header("References")]
	public Transform recoilHolder;

	public Transform gunPivot;

	public Camera playerCamera;

	[Header("Camera holder recoil (degrees)")]
	public Vector3 recoil;

	public float initialSmoothTime;

	public float settleSmoothTime;

	private Vector3 originalRotation;

	private Vector3 targetRotation;

	private Vector3 currentRotation;

	private Vector3 targetVelocity = Vector3.zero;

	private Vector3 currentVelocity = Vector3.zero;

	[Header("Gun kickback (cm)")]
	public Vector3 kickback;

	public Vector3 tilt;

	public float kickbackInitialSmoothTime;

	public float kickbackSettleSmoothTime;

	private Vector3 gunCurrentPos;

	private Vector3 gunTargetPos;

	private Vector3 gunDefaultPos;

	private Vector3 gunCurrentTilt;

	private Vector3 gunTargetTilt;

	private Vector3 gunTargetVelocity = Vector3.zero;

	private Vector3 gunCurrentVelocity = Vector3.zero;

	private Vector3 gunTargetTiltVelocity = Vector3.zero;

	private Vector3 gunTurrentTiltVelocity = Vector3.zero;

	private void Start()
	{
		originalRotation = recoilHolder.localRotation.eulerAngles;
	}

	private void Update()
	{
		targetRotation = Vector3.SmoothDamp(targetRotation, originalRotation, ref targetVelocity, settleSmoothTime);
		currentRotation = Vector3.SmoothDamp(currentRotation, targetRotation, ref currentVelocity, initialSmoothTime);
		recoilHolder.localRotation = Quaternion.Euler(currentRotation);
		gunTargetPos = Vector3.SmoothDamp(gunTargetPos, gunDefaultPos, ref gunTargetVelocity, kickbackSettleSmoothTime);
		gunCurrentPos = Vector3.SmoothDamp(gunCurrentPos, gunTargetPos, ref gunCurrentVelocity, kickbackInitialSmoothTime);
		gunPivot.localPosition = gunCurrentPos;
		gunTargetTilt = Vector3.SmoothDamp(gunTargetTilt, Vector3.zero, ref gunTargetTiltVelocity, kickbackSettleSmoothTime);
		gunCurrentTilt = Vector3.SmoothDamp(gunCurrentTilt, gunTargetTilt, ref gunTurrentTiltVelocity, kickbackInitialSmoothTime);
		gunPivot.localRotation = Quaternion.Euler(gunCurrentTilt);
	}

	public void GenerateRecoil()
	{
		targetRotation += new Vector3(recoil.x, Random.Range(0f - recoil.y, recoil.y), Random.Range(0f - recoil.z, recoil.z));
		gunTargetPos += 0.01f * new Vector3(Random.Range(0f - kickback.x, kickback.x), kickback.y, Random.Range(kickback.z * 0.5f, kickback.z));
		gunTargetTilt += new Vector3(0f - tilt.x, Random.Range(0f - tilt.y, tilt.y), Random.Range(0f - tilt.z, tilt.z));
	}
}
