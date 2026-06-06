using System;
using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Serialization;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Aiming/Aim Target")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/utilities/aim-target")]
	public class AimTarget : MonoBehaviour, IAimTarget
	{
		public static List<AimTarget> AimTargets;

		[SerializeField]
		[Tooltip("It will center the Aim Ray into this gameObject's collider")]
		private bool aimAssist;

		[SerializeField]
		[Tooltip("Transform Point for to center the Aim Ray")]
		[FormerlySerializedAs("m_AimPoint")]
		private Transform m_AimCenter;

		[SerializeField]
		[Tooltip("The Aim Assist will use Own Trigers to find Aimers")]
		private bool UseOnTriggerEnter;

		[Tooltip("Layer to check on the Aimer")]
		[SerializeField]
		private LayerReference layer = new LayerReference(-1);

		[Tooltip("Search only Tags")]
		public Tag[] Tags;

		private IAim aim;

		public GameObjectEvent OnAimEnter = new GameObjectEvent();

		public GameObjectEvent OnAimExit = new GameObjectEvent();

		public bool debug;

		private List<Aim> Aimed_by;

		public LayerMask Layer
		{
			get
			{
				return layer.Value;
			}
			set
			{
				layer.Value = value;
			}
		}

		public bool AimAssist
		{
			get
			{
				return aimAssist;
			}
			set
			{
				aimAssist = value;
			}
		}

		public bool IsBeingAimed { get; set; }

		public Transform AimPoint => m_AimCenter;

		GameObject IAimTarget.gameObject => base.gameObject;

		protected virtual void OnEnable()
		{
			if (m_AimCenter == null)
			{
				m_AimCenter = base.transform;
			}
			if (AimTargets == null)
			{
				AimTargets = new List<AimTarget>();
			}
			AimTargets.Add(this);
			Aimed_by = new List<Aim>();
		}

		protected virtual void OnDisable()
		{
			AimTargets.Remove(this);
			foreach (Aim item in Aimed_by)
			{
				item.ClearAimAssist();
			}
		}

		private void OnValidate()
		{
			if (m_AimCenter == null)
			{
				m_AimCenter = base.transform;
			}
		}

		public void IsBeenAimed(bool enter, Aim AimedBy)
		{
			try
			{
				if ((Tags == null || Tags.Length == 0 || AimedBy.gameObject.HasMalbersTagInParent(Tags)) && MTools.Layer_in_LayerMask(AimedBy.gameObject.layer, Layer))
				{
					if (debug)
					{
						Debug.Log($"[{base.name}] Is Being Aimed by [{AimedBy.name}]. Enter: {enter}", AimedBy);
					}
					IsBeingAimed = enter;
					if (enter)
					{
						OnAimEnter.Invoke(AimedBy.gameObject);
						Aimed_by.Add(AimedBy);
					}
					else
					{
						OnAimExit.Invoke(AimedBy.gameObject);
						Aimed_by.Remove(AimedBy);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		public bool TrueConditions(Collider other)
		{
			if (!base.enabled)
			{
				return false;
			}
			if (Tags != null && Tags.Length != 0 && !other.gameObject.HasMalbersTagInParent(Tags))
			{
				return false;
			}
			if (other == null)
			{
				return false;
			}
			if (other.isTrigger)
			{
				return false;
			}
			if (!MTools.Layer_in_LayerMask(other.gameObject.layer, Layer))
			{
				return false;
			}
			if (base.transform.IsChildOf(other.transform))
			{
				return false;
			}
			return true;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!TrueConditions(other))
			{
				return;
			}
			IAim aim = other.FindInterface<IAim>();
			if (aim != null && this.aim != aim)
			{
				if (debug)
				{
					Debug.Log("OnTrigger Enter [" + other.name + "]", this);
				}
				aim.AimTarget = AimPoint;
				this.aim = aim;
				OnAimEnter.Invoke(other.gameObject);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (!TrueConditions(other))
			{
				return;
			}
			IAim aim = other.FindInterface<IAim>();
			if (aim != null && this.aim == aim)
			{
				aim.AimTarget = null;
				this.aim = null;
				OnAimExit.Invoke(other.gameObject);
				if (debug)
				{
					Debug.Log("OnTrigger Exit [" + other.name + "]", this);
				}
			}
		}
	}
}
