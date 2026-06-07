using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

namespace DV
{
	public class WeatherGameParamsSetter : MonoBehaviour
	{
		private void Start()
		{
			SingletonBehaviour<WeatherDriver>.Instance.SetGameParams(Globals.G.GameParams.WeatherParams);
			Object.Destroy(this);
		}
	}
}
