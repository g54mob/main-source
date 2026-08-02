using System.Collections.Generic;
using UnityEngine;

namespace HQFPSTemplate
{
	public class PlayerCamera : PlayerComponent
	{
		[BHeader("General", true)]
		[SerializeField]
		[Tooltip("The camera root which will be rotated up & down (on the X axis).")]
		private Transform m_LookRoot;

		[SerializeField]
		private Transform m_PlayerRoot;

		[SerializeField]
		private Camera m_WorldCamera;

		[SerializeField]
		private CameraPhysicsHandler m_CameraPhysicsHandler;

		[Space]
		[SerializeField]
		[Tooltip("The up & down rotation will be inverted, if checked.")]
		private bool m_Invert;

		[BHeader("Mouse Sensitivity")]
		[SerializeField]
		[Tooltip("The higher it is, the faster the camera will rotate.")]
		private float m_Sensitivity = 5f;

		[BHeader("Mouse Smoothing")]
		[SerializeField]
		private bool m_Raw;

		[SerializeField]
		[ShowIf("m_Raw", false, 10f)]
		[Range(0f, 20f)]
		private int m_SmoothSteps = 10;

		[SerializeField]
		[ShowIf("m_Raw", false, 10f)]
		[Range(0f, 1f)]
		private float m_SmoothWeight = 0.4f;

		[BHeader("Rotation Limits")]
		[ReadOnly]
		public Vector2 m_DefaultLookLimits = new Vector2(-60f, 90f);

		[BHeader("Equipment")]
		[SerializeField]
		[Range(0.01f, 10f)]
		private float m_EquipmentWorldScale = 0.5f;

		private Vector2 m_LookAngles;

		private float m_CurrentSensitivity;

		private Vector2 m_CurrentMouseLook;

		private Vector2 m_SmoothMove;

		private List<Vector2> m_SmoothBuffer = new List<Vector2>();

		public float baseSensivity = 2.5f;

		private float m_SensitivityMod = 1f;

		private bool m_Loaded;

		public float SensitivityFactor { get; set; }

		public CameraPhysicsHandler Physics => m_CameraPhysicsHandler;

		public Camera UnityCamera => m_WorldCamera;

		public Vector2 LookAngles
		{
			get
			{
				return m_LookAngles;
			}
			set
			{
				m_LookAngles = value;
			}
		}

		public Vector2 LastMovement { get; private set; }

		public void MoveCamera(float verticalMove, float horizontalMove)
		{
			LookAngles += new Vector2(verticalMove, horizontalMove);
		}

		public void OnLoad()
		{
			m_Loaded = true;
		}

		private void Awake()
		{
			SensitivityFactor = 1f;
			base.transform.localScale = new Vector3(m_EquipmentWorldScale, m_EquipmentWorldScale, m_EquipmentWorldScale);
		}

		private void Start()
		{
			if (!m_LookRoot)
			{
				Debug.LogErrorFormat(this, "Assign the view root in the inspector!", base.name);
				base.enabled = false;
			}
			if (!m_Loaded)
			{
				m_LookAngles = new Vector2(base.transform.localEulerAngles.x, m_PlayerRoot.localEulerAngles.y);
			}
		}

		private void LateUpdate()
		{
			if (TrainGameManager.isInputActive && !TrainGameManager.isMouseLocked)
			{
				SettingsData settingsData = SettingsManager.Instance.GetSettingsData();
				m_Sensitivity = settingsData.mouseSensitivity * baseSensivity;
				m_Invert = settingsData.invertMouse;
				Vector2 lookAngles = m_LookAngles;
				m_CurrentSensitivity = m_Sensitivity * m_SensitivityMod;
				if (!base.Player.Pause.Active)
				{
					MoveView(new Vector2(base.Player.LookInput.Get().y, base.Player.LookInput.Get().x), Time.deltaTime);
				}
				LastMovement = m_LookAngles - lookAngles;
			}
		}

		private void MoveView(Vector2 lookInput, float deltaTime)
		{
			if (!m_Raw)
			{
				CalculateSmoothLookInput(lookInput, deltaTime);
				m_LookAngles.x += m_CurrentMouseLook.x * m_CurrentSensitivity * (m_Invert ? 1f : (-1f));
				m_LookAngles.y += m_CurrentMouseLook.y * m_CurrentSensitivity;
				m_LookAngles.x = ClampAngle(m_LookAngles.x, m_DefaultLookLimits.x, m_DefaultLookLimits.y);
			}
			else
			{
				m_LookAngles.x += lookInput.x * m_CurrentSensitivity * (m_Invert ? 1f : (-1f));
				m_LookAngles.y += lookInput.y * m_CurrentSensitivity;
				m_LookAngles.x = ClampAngle(m_LookAngles.x, m_DefaultLookLimits.x, m_DefaultLookLimits.y);
			}
			m_PlayerRoot.localRotation = Quaternion.Euler(0f, m_LookAngles.y, 0f);
			m_LookRoot.localRotation = Quaternion.Euler(m_LookAngles.x, 0f, 0f);
			base.Entity.LookDirection.Set(m_LookRoot.forward);
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
}
