using System;
using System.Collections;
using System.IO;
using Assets.Scripts.Flight.UI;
using Jundroo.Common;
using UnityEngine;

namespace Assets.Scripts.Flight.Missions
{
	public class MissionScript : MonoBehaviour, IMissionUnitCreator
	{
		[SerializeField]
		private string _filename;

		[SerializeField]
		private FlightUIScript _flightUI;

		private Mission _mission;

		private ReferenceFrame _referenceFrame;

		public IMissionUnit CreateMissionUnit(UnitType type, UnitFaction faction, string id, string callsign)
		{
			if (type == UnitType.Craft)
			{
				return new CraftMissionUnit(id, faction == UnitFaction.Enemy, _referenceFrame);
			}
			throw new NotImplementedException();
		}

		public IEnumerator StartMission()
		{
			yield return new WaitForSeconds(1f);
			string rootPath = Path.Combine(Project.PersistentDataPath, "Missions", "GNG");
			_referenceFrame = new ReferenceFrame();
			CraftMissionUnit player = new CraftMissionUnit(FlightSceneScript.Instance.LocalPlayer?.Aircraft, _referenceFrame);
			_mission = new Mission(_flightUI, _referenceFrame, player, this, rootPath, _filename);
		}

		protected virtual void Start()
		{
			StartCoroutine(StartMission());
		}

		protected virtual void Update()
		{
			_mission?.Update();
		}
	}
}
