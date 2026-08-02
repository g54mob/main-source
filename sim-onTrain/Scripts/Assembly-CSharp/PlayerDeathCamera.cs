using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerDeathCamera : MonoBehaviour
{
	[Header("Target")]
	public Transform playerBodyTarget;

	[Header("Orbit Settings")]
	[Tooltip("Yörünge yarıçapı (metre)")]
	public float orbitRadius = 1.5f;

	[Tooltip("Uzaklaşma animasyon süresi (saniye)")]
	public float zoomOutDuration = 0.8f;

	private float currentOrbitRadius;

	[Header("Mouse Sensitivity - PlayerCamera ile aynı")]
	[SerializeField]
	private bool m_Raw;

	[SerializeField]
	[Range(0f, 20f)]
	private int m_SmoothSteps = 10;

	[SerializeField]
	[Range(0f, 1f)]
	private float m_SmoothWeight = 0.4f;

	[SerializeField]
	private float baseSensivity = 2.5f;

	private float m_Sensitivity;

	[Header("Rotation Limits")]
	[Tooltip("Yukarı/aşağı bakış limitleri")]
	public Vector2 m_DefaultLookLimits = new Vector2(-30f, 60f);

	private float m_HorizontalAngle;

	private float m_VerticalAngle = 20f;

	private Vector2 m_CurrentMouseLook;

	private Vector2 m_SmoothMove;

	private List<Vector2> m_SmoothBuffer = new List<Vector2>();

	private void Start()
	{
		InitializeAngles();
	}

	private void OnEnable()
	{
		base.transform.DOKill();
		InitializeAngles();
		m_SmoothBuffer.Clear();
		StartOrbitAnimation();
	}

	public void StartOrbitAnimation()
	{
		currentOrbitRadius = 0f;
		DOTween.To(() => currentOrbitRadius, delegate(float x)
		{
			currentOrbitRadius = x;
		}, orbitRadius, zoomOutDuration).SetEase(Ease.OutCubic);
		Debug.Log($"[PlayerDeathCamera] Orbit animation started: 0 -> {orbitRadius} in {zoomOutDuration}s");
	}

	private void InitializeAngles()
	{
		if (playerBodyTarget != null)
		{
			Vector3 vector = base.transform.position - playerBodyTarget.position;
			if (vector.magnitude > 0.001f)
			{
				m_HorizontalAngle = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
				m_VerticalAngle = Mathf.Asin(vector.y / vector.magnitude) * 57.29578f;
			}
			else
			{
				m_HorizontalAngle = 0f;
				m_VerticalAngle = 20f;
			}
			Debug.Log($"[PlayerDeathCamera] Initialized - HAngle: {m_HorizontalAngle}, VAngle: {m_VerticalAngle}");
		}
		else
		{
			Debug.LogWarning("[PlayerDeathCamera] playerBodyTarget is null!");
		}
	}

	private void LateUpdate()
	{
		if (playerBodyTarget == null)
		{
			Debug.LogWarning("[PlayerDeathCamera] playerBodyTarget is null in LateUpdate!");
			return;
		}
		m_Sensitivity = SettingsManager.Instance.GetSettingsData().mouseSensitivity * baseSensivity;
		Vector2 lookInput = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
		if (!m_Raw)
		{
			CalculateSmoothLookInput(lookInput, Time.deltaTime);
			m_HorizontalAngle += m_CurrentMouseLook.y * m_Sensitivity;
			m_VerticalAngle -= m_CurrentMouseLook.x * m_Sensitivity;
		}
		else
		{
			m_HorizontalAngle += lookInput.y * m_Sensitivity;
			m_VerticalAngle -= lookInput.x * m_Sensitivity;
		}
		m_VerticalAngle = ClampAngle(m_VerticalAngle, m_DefaultLookLimits.x, m_DefaultLookLimits.y);
		float f = m_VerticalAngle * (MathF.PI / 180f);
		float f2 = m_HorizontalAngle * (MathF.PI / 180f);
		Vector3 vector = new Vector3(currentOrbitRadius * Mathf.Cos(f) * Mathf.Sin(f2), currentOrbitRadius * Mathf.Sin(f), currentOrbitRadius * Mathf.Cos(f) * Mathf.Cos(f2));
		base.transform.position = playerBodyTarget.position + vector;
		base.transform.LookAt(playerBodyTarget);
	}

	private float ClampAngle(float angle, float min, float max)
	{
		if (angle > 360f)
		{
			angle -= 360f;
		}
		else if (angle < -360f)
		{
			angle += 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	private void CalculateSmoothLookInput(Vector2 lookInput, float deltaTime)
	{
		if (deltaTime != 0f)
		{
			m_SmoothMove = new Vector2(lookInput.x, lookInput.y);
			m_SmoothSteps = Mathf.Clamp(m_SmoothSteps, 1, 20);
			m_SmoothWeight = Mathf.Clamp01(m_SmoothWeight);
			while (m_SmoothBuffer.Count > m_SmoothSteps)
			{
				m_SmoothBuffer.RemoveAt(0);
			}
			m_SmoothBuffer.Add(m_SmoothMove);
			float num = 1f;
			Vector2 zero = Vector2.zero;
			float num2 = 0f;
			for (int num3 = m_SmoothBuffer.Count - 1; num3 > 0; num3--)
			{
				zero += m_SmoothBuffer[num3] * num;
				num2 += num;
				num *= m_SmoothWeight / (deltaTime * 60f);
			}
			num2 = Mathf.Max(1f, num2);
			m_CurrentMouseLook = zero / num2;
		}
	}
}
