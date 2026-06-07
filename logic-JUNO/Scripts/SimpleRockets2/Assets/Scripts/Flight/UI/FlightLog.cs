using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using ModApi.Craft.Parts;
using ModApi.Flight.UI;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class FlightLog : IFlightLog
	{
		private enum PartDamagePhase
		{
			Active = 0,
			Complete = 1,
			Destroyed = 2
		}

		private static class LogColors
		{
			public const string DamageActive = "#FF0000";

			public const string DamageComplete = "#BB2222";

			public const string DamageDestroyed = "#990000";

			public const string Disconnected = "#990000";

			public const string Exploded = "#990000";
		}

		private class PartDamageEntry
		{
			public float Cooldown { get; set; }

			public float Damage { get; set; }

			public FlightLogEntry LogEntry { get; set; }

			public PartData Part { get; set; }

			public PartDamageEntry(FlightLogEntry logEntry, PartData part, float damage, float cooldown)
			{
				LogEntry = logEntry;
				Part = part;
				Damage = damage;
				Cooldown = cooldown;
			}
		}

		private class PartDamageGroup
		{
			private string _damageMessageName;

			public float ActiveDamageCooldownResetValue { get; }

			public PartDamageType DamageType { get; }

			public float DestroyedCooldown { get; set; }

			public float DestroyedCooldownResetValue { get; }

			public Dictionary<PartData, PartDamageEntry> PartsDamaged { get; }

			public List<PartData> PartsDestroyed { get; }

			public PartDamageGroup(PartDamageType damageType, float activeDamageCooldown, float destroyedCooldown)
			{
				DamageType = damageType;
				ActiveDamageCooldownResetValue = activeDamageCooldown;
				DestroyedCooldownResetValue = destroyedCooldown;
				PartsDestroyed = new List<PartData>();
				PartsDamaged = new Dictionary<PartData, PartDamageEntry>();
				_damageMessageName = damageType switch
				{
					PartDamageType.Heat => "heat damage", 
					PartDamageType.GForce => "excessive Gs damage", 
					PartDamageType.Overexpansion => "overexpansion damage", 
					PartDamageType.Overspin => "damage from spinning too fast", 
					PartDamageType.Pressure => "atmospheric pressure damage", 
					PartDamageType.Explosion => "explosion damage", 
					_ => "damage", 
				};
			}

			public string GetDamagedMessage(PartData part)
			{
				EvaData modifier = part.GetModifier<EvaData>();
				if (modifier != null)
				{
					return (modifier.IsTourist ? "A tourist" : ("Astronaut '" + modifier.CrewName + "'")) + " is taking " + _damageMessageName;
				}
				return "Part '" + part.Name + "' is taking " + _damageMessageName;
			}

			public string GetDamagedMessage(int partCount)
			{
				return $"{partCount} parts are taking {_damageMessageName}";
			}

			public string GetDestroyedMessage(PartData part)
			{
				EvaData modifier = part.GetModifier<EvaData>();
				if (modifier != null)
				{
					return (modifier.IsTourist ? "A tourist" : ("Astronaut '" + modifier.CrewName + "'")) + " died from excessive " + _damageMessageName;
				}
				return "Part '" + part.Name + "' exploded from excessive " + _damageMessageName;
			}

			public string GetDestroyedMessage(int partCount)
			{
				return $"{partCount} parts exploded from excessive {_damageMessageName}";
			}

			public string GetDetailedDamageMessage(PartData part, PartDamagePhase phase, float damage = 0f)
			{
				EvaData modifier = part.GetModifier<EvaData>();
				switch (phase)
				{
				case PartDamagePhase.Active:
					if (modifier == null)
					{
						return string.Format("<color={0}>Part '{1}' [ID: {2}] is taking {3}: {4:F1}  (Total Damage: {5:F1})", "#FF0000", part.Name, part.Id, _damageMessageName, damage, part.Damage);
					}
					return string.Format("<color={0}>{1} [ID: {2}] is taking {3}: {4:F1}  (Total Damage: {5:F1})", "#FF0000", modifier.IsTourist ? "A tourist" : ("Astronaut '" + modifier.CrewName + "'"), part.Id, _damageMessageName, damage, part.Damage);
				case PartDamagePhase.Complete:
					if (modifier == null)
					{
						return string.Format("<color={0}>Part '{1}' [ID: {2}] took {3}: {4:F1}  (Total Damage: {5:F1})", "#BB2222", part.Name, part.Id, _damageMessageName, damage, part.Damage);
					}
					return string.Format("<color={0}>{1} [ID: {2}] took {3}: {4:F1}  (Total Damage: {5:F1})", "#BB2222", modifier.IsTourist ? "A tourist" : ("Astronaut '" + modifier.CrewName + "'"), part.Id, _damageMessageName, damage, part.Damage);
				case PartDamagePhase.Destroyed:
					if (modifier == null)
					{
						return string.Format("<color={0}>Part '{1}' [ID: {2}] exploded from excessive {3}.", "#990000", part.Name, part.Id, _damageMessageName);
					}
					return string.Format("<color={0}>{1} [ID: {2}] died from excessive {3}.", "#990000", modifier.IsTourist ? "A tourist" : ("Astronaut '" + modifier.CrewName + "'"), part.Id, _damageMessageName);
				default:
					throw new NotSupportedException("Unknown damage phase type");
				}
			}
		}

		private const float ExplodedOrDisconnectedPartCooldownResetValue = 4f;

		private List<PartData> _disconnectedParts;

		private float _explodedOrDisconnectedCooldown;

		private List<PartData> _explodedParts;

		private FlightSceneInterfaceScript _flightSceneUI;

		private List<FlightLogEntry> _logEntries;

		private PartDamageGroup _partDamageBasic;

		private PartDamageGroup _partDamageExplosion;

		private PartDamageGroup _partDamageHeat;

		private PartDamageGroup _partDamageGForce;

		private PartDamageGroup _partDamageOverexpansion;

		private PartDamageGroup _partDamageOverspin;

		private PartDamageGroup _partDamagePressure;

		private List<PartDamageEntry> _partDamageRemovalTempList = new List<PartDamageEntry>();

		private bool _totalCraftDestruction;

		public IReadOnlyList<FlightLogEntry> LogEntries => _logEntries;

		public event LogEntryAddedDelegate LogEntryAdded;

		public FlightLog(FlightSceneInterfaceScript flightSceneUI)
		{
			_logEntries = new List<FlightLogEntry>();
			_flightSceneUI = flightSceneUI;
			_explodedParts = new List<PartData>();
			_disconnectedParts = new List<PartData>();
			_partDamageBasic = new PartDamageGroup(PartDamageType.Basic, 1f, 4f);
			_partDamageHeat = new PartDamageGroup(PartDamageType.Heat, 1f, 4f);
			_partDamageGForce = new PartDamageGroup(PartDamageType.GForce, 1f, 4f);
			_partDamageOverexpansion = new PartDamageGroup(PartDamageType.Overexpansion, 1f, 4f);
			_partDamageOverspin = new PartDamageGroup(PartDamageType.Overspin, 1f, 4f);
			_partDamagePressure = new PartDamageGroup(PartDamageType.Pressure, 1f, 4f);
			_partDamageExplosion = new PartDamageGroup(PartDamageType.Explosion, 1f, 4f);
		}

		public FlightLogEntry AddLog(string text, FlightLogEntryCategory category, bool isDynamic = false, IPartScript associatedPart = null)
		{
			FlightLogEntry flightLogEntry = new FlightLogEntry(_logEntries.Count, text, category, isDynamic, associatedPart);
			_logEntries.Add(flightLogEntry);
			this.LogEntryAdded?.Invoke(flightLogEntry);
			return flightLogEntry;
		}

		public void LogDisconnectedPart(IPartScript part)
		{
			if (part.CraftScript.Data.Assembly.Parts.Count != 1)
			{
				_disconnectedParts.Add(part.Data);
				_explodedOrDisconnectedCooldown = 4f;
				AddLog(string.Format("<color={0}>{1} [ID {2}] has been disconnected.", "#990000", part.Data.Name, part.Data.Id), FlightLogEntryCategory.CraftDamage, isDynamic: false, part);
			}
		}

		public void LogExplodedPart(IPartScript part)
		{
			_explodedParts.Add(part.Data);
			_explodedOrDisconnectedCooldown = 4f;
			EvaData modifier = part.Data.GetModifier<EvaData>();
			string text = ((modifier != null) ? string.Format("<color={0}>{1} [ID {2}] has died.", "#990000", modifier.IsTourist ? "A tourist" : ("Astronaut '" + modifier.CrewName + "'"), part.Data.Id) : string.Format("<color={0}>{1} [ID {2}] has exploded.", "#990000", part.Data.Name, part.Data.Id));
			AddLog(text, FlightLogEntryCategory.CraftDamage, isDynamic: false, part);
		}

		public void LogPartDamage(IPartScript part, float damage, PartDamageType type, bool destroyed, float thresholdScale = 1f)
		{
			if ((double)damage < 0.1 * (double)thresholdScale)
			{
				return;
			}
			PartDamageGroup partDamageGroup = GetPartDamageGroup(type);
			if (partDamageGroup == null)
			{
				return;
			}
			PartData data = part.Data;
			if (partDamageGroup.PartsDamaged.TryGetValue(data, out var value))
			{
				value.Damage += damage;
				if (destroyed)
				{
					value.LogEntry.Text = partDamageGroup.GetDetailedDamageMessage(value.Part, PartDamagePhase.Complete, value.Damage);
					partDamageGroup.PartsDamaged.Remove(data);
				}
				else
				{
					value.Cooldown = partDamageGroup.ActiveDamageCooldownResetValue;
					value.LogEntry.Text = partDamageGroup.GetDetailedDamageMessage(value.Part, PartDamagePhase.Active, value.Damage);
				}
			}
			else if (!destroyed)
			{
				FlightLogEntry logEntry = AddLog(partDamageGroup.GetDetailedDamageMessage(part.Data, PartDamagePhase.Active, damage), FlightLogEntryCategory.CraftDamage, isDynamic: true, part);
				partDamageGroup.PartsDamaged[data] = new PartDamageEntry(logEntry, part.Data, damage, partDamageGroup.ActiveDamageCooldownResetValue);
			}
			if (destroyed)
			{
				partDamageGroup.PartsDestroyed.Add(part.Data);
				partDamageGroup.DestroyedCooldown = partDamageGroup.DestroyedCooldownResetValue;
				AddLog(partDamageGroup.GetDetailedDamageMessage(part.Data, PartDamagePhase.Destroyed), FlightLogEntryCategory.CraftDamage, isDynamic: false, part);
			}
		}

		public void LogTotalCraftDestruction(string message)
		{
			_totalCraftDestruction = true;
			AddLog(message, FlightLogEntryCategory.CraftDamage);
			_flightSceneUI.ShowDamageMessage(message, devlog: true, 15f);
		}

		public void Update(float deltaTime)
		{
			ProcessDamageCooldowns(_partDamageBasic, deltaTime);
			ProcessDamageCooldowns(_partDamageHeat, deltaTime);
			ProcessDamageCooldowns(_partDamageOverexpansion, deltaTime);
			ProcessDamageCooldowns(_partDamageOverspin, deltaTime);
			ProcessDamageCooldowns(_partDamagePressure, deltaTime);
			ProcessDamageCooldowns(_partDamageExplosion, deltaTime);
			UpdateFlightSceneMessage(deltaTime);
		}

		public void UpdateLogEntry(int id, string text)
		{
			if (id >= _logEntries.Count)
			{
				throw new ArgumentOutOfRangeException("id");
			}
			FlightLogEntry flightLogEntry = _logEntries[id];
			if (!flightLogEntry.IsDynamic)
			{
				throw new InvalidOperationException($"Unable to update log entry '{id}' because it is not marked as dynamic.");
			}
			flightLogEntry.Text = text;
		}

		private PartDamageGroup GetPartDamageGroup(PartDamageType damageType)
		{
			switch (damageType)
			{
			case PartDamageType.Basic:
				return _partDamageBasic;
			case PartDamageType.Heat:
				return _partDamageHeat;
			case PartDamageType.GForce:
				return _partDamageGForce;
			case PartDamageType.Overexpansion:
				return _partDamageOverexpansion;
			case PartDamageType.Overspin:
				return _partDamageOverspin;
			case PartDamageType.Pressure:
				return _partDamagePressure;
			case PartDamageType.Explosion:
				return _partDamageExplosion;
			default:
				Debug.LogError($"Unknown damage type '{damageType}'");
				return null;
			}
		}

		private void ProcessDamageCooldowns(PartDamageGroup partDamageGroup, float deltaTime)
		{
			_partDamageRemovalTempList.Clear();
			foreach (PartDamageEntry value in partDamageGroup.PartsDamaged.Values)
			{
				value.Cooldown -= deltaTime;
				if (value.Cooldown <= 0f)
				{
					_partDamageRemovalTempList.Add(value);
				}
			}
			foreach (PartDamageEntry partDamageRemovalTemp in _partDamageRemovalTempList)
			{
				partDamageRemovalTemp.LogEntry.Text = partDamageGroup.GetDetailedDamageMessage(partDamageRemovalTemp.Part, PartDamagePhase.Complete, partDamageRemovalTemp.Damage);
				partDamageGroup.PartsDamaged.Remove(partDamageRemovalTemp.Part);
			}
		}

		private void UpdateFlightSceneMessage(float deltaTime)
		{
			if (!_totalCraftDestruction)
			{
				int totalDestroyedParts = _partDamageBasic.PartsDestroyed.Count + _partDamageHeat.PartsDestroyed.Count + _partDamageOverexpansion.PartsDestroyed.Count + _partDamageOverspin.PartsDestroyed.Count + _partDamagePressure.PartsDestroyed.Count + _partDamageExplosion.PartsDestroyed.Count + _explodedParts.Count;
				bool logMessageShown = false;
				logMessageShown = UpdateFlightSceneMessageForDestroyedParts(_partDamageBasic, totalDestroyedParts, logMessageShown, deltaTime);
				logMessageShown = UpdateFlightSceneMessageForDestroyedParts(_partDamageHeat, totalDestroyedParts, logMessageShown, deltaTime);
				logMessageShown = UpdateFlightSceneMessageForDestroyedParts(_partDamageOverexpansion, totalDestroyedParts, logMessageShown, deltaTime);
				logMessageShown = UpdateFlightSceneMessageForDestroyedParts(_partDamageOverspin, totalDestroyedParts, logMessageShown, deltaTime);
				logMessageShown = UpdateFlightSceneMessageForDestroyedParts(_partDamagePressure, totalDestroyedParts, logMessageShown, deltaTime);
				logMessageShown = UpdateFlightSceneMessageForDestroyedParts(_partDamageExplosion, totalDestroyedParts, logMessageShown, deltaTime);
				logMessageShown = UpdateFlightSceneMessageForDestroyedAndDisconnectedParts(logMessageShown, deltaTime);
				if (!logMessageShown)
				{
					int totalDamagedParts = _partDamageBasic.PartsDamaged.Count + _partDamageHeat.PartsDamaged.Count + _partDamageOverexpansion.PartsDamaged.Count + _partDamageOverspin.PartsDamaged.Count + _partDamagePressure.PartsDamaged.Count + _partDamageExplosion.PartsDamaged.Count;
					logMessageShown = UpdateFlightSceneMessageForDamagedParts(_partDamageBasic, totalDamagedParts, logMessageShown, deltaTime);
					logMessageShown = UpdateFlightSceneMessageForDamagedParts(_partDamageHeat, totalDamagedParts, logMessageShown, deltaTime);
					logMessageShown = UpdateFlightSceneMessageForDamagedParts(_partDamageOverexpansion, totalDamagedParts, logMessageShown, deltaTime);
					logMessageShown = UpdateFlightSceneMessageForDamagedParts(_partDamageOverspin, totalDamagedParts, logMessageShown, deltaTime);
					logMessageShown = UpdateFlightSceneMessageForDamagedParts(_partDamagePressure, totalDamagedParts, logMessageShown, deltaTime);
					logMessageShown = UpdateFlightSceneMessageForDamagedParts(_partDamageExplosion, totalDamagedParts, logMessageShown, deltaTime);
				}
			}
		}

		private bool UpdateFlightSceneMessageForDamagedParts(PartDamageGroup partDamageGroup, int totalDamagedParts, bool logMessageShown, float deltaTime)
		{
			if (logMessageShown)
			{
				return logMessageShown;
			}
			int count = partDamageGroup.PartsDamaged.Count;
			if (count > 0)
			{
				if (count == totalDamagedParts)
				{
					if (count == 1)
					{
						PartDamageEntry partDamageEntry = partDamageGroup.PartsDamaged.Values.First();
						_flightSceneUI.ShowDamageMessage(partDamageGroup.GetDamagedMessage(partDamageEntry.Part));
					}
					else
					{
						_flightSceneUI.ShowDamageMessage(partDamageGroup.GetDamagedMessage(count));
					}
				}
				else
				{
					_flightSceneUI.ShowDamageMessage($"{totalDamagedParts} parts are taking damage");
				}
			}
			return logMessageShown;
		}

		private bool UpdateFlightSceneMessageForDestroyedAndDisconnectedParts(bool logMessageShown, float deltaTime)
		{
			if (_explodedParts.Count > 0 || _disconnectedParts.Count > 0)
			{
				_explodedOrDisconnectedCooldown -= deltaTime;
				if (_explodedOrDisconnectedCooldown <= 0f)
				{
					_explodedParts.Clear();
					_disconnectedParts.Clear();
				}
			}
			if (logMessageShown)
			{
				return logMessageShown;
			}
			if (_explodedParts.Count > 0)
			{
				if (_disconnectedParts.Count > 0)
				{
					_flightSceneUI.ShowDamageMessage($"{_explodedParts.Count + _disconnectedParts.Count} parts have exploded or disconnected");
				}
				else if (_explodedParts.Count == 1)
				{
					PartData partData = _explodedParts[0];
					EvaData modifier = partData.GetModifier<EvaData>();
					string message = ((modifier != null) ? ((modifier.IsTourist ? "A tourist" : ("Astronaut '" + modifier.CrewName + "'")) + " has died.") : ("Part '" + partData.Name + "' has exploded"));
					_flightSceneUI.ShowDamageMessage(message);
				}
				else
				{
					_flightSceneUI.ShowDamageMessage($"{_explodedParts.Count} parts have exploded");
				}
				logMessageShown = true;
			}
			else if (_disconnectedParts.Count > 0)
			{
				_flightSceneUI.ShowDamageMessage($"{_disconnectedParts.Count} parts have been disconnected");
				logMessageShown = true;
			}
			return logMessageShown;
		}

		private bool UpdateFlightSceneMessageForDestroyedParts(PartDamageGroup partDamageGroup, int totalDestroyedParts, bool logMessageShown, float deltaTime)
		{
			int count = partDamageGroup.PartsDestroyed.Count;
			if (count > 0)
			{
				partDamageGroup.DestroyedCooldown -= deltaTime;
				if (partDamageGroup.DestroyedCooldown <= 0f)
				{
					partDamageGroup.PartsDestroyed.Clear();
					return logMessageShown;
				}
				if (logMessageShown)
				{
					return logMessageShown;
				}
				if (count == totalDestroyedParts)
				{
					if (count == 1)
					{
						PartData part = partDamageGroup.PartsDestroyed[0];
						_flightSceneUI.ShowDamageMessage(partDamageGroup.GetDestroyedMessage(part));
					}
					else
					{
						_flightSceneUI.ShowDamageMessage(partDamageGroup.GetDestroyedMessage(count));
					}
				}
				else
				{
					_flightSceneUI.ShowDamageMessage($"{totalDestroyedParts} parts have been destroyed");
				}
				return true;
			}
			return logMessageShown;
		}
	}
}
