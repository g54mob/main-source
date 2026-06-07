using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Lamp : MonoBehaviour
{
	public Transform lightsRoot;

	public Light2D lampLight;

	public SpriteRenderer lightSprite;

	public InteractableSwitch interactableSwitch;

	public Transform[] slots;

	public SpriteRenderer fakeDesktopShadow;

	public float globalLightOffIntensity;

	public float movementTransitionDuration;

	public Ease movmementEase;

	public float movementEaseAmplitude;

	public float movementEasePeriod;

	private Transform currentSlot;

	private Sequence lightTween;

	private Sequence movementTween;

	private float defaultLightIntensity;

	private Color defaultLightColor;

	private Color defaultGlobalLightColor;

	private Color defaultLightSpriteColor;

	private float _lampI;

	private float _globalI;

	private Color _color;

	public bool isMoving => false;

	public bool isOn => false;

	private void Start()
	{
	}

	public void ActivateLight()
	{
	}

	public void DeactivateLight()
	{
	}

	public void Disable()
	{
	}

	public void Enable()
	{
	}

	public void TurnOn()
	{
	}

	public void TurnOff()
	{
	}

	public void Toggle()
	{
	}

	public void SetColor(Color color)
	{
	}

	private void LateUpdate()
	{
	}

	public void ResetColor()
	{
	}

	public void Move(Vector2 direction)
	{
	}

	public void RefreshPosition()
	{
	}

	public void DetachLights()
	{
	}

	public void AttachLights()
	{
	}
}
