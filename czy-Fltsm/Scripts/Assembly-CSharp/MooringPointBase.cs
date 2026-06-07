using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class MooringPointBase : MonoBehaviour, IPersistentReference
{
	public class Event : UnityEvent<MooringPointBase>
	{
	}

	[SerializeField]
	public Transform MooringTransform;

	[SerializeField]
	[Tooltip("Transform that a boat needs to reach to moor.")]
	protected Transform _entranceTransform;

	[SerializeField]
	private Target _mooringTarget;

	[SerializeField]
	[Tooltip("Transform to which the rope from the boat will attach.")]
	protected Transform _ropeAttachmentPoint;

	[SerializeField]
	[Tooltip("Visual prefab for the mooring rope.")]
	private GameObject _mooringRopePrefab;

	[Tooltip("The prefab that is shown when a mooring point is free.")]
	public GameObject FreeMooringPointPrefab;

	[Header("Audio")]
	[Tooltip("The audio clip properties to play when a boat is moored.")]
	public AudioClipProperties MooringAudio;

	[Tooltip("The audio clip properties to play when a boat is unmoored.")]
	public AudioClipProperties UnmooringAudio;

	private GameObject _attachedRope;

	public bool IsEmpty => MooredBoat == null;

	public bool IsReserved => ReservingAgent != null;

	public bool IsBlocked { get; protected set; }

	public virtual bool IsAvailableForMooring
	{
		get
		{
			if (MooredBoat == null)
			{
				return ReservingAgent == null;
			}
			return false;
		}
	}

	public Boat MooredBoat { get; private set; }

	public Agent ReservingAgent { get; protected set; }

	public Project ReservingProject { get; protected set; }

	public Target EmbarkTarget { get; protected set; }

	public Target MooringTarget => _mooringTarget;

	public abstract bool IsInTown { get; }

	public UnityEvent MooringPointUpdated { get; private set; } = new UnityEvent();

	public Event MooringPointUnreserved { get; private set; } = new Event();

	public Event MooringPointReserved { get; private set; } = new Event();

	public int PersistentIndex { get; set; } = -1;

	protected virtual void FixedUpdate()
	{
		AlignRope();
	}

	protected virtual void OnDestroy()
	{
		RemoveListeners();
	}

	public IEnumerator EmbarkCoroutine(Agent captain)
	{
		if (MooredBoat == null)
		{
			Debug.LogErrorFormat("'{0}' tried to embark, but there is not boat moored at the mooring point!", captain.Name);
			yield break;
		}
		if (ReservingAgent == null)
		{
			Debug.LogWarningFormat("'{0}' is embarking from a mooring point it had not reserved!");
		}
		else if (ReservingAgent != captain)
		{
			Debug.LogErrorFormat("'{0}' tried to embark from a mooring point that is reserved by '{1}'", captain.Name, ReservingAgent.name);
			yield break;
		}
		if (MooredBoat.BoardCaptain(captain))
		{
			while (MooredBoat.IsWaitingForPassengers)
			{
				yield return null;
			}
			UnmoorBoat(captain);
		}
		else
		{
			Debug.LogErrorFormat("'{0}' was unable to embark because it could not board boat '{1}'!", captain.Name, MooredBoat.name);
		}
	}

	public virtual bool MoorBoat(Boat boat, bool restore = false)
	{
		if (MooredBoat != null)
		{
			Debug.LogError("Cannot moor boat on a mooringpoint that already has a boat moored!");
			return false;
		}
		if (!restore && !Unreserve(boat.Captain))
		{
			return false;
		}
		boat.CurrentMooringPoint = this;
		boat.transform.SetParent(MooringTransform);
		boat.transform.localPosition = Vector3.zero;
		boat.transform.localRotation = Quaternion.identity;
		MooredBoat = boat;
		AttachRope();
		PlaySFX(MooringAudio);
		MooringPointUpdated.Invoke();
		return true;
	}

	public virtual bool UnmoorBoat(Agent agent)
	{
		if (!MooredBoat)
		{
			Debug.LogError("Trying to unmoor a boat from a MooringPoint where no boat is moored!");
			return false;
		}
		if (!MooredBoat.Captain)
		{
			Debug.LogError("Trying to unmoor a boat which has no captain!");
			return false;
		}
		if (!Unreserve(MooredBoat.Captain))
		{
			return false;
		}
		MooredBoat.SendUpdatedEvent();
		UnmoorBoat(moveBoat: true);
		PlaySFX(UnmooringAudio);
		MooringPointUpdated.Invoke();
		return true;
	}

	public void UnmoorBoat(bool moveBoat = false)
	{
		MooredBoat.ResourceProvider.Unregister();
		MooredBoat.transform.SetParent(null);
		MooredBoat.CurrentMooringPoint = null;
		if (moveBoat)
		{
			MooredBoat.transform.position = _entranceTransform.position;
			MooredBoat.transform.rotation = _entranceTransform.rotation;
		}
		DetachRope();
		MooredBoat = null;
		ReservingAgent = null;
		ReservingProject = null;
	}

	public bool Reserve(Agent agent, Project project = null)
	{
		if (IsBlocked)
		{
			return false;
		}
		if (IsReserved)
		{
			Debug.LogWarningFormat("MooringPoint could not be reserved by '{0}' because it is already reserved by '{1}'", agent.Name, ReservingAgent.Name);
			return false;
		}
		ReservingAgent = agent;
		ReservingProject = project;
		if (!IsEmpty)
		{
			ReservingAgent.ReservedBoat = MooredBoat;
		}
		MooringPointReserved.Invoke(this);
		return true;
	}

	public bool Unreserve(Agent agent)
	{
		if (!IsReserved)
		{
			Debug.LogWarningFormat("'{0}' is unreserving a {1} that is not reserved!", agent, IsInTown ? "MooringPoint" : "LandmakrMooringPoint");
		}
		else if (agent != ReservingAgent)
		{
			Debug.LogErrorFormat("'{0}' is trying to unreserve a mooring point that has been reserved by '{1}'", agent.Name, ReservingAgent.Name);
			return false;
		}
		if (!IsEmpty && agent != null && agent.ReservedBoat != MooredBoat)
		{
			Debug.LogErrorFormat("'{0}' is trying to unreserve a moored boat which it has not reserved!", agent.Name);
			return false;
		}
		MooringPointUnreserved.Invoke(this);
		if ((bool)ReservingAgent)
		{
			ReservingAgent.ReservedBoat = null;
		}
		ReservingAgent = null;
		ReservingProject = null;
		return true;
	}

	public void UnreserveForProject(Project project)
	{
		if (ReservingProject == null || ReservingProject == project)
		{
			Debug.LogWarningFormat("Project '{0}' was finished while still having a mooringpoint reserved!", project.Properties.name);
			MooringPointUnreserved.Invoke(this);
			ReservingAgent = null;
			ReservingProject = null;
			if (MooredBoat != null && MooredBoat.Captain != null)
			{
				MooredBoat.ClearCaptain();
			}
		}
		else
		{
			Debug.LogWarningFormat("Project '{0}' with target at position {1} is trying to unreserve a mooring point that is reserved by project '{2}' with target at position {3}.", project.Properties.name, project.Target ? project.Target.transform.position.ToString() : "Null", ReservingProject.Properties.name, ReservingProject.Target ? ReservingProject.Target.transform.position.ToString() : "Null");
		}
	}

	protected void RemoveListeners()
	{
		if (MooringPointUpdated != null)
		{
			MooringPointUpdated.RemoveAllListeners();
		}
	}

	private void AttachRope()
	{
		if (_attachedRope == null)
		{
			_attachedRope = Object.Instantiate(_mooringRopePrefab, _ropeAttachmentPoint, worldPositionStays: true);
		}
		_attachedRope.SetActive(value: true);
		AlignRope();
	}

	private void DetachRope()
	{
		if ((bool)_attachedRope)
		{
			_attachedRope.SetActive(value: false);
		}
	}

	private void AlignRope()
	{
		if ((bool)_attachedRope && _attachedRope.activeInHierarchy)
		{
			_attachedRope.transform.position = _ropeAttachmentPoint.position;
			_attachedRope.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(_ropeAttachmentPoint.position, MooredBoat.RopeAttachment.position) / 2f);
			_attachedRope.transform.rotation = Quaternion.LookRotation(MooredBoat.RopeAttachment.position - _ropeAttachmentPoint.position);
		}
	}

	private void PlaySFX(AudioClipProperties audioClip)
	{
		if (!(audioClip == null))
		{
			AudioManager.Play(audioClip, base.transform);
		}
	}

	public bool ReturnIsReservedByAgent(Agent agent)
	{
		if (IsReserved)
		{
			return agent == ReservingAgent;
		}
		return false;
	}

	protected virtual void OnDrawGizmos()
	{
		if ((bool)GameManager.GraphManager && GameManager.GraphManager.WaterSurfaceGraph.ReturnNode(_mooringTarget, null, 0) is GridNode gridNode)
		{
			if (gridNode.Clearance < 2)
			{
				Gizmos.color = Color.red;
			}
			else if (gridNode.Clearance < 3)
			{
				Gizmos.color = Color.yellow;
			}
			else
			{
				Gizmos.color = Color.green;
			}
			Gizmos.DrawSphere(gridNode.RootPosition, 0.5f);
		}
		GizmoHelper.DrawSphereWithLabel(_entranceTransform.position, 0.1f, "Entrance");
		GizmoHelper.DrawSphereWithLabel(_ropeAttachmentPoint.position, 0.1f, "Rope Attachment");
	}
}
