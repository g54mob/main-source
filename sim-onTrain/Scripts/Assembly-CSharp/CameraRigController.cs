using HQFPSTemplate;
using UnityEngine;

public class CameraRigController : MonoBehaviour
{
	public Transform cameraTransform;

	public Vector2 cameraRotationLimits;

	public Transform spineRigTarget;

	public Transform shoulderRigTarget;

	public Transform cameraRoot;

	public Transform fpEquipment;

	public WeaponTpsPositionSetter currentWeapon;

	private PlayerCamera playerCamera;

	private bool isActive = true;

	private Vector3 defaultSpineRigTargetPosition;

	private Vector3 defaultShoulderRigTargetPosition;

	private Vector3 defaultCameraRootPosition;

	private void Start()
	{
		playerCamera = GetComponentInChildren<PlayerCamera>();
		if (playerCamera != null)
		{
			playerCamera.m_DefaultLookLimits = cameraRotationLimits;
		}
		if (spineRigTarget != null)
		{
			defaultSpineRigTargetPosition = spineRigTarget.localPosition;
		}
		if (shoulderRigTarget != null)
		{
			defaultShoulderRigTargetPosition = shoulderRigTarget.localPosition;
		}
		if (cameraRoot != null)
		{
			defaultCameraRootPosition = cameraRoot.localPosition;
		}
	}

	public void SetActive(bool active)
	{
		isActive = active;
		if (!active)
		{
			ResetToDefault();
		}
	}

	public void ClearWeapon()
	{
		currentWeapon = null;
		ResetToDefault();
	}

	public void ResetToDefault()
	{
		if (spineRigTarget != null)
		{
			spineRigTarget.localPosition = defaultSpineRigTargetPosition;
		}
		if (shoulderRigTarget != null)
		{
			shoulderRigTarget.localPosition = defaultShoulderRigTargetPosition;
		}
		if (cameraRoot != null)
		{
			cameraRoot.localPosition = defaultCameraRootPosition;
		}
	}

	private void Update()
	{
		if (!isActive || currentWeapon == null)
		{
			return;
		}
		float num = cameraTransform.localEulerAngles.x;
		if (num > 180f)
		{
			num -= 360f;
		}
		if (num < 0f)
		{
			float num2 = Mathf.Abs(num);
			float num3 = Mathf.Abs(cameraRotationLimits.x) / 2f;
			if (num2 <= num3)
			{
				float t = Mathf.InverseLerp(0f, num3, num2);
				spineRigTarget.localPosition = Vector3.Lerp(currentWeapon.spineRigTargetStandartPosition, currentWeapon.spineRigTargetMax1Position, t);
				shoulderRigTarget.localPosition = Vector3.Lerp(currentWeapon.shoulderRigTargetStandartPosition, currentWeapon.shoulderRigTargetMax1Position, t);
				cameraRoot.localPosition = Vector3.Lerp(currentWeapon.cameraRootStandartPosition, currentWeapon.cameraRootMax1Position, t);
			}
			else
			{
				float t2 = Mathf.InverseLerp(num3, Mathf.Abs(cameraRotationLimits.x), num2);
				spineRigTarget.localPosition = Vector3.Lerp(currentWeapon.spineRigTargetMax1Position, currentWeapon.spineRigTargetMax2Position, t2);
				shoulderRigTarget.localPosition = Vector3.Lerp(currentWeapon.shoulderRigTargetMax1Position, currentWeapon.shoulderRigTargetMax2Position, t2);
				cameraRoot.localPosition = Vector3.Lerp(currentWeapon.cameraRootMax1Position, currentWeapon.cameraRootMax2Position, t2);
			}
		}
		else if (num > 0f)
		{
			float num4 = cameraRotationLimits.y / 2f;
			if (num <= num4)
			{
				float t3 = Mathf.InverseLerp(0f, num4, num);
				spineRigTarget.localPosition = Vector3.Lerp(currentWeapon.spineRigTargetStandartPosition, currentWeapon.spineRigTargetMin1Position, t3);
				shoulderRigTarget.localPosition = Vector3.Lerp(currentWeapon.shoulderRigTargetStandartPosition, currentWeapon.shoulderRigTargetMin1Position, t3);
				cameraRoot.localPosition = Vector3.Lerp(currentWeapon.cameraRootStandartPosition, currentWeapon.cameraRootMin1Position, t3);
			}
			else
			{
				float t4 = Mathf.InverseLerp(num4, cameraRotationLimits.y, num);
				spineRigTarget.localPosition = Vector3.Lerp(currentWeapon.spineRigTargetMin1Position, currentWeapon.spineRigTargetMin2Position, t4);
				shoulderRigTarget.localPosition = Vector3.Lerp(currentWeapon.shoulderRigTargetMin1Position, currentWeapon.shoulderRigTargetMin2Position, t4);
				cameraRoot.localPosition = Vector3.Lerp(currentWeapon.cameraRootMin1Position, currentWeapon.cameraRootMin2Position, t4);
			}
		}
		else
		{
			spineRigTarget.localPosition = currentWeapon.spineRigTargetStandartPosition;
			shoulderRigTarget.localPosition = currentWeapon.shoulderRigTargetStandartPosition;
			cameraRoot.localPosition = currentWeapon.cameraRootStandartPosition;
		}
	}
}
