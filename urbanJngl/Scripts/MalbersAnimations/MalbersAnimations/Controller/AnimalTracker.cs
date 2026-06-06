using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Animal Controller/Animal Tracker")]
	[DefaultExecutionOrder(10000)]
	public class AnimalTracker : MonoBehaviour
	{
		[RequiredField]
		public MAnimal animal;

		[RequiredField]
		public Transform Tracker;

		[Tooltip("Unparent the Tracker")]
		public bool NoParent = true;

		[Tooltip("Use FixedUpdate instead of Update")]
		public bool FixedUpdate;

		private float CurrentLerp;

		public List<TransformTracker> Trackers = new List<TransformTracker>();

		public float DebugSize = 0.05f;

		private TransformTracker Current;

		private bool FoundMode;

		[HideInInspector]
		[SerializeField]
		private int selectedIndex;

		public int CurrentIndex { get; private set; }

		public int CurrentState { get; private set; }

		public int LastState { get; private set; }

		public int LastStance { get; private set; }

		public int CurrentStance { get; private set; }

		public int CurrentStartMode { get; private set; }

		public int CurrentExitMode { get; private set; }

		private void OnEnable()
		{
			animal.OnStateChange.AddListener(OnStateChange);
			animal.OnStanceChange.AddListener(OnStanceChange);
			animal.OnModeStart.AddListener(OnModeStart);
			animal.OnModeEnd.AddListener(OnModeEnd);
			if (NoParent)
			{
				Tracker.SetParent(null);
			}
			Initialize();
			if (FixedUpdate)
			{
				StartCoroutine(UpdateCycleFixed());
			}
			else
			{
				StartCoroutine(UpdateCycle());
			}
			OnStanceChange(animal.ActiveStance.ID);
			CurrentLerp = 0f;
		}

		private IEnumerator UpdateCycleFixed()
		{
			WaitForFixedUpdate fixedTime = new WaitForFixedUpdate();
			while (true)
			{
				yield return fixedTime;
				UpdateTrackerPos(Time.fixedDeltaTime);
			}
		}

		private IEnumerator UpdateCycle()
		{
			new WaitForFixedUpdate();
			while (true)
			{
				yield return null;
				UpdateTrackerPos(Time.deltaTime);
			}
		}

		private void Initialize()
		{
			foreach (TransformTracker tracker in Trackers)
			{
				if (tracker.RelativeTo == null || tracker.RelativeTo == base.transform)
				{
					tracker.RelativeTo = base.transform.parent;
				}
			}
		}

		private void OnDisable()
		{
			animal.OnStateChange.RemoveListener(OnStateChange);
			animal.OnStanceChange.RemoveListener(OnStanceChange);
			animal.OnModeStart.RemoveListener(OnModeStart);
			animal.OnModeEnd.RemoveListener(OnModeEnd);
			StopAllCoroutines();
		}

		private void OnStateChange(int state)
		{
			FindState(state);
			LastState = CurrentState;
			CurrentState = state;
		}

		private void OnStanceChange(int stance)
		{
			bool num = FindStance(stance);
			LastStance = CurrentStance;
			CurrentStance = stance;
			if (!num)
			{
				FindState(CurrentState);
			}
		}

		private bool FindState(int state)
		{
			bool flag = false;
			for (int i = 0; i < Trackers.Count; i++)
			{
				TransformTracker transformTracker = Trackers[i];
				if (!transformTracker.Active)
				{
					continue;
				}
				bool num = transformTracker.CheckState && transformTracker.State.ID == state;
				bool flag2 = !transformTracker.CheckStance || (transformTracker.CheckStance && (int)transformTracker.Stance == CurrentStance);
				if (num && flag2 && !flag && transformTracker.RepositionTracker)
				{
					transformTracker.reaction?.React(animal);
					flag = true;
					if (transformTracker.RepositionTracker)
					{
						CurrentLerp = 0f;
						CurrentIndex = i;
						Current = transformTracker;
					}
				}
			}
			return flag;
		}

		private bool FindStance(int stance)
		{
			bool flag = false;
			for (int i = 0; i < Trackers.Count; i++)
			{
				TransformTracker transformTracker = Trackers[i];
				if (!transformTracker.Active)
				{
					continue;
				}
				bool flag2 = transformTracker.CheckStance && transformTracker.Stance.ID == stance;
				if ((!transformTracker.CheckState || (transformTracker.CheckState && (int)transformTracker.State == CurrentState)) && flag2 && !flag)
				{
					transformTracker.reaction?.React(animal);
					flag = true;
					if (transformTracker.RepositionTracker)
					{
						CurrentLerp = 0f;
						CurrentIndex = i;
						Current = transformTracker;
					}
				}
			}
			return flag;
		}

		private void OnModeStart(int Mode, int Ability)
		{
			for (int i = 0; i < Trackers.Count; i++)
			{
				TransformTracker transformTracker = Trackers[i];
				if (transformTracker.ModeAction != TransformTracker.ModeStatus.Start)
				{
					continue;
				}
				bool flag = !transformTracker.CheckState || (transformTracker.CheckState && (int)transformTracker.State == CurrentState);
				bool flag2 = !transformTracker.CheckStance || (transformTracker.CheckStance && (int)transformTracker.Stance == CurrentStance);
				if (transformTracker.CheckMode && transformTracker.Mode.ID == Mode && flag && flag2 && (!transformTracker.CheckAbility || (transformTracker.CheckAbility && transformTracker.Ability == Ability)))
				{
					FoundMode = true;
					transformTracker.reaction?.React(animal);
					if (transformTracker.RepositionTracker)
					{
						CurrentLerp = 0f;
						CurrentIndex = i;
						Current = transformTracker;
					}
				}
			}
		}

		private void OnModeEnd(int Mode, int Ability)
		{
			foreach (TransformTracker tracker in Trackers)
			{
				if (tracker.ModeAction == TransformTracker.ModeStatus.Exit)
				{
					bool flag = !tracker.CheckState || (tracker.CheckState && (int)tracker.State == CurrentState);
					bool flag2 = !tracker.CheckStance || (tracker.CheckStance && (int)tracker.Stance == CurrentStance);
					if (tracker.CheckMode && tracker.Mode.ID == Mode && flag && flag2 && (!tracker.CheckAbility || (tracker.CheckAbility && tracker.Ability == Ability)))
					{
						tracker.reaction?.React(animal);
						CurrentLerp = 0f;
					}
				}
			}
			if (FoundMode)
			{
				FindState(CurrentState);
			}
			FoundMode = false;
		}

		public void SetAnimal(GameObject go)
		{
			if (animal != go)
			{
				animal.OnStateChange.RemoveListener(OnStateChange);
				animal.OnStanceChange.RemoveListener(OnStanceChange);
				animal.OnModeStart.RemoveListener(OnModeStart);
				animal.OnModeEnd.RemoveListener(OnModeEnd);
			}
			if (go.TryGetComponent<MAnimal>(out animal))
			{
				animal.OnStateChange.AddListener(OnStateChange);
				animal.OnStanceChange.AddListener(OnStanceChange);
				animal.OnModeStart.AddListener(OnModeStart);
				animal.OnModeEnd.AddListener(OnModeEnd);
				OnStateChange(animal.ActiveStateID);
				OnStanceChange(animal.ActiveStance.ID);
			}
		}

		public void SetAnimal(Component an)
		{
			SetAnimal(an.gameObject);
		}

		private void UpdateTrackerPos(float deltatime)
		{
			if (Current != null && !(Tracker == null))
			{
				CurrentLerp = Mathf.Lerp(CurrentLerp, Current.Lerp, deltatime * Current.Lerp);
				Tracker.SetPositionAndRotation(Vector3.Slerp(Tracker.position, Current.RelativeTo.TransformPoint(Current.Position), deltatime * CurrentLerp), Quaternion.Slerp(Tracker.rotation, Current.RelativeTo.rotation * Quaternion.Euler(Current.Rotation), deltatime * CurrentLerp));
			}
		}

		private void Reset()
		{
			animal = this.FindComponent<MAnimal>();
			Trackers = new List<TransformTracker>(1)
			{
				new TransformTracker
				{
					Active = true,
					RelativeTo = base.transform,
					State = MTools.GetInstance<StateID>("Idle"),
					Stance = MTools.GetInstance<StanceID>("Default"),
					Ability = -1,
					Lerp = 2f,
					Position = new Vector3(0f, 0f, 0.25f),
					Rotation = new Vector3(0f, 0f, 0f)
				}
			};
		}

		private void OnValidate()
		{
			foreach (TransformTracker tracker in Trackers)
			{
				string text = "";
				if ((tracker.track & TrackerType.State) == TrackerType.State)
				{
					text = text + " [" + ((tracker.State != null) ? tracker.State.name : "NONE") + "]";
				}
				if ((tracker.track & TrackerType.Stance) == TrackerType.Stance)
				{
					text = text + " [" + ((tracker.State != null) ? tracker.Stance.name : "NONE") + "]";
				}
				if ((tracker.track & TrackerType.Mode) == TrackerType.Mode)
				{
					text = text + " [" + ((tracker.Mode != null) ? tracker.Mode.name : "NONE") + "]";
				}
				if ((tracker.track & TrackerType.Ability) == TrackerType.Ability)
				{
					text = text + " Ability [" + tracker.Ability + "]";
				}
				tracker.name = text;
				if (tracker.RelativeTo == null || tracker.RelativeTo == base.transform)
				{
					tracker.RelativeTo = base.transform.parent;
				}
			}
		}

		private void OnDrawGizmosSelected()
		{
			foreach (TransformTracker tracker in Trackers)
			{
				if (!(tracker.RelativeTo == null) && tracker.RepositionTracker)
				{
					Gizmos.color = (tracker.Active ? tracker.DebugColor : Color.red);
					Matrix4x4 matrix = Gizmos.matrix;
					Gizmos.matrix = Matrix4x4.TRS(tracker.RelativeTo.TransformPoint(tracker.Position), tracker.RelativeTo.rotation * Quaternion.Euler(tracker.Rotation), Vector3.one);
					Gizmos.DrawCube(Vector3.zero, Vector3.one * DebugSize);
					Gizmos.matrix = matrix;
					Gizmos.DrawLine(tracker.RelativeTo.TransformPoint(tracker.Position), tracker.RelativeTo.position);
				}
			}
		}
	}
}
