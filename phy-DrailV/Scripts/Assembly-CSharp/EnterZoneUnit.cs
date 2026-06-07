using Bolt;
using DV;
using Ludiq;
using UnityEngine;

[UnitTitle("Enter Zone")]
[UnitSubtitle("Player enters a zone of trigger collider(s)")]
[UnitCategory("Movement")]
[TypeIcon(typeof(BoxCollider))]
public class EnterZoneUnit : GenericWaitForConditionWithMessage
{
	public class PlayerEnterDetector : MonoBehaviour
	{
		private Collider[] detectionColliders;

		public bool IsPlayerPresent { get; private set; }

		public bool FeetMode { get; set; }

		private void Awake()
		{
			detectionColliders = GetComponentsInChildren<Collider>();
			IsPlayerPresent = CheckForPlayer(detectionColliders, IsPlayerPresent);
		}

		public static bool CheckForPlayer(Collider[] detectionColliders, bool feetMode, bool defaultState = false)
		{
			if (PlayerManager.PlayerTransform == null || PlayerManager.PlayerCamera == null || !TimeUtil.IsFlowing)
			{
				return defaultState;
			}
			Vector3 vector = Vector3.zero;
			if (VRManager.IsVREnabled() && feetMode && !GamePreferences.Get<bool>(Preferences.SmoothLocomotion))
			{
				float y = ((!GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType)) ? (0f - GamePreferences.Get<float>(Preferences.PlayerRoomscaleHeight)) : (0f - GamePreferences.Get<float>(Preferences.PlayerSeatedHeight) - 1.62f));
				vector = new Vector3(0f, y, 0f);
			}
			Vector3 vector2 = (feetMode ? PlayerManager.PlayerTransform.position : PlayerManager.PlayerCamera.transform.position);
			vector2 += vector;
			bool result = false;
			for (int i = 0; i < detectionColliders.Length; i++)
			{
				if (detectionColliders[i].ClosestPoint(vector2) == vector2)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		private void LateUpdate()
		{
			IsPlayerPresent = CheckForPlayer(detectionColliders, FeetMode, IsPlayerPresent);
		}
	}

	[DoNotSerialize]
	public ValueInput markerObject;

	[DoNotSerialize]
	public ValueInput feetMode;

	protected override string DoneFieldName => "Entered";

	protected virtual bool WantedState => true;

	protected override void InternalDefinition()
	{
		markerObject = ValueInput<GameObject>("Marker", null);
		feetMode = ValueInput("Feet", @default: false);
		Requirement(markerObject, inputTrigger);
	}

	public override object PrepareContext(Flow flow)
	{
		PlayerEnterDetector playerEnterDetector = flow.GetValue<GameObject>(markerObject).AddComponent<PlayerEnterDetector>();
		playerEnterDetector.FeetMode = flow.GetValue<bool>(feetMode);
		return playerEnterDetector;
	}

	public override void CleanupContext(Flow flow, object context)
	{
		base.CleanupContext(flow, context);
		Object.Destroy((PlayerEnterDetector)context);
	}

	public override bool CheckCondition(Flow flow, object context, bool silent = false)
	{
		return ((PlayerEnterDetector)context).IsPlayerPresent == WantedState;
	}
}
