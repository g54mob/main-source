using UnityEngine;

public class Obj_RangeIndicator : MonoBehaviour
{
	public enum eMagicRingMaterialType
	{
		MAGIC_CIRCLE = 0,
		COGWHEEL = 1
	}

	[SerializeField]
	private Transform node_RangeRingScale;

	[SerializeField]
	private Transform node_DottedRing_Blue;

	[SerializeField]
	private Transform node_DottedRing_Secondary;

	[SerializeField]
	private Transform node_DottedRing_Vision;

	[SerializeField]
	private Spin spin;

	[SerializeField]
	private Obj_AreaMonsterDetector areaMonsterDetector;

	[SerializeField]
	private Renderer renderer_RangeRing;

	[SerializeField]
	private Renderer renderer_RangeRing_Donut;

	[SerializeField]
	private Material mat_FullCircleRange;

	[SerializeField]
	private Material mat_SkillMagicCircle;

	[SerializeField]
	private Material mat_CogwheelCircle;

	[SerializeField]
	private Transform targetTransform;

	private bool isActivated;

	private bool isLocked;

	private ABaseTower targetTower;

	private bool isLockToMouse;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnOverrideTowerRangeTransform(Transform transform)
	{
	}

	private void OnForceUpdateTowerRangeIndicator(ABaseTower tower, float range)
	{
	}

	private void Update()
	{
	}

	private void OnLockRangeIndicator(bool isLocked)
	{
	}

	private void OnToggleRangeIndicator(bool isOn)
	{
	}

	private void OnToggleSecondaryRangeIndicator(bool isOn, ABaseTower tower, float fromRange, float toRange)
	{
	}

	private void OnToggleVisionRangeIndicator(bool isOn, ABaseTower tower, float range)
	{
	}

	private void OnSetupRangeIndicatorForTower(ABaseTower tower, float range)
	{
	}

	private void OnSetupRangeIndicatorForMouse(float range, eMagicRingMaterialType ringMaterialType)
	{
	}

	public void SetRingRange(ABaseTower tower)
	{
	}

	public void SetRingRange(float range, float minRange = 0f)
	{
	}
}
