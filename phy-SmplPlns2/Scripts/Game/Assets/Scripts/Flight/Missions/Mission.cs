using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Lua;
using Jundroo.Common;
using UnityEngine;

namespace Assets.Scripts.Flight.Missions
{
	public class Mission
	{
		private IFlightUI _flightUI;

		private LuaScript _lua;

		private string _rootPath;

		private float _startTime;

		private IMissionUnitCreator _unitCreator;

		public float MissionTime => Time.time - _startTime;

		public IMissionUnit Player { get; } = new MissionUnit();

		public IReferenceFrame ReferenceFrame { get; }

		public List<IMissionUnit> Units { get; } = new List<IMissionUnit>();

		public Mission(IFlightUI flightUI, IReferenceFrame referenceFrame, IMissionUnit player, IMissionUnitCreator unitCreator, string rootPath, string scriptFilename)
		{
			Player = player;
			ReferenceFrame = referenceFrame;
			_rootPath = rootPath;
			_flightUI = flightUI;
			_startTime = Time.time;
			_unitCreator = unitCreator;
			_lua = new LuaScript();
			_lua.RegisterType<Mission>();
			_lua.RegisterType<IMissionUnit>();
			_lua.RegisterType<UnitType>(includeStatic: true);
			_lua.RegisterType<UnitFaction>(includeStatic: true);
			_lua.RunScriptFromFile(Path.Combine(rootPath, scriptFilename));
			_lua.Call("initialize", this);
			_lua.StartCoroutine("onStartMission");
		}

		public IMissionUnit CreateMissionUnit(UnitType type, UnitFaction faction, string id, string callsign)
		{
			IMissionUnit missionUnit = _unitCreator.CreateMissionUnit(type, faction, id, callsign);
			Units.Add(missionUnit);
			return missionUnit;
		}

		public void EndMission(string reason)
		{
			Debug.Log("End Mission. Reason " + reason);
		}

		public void RadioMessage(string source, string message, string audioFile = null)
		{
			string profileImage = Path.Combine(Project.PersistentDataPath, "Missions", "GNG", "Images", "Profile-" + source + ".png");
			_flightUI.RadioPanel.CreateMessage(message, source, profileImage);
		}

		public void Update()
		{
			_lua?.UpdateCoroutines();
			Vector3 position = Player.Position;
			foreach (IMissionUnit unit in Units)
			{
				if (!unit.IsSpawned && !unit.IsDead && unit.SpawnRadius > 0.0 && (double)(unit.Position - position).magnitude < unit.SpawnRadius)
				{
					unit.Spawn();
				}
			}
		}
	}
}
