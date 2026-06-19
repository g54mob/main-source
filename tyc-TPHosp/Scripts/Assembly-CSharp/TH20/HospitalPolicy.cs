using JetBrains.Annotations;

namespace TH20
{
	public class HospitalPolicy
	{
		[UsedImplicitly]
		public class ConfigData
		{
			public float DiagnosisCertaintyMin = 50f;

			public float DiagnosisCertaintyMax = 100f;

			public float DiagnosisCertaintyDefault = 90f;

			public int QueueWarningMin = 1;

			public int QueueWarningMax = 20;

			public int QueueWarningDefault = 6;

			public bool AutoSendForTreatment;

			public bool StaffLeaveRooms = true;

			public bool StaffTrainingRequests = true;

			public bool StaffPromotion;
		}

		private ConfigData _config;

		public ConfigData Config => _config;

		public float DiagnosisCertainty { get; set; } = 90f;

		public bool AutoSendForTreatment { get; set; }

		public int QueueWarningLength { get; set; } = 6;

		public bool StaffLeaveRooms { get; set; } = true;

		public bool StaffTrainingRequests { get; set; } = true;

		public bool StaffPromotion { get; set; }

		public HospitalPolicy(ConfigData config)
		{
			_config = config;
			Reset();
		}

		public void Reset()
		{
			DiagnosisCertainty = _config.DiagnosisCertaintyDefault;
			AutoSendForTreatment = _config.AutoSendForTreatment;
			QueueWarningLength = _config.QueueWarningDefault;
			StaffLeaveRooms = _config.StaffLeaveRooms;
			StaffTrainingRequests = _config.StaffTrainingRequests;
			StaffPromotion = _config.StaffPromotion;
		}
	}
}
