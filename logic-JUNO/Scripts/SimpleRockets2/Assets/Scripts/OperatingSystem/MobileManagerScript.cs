using Assets.Scripts.Flight;
using Assets.Scripts.State;
using ModApi;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.OperatingSystem
{
	public class MobileManagerScript : MonoBehaviour
	{
		public static MobileManagerScript Create(GameObject parent)
		{
			if (Device.IsAndroidBuild)
			{
				return AndroidManagerScript.CreateAndroidManager(parent);
			}
			if (Device.IsIosBuild)
			{
				return IosManagerScript.CreateIosManager(parent);
			}
			return null;
		}

		protected virtual void OnApplicationPause(bool paused)
		{
			if (paused)
			{
				Debug.Log("Application Paused");
				if (Game.InDesignerScene)
				{
					Debug.Log("Suspending application. Saving designer editor craft.");
					Game.Instance.Designer.SaveCraft(CraftDesigns.EditorCraftId);
					ApplicationState.AppSuspended = true;
				}
				else if (Game.InFlightScene)
				{
					Debug.Log("Suspending application. Saving game state and flight state.");
					GameState gameState = Game.Instance.GameState;
					if (gameState.Type == GameStateType.Default || gameState.Type == GameStateType.Simulation)
					{
						FlightSceneScript.Instance.FlightState.Save();
						gameState.Save();
						ApplicationState.AppSuspended = true;
					}
				}
			}
			else
			{
				Debug.Log("Application Resumed");
				if (Game.InFlightScene || Game.InDesignerScene)
				{
					ApplicationState.AppSuspended = false;
				}
			}
		}
	}
}
