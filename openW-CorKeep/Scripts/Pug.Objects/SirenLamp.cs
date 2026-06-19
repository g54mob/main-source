using Pug.Automation;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class SirenLamp : EntityMonoBehaviour
{
	private enum ElectricityState
	{
		None = 0,
		On = 1,
		Off = 2
	}

	public SpriteObject litBulbSO;

	public SpriteObject baseSprite;

	public Transform spinTransform;

	public float spinDegBySeconds;

	public float spriteAngleOffset;

	public Transform pointLamps;

	public Transform spotLamps;

	private static readonly int _rot0ID = SpriteAsset.StringToHash("bulb_rotation1");

	private static readonly int _rot1ID = SpriteAsset.StringToHash("bulb_rotation2");

	private static readonly int _rot2ID = SpriteAsset.StringToHash("bulb_rotation3");

	private static readonly int _rot3ID = SpriteAsset.StringToHash("bulb_rotation4");

	private static readonly int _rot4ID = SpriteAsset.StringToHash("bulb_rotation5");

	private static readonly int _rot5ID = SpriteAsset.StringToHash("bulb_rotation6");

	private static readonly int _rot6ID = SpriteAsset.StringToHash("bulb_rotation7");

	private static readonly int _rot7ID = SpriteAsset.StringToHash("bulb_rotation8");

	private const int _animFrameCount = 8;

	private const float _animAngleStep = 22.5f;

	private ElectricityState _state;

	private float _currentSpinAngleDeg;

	protected override void Awake()
	{
		base.Awake();
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		_state = ElectricityState.None;
		pointLamps.gameObject.SetActive(value: false);
		spotLamps.gameObject.SetActive(value: true);
		_currentSpinAngleDeg = Random.Range(0f, 180f);
		UpdateAnimationBySpinAngle();
	}

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateElectricityState();
		if (_state == ElectricityState.On)
		{
			UpdateSpinning();
		}
	}

	private void UpdateElectricityState()
	{
		ElectricityCD componentData = EntityUtility.GetComponentData<ElectricityCD>(base.entity, base.world);
		ElectricityState electricityState = ElectricityState.Off;
		if (componentData.hasEnoughElectricityToPowerStuff)
		{
			electricityState = ElectricityState.On;
		}
		if (_state != electricityState)
		{
			_state = electricityState;
			if (_state == ElectricityState.On)
			{
				spinTransform.gameObject.SetActive(value: true);
				baseSprite.emissiveColor = new Color(1f, 1f, 1f, 1f);
				litBulbSO.color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				spinTransform.gameObject.SetActive(value: false);
				baseSprite.emissiveColor = new Color(0f, 0f, 0f, 1f);
				litBulbSO.color = new Color(1f, 1f, 1f, 0f);
			}
		}
	}

	private void UpdateSpinning()
	{
		if (!(spinTransform == null))
		{
			_currentSpinAngleDeg += spinDegBySeconds * Time.deltaTime;
			if (_currentSpinAngleDeg > 360f)
			{
				_currentSpinAngleDeg -= 360f;
			}
			spinTransform.localRotation = Quaternion.AngleAxis(_currentSpinAngleDeg, Vector3.up);
			UpdateAnimationBySpinAngle();
		}
	}

	private void UpdateAnimationBySpinAngle()
	{
		int num = Mathf.RoundToInt((_currentSpinAngleDeg + spriteAngleOffset) / 22.5f) % 8;
		int variant = _rot0ID;
		switch (num)
		{
		case 0:
			variant = _rot0ID;
			break;
		case 1:
			variant = _rot1ID;
			break;
		case 2:
			variant = _rot2ID;
			break;
		case 3:
			variant = _rot3ID;
			break;
		case 4:
			variant = _rot4ID;
			break;
		case 5:
			variant = _rot5ID;
			break;
		case 6:
			variant = _rot6ID;
			break;
		case 7:
			variant = _rot7ID;
			break;
		}
		litBulbSO.SetVariant(variant);
	}
}
