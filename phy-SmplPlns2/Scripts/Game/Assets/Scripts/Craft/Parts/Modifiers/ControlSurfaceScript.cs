using System;
using Assets.Scripts.Flight;
using Jundroo.Common.Utils;
using UnityEngine;
using UnityFS;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	public class ControlSurfaceScript : MonoBehaviour
	{
		public const float ControlSurfaceTransitTime = 0.3f;

		private Func<bool> _activatedFunction;

		private float _angle;

		private AnimationCurve _inputCurve;

		private Func<float> _inputFunction;

		private MeshFilter _meshFilter;

		private float _prevInputValue;

		public AircraftControls AircraftControls { get; private set; }

		public float Angle
		{
			get
			{
				return _angle;
			}
			set
			{
				if (Angle != value)
				{
					_angle = value;
					base.transform.localRotation = Quaternion.AngleAxis(_angle, HingeAxis);
				}
			}
		}

		public ControlSurfaceData ControlSurface { get; set; }

		public ControlSurface ControlSurfacePhysics { get; set; }

		public bool Damaged { get; set; }

		public Vector3 HingeAxis { get; set; }

		public Mesh Mesh
		{
			get
			{
				return _meshFilter.mesh;
			}
			set
			{
				Mesh mesh = _meshFilter.mesh;
				if (mesh != null)
				{
					UnityEngine.Object.Destroy(mesh);
				}
				_meshFilter.mesh = value;
				string text = value.name;
				Mesh mesh2 = _meshFilter.mesh;
				value.name = text;
				if (value != mesh2)
				{
					Debug.LogWarning($"Control surface mesh leaked. Original: {value.name} ({value.GetInstanceID()}), After Assignment: {mesh2.name} ({mesh2.GetInstanceID()})");
				}
			}
		}

		public MeshRenderer MeshRenderer { get; private set; }

		public WingScript WingScript { get; set; }

		private float ControlSurfaceStep => Time.deltaTime / 0.3f;

		public void CreateComponents()
		{
			MeshRenderer = GetComponent<MeshRenderer>();
			_meshFilter = GetComponent<MeshFilter>();
		}

		public void Initialize(PartScript part, bool createPhysics)
		{
			_inputCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
			AircraftControls = part.Aircraft.Controls;
			if (!createPhysics)
			{
				return;
			}
			Wing wingPhysicsScript = WingScript.WingPhysicsScript;
			ControlSurfacePhysics = wingPhysicsScript.gameObject.AddComponent<ControlSurface>();
			ControlSurfacePhysics.AircraftControls = part.Aircraft.Controls;
			ControlSurfacePhysics.MaxDeflectionDegrees = ControlSurface.MaxDeflectionDegree;
			ControlSurfacePhysics.RootHingeDistanceFromTrailingEdge = WingScript.Wing.HingeDistanceFromTrailingEdge;
			ControlSurfacePhysics.TipHingeDistanceFromTrailingEdge = WingScript.Wing.HingeDistanceFromTrailingEdge;
			ControlSurfacePhysics.AffectedSections = new bool[wingPhysicsScript.SectionCount];
			ControlSurfacePhysics.AxisName = ControlSurface.InputId;
			ControlSurfacePhysics.SetControllable(enable: true);
			for (int i = ControlSurface.Start; i < ControlSurface.End; i++)
			{
				if (i < ControlSurfacePhysics.AffectedSections.Length)
				{
					ControlSurfacePhysics.AffectedSections[i] = true;
				}
			}
		}

		protected virtual void FixedUpdate()
		{
			if (Damaged || PauseManager.Paused)
			{
				return;
			}
			float num = 0f;
			if (AircraftControls != null && WingScript.LoadContext != CraftLoadContext.Flight)
			{
				string text = ControlSurface.InputId;
				bool flag = text.StartsWith("-");
				if (flag)
				{
					text = text.Remove(0, 1);
				}
				switch (text)
				{
				case "Roll":
					num = (flag ? (0f - AircraftControls.Roll) : AircraftControls.Roll);
					break;
				case "Pitch":
					num = (flag ? (0f - AircraftControls.Pitch) : AircraftControls.Pitch);
					break;
				case "Yaw":
					num = (flag ? (0f - AircraftControls.Yaw) : AircraftControls.Yaw);
					break;
				case "VTOL":
					num = (flag ? (0f - AircraftControls.Vtol) : AircraftControls.Vtol);
					break;
				case "Trim":
					num = (flag ? (0f - AircraftControls.Trim) : AircraftControls.Trim);
					break;
				}
			}
			else
			{
				num = _inputFunction();
			}
			bool flag2 = false;
			if (WingScript.Wing.Inverted)
			{
				flag2 = ControlSurface.AutoInvert;
			}
			if (ControlSurface.Invert)
			{
				flag2 = !flag2;
			}
			float num2 = 0f;
			if (ControlSurface.Trim == ControlSurfaceData.TrimType.On)
			{
				num2 = AircraftControls.Trim * 0.25f;
			}
			else if (ControlSurface.Trim == ControlSurfaceData.TrimType.Inverted)
			{
				num2 = (0f - AircraftControls.Trim) * 0.25f;
			}
			num += num2;
			if (flag2)
			{
				num *= -1f;
			}
			if (!_activatedFunction())
			{
				if (ControlSurface.ActivationGroupLocksInput)
				{
					return;
				}
				num = 0f;
			}
			if (float.IsNaN(num))
			{
				Debug.LogErrorFormat("Input is NaN for: {0}", ControlSurface.InputId);
				return;
			}
			float time = Mathf.Clamp01(Mathf.Abs(num));
			float num3 = _inputCurve.Evaluate(time);
			num3 *= Mathf.Sign(num);
			float num4 = _prevInputValue + ((num3 > _prevInputValue) ? ControlSurfaceStep : (0f - ControlSurfaceStep));
			if (Utilities.CompareFloats(num4, num3, ControlSurfaceStep + 0.0001f))
			{
				num4 = num3;
			}
			Angle = num4 * (float)ControlSurface.MaxDeflectionDegree;
			if (ControlSurfacePhysics != null)
			{
				ControlSurfacePhysics.CurrentDeflection = Angle;
			}
			_prevInputValue = num4;
		}

		protected virtual void Start()
		{
			_inputFunction = AircraftControls.GetAxisGetter(ControlSurface.InputId, -1f, WingScript.PartScript);
			_activatedFunction = AircraftControls.GetActivatorGetter(ControlSurface.ActivationString, WingScript.PartScript, valueIfZero: true);
		}
	}
}
