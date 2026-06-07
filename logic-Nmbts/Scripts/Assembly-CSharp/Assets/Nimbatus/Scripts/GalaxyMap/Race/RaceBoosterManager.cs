using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Thruster;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race
{
	public class RaceBoosterManager : MonoBehaviour
	{
		public class ThrusterBoostData
		{
			public IThruster Thruster;

			public float AddedForce;

			public float Time;

			public DronePart Root;

			public float Mass;
		}

		[HideInInspector]
		public static RaceBoosterManager Instance;

		private List<ThrusterBoostData> _thrusters = new List<ThrusterBoostData>();

		public void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
		}

		public void Update()
		{
			foreach (ThrusterBoostData item in _thrusters.ToList())
			{
				if (item.Thruster == null || !item.Thruster.IsThrusterAlive())
				{
					_thrusters.Remove(item);
					continue;
				}
				item.Time -= Time.deltaTime;
				if (item.Time < 0f)
				{
					item.Thruster.SetCurrentThrust(item.Thruster.GetCurrentThrust() - item.AddedForce);
					_thrusters.Remove(item);
				}
			}
		}

		public void OnDisable()
		{
			if (Instance == this)
			{
				Instance = null;
			}
		}

		public void TryAddThrust(IThruster thruster, float force, float time, DronePart root)
		{
			ThrusterBoostData thrusterBoostData = _thrusters.Find((ThrusterBoostData t) => t.Thruster == thruster);
			if (thrusterBoostData == null)
			{
				float mass = root.GetMass();
				int count = _thrusters.Where((ThrusterBoostData t) => t.Root == root).ToList().Count;
				float num = force / (float)(count + 1) * (mass - 2f);
				thruster.SetCurrentThrust(thruster.GetCurrentThrust() + num);
				_thrusters.Add(new ThrusterBoostData
				{
					Thruster = thruster,
					AddedForce = num,
					Time = time,
					Root = root,
					Mass = mass
				});
			}
			else
			{
				if (thrusterBoostData.Root != root)
				{
					thrusterBoostData.Root = root;
					thrusterBoostData.Mass = root.GetMass();
				}
				thrusterBoostData.Time = time;
				int count2 = _thrusters.Where((ThrusterBoostData t) => t.Root == root).ToList().Count;
				float num2 = force / (float)count2 * (thrusterBoostData.Mass - 2f);
				thruster.SetCurrentThrust(thruster.GetCurrentThrust() - thrusterBoostData.AddedForce + num2);
				thrusterBoostData.AddedForce = num2;
			}
		}
	}
}
