using System;
using MadGoat_SSAA;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider))]
public class AnimOnClick : MonoBehaviour
{
	public string Trigger;

	public float Cooldown;

	public AudioClip[] Clips;

	public float Volume = 1f;

	public float Pan;

	[NonSerialized]
	private float _coolTimer;

	[NonSerialized]
	private Animator _anim;

	[NonSerialized]
	private Collider _coll;

	private void Awake()
	{
		_anim = GetComponent<Animator>();
		_coll = GetComponent<Collider>();
	}

	private MadGoatSSAA GetCurrentSSAA()
	{
		if (MainMenuController.Instance != null)
		{
			return MainMenuController.Instance.SSAAScript;
		}
		if (ActorCustomization.Instance != null)
		{
			return ActorCustomization.Instance.SSAAScript;
		}
		if (CameraScript.Instance != null)
		{
			return CameraScript.Instance.SSAScript;
		}
		return null;
	}

	private Ray GetCameraRay(Vector3 pos)
	{
		MadGoatSSAA currentSSAA = GetCurrentSSAA();
		if (currentSSAA != null)
		{
			return currentSSAA.ScreenPointToRay(pos);
		}
		return Camera.main.ScreenPointToRay(pos);
	}

	private void Update()
	{
		if (_coolTimer > 0f)
		{
			_coolTimer -= Time.deltaTime;
		}
		else
		{
			if (GUICheck.OverGUI || !Input.GetMouseButtonDown(0))
			{
				return;
			}
			Ray cameraRay = GetCameraRay(Input.mousePosition);
			RaycastHit hitInfo;
			if (_coll.Raycast(cameraRay, out hitInfo, 100f))
			{
				if (Clips != null && Clips.Length != 0)
				{
					UISoundFX.PlaySFX(Clips.GetRandom(), Volume, UnityEngine.Random.Range(0.9f, 1.1f), Pan);
				}
				_coolTimer = Cooldown;
				_anim.SetTrigger(Trigger);
			}
		}
	}
}
