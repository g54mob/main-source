using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Flight.Events;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CameraVantageScript : PartModifierScript, IVariableOutput
	{
		public Transform LocalOrientedCenterOfMassRigidBodies;

		private CameraController _cameraController;

		private CameraVantageData _cameraVantage;

		private Transform _transformToTrack;

		public CameraVantageData Data => _cameraVantage;

		public Vector3 FirstPersonVantagePosition
		{
			get
			{
				if (Data.UpOffset != 0f)
				{
					return _transformToTrack.position + (UseGravityAsUp ? Vector3.up : base.transform.up) * Data.UpOffset;
				}
				return _transformToTrack.TransformPoint(Data.Offset);
			}
		}

		public bool HidePart { get; private set; }

		public IRigidBody RigidBody { get; private set; }

		public Transform TransformToTrack
		{
			get
			{
				return _transformToTrack;
			}
			set
			{
				_transformToTrack = value;
				RigidBody = new RigidBodyPhysx(_transformToTrack.GetComponentInParent<Rigidbody>());
			}
		}

		public bool UseGravityAsUp { get; set; }

		public ViewMode ViewMode
		{
			get
			{
				return _cameraVantage.ViewMode;
			}
			set
			{
				_cameraVantage.ViewMode = value;
			}
		}

		public bool IsSelected { get; set; }

		public Vector3 ViewPosition { get; set; }

		public Vector3 ViewRotation { get; set; }

		[VariableOutput("Is Active")]
		private float Active
		{
			get
			{
				if (!IsSelected)
				{
					return 0f;
				}
				return 1f;
			}
		}

		[VariableOutput("Look Pitch")]
		private float LookPitch => ViewRotation.x;

		[VariableOutput("Look Roll")]
		private float LookRoll => ViewRotation.z;

		[VariableOutput("Look Yaw")]
		private float LookYaw => ViewRotation.y;

		[VariableOutput("View Offset X")]
		private float PosX => ViewPosition.x;

		[VariableOutput("View Offset Y")]
		private float PosY => ViewPosition.y;

		[VariableOutput("View Offset Z")]
		private float PosZ => ViewPosition.z;

		public void Initialize(CameraVantageData cameraVantage, bool hidePart)
		{
			_cameraVantage = cameraVantage;
			HidePart = hidePart;
			TransformToTrack = base.transform;
		}

		protected virtual void OnDestroy()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerEnteredAircraft -= OnPlayerEnteredAircraft;
				instance.PlayerExitedAircraft -= OnPlayerExitedAircraft;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
		}

		private void OnPlayerEnteredAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (e.Player.IsPrimaryLocal && e.Aircraft == base.PartScript.Aircraft)
			{
				_cameraController = CameraManagerScript.Instance.RegisterCustomCameraVantage(this);
			}
		}

		private void OnPlayerExitedAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (_cameraController != null && e.Player.IsPrimaryLocal && e.Aircraft == base.PartScript.Aircraft)
			{
				CameraManagerScript.Instance?.UnregisterCustomCameraVantage(_cameraController);
				_cameraController = null;
			}
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			if (base.LoadContext != CraftLoadContext.Flight)
			{
				return;
			}
			Transform orientedCenterOfMassRigidBodies = base.PartScript.Aircraft.OrientedCenterOfMassRigidBodies;
			GameObject gameObject = new GameObject("CenterOfMass");
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.SetPositionAndRotation(orientedCenterOfMassRigidBodies.position, orientedCenterOfMassRigidBodies.rotation);
			LocalOrientedCenterOfMassRigidBodies = gameObject.transform;
			if (HidePart)
			{
				MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].gameObject.SetActive(value: false);
				}
				Collider[] componentsInChildren2 = GetComponentsInChildren<Collider>(includeInactive: true);
				for (int i = 0; i < componentsInChildren2.Length; i++)
				{
					componentsInChildren2[i].gameObject.SetActive(value: false);
				}
			}
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerEnteredAircraft += OnPlayerEnteredAircraft;
				instance.PlayerExitedAircraft += OnPlayerExitedAircraft;
				instance.RaisePlayerEnteredAircraft(OnPlayerEnteredAircraft);
			}
		}

		public void UpdateOutputs()
		{
		}
	}
}
