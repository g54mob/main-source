using System;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
	public TiledBox DynamicBox;

	public Transform BoxPoint;

	public Transform UArm;

	public Transform LArm;

	public Transform RArm;

	public Transform LLArm;

	public Transform RRArm;

	public Transform[] Fans;

	public AnimationCurve Height;

	public AnimationCurve Pitch;

	public AnimationCurve ArmDown;

	public AnimationCurve ArmRot;

	public AnimationCurve ArmOut;

	public float MainArmFactor = 0.1f;

	public float ArmFactor = 0.01f;

	public float SubArmFactor = 0.3f;

	public float FanSpeed = 360f;

	public float MaxVolume = 0.8f;

	public float ArmSFXStart = 7f;

	public bool ArmSFXPlayed;

	public AudioClip ArmSFX;

	public new bool Destroy;

	public bool GotBox;

	public bool Visible;

	public GameObject Rend;

	public bool PlayAudio;

	public AudioSource SFX;

	[NonSerialized]
	public HelicopterData Data;

	public void Init(HelicopterData data)
	{
		Data = data;
		ProductPallet target = data.Target;
		Destroy = false;
		GotBox = false;
		Visible = false;
		PlayAudio = false;
		ArmSFXPlayed = false;
		SFX.volume = 0f;
		if (target == null)
		{
			Destroy = true;
			return;
		}
		base.transform.rotation = target.transform.rotation;
		base.transform.position = new Vector3(target.transform.position.x, (float)(data.StartFloor * 2) + Height.Evaluate(0f), target.transform.position.z);
	}

	private void FixedUpdate()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (Destroy)
		{
			SFX.Stop();
			Destroy = false;
			Data = null;
			GameSettings.Instance.BoxController.ReleaseHelicopter(this);
			base.gameObject.SetActive(false);
			if (GotBox)
			{
				GameSettings.Instance.BoxController.ReleaseBox(DynamicBox);
				DynamicBox = null;
			}
			return;
		}
		bool flag = GameSettings.Instance.ActiveFloor >= Data.StartFloor;
		if (flag != Visible)
		{
			Visible = flag;
			Rend.SetActive(Visible);
			BoxPoint.gameObject.SetActive(Visible);
		}
		PlayAudio = Visible && GameSettings.GameSpeed > 0f && (base.transform.position - CameraScript.Instance.LastListenerPos).sqrMagnitude < SFX.maxDistance * SFX.maxDistance;
		if (!PlayAudio && SFX.isPlaying)
		{
			SFX.volume = Mathf.Lerp(SFX.volume, 0f, Time.deltaTime * 8f);
			if (Mathf.Approximately(SFX.volume, 0f))
			{
				SFX.Stop();
			}
		}
		else if (PlayAudio)
		{
			if (!SFX.isPlaying)
			{
				SFX.volume = 0f;
				SFX.Play();
			}
			else
			{
				SFX.volume = Mathf.Lerp(SFX.volume, MaxVolume, Time.deltaTime * 8f);
			}
			if (!ArmSFXPlayed && Data.CurrentTime >= ArmSFXStart && Data.CurrentTime <= ArmSFXStart + 1f)
			{
				ArmSFXPlayed = true;
				SFX.PlayOneShot(ArmSFX);
			}
			SFX.outputAudioMixerGroup = ((GameSettings.Instance.sRoomManager.CameraRoom == GameSettings.Instance.sRoomManager.Outside) ? AudioManager.InGameNormal : AudioManager.InGameHighPass);
		}
		if (!Visible)
		{
			return;
		}
		if (!GotBox && Data.HeldBoxes > 0)
		{
			GotBox = true;
			DynamicBox = GameSettings.Instance.BoxController.GetBox();
			DynamicBox.SetBoxes(Data.HeldBoxes, false);
			DynamicBox.transform.SetParent(BoxPoint);
			DynamicBox.transform.localPosition = new Vector3(0f, (0f - DynamicBox.transform.localScale.y) * 0.6f, 0f);
			DynamicBox.transform.localRotation = Quaternion.identity;
		}
		Vector3 position = base.transform.position;
		Vector3 eulerAngles = base.transform.rotation.eulerAngles;
		float time = Data.CurrentTime / 30f;
		Vector3Int boxSize = TiledBox.GetBoxSize((Data.Order != null) ? Data.HeldBoxes : Data.Target.CurrentAmount);
		base.transform.SetPositionAndRotation(new Vector3(position.x, (float)(Data.StartFloor * 2) + Height.Evaluate(time) + (float)(boxSize.y - 3) * 0.6f, position.z), Quaternion.Euler(Pitch.Evaluate(time), eulerAngles.y, eulerAngles.z));
		UArm.localRotation = Quaternion.Euler(-90f, ArmRot.Evaluate(time), 0f);
		UArm.localPosition = new Vector3(UArm.localPosition.x, ArmDown.Evaluate(time) * MainArmFactor, UArm.localPosition.z);
		LArm.localPosition = new Vector3(ArmOut.Evaluate(time) * ArmFactor, LArm.localPosition.y, LArm.localPosition.z);
		RArm.localPosition = new Vector3((0f - ArmOut.Evaluate(time)) * ArmFactor, RArm.localPosition.y, RArm.localPosition.z);
		LLArm.localPosition = new Vector3(ArmOut.Evaluate(time) * (float)boxSize.x * SubArmFactor, LLArm.localPosition.y, LLArm.localPosition.z);
		RRArm.localPosition = new Vector3((0f - ArmOut.Evaluate(time)) * (float)boxSize.x * SubArmFactor, RRArm.localPosition.y, RRArm.localPosition.z);
		if (GameSettings.GameSpeed > 0f)
		{
			Quaternion quaternion = Quaternion.Euler(0f, 0f, Time.deltaTime * FanSpeed);
			for (int i = 0; i < Fans.Length; i++)
			{
				Fans[i].transform.rotation = Fans[i].transform.rotation * quaternion;
			}
		}
	}
}
