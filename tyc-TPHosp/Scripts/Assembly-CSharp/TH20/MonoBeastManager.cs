using System;
using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class MonoBeastManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public SharedInstance<MonoBeastDefinition> Definition;

			public float PercentageChanceOfSpawn = 100f;

			public SharedInstance<RoomItemDefinition>[] Splats;

			public GameObject PuffEffect;

			public GameObject ShotEffect;

			public float PuffEffectTime;
		}

		private readonly Config _config;

		private readonly Level _level;

		private readonly List<MonoBeast> _beasts;

		private MonoBeast _cursorBeast;

		private int _killStreak;

		private int _maxStreak;

		public Action<MonoBeast, int> OnMonoBeastShot;

		public Action OnKillStreakEnded;

		public List<MonoBeast> Beasts => _beasts;

		public MonoBeastManager(Config config, Level level)
		{
			_config = config;
			_level = level;
			_beasts = new List<MonoBeast>();
			CommonInitialisation();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			CommonInitialisation();
		}

		private void CommonInitialisation()
		{
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnCursorHighlight = (Action<ICursorSelectable>)Delegate.Combine(buildEvents2.OnCursorHighlight, new Action<ICursorSelectable>(OnCursorHighlight));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnCursorSelectObject = (Action<ICursorSelectable>)Delegate.Combine(buildEvents3.OnCursorSelectObject, new Action<ICursorSelectable>(OnCursorSelectObject));
			ConsoleCommandsDatabase.RegisterCommand("SpawnMonoBeast", "Spawns a MonoBeast at the cursor location", "SpawnMonoBeast", DebugSpawnMonoBeastAtCursor);
		}

		public override void Destroy()
		{
			_beasts.ClearAndCallDestroy();
			ConsoleCommandsDatabase.UnRegisterCommand("SpawnMonoBeast");
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Remove(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnCursorHighlight = (Action<ICursorSelectable>)Delegate.Remove(buildEvents2.OnCursorHighlight, new Action<ICursorSelectable>(OnCursorHighlight));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnCursorSelectObject = (Action<ICursorSelectable>)Delegate.Remove(buildEvents3.OnCursorSelectObject, new Action<ICursorSelectable>(OnCursorSelectObject));
			ActionExtension.VerifyCallValid = true;
			OnMonoBeastShot.VerifyIsNull();
			OnKillStreakEnded.VerifyIsNull();
			ActionExtension.VerifyCallValid = false;
			base.Destroy();
		}

		public void SpawnBeast(Vector3 position, float rotation, Room room)
		{
			if (RandomUtils.GlobalRandomInstance.NextFloat(0f, 100f) <= _config.PercentageChanceOfSpawn)
			{
				SpawnBeastInner(position, rotation, room);
			}
		}

		public void SpawnBeastInner(Vector3 position, float rotation, Room room)
		{
			MonoBeast item = new MonoBeast(_config.Definition.Instance, _level, position, rotation, room);
			_beasts.Add(item);
		}

		private ConsoleCommandResult DebugSpawnMonoBeastAtCursor(params string[] args)
		{
			Vector3 worldPosition = _level.CursorManager.WorldPosition;
			Room roomAtWorldCoord = _level.WorldState.GetRoomAtWorldCoord(worldPosition, includeHospital: true, includeClosedPlots: false);
			if (roomAtWorldCoord != null)
			{
				SpawnBeastInner(worldPosition, 0f, roomAtWorldCoord);
			}
			return ConsoleCommandResult.Succeeded();
		}

		public void DestroyBeast(MonoBeast monoBeast, bool timedOut, bool triggerEffect = true)
		{
			if (triggerEffect)
			{
				GameObject gameObject = (timedOut ? _config.PuffEffect : _config.ShotEffect);
				UnityEngine.Object.Destroy(UnityEngine.Object.Instantiate(gameObject, monoBeast.Position, gameObject.transform.rotation), _config.PuffEffectTime);
			}
			if (_cursorBeast == monoBeast)
			{
				_cursorBeast = null;
			}
			_beasts.Remove(monoBeast);
			monoBeast.Destroy();
		}

		private bool CursorDisabled()
		{
			if (!_level.InputManager.IsMouseOverGui)
			{
				return Time.timeScale < 1f;
			}
			return true;
		}

		public void Update()
		{
			for (int num = _beasts.Count - 1; num >= 0; num--)
			{
				_beasts[num].Update();
			}
			if (_level.CursorManager.IsModeActive<CursorSelect>())
			{
				if (_cursorBeast == null || CursorDisabled())
				{
					_level.CursorManager.SetCursorIcon(CursorIcon.Default);
				}
				else
				{
					_level.CursorManager.SetCursorIcon(CursorIcon.Crosshair);
				}
			}
		}

		private void OnRoomBuiltEvent(Room room, int cost)
		{
			FloorPlan floorPlan = room.FloorPlan;
			HospitalMap hospitalMap = floorPlan.HospitalMap;
			FloorPlan floorPlan2 = hospitalMap.FloorPlan;
			GridBounds worldBounds = floorPlan.WorldBounds;
			List<MonoBeast> list = new List<MonoBeast>();
			foreach (MonoBeast beast in _beasts)
			{
				if (beast.Room.FloorPlan.HospitalMap == hospitalMap)
				{
					Vector3 position = beast.Position;
					if (worldBounds.IsInBounds(position.ToGridCoord()) && RoomAlgorithms.RoomContainsWorldPosition(floorPlan, position, 0.5f) && RoomAlgorithms.FindNearestFreeTile(floorPlan2, position, out var result))
					{
						beast.Position = result + RandomUtils.RandomXZVector(-0.5f, 0.5f);
					}
					list.Add(beast);
				}
			}
			foreach (MonoBeast item in list)
			{
				item.CancelNav();
			}
		}

		private void OnCursorHighlight(ICursorSelectable selectable)
		{
			if (selectable == null)
			{
				_cursorBeast = null;
			}
			else
			{
				_cursorBeast = selectable as MonoBeast;
			}
		}

		private void OnCursorSelectObject(ICursorSelectable cursorSelectable)
		{
			if (CursorDisabled())
			{
				return;
			}
			if (_cursorBeast == null)
			{
				if (cursorSelectable == null && _killStreak != 0)
				{
					_killStreak = 0;
					OnKillStreakEnded.InvokeSafe();
				}
				return;
			}
			if (_killStreak != 0)
			{
				string text = ScriptLocalization.Misc.MonoBeast_KillStreak_CS.Replace("{[COUNT]}", _killStreak.ToString());
				_level.InWorldMessages.ShowMessage(text, _cursorBeast.Position + Vector3.up, 4f, InWorldMessages.MessageType.Info);
			}
			RoomItemAlgorithms.SpawnItem(_config.Splats.RandomItem().Instance, _cursorBeast.Position, 0f, _cursorBeast.Rotation, _level, _cursorBeast.Room);
			DestroyBeast(_cursorBeast, timedOut: false);
			_killStreak++;
			PlatformStatsAndAchievements.SetStatValue(Stat.MonoBrowShotChainReached, _killStreak);
			if (_killStreak > _maxStreak)
			{
				_maxStreak = _killStreak;
			}
			OnMonoBeastShot.InvokeSafe(_cursorBeast, _killStreak);
			PlatformStatsAndAchievements.TriggerAchievement(AchievementId.MonoBrowKill);
		}
	}
}
