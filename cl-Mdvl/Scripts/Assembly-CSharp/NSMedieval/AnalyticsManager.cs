using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

namespace NSMedieval
{
	public class AnalyticsManager : MonoSingleton<AnalyticsManager>
	{
		public void OnScreenVisit(string screenName, IDictionary<string, object> eventData = null)
		{
		}

		private void OnDateUpdate()
		{
		}

		private Dictionary<string, object> AttachStandardParams(string paramName, object paramObject)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{ paramName, paramObject },
				{
					"total_workers",
					GlobalSaveController.CurrentVillageData.Workers.Count
				},
				{
					"village_name",
					GlobalSaveController.CurrentVillageData.Name
				}
			};
			string text = "Parameters Sent:";
			foreach (KeyValuePair<string, object> item in dictionary)
			{
				text += $"\n   - {item.Key}: {item.Value}";
			}
			Log.Debug(text, "C:\\GIT\\dev\\Assets\\Scripts\\Analytics\\AnalyticsManager.cs");
			return dictionary;
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		private void Start()
		{
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
		}

		private void OnSessionStateChanged(AnalyticsSessionState sessionState, long sessionId, long sessionElapsedTime, bool sessionChanged)
		{
		}
	}
}
