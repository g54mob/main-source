using ClockStone;
using UnityEngine;

public class InteractableTV : InteractableBase
{
	private bool turnedOn;

	public Material TVOffMaterial;

	public Material TVOnMaterial;

	public Transform focusTransform;

	public Transform interactionPointTransform;

	public MeshRenderer screenRenderer;

	private string tvOnSound = "tv_turn_on";

	private string tvOffSound = "tv_turn_off";

	private string tvLoopSound = "tv_static_loop";

	private AudioObject tvSoundObject;

	private Vector2 offset = new Vector2(0f, 0f);

	private Vector2 currentScrollSpeed = new Vector2(0f, 0f);

	private Vector2 currentScrollSpeedTarget = new Vector2(0f, 0f);

	private Vector2 scrollSpeedMin = new Vector2(0f, 0.05f);

	private Vector2 scrollSpeedMax = new Vector2(0f, 0.5f);

	private Vector2 horizontalTrackingSpeed = new Vector2(0.001f, 0f);

	private float speedUpdateRate = 1f;

	private float currentTimeUntilSpeedSwitch;

	private float speedSwitchTimerMin = 0.25f;

	private float speedSwitchTimerMax = 3f;

	private void Awake()
	{
		TurnOff(fromLoad: true);
	}

	private void OnDestroy()
	{
		if (tvSoundObject != null)
		{
			tvSoundObject.Stop();
			tvSoundObject = null;
		}
	}

	public void Save(SaveablePlacedObject saveableObject)
	{
		saveableObject.boolList.Add(turnedOn);
	}

	public void Load(SaveablePlacedObject saveableObject)
	{
		if (saveableObject.boolList.Count != 0)
		{
			if (saveableObject.boolList[0])
			{
				TurnOn(fromLoad: true);
			}
			else
			{
				TurnOff(fromLoad: true);
			}
		}
	}

	private void Update()
	{
		if (IsCurrentlyOn())
		{
			UpdateTexture();
		}
	}

	public override Transform GetFocusTransform()
	{
		return focusTransform;
	}

	public override bool HasCustomInteractionPoint()
	{
		return true;
	}

	public override Vector3 GetInteractionPoint()
	{
		return interactionPointTransform.position;
	}

	public override Transform GetInteractionPointTransform()
	{
		return interactionPointTransform;
	}

	public void ToggleState()
	{
		if (!turnedOn)
		{
			TurnOn();
		}
		else
		{
			TurnOff();
		}
	}

	public bool IsCurrentlyOn()
	{
		return turnedOn;
	}

	public override void OnObjectBittenByDog(Vector3 biteVector, GameObject dog)
	{
		ToggleState();
	}

	public void TurnOn(bool fromLoad = false)
	{
		if (!fromLoad)
		{
			AudioController.Play(tvOnSound, base.transform.position);
		}
		if (tvSoundObject == null)
		{
			tvSoundObject = AudioController.Play(tvLoopSound, base.transform.position);
		}
		turnedOn = true;
		screenRenderer.material = TVOnMaterial;
	}

	public void TurnOff(bool fromLoad = false)
	{
		turnedOn = false;
		screenRenderer.material = TVOffMaterial;
		if (tvSoundObject != null)
		{
			tvSoundObject.Stop();
			tvSoundObject = null;
		}
		if (!fromLoad)
		{
			AudioController.Play(tvOffSound);
		}
	}

	private void UpdateTexture()
	{
		currentTimeUntilSpeedSwitch -= Time.deltaTime;
		if (currentTimeUntilSpeedSwitch <= 0f)
		{
			currentTimeUntilSpeedSwitch = Random.Range(speedSwitchTimerMin, speedSwitchTimerMax);
			currentScrollSpeedTarget = new Vector2(Random.Range(scrollSpeedMin.x, scrollSpeedMax.x), Random.Range(scrollSpeedMin.y, scrollSpeedMax.y));
		}
		offset -= currentScrollSpeed * Time.deltaTime;
		while (offset.y < -1f)
		{
			offset = new Vector2(offset.x, offset.y + 1f);
		}
		if (currentScrollSpeed.x < currentScrollSpeedTarget.x)
		{
			currentScrollSpeed.x += speedUpdateRate * Time.deltaTime;
			if (currentScrollSpeed.x > currentScrollSpeedTarget.x)
			{
				currentScrollSpeed.x = currentScrollSpeedTarget.x;
			}
		}
		else if (currentScrollSpeed.x > currentScrollSpeedTarget.x)
		{
			currentScrollSpeed.x -= speedUpdateRate * Time.deltaTime;
			if (currentScrollSpeed.x < currentScrollSpeedTarget.x)
			{
				currentScrollSpeed.x = currentScrollSpeedTarget.x;
			}
		}
		if (currentScrollSpeed.y < currentScrollSpeedTarget.y)
		{
			currentScrollSpeed.y += speedUpdateRate * Time.deltaTime;
			if (currentScrollSpeed.y > currentScrollSpeedTarget.y)
			{
				currentScrollSpeed.y = currentScrollSpeedTarget.y;
			}
		}
		else if (currentScrollSpeed.y > currentScrollSpeedTarget.y)
		{
			currentScrollSpeed.y -= speedUpdateRate * Time.deltaTime;
			if (currentScrollSpeed.y < currentScrollSpeedTarget.y)
			{
				currentScrollSpeed.y = currentScrollSpeedTarget.y;
			}
		}
		offset += Mathf.Sin(Time.time * 10f) * horizontalTrackingSpeed;
		screenRenderer.material.SetTextureOffset("_MainTex", offset);
	}
}
