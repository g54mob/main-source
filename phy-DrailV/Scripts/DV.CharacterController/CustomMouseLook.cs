using System;
using DV.Interaction.Inputs;
using UnityEngine;

[Serializable]
public class CustomMouseLook
{
	public bool clampVerticalRotation = true;

	public float MinimumX = -90f;

	public float MaximumX = 90f;

	public bool invertyMouseY;

	public Transform cameraHolder;

	public Transform cameraAnchor;

	private const float SLOW_FACTOR = 0.2f;

	private const float CRAWL_FACTOR = 0.01f;

	private float sensitivityMultiplier = 1f;

	private Quaternion m_CharacterTargetRot;

	private Quaternion m_CameraTargetRot;

	private MouseSensitivityState state;

	private ACharacterControllerProvider provider;

	public void Init(Transform character, Transform camera, ACharacterControllerProvider provider)
	{
		m_CharacterTargetRot = character.rotation;
		m_CameraTargetRot = camera.localRotation;
		this.provider = provider;
		if (!provider.IsVR)
		{
			provider.RequestCursor(this, cursorVisible: false);
			provider.InvertMouseYChanged_Register(OnInvertMouseYUpdated);
			OnInvertMouseYUpdated();
		}
		provider.RequestSystemStuff_Register(OnMouseSensitivityStateChanged, ScreenspaceMouseOnValueChanged);
	}

	private void ScreenspaceMouseOnValueChanged(bool on)
	{
		if (on)
		{
			RequestMouseSensitivityState(this, MouseSensitivityState.Crawl, 1);
		}
		else
		{
			RemoveRequest(this);
		}
	}

	private void OnMouseSensitivityStateChanged(float value)
	{
		MouseSensitivityState desiredState = (MouseSensitivityState)value;
		ChangeSlowdownState(desiredState);
	}

	public void RequestMouseSensitivityState(object caller, MouseSensitivityState state, int priority = 0)
	{
		provider.RequestValue(caller, (int)state, priority);
	}

	public void RemoveRequest(object caller)
	{
		provider.RemoveValue(caller);
	}

	private void OnInvertMouseYUpdated()
	{
		invertyMouseY = provider.InvertMouseYPreference;
	}

	public void ChangeSlowdownState(MouseSensitivityState desiredState)
	{
		if (state != desiredState)
		{
			state = desiredState;
			switch (state)
			{
			case MouseSensitivityState.Normal:
				sensitivityMultiplier = 1f;
				return;
			case MouseSensitivityState.Slow:
				sensitivityMultiplier = 0.2f;
				return;
			case MouseSensitivityState.Crawl:
				sensitivityMultiplier = 0.01f;
				return;
			case MouseSensitivityState.Locked:
				sensitivityMultiplier = 0f;
				return;
			}
			Debug.LogError(string.Format("'{0}' in '{1}' requests change to an unsupported state '{2}'. Assuming no slowdown.", "ChangeSlowdownState", "CustomMouseLook", desiredState));
			sensitivityMultiplier = 1f;
			state = MouseSensitivityState.Normal;
		}
	}

	public void ForceRotation(Transform character, Transform camera, Quaternion rotation)
	{
		m_CharacterTargetRot = rotation;
		m_CameraTargetRot = Quaternion.identity;
		if (clampVerticalRotation)
		{
			m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);
		}
		character.rotation = m_CharacterTargetRot;
		cameraHolder.rotation = m_CharacterTargetRot;
		camera.localRotation = m_CameraTargetRot;
	}

	public void ForceRotationNoTilt(Transform character, Transform camera, Quaternion rotation)
	{
		Vector3 eulerAngles = rotation.eulerAngles;
		m_CharacterTargetRot = Quaternion.Euler(0f, eulerAngles.y, 0f);
		m_CameraTargetRot = Quaternion.Euler(eulerAngles.x, 0f, 0f);
		if (clampVerticalRotation)
		{
			m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);
		}
		character.rotation = m_CharacterTargetRot;
		cameraHolder.rotation = m_CharacterTargetRot;
		camera.localRotation = m_CameraTargetRot;
	}

	public void LookRotation(Transform character, Transform camera)
	{
		Vector2 mouseAxisInput = InputManager.GetMouseAxisInput();
		LookRotation(character, camera, mouseAxisInput * sensitivityMultiplier);
	}

	public void LookRotation(Transform character, Transform camera, Vector2 mouseDelta)
	{
		if (invertyMouseY)
		{
			mouseDelta.y *= -1f;
		}
		m_CharacterTargetRot = ((character.parent != null) ? character.localRotation : Quaternion.Euler(0f, character.eulerAngles.y, 0f));
		m_CharacterTargetRot *= Quaternion.Euler(0f, mouseDelta.x, 0f);
		m_CameraTargetRot *= Quaternion.Euler(0f - mouseDelta.y, 0f, 0f);
		if (clampVerticalRotation)
		{
			m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);
		}
		Quaternion localRotation = (cameraHolder.localRotation = m_CharacterTargetRot);
		character.localRotation = localRotation;
		camera.localRotation = m_CameraTargetRot * cameraAnchor.localRotation;
	}

	private Quaternion ClampRotationAroundXAxis(Quaternion q)
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1f;
		float value = 114.59156f * Mathf.Atan(q.x);
		value = Mathf.Clamp(value, MinimumX, MaximumX);
		q.x = Mathf.Tan((float)Math.PI / 360f * value);
		return q;
	}
}
