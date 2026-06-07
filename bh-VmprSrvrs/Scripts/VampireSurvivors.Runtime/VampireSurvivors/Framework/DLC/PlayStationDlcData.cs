using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace VampireSurvivors.Framework.DLC
{
	[Serializable]
	public class PlayStationDlcData
	{
		[SerializeField]
		private string _ContentLabel;

		[SerializeField]
		private string _ServiceId;

		[SerializeField]
		private string _EntitlementKey;

		[SerializeField]
		private string _IconAssetPath;

		public string ContentLabel => null;

		public string ServiceId => null;

		public string EntitlementKey => null;

		public string IconAssetPath => null;

		public string ContentId()
		{
			return null;
		}

		public void UpdateEntitlementKey(string newEntitlementKey)
		{
		}

		private bool IsContentLabelValid(string contentLabel, ref string errorMessage, ref InfoMessageType? messageType)
		{
			return false;
		}

		private bool IsServiceIdValid(string serviceId, ref string errorMessage, ref InfoMessageType? messageType)
		{
			return false;
		}

		private bool IsEntitlementKeyValid(string entitlementKey, ref string errorMessage, ref InfoMessageType? messageType)
		{
			return false;
		}
	}
}
