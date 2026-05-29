using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.NPCs
{
	public class NPCSpeedController : MonoBehaviour
	{
		[Serializable]
		public class SpeedControl
		{
			public string id;

			public int priority;

			public float speed;

			public SpeedControl(string id, int priority, float speed)
			{
			}
		}

		[Range(0f, 1f)]
		[Header("Settings")]
		public float DefaultWalkSpeed;

		[FormerlySerializedAs("SpeedMultiplier")]
		[SerializeField]
		private float _SpeedMultiplier;

		[Header("References")]
		public NPCMovement Movement;

		protected List<SpeedControl> speedControlStack;

		public SpeedControl ActiveSpeedControl;

		public float SpeedMultiplier
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		public void AddSpeedControl(SpeedControl control)
		{
		}

		public SpeedControl GetSpeedControl(string id)
		{
			return null;
		}

		public bool DoesSpeedControlExist(string id)
		{
			return false;
		}

		public void RemoveSpeedControl(string id)
		{
		}

		private void UpdateActiveSpeedControl()
		{
		}
	}
}
