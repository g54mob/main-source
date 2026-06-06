using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Animal Controller/Check Point")]
	public class MCheckPoint : MonoBehaviour
	{
		public static List<MCheckPoint> CheckPoints;

		public static MCheckPoint LastCheckPoint;

		public UnityEvent OnEnter = new UnityEvent();

		[FormerlySerializedAs("OnActive")]
		public UnityEvent OnReset = new UnityEvent();

		public Collider Collider { get; set; }

		private void Start()
		{
			if (MRespawner.instance == null)
			{
				Debug.LogWarning(base.name + " has being destroyed since there's no Respawner");
				Object.Destroy(base.gameObject);
			}
			if (MAnimal.MainAnimal == null)
			{
				Debug.LogWarning(base.name + " has being destroyed since there's no Main Animal Player, Set on your Main Character: Main Player = true");
				Object.Destroy(base.gameObject);
			}
			Collider = GetComponent<Collider>();
			if ((bool)Collider)
			{
				Collider.isTrigger = true;
			}
			else
			{
				Debug.LogError(base.name + " needs a Collider");
			}
			OnReset.Invoke();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!other.isTrigger && !(LastCheckPoint == this))
			{
				MAnimal componentInParent = other.GetComponentInParent<MAnimal>();
				if ((bool)componentInParent && !(componentInParent != MAnimal.MainAnimal))
				{
					MRespawner.instance.transform.SetPositionAndRotation(base.transform.position, base.transform.rotation);
					MRespawner.instance.RespawnState = componentInParent.ActiveStateID;
					ResetCheckPoint();
					LastCheckPoint = this;
					OnEnter.Invoke();
					Collider.enabled = false;
				}
			}
		}

		public static void ResetCheckPoint()
		{
			if ((bool)LastCheckPoint)
			{
				LastCheckPoint.Collider.enabled = true;
				LastCheckPoint.OnReset.Invoke();
				LastCheckPoint = null;
			}
		}

		private void OnEnable()
		{
			if (CheckPoints == null)
			{
				CheckPoints = new List<MCheckPoint>();
			}
			CheckPoints.Add(this);
		}

		private void OnDisable()
		{
			if (CheckPoints != null)
			{
				CheckPoints.Remove(this);
			}
		}
	}
}
