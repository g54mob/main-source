using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;
using __Project__.Scripts.PlayerAim;

public class PlayerCrosshairManager : NoktaSingleton<PlayerCrosshairManager>
{
	[Header("[--Aim--]")]
	[SerializeField]
	private List<Aim> aimList;

	[SerializeField]
	private GameObject aimPrefab;

	[SerializeField]
	private Transform aimSlotParent;

	[Header("[--Aim Scale--]")]
	[SerializeField]
	private Slider aimScaleSlider;

	[Header("[--Aim Color--]")]
	[SerializeField]
	private Button colorOpenButton;

	[SerializeField]
	private Button colorCloseButton;

	[SerializeField]
	private GameObject colorPanel;

	private List<Button> _aimSlotButtons;

	private List<AimSlot> _aimSlots;

	private List<Graphic> _aimSlotGraphic;

	private PlayerAimSettings _playerAimSettings;

	[SerializeField]
	private WindowTab m_Tab;

	[SerializeField]
	private GamepadSelectableParent m_GamepadSelectableParent;

	private bool m_IsColorPanelOpened;

	public bool IsColorPanelOpened => false;

	public float AimScale
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public int AimID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public string AimHexCode
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	public void Init()
	{
	}

	private void OnDisable()
	{
	}

	public void GamepadOpen()
	{
	}

	public void SetColorGraphic(Color color)
	{
	}

	public void ColorPanelOpen()
	{
	}

	public void ColorPanelClose()
	{
	}

	public void ForceCloseColorPanel()
	{
	}

	public void GamepadScaleChange(bool isIncrease)
	{
	}

	private void OnValueChangedScaleSlider(float value)
	{
	}

	public List<Aim> GetAimList()
	{
		return null;
	}

	public Sprite GetAimSprite()
	{
		return null;
	}

	public void SetTickOtherSlots(int id, bool value)
	{
	}
}
