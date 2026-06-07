using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Assets.Scripts.Craft;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Flight.AI
{
	public class AiAircraftInfo
	{
		public Vector3 MaxAngularVelocities;

		public Vector3 MaxAngularVelocitySpeeds;

		private const string PlayerPrefsPrependForAircraft = "AiPerf_";

		private const char Separator = '@';

		private bool _hasBeenPerformanceChecked;

		private int _partCount;

		private int _wingCount;

		public string AircraftId { get; private set; }

		public bool? AircraftIsAbleToTakeOff { get; set; }

		public bool? AircraftIsFylable { get; set; }

		public XElement AircraftXml { get; private set; }

		public bool HasBeenPerformanceChecked
		{
			get
			{
				return _hasBeenPerformanceChecked;
			}
			set
			{
				_hasBeenPerformanceChecked = value;
			}
		}

		public int PartCount
		{
			get
			{
				return _partCount;
			}
			set
			{
				_partCount = value;
			}
		}

		public int WingCount
		{
			get
			{
				return _wingCount;
			}
			set
			{
				_wingCount = value;
			}
		}

		public AiAircraftInfo(string aircraftId, XElement xml = null)
		{
			string text = PlayerPrefs.GetString(GetPlayerPrefKeyForAircraft(aircraftId));
			AircraftId = aircraftId;
			AircraftXml = xml;
			if (string.IsNullOrEmpty(AircraftId) && AircraftXml != null)
			{
				AircraftId = (string)AircraftXml.Attribute("name");
			}
			if (!string.IsNullOrEmpty(text))
			{
				try
				{
					string[] array = text.Split('@');
					MaxAngularVelocities = array[0].ParseVector3();
					MaxAngularVelocitySpeeds = array[1].ParseVector3();
					bool result;
					bool flag = bool.TryParse(array[2], out result);
					AircraftIsFylable = (flag ? new bool?(result) : ((bool?)null));
					bool result2;
					bool flag2 = bool.TryParse(array[3], out result2);
					AircraftIsAbleToTakeOff = (flag2 ? new bool?(result2) : ((bool?)null));
					HasBeenPerformanceChecked = bool.Parse(array[4]);
					PartCount = int.Parse(array[5]);
					WingCount = int.Parse(array[6]);
					return;
				}
				catch (Exception ex)
				{
					Debug.LogWarningFormat("There was a problem reading the performance information for an aircraft, defaulting. Exception: {0}", ex.Message);
					RestoreDefaults();
					return;
				}
			}
			RestoreDefaults();
		}

		public void ForceFlyabilityRetests()
		{
			RestoreDefaults();
		}

		public float GetObjectAvoidanceDangerZoneDistance(AircraftScript aircraftScript)
		{
			float num = 0f;
			float num2 = 0f;
			if (HasBeenPerformanceChecked)
			{
				num = MathF.PI * 2f / MaxAngularVelocities.x;
				num2 = MathF.PI * 2f / MaxAngularVelocities.z;
				num /= 4f;
				num2 /= 4f;
			}
			else
			{
				num = 4f;
				num2 = 1.5f;
			}
			float num3 = (0f - aircraftScript.InstrumentData.Pitch) / 90f;
			num *= num3;
			float roll = aircraftScript.InstrumentData.Roll;
			float num4 = ((roll > 180f) ? (180f - (roll - 180f)) : roll) / 180f;
			num2 *= num4;
			num += 0.3f;
			num2 += 0.3f;
			num += 0.1f;
			num2 += 0.1f;
			float num5 = (num + num2) * aircraftScript.AirSpeed;
			float num6 = ((!(num3 > 0f)) ? float.MinValue : num5);
			return Mathf.Max(num6 * 2f, 2500f);
		}

		public void Save()
		{
			string playerPrefsString = GetPlayerPrefsString();
			PlayerPrefs.SetString(GetPlayerPrefKeyForAircraft(AircraftId), playerPrefsString);
			PlayerPrefs.Save();
		}

		public string GetPlayerPrefsString()
		{
			if (AircraftIsFylable == false)
			{
				Debug.LogWarningFormat("Aircraft is being marked as unflyable: {0}", AircraftId);
			}
			return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}", '@', MaxAngularVelocities.ToXAttributeValue(), MaxAngularVelocitySpeeds.ToXAttributeValue(), AircraftIsFylable.ToString(), AircraftIsAbleToTakeOff.HasValue ? AircraftIsAbleToTakeOff.Value.ToString() : "null", HasBeenPerformanceChecked.ToString(), PartCount.ToString(), WingCount.ToString());
		}

		private static string GetPlayerPrefKeyForAircraft(string aircraftId)
		{
			return string.Format("{0}{1}", "AiPerf_", aircraftId);
		}

		private void RestoreDefaults()
		{
			try
			{
				HasBeenPerformanceChecked = false;
				AircraftIsFylable = null;
				AircraftIsAbleToTakeOff = null;
				MaxAngularVelocities = Vector3.zero;
				MaxAngularVelocitySpeeds = Vector3.zero;
				if (!Game.Instance.CraftDatabase.TryGetCraft(AircraftId, out var craftFileInfo))
				{
					Debug.LogError("Could not find craft file for aircraft: " + AircraftId);
					return;
				}
				FileInfo fileInfo = new FileInfo(craftFileInfo.FullFilePath);
				if (!fileInfo.Exists || fileInfo.Length > 64000)
				{
					PartCount = int.MaxValue;
					WingCount = int.MaxValue;
					return;
				}
				XElement root = XDocument.Load(fileInfo.FullName).Root;
				PartCount = (from part in root.XPathSelectElements("Assembly/Parts/Part")
					select (part))?.Count() ?? 0;
				WingCount = (from wing in root.XPathSelectElements("Assembly/Parts/Part/Wing.State")
					where wing.Attribute("wingPhysicsEnabled") == null || wing.Attribute("wingPhysicsEnabled").Value == "true"
					select wing)?.Count() ?? 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				Debug.LogWarningFormat("Could not restore default AI info for aircraft: {0}", ex.Message);
			}
		}
	}
}
