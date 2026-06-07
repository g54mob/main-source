using System;
using UnityEngine;

namespace DV.Logic.Job
{
	[Serializable]
	public class TrackID
	{
		public const string STORAGE_TYPE = "S";

		public const string LOADING_TYPE = "L";

		public const string REGULAR_IN_TYPE = "I";

		public const string REGULAR_OUT_TYPE = "O";

		public const string PARKING_TYPE = "P";

		public const string MAIN_LINE_TYPE = "M";

		public const string STORAGE_PASSENGER_TYPE = "SP";

		public const string LOADING_PASSENGER_TYPE = "LP";

		private const string FULL_FORMAT = "{0}-{1}-{2}-{3}";

		private const string DELIMITER = "-";

		[SerializeField]
		public string yardId;

		[SerializeField]
		private string subYardId;

		[SerializeField]
		private string trackType;

		[SerializeField]
		private string orderNumber;

		private string _trimmedOrderNumber;

		private string TrimmedOrderNumber
		{
			get
			{
				if (_trimmedOrderNumber == null)
				{
					_trimmedOrderNumber = orderNumber.TrimStart('0');
				}
				return _trimmedOrderNumber;
			}
		}

		public string TrackPartOnly => subYardId + TrimmedOrderNumber + trackType;

		public string FullDisplayID => yardId + "-" + subYardId + TrimmedOrderNumber + trackType;

		public string SignIDSubYardPart => subYardId;

		public string SignIDTrackPart => TrimmedOrderNumber + trackType;

		public string RailTrackGameObjectID => "[Y]_[" + yardId + "]_[" + subYardId + "-" + orderNumber + "-" + trackType + "]";

		public string FullID => $"{yardId}-{subYardId}-{orderNumber}-{trackType}";

		public TrackID(string yardId, string subYardId, string orderNumber, string trackType)
		{
			this.yardId = yardId;
			this.subYardId = subYardId;
			this.orderNumber = orderNumber;
			this.trackType = trackType;
		}

		public bool IsGeneric()
		{
			if (!(yardId == "#Y") && !(subYardId == "#S"))
			{
				return trackType == "#T";
			}
			return true;
		}

		public override string ToString()
		{
			return FullDisplayID;
		}
	}
}
