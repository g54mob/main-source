using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class SceneGizmoLookAndFeel : Settings
	{
		[SerializeField]
		private GizmoCap3DLookAndFeel _midCapLookAndFeel = new GizmoCap3DLookAndFeel();

		[SerializeField]
		private GizmoCap3DLookAndFeel[] _axesCapsLookAndFeel = new GizmoCap3DLookAndFeel[6];

		[SerializeField]
		private SceneGizmoScreenCorner _screenCorner = SceneGizmoScreenCorner.TopRight;

		[SerializeField]
		private Vector2 _screenOffset = Vector2.zero;

		[SerializeField]
		private Color _axesLabelTint = Color.white;

		[SerializeField]
		private Color _camPrjSwitchLabelTint = Color.white.KeepAllButAlpha(0.7f);

		[SerializeField]
		private bool _isCamPrjSwitchLabelVisible = true;

		private GizmoCap3DLookAndFeel AxisCapLookAndFeel => _axesCapsLookAndFeel[0];

		public SceneGizmoScreenCorner ScreenCorner
		{
			get
			{
				return _screenCorner;
			}
			set
			{
				_screenCorner = value;
			}
		}

		public Vector2 ScreenOffset
		{
			get
			{
				return _screenOffset;
			}
			set
			{
				_screenOffset = value;
			}
		}

		public Color AxesLabelTint
		{
			get
			{
				return _axesLabelTint;
			}
			set
			{
				_axesLabelTint = value;
			}
		}

		public Color CamPrjSwitchLabelTint
		{
			get
			{
				return _camPrjSwitchLabelTint;
			}
			set
			{
				_camPrjSwitchLabelTint = value;
			}
		}

		public bool IsCamPrjSwitchLabelVisible
		{
			get
			{
				return _isCamPrjSwitchLabelVisible;
			}
			set
			{
				_isCamPrjSwitchLabelVisible = value;
			}
		}

		public Texture2D CamPerspModeLabelTexture => Singleton<TexturePool>.Get.CamPerspMode;

		public Texture2D CamOrthoModeLabelTexture => Singleton<TexturePool>.Get.CamOrthoMode;

		public Color HoveredColor => AxisCapLookAndFeel.HoveredColor;

		public GizmoCap3DType AxesCapType => AxisCapLookAndFeel.CapType;

		public GizmoCap3DType MidCapType => _midCapLookAndFeel.CapType;

		public static int ScreenSize => 90;

		public static float MidCapBoxSize => 1.01f;

		public static float MidCapSphereRadius => 0.73f;

		public static float AxisLabelScreenSize => 10f;

		public static float AxisCamAlignFadeOutThreshold => 0.91f;

		public static float AxisCamAlignFadeOutDuration => 0.2f;

		public static float AxisCamAlignFadeOutAlpha => 0f;

		public SceneGizmoLookAndFeel()
		{
			for (int i = 0; i < _axesCapsLookAndFeel.Length; i++)
			{
				_axesCapsLookAndFeel[i] = new GizmoCap3DLookAndFeel();
			}
			SetMidCapColor(RTSystemValues.CenterAxisColor);
			SetMidCapType(GizmoCap3DType.Box);
			SetAxisCapColor(RTSystemValues.XAxisColor, 0, AxisSign.Positive);
			SetAxisCapColor(RTSystemValues.YAxisColor, 1, AxisSign.Positive);
			SetAxisCapColor(RTSystemValues.ZAxisColor, 2, AxisSign.Positive);
			SetAxisCapColor(RTSystemValues.CenterAxisColor, 0, AxisSign.Negative);
			SetAxisCapColor(RTSystemValues.CenterAxisColor, 1, AxisSign.Negative);
			SetAxisCapColor(RTSystemValues.CenterAxisColor, 2, AxisSign.Negative);
			SetAxisCapType(GizmoCap3DType.Cone);
			_midCapLookAndFeel.BoxWidth = MidCapBoxSize;
			_midCapLookAndFeel.BoxHeight = MidCapBoxSize;
			_midCapLookAndFeel.BoxDepth = MidCapBoxSize;
			_midCapLookAndFeel.SphereRadius = MidCapSphereRadius;
		}

		public void SetMidCapColor(Color color)
		{
			_midCapLookAndFeel.Color = color;
		}

		public void SetAxisCapColor(Color color, int axisIndex, AxisSign axisSign)
		{
			GetAxisCapLookAndFeel(axisIndex, axisSign).Color = color;
		}

		public Color GetAxisCapColor(int axisIndex, AxisSign axisSign)
		{
			return GetAxisCapLookAndFeel(axisIndex, axisSign).Color;
		}

		public void SetHoveredColor(Color hoveredColor)
		{
			GizmoCap3DLookAndFeel[] axesCapsLookAndFeel = _axesCapsLookAndFeel;
			for (int i = 0; i < axesCapsLookAndFeel.Length; i++)
			{
				axesCapsLookAndFeel[i].HoveredColor = hoveredColor;
			}
			_midCapLookAndFeel.HoveredColor = hoveredColor;
		}

		public void SetMidCapFillMode(GizmoFillMode3D fillMode)
		{
			_midCapLookAndFeel.FillMode = fillMode;
		}

		public void SetAxisCapFillMode(GizmoFillMode3D fillMode)
		{
			GizmoCap3DLookAndFeel[] axesCapsLookAndFeel = _axesCapsLookAndFeel;
			for (int i = 0; i < axesCapsLookAndFeel.Length; i++)
			{
				axesCapsLookAndFeel[i].FillMode = fillMode;
			}
		}

		public void SetMidCapShadeMode(GizmoShadeMode shadeMode)
		{
			_midCapLookAndFeel.ShadeMode = shadeMode;
		}

		public void SetAxisCapShadeMode(GizmoShadeMode shadeMode)
		{
			GizmoCap3DLookAndFeel[] axesCapsLookAndFeel = _axesCapsLookAndFeel;
			for (int i = 0; i < axesCapsLookAndFeel.Length; i++)
			{
				axesCapsLookAndFeel[i].ShadeMode = shadeMode;
			}
		}

		public List<Enum> GetAllowedMidCapTypes()
		{
			return new List<Enum>
			{
				GizmoCap3DType.Box,
				GizmoCap3DType.Sphere
			};
		}

		public List<Enum> GetAllowedAxesCapTypes()
		{
			return new List<Enum>
			{
				GizmoCap3DType.Cone,
				GizmoCap3DType.Pyramid
			};
		}

		public bool IsMidCapTypeAllowed(GizmoCap3DType capType)
		{
			if (capType != GizmoCap3DType.Box)
			{
				return capType == GizmoCap3DType.Sphere;
			}
			return true;
		}

		public void SetMidCapType(GizmoCap3DType capType)
		{
			if (IsMidCapTypeAllowed(capType))
			{
				_midCapLookAndFeel.CapType = capType;
			}
		}

		public bool IsAxisCapTypeAllowed(GizmoCap3DType capType)
		{
			if (capType != GizmoCap3DType.Cone)
			{
				return capType == GizmoCap3DType.Pyramid;
			}
			return true;
		}

		public void SetAxisCapType(GizmoCap3DType capType)
		{
			GizmoCap3DLookAndFeel[] axesCapsLookAndFeel = _axesCapsLookAndFeel;
			for (int i = 0; i < axesCapsLookAndFeel.Length; i++)
			{
				axesCapsLookAndFeel[i].CapType = capType;
			}
		}

		public float GetAxesLabelWorldSize(Camera gizmoCam, Vector3 labelWorldPos)
		{
			return gizmoCam.ScreenToEstimatedWorldSize(labelWorldPos, AxisLabelScreenSize);
		}

		public Vector2 CalculateMaxPrjSwitchLabelRectSize()
		{
			Vector2 lhs = new Vector2(CamOrthoModeLabelTexture.width, CamOrthoModeLabelTexture.height);
			Vector2 rhs = new Vector2(CamPerspModeLabelTexture.width, CamPerspModeLabelTexture.height);
			return Vector2.Max(lhs, rhs);
		}

		public void ConnectMidCapLookAndFeel(GizmoCap3D midCap)
		{
			midCap.SharedLookAndFeel = _midCapLookAndFeel;
		}

		public void ConnectAxisCapLookAndFeel(GizmoCap3D axisCap, int axisIndex, AxisSign axisSign)
		{
			axisCap.SharedLookAndFeel = GetAxisCapLookAndFeel(axisIndex, axisSign);
		}

		private GizmoCap3DLookAndFeel GetAxisCapLookAndFeel(int axisIndex, AxisSign axisSign)
		{
			if (axisSign == AxisSign.Positive)
			{
				return _axesCapsLookAndFeel[axisIndex];
			}
			return _axesCapsLookAndFeel[axisIndex + 3];
		}
	}
}
