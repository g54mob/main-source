using System;
using System.Collections.Generic;
using System.Text;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.Logic.Job
{
	public class IdGenerator : SingletonBehaviour<IdGenerator>
	{
		public const string GENERIC_YARD_NAME = "#Y";

		public const string GENERIC_SUB_YARD_NAME = "#S";

		public const string GENERIC_TRACK_TYPE = "#T";

		private const int ID_PER_TRAINCAR_TYPE_LIMIT = 1000;

		private const int ID_PER_LOCO_TYPE_LIMIT = 100;

		private const string ID_NUMBER_FORMAT = "D3";

		private const string JOB_ID_FORMAT = "{0}-{1:D2}";

		private const string JOB_ID_WITH_STATION_FORMAT = "{0}-{1}-{2:D2}";

		private const int ID_PER_JOB_TYPE_LIMIT = 100;

		private const string LOCO_ID_PREFIX = "L";

		private const string NON_LOCO_ID_PREFIX = "C";

		public Dictionary<string, Car> carGuidToCar = new Dictionary<string, Car>();

		private HashSet<string> existingCarIds = new HashSet<string>();

		private HashSet<string> existingJobIds = new HashSet<string>();

		private HashSet<string> reservedCarIds = new HashSet<string>();

		private int TrackIdGenerator;

		private static System.Random idRng = new System.Random();

		public new static string AllowAutoCreate()
		{
			return "[IdGenerator]";
		}

		public string GenerateCarID(TrainCarLivery carType)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = CarTypes.IsLocomotive(carType);
			stringBuilder.Append(flag ? "L" : "C");
			stringBuilder.Append(carType.parentType.carInstanceIdGenBase);
			int num = (flag ? 100 : 1000);
			bool flag2 = false;
			int num2 = idRng.Next(0, num);
			int num3 = num2;
			do
			{
				string text = num3.ToString("D3");
				string item = stringBuilder.ToString() + text;
				if (!existingCarIds.Contains(item) && !reservedCarIds.Contains(item))
				{
					stringBuilder.Append(text);
					flag2 = true;
					break;
				}
				num3 = ((num3 < num - 1) ? (num3 + 1) : 0);
			}
			while (num3 != num2);
			if (!flag2)
			{
				Debug.LogError($"Couldn't find free carId for type:{carType} within limit [{num}]! Finding first available carId number above limit!");
				int num4 = num;
				string text2;
				while (true)
				{
					text2 = num4.ToString("D3");
					string item2 = stringBuilder.ToString() + text2;
					if (!existingCarIds.Contains(item2) && !reservedCarIds.Contains(item2))
					{
						break;
					}
					num4++;
				}
				stringBuilder.Append(text2);
			}
			string text3 = stringBuilder.ToString();
			RegisterCarId(text3);
			return text3;
		}

		public TrackID GenerateGenericTrackID()
		{
			return new TrackID("#Y", "#S", TrackIdGenerator++.ToString(), "#T");
		}

		public string GenerateJobID(JobType jobType, StationsChainData jobStationsInfo = null)
		{
			string text;
			switch (jobType)
			{
			case JobType.Transport:
				text = "FH";
				break;
			case JobType.ShuntingLoad:
				text = "SL";
				break;
			case JobType.ShuntingUnload:
				text = "SU";
				break;
			case JobType.EmptyHaul:
				text = "LH";
				break;
			case JobType.Custom:
				text = "CU";
				break;
			case JobType.ComplexTransport:
				text = "CT";
				break;
			default:
				text = "Invalid";
				throw new Exception("Trying to generate ID for Unknown job type");
			}
			string text2 = string.Empty;
			if (jobStationsInfo != null)
			{
				text2 = ((jobType != JobType.ShuntingUnload) ? jobStationsInfo.chainOriginYardId : jobStationsInfo.chainDestinationYardId);
			}
			else
			{
				Debug.LogWarning("Provided jobStationsInfo is null. Generating job id without station id");
			}
			bool flag = !string.IsNullOrEmpty(text2);
			bool flag2 = false;
			string text3 = "";
			int num = idRng.Next(0, 100);
			int num2 = num;
			do
			{
				text3 = (flag ? $"{text2}-{text}-{num2:D2}" : $"{text}-{num2:D2}");
				if (!existingJobIds.Contains(text3))
				{
					flag2 = true;
					break;
				}
				num2 = ((num2 < 99) ? (num2 + 1) : 0);
			}
			while (num2 != num);
			if (!flag2)
			{
				Debug.LogError("Couldn't find free jobId for job type: " + text + "! Using 0 for jobId number!");
				text3 = (flag ? $"{text2}-{text}-{0:D2}" : $"{text}-{0:D2}");
			}
			RegisterJobId(text3);
			return text3;
		}

		public void RegisterJobId(string jobId)
		{
			if (!existingJobIds.Add(jobId))
			{
				Debug.LogError("jobId: " + jobId + " was already registered!");
			}
		}

		public void UnregisterJobId(string jobId)
		{
			if (!existingJobIds.Remove(jobId))
			{
				Debug.LogError("jobId: " + jobId + " wasn't registered!");
			}
		}

		public void RegisterCarId(string carId)
		{
			if (!existingCarIds.Add(carId))
			{
				Debug.LogError("carId: " + carId + " was already registered!");
			}
			if (reservedCarIds.Contains(carId))
			{
				Debug.LogError("carId: " + carId + " is reserved!");
			}
		}

		public void UnregisterCarId(string carId)
		{
			if (!existingCarIds.Remove(carId))
			{
				Debug.LogError("carId: " + carId + " wasn't registered!");
			}
		}

		public void ReserveCarId(string carId)
		{
			if (!reservedCarIds.Add(carId))
			{
				Debug.LogError("carId: " + carId + " was already reserved!");
			}
		}

		public void UnReserveCarId(string carId)
		{
			if (!reservedCarIds.Remove(carId))
			{
				Debug.LogError("carId: " + carId + " wasn't reserved!");
			}
		}
	}
}
