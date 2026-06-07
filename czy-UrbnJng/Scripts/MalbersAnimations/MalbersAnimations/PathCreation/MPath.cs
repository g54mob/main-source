using System.Collections;
using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations.PathCreation
{
	[AddComponentMenu("Malbers/Animal Controller/Path")]
	public class MPath : MonoBehaviour
	{
		[RequiredField]
		[Tooltip("Path Reference")]
		public IPath Path;

		[Tooltip("The Animal will align automatically when is near the Path ")]
		public BoolReference Automatic = new BoolReference(value: true);

		[Tooltip("If the Animal is already on another Path then change to the new path. Else use the Path Input on your character")]
		public BoolReference AutoChangePath = new BoolReference(value: true);

		[Tooltip("Radius to check if the Character can Enter this path")]
		[Min(0f)]
		public float SearchRadius = 0.5f;

		[Tooltip("Orient Smothness per path")]
		[Min(0f)]
		public float OrientSmoothness = 1f;

		[Tooltip("Offset of the Radius on the Path")]
		public Vector3 SearchOffset = new Vector3(0f, 0.5f, 0f);

		[Tooltip("Local Offset of the Animal Position with the Path")]
		public Vector3 AlignmentOffset = new Vector3(0f, 0f, 0f);

		[Tooltip("Time needed so the animal can enter the same path again")]
		[Min(0f)]
		public float pathCooldown = 1f;

		[Tooltip("The Animal Can Exit at the start of the path")]
		public BoolReference CanExitOnStart = new BoolReference(value: true);

		[Tooltip("The Animal Can Exit at the end of the path")]
		public BoolReference CanExitOnEnd = new BoolReference(value: true);

		[Tooltip("The Animal Can Exit at the in the middle of the path (Using Input)")]
		public BoolReference CanExitOnMiddle = new BoolReference(value: true);

		[Tooltip("Rotate the Character using the Rotation Value Path Points")]
		public BoolReference usePathRotation = new BoolReference(value: false);

		[Tooltip("Don't allow the Character to Rotate on the Spline... Move Backwards")]
		public BoolReference LockRotation = new BoolReference(value: false);

		[Tooltip("Point the Animal always from Start to End of the Path")]
		public PathFollowDir FollowDirection;

		[Tooltip("Search for the Animal when is inside the Trigger Bounds")]
		[Min(0f)]
		public float interval = 0.1f;

		[RequiredField]
		[Tooltip("This trigger will activate the search when any animal had entered the trigger")]
		public BoxCollider PathBounds;

		[Min(0f)]
		[Tooltip("Expand the Bounds this amount")]
		public float expand = 1f;

		[Tooltip("Layer to find the Animals")]
		public LayerReference Layer = new LayerReference(1048576);

		[Tooltip("When the Animal Enters the Path, it will activate this State")]
		public StateID ActivateState;

		[Tooltip("Remove Grounded From the Animal so it Aligns Directly to the Spline Path")]
		public bool IgnoreGrounded = true;

		[Tooltip("Ignore Vertical Alignment do just Horizontal Alignment")]
		public bool IgnoreVertical = true;

		[Tooltip("If this Path is activated while the character is on another path, Ignore Old Path Reactions")]
		public bool NoExitPathReactions;

		[Tooltip("While the animal is on the path, all these states will be disabled")]
		public List<StateID> DisableStates;

		[Tooltip("States that can be used to exit the path or ignore the Path")]
		public List<StateID> IgnoreStates;

		[Tooltip("Modes that can be used to exit early the Path")]
		public List<ModeID> IgnoreModes;

		[Tooltip("The Animal Exit/Ignore the path if is on any Mode")]
		public BoolReference exitAnyMode = new BoolReference(value: false);

		[SerializeField]
		[HideInInspector]
		private TriggerProxy BoundsProxy;

		private float m_PathPosition;

		private float m_PreviousPathPosition;

		[Tooltip("Adds a reaction to the Animal entering the Path")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction EnterReaction;

		[Tooltip("Adds a reaction to the Animal exiting the Path")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction ExitReaction;

		[Tooltip("Adds a reaction to the Animal entering the path from the Start point of the Path")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction EnterFromStart;

		[Tooltip("Adds a reaction to the Animal entering the path from the End point of the Path")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction EnterFromEnd;

		[Tooltip("Adds a reaction to the Animal entering the path from the middle of the Path")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction EnterFromMiddle;

		[Tooltip("Adds a reaction to the Animal exiting the path from the start of the Path")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction ExitFromStart;

		[Tooltip("Adds a reaction to the Animal exiting the path from the End of the Path")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction ExitFromEnd;

		[Tooltip("Adds a reaction to the Animal exiting the path from the Middle of the Path")]
		[SerializeReference]
		[SubclassSelector]
		public Reaction ExitFromMiddle;

		[Tooltip("Stores the Current Path Position of the Character in a Transform")]
		public TransformReference PathPosition = new TransformReference();

		public PathConstraintEvent OnEnterBounds = new PathConstraintEvent();

		public PathConstraintEvent OnExitBounds = new PathConstraintEvent();

		public BoolEvent CanEnterPath = new BoolEvent();

		public PathConstraintEvent OnEnterPath = new PathConstraintEvent();

		public PathConstraintEvent OnExitPath = new PathConstraintEvent();

		public BoolEvent IsOnEndOfPath = new BoolEvent();

		public BoolEvent IsOnStartOfPath = new BoolEvent();

		public HashSet<MPathConstraint> ActivePathContraints = new HashSet<MPathConstraint>();

		public bool debug;

		public static List<MPath> Paths;

		private IEnumerator I_CheckInBounds;

		[HideInInspector]
		[SerializeField]
		private int Editor_Tabs1;

		public bool IsClosed => Path.IsClosed;

		public bool ReachEnd { get; internal set; }

		public bool ReachStart { get; internal set; }

		public bool InsidePathSphere { get; set; }

		public void SetEndOfPathEvent(bool v)
		{
			BoolEvent isOnEndOfPath = IsOnEndOfPath;
			bool arg = (ReachEnd = v);
			isOnEndOfPath.Invoke(arg);
		}

		public void SetStartOfPathEvent(bool v)
		{
			BoolEvent isOnStartOfPath = IsOnStartOfPath;
			bool arg = (ReachStart = v);
			isOnStartOfPath.Invoke(arg);
		}

		public void Debugging(string value)
		{
		}

		private void Awake()
		{
			if (BoundsProxy == null && PathBounds != null && !PathBounds.TryGetComponent<TriggerProxy>(out BoundsProxy))
			{
				BoundsProxy = PathBounds.gameObject.AddComponent<TriggerProxy>();
			}
			BoundsProxy.Layer = Layer;
			PathBounds.isTrigger = true;
		}

		private void OnEnable()
		{
			if (Paths == null)
			{
				Paths = new List<MPath>();
			}
			Paths.Add(this);
			BoundsProxy?.OnGameObjectEnter.AddListener(_OnBoundsTriggerEnter);
			BoundsProxy?.OnGameObjectExit.AddListener(_OnBoundsTriggerExit);
			if (!TryGetComponent<IPath>(out Path))
			{
				Debugging("Path Not found. Disable All");
				base.enabled = false;
				PathBounds.enabled = false;
			}
		}

		private void OnDisable()
		{
			BoundsProxy?.OnGameObjectEnter.RemoveListener(_OnBoundsTriggerEnter);
			BoundsProxy?.OnGameObjectExit.RemoveListener(_OnBoundsTriggerExit);
			Paths?.Remove(this);
		}

		private void _OnBoundsTriggerEnter(GameObject gameObject)
		{
			MPathConstraint mPathConstraint = gameObject.FindComponent<MPathConstraint>();
			if ((bool)mPathConstraint)
			{
				ActivePathContraints.Add(mPathConstraint);
				OnEnterBounds.Invoke(mPathConstraint);
				Debugging(base.name + ".Constraint Detected: " + mPathConstraint.name);
				if (I_CheckInBounds == null)
				{
					I_CheckInBounds = CheckInBounds();
					StartCoroutine(I_CheckInBounds);
				}
			}
		}

		private void _OnBoundsTriggerExit(GameObject gameObject)
		{
			MPathConstraint mPathConstraint = gameObject.FindComponent<MPathConstraint>();
			if ((bool)mPathConstraint)
			{
				ActivePathContraints.Remove(mPathConstraint);
				OnExitBounds.Invoke(mPathConstraint);
				Debugging(base.name + ".Constraint Removed: " + mPathConstraint.name);
				if (ActivePathContraints.Count == 0 && I_CheckInBounds != null)
				{
					StopCoroutine(I_CheckInBounds);
					I_CheckInBounds = null;
				}
			}
		}

		private IEnumerator CheckInBounds()
		{
			WaitForSeconds WaitTime = new WaitForSeconds(interval);
			while (ActivePathContraints.Count > 0)
			{
				InBounds();
				yield return WaitTime;
			}
		}

		private void Reset()
		{
			if (Path == null)
			{
				Path = GetComponent<IPath>();
			}
			if (!TryGetComponent<BoxCollider>(out PathBounds))
			{
				PathBounds = base.gameObject.AddComponent<BoxCollider>();
			}
			if (BoundsProxy == null && !PathBounds.TryGetComponent<TriggerProxy>(out BoundsProxy))
			{
				BoundsProxy = PathBounds.gameObject.AddComponent<TriggerProxy>();
			}
			PathBounds.isTrigger = true;
			base.gameObject.SetLayer(2);
			GameObject gameObject = new GameObject("PathPosition");
			gameObject.transform.parent = base.transform;
			gameObject.transform.ResetLocal();
			PathPosition.Value = gameObject.transform;
		}

		private void OnValidate()
		{
			if (Path == null)
			{
				Path = GetComponent<IPath>();
			}
		}

		internal void CalculateBounds()
		{
			OnValidate();
			if (Path != null)
			{
				Bounds bounds = Path.bounds;
				bounds.Expand(2f);
				bounds.center = new Vector3(bounds.center.x, bounds.center.y + 1f, bounds.center.z);
				PathBounds.size = bounds.size;
				PathBounds.center = bounds.center;
				MTools.SetDirty(PathBounds);
			}
		}

		public virtual bool InBounds()
		{
			foreach (MPathConstraint activePathContraint in ActivePathContraints)
			{
				if (activePathContraint.Path == this)
				{
					continue;
				}
				Vector3 position = activePathContraint.transform.position;
				m_PreviousPathPosition = Mathf.Clamp(m_PreviousPathPosition, 0f, m_PathPosition);
				m_PathPosition = Path.GetClosestTimeOnPath(position);
				Vector3 vector = Path.GetPointAtTime(m_PathPosition) + SearchOffset;
				MDebug.DrawWireSphere(vector, Color.red, SearchRadius, interval);
				MDebug.DrawWireSphere(activePathContraint.ContraintPos, Color.green, activePathContraint.Radius, interval);
				if ((bool)PathPosition.Value)
				{
					PathPosition.Value.position = vector;
				}
				if (MTools.DoSpheresIntersect(vector, SearchRadius, activePathContraint.ContraintPos, activePathContraint.Radius))
				{
					if (activePathContraint.LastPath.Contains(this))
					{
						continue;
					}
					if (Automatic.Value)
					{
						if (activePathContraint.Path == null || AutoChangePath.Value)
						{
							activePathContraint.EnterPath(this);
						}
						else
						{
							activePathContraint.NextPath = this;
						}
					}
					else
					{
						if (!InsidePathSphere)
						{
							CanEnterPath.Invoke(arg0: true);
							InsidePathSphere = true;
						}
						activePathContraint.NextPath = this;
					}
					return true;
				}
				if (InsidePathSphere)
				{
					CanEnterPath.Invoke(arg0: false);
					InsidePathSphere = false;
				}
				if (activePathContraint.LastPath.Contains(this))
				{
					activePathContraint.LastPath.Remove(this);
				}
				if (activePathContraint.NextPath == this)
				{
					activePathContraint.NextPath = null;
				}
			}
			return false;
		}
	}
}
