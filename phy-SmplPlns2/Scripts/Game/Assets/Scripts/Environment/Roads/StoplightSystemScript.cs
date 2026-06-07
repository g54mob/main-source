using Assets.Scripts.Flight;
using UnityEngine;

namespace Assets.Scripts.Environment.Roads
{
	public class StoplightSystemScript : MonoBehaviour
	{
		private float _pauseDuration = 2f;

		private StoplightScript[] _stoplights;

		private float _totalCycleDuration;

		protected virtual void Start()
		{
			_stoplights = GetComponentsInChildren<StoplightScript>();
			for (int i = 0; i < _stoplights.Length; i++)
			{
				_stoplights[i].ChangeLight(StoplightType.Red);
			}
			StoplightScript[] stoplights = _stoplights;
			foreach (StoplightScript stoplightScript in stoplights)
			{
				_totalCycleDuration += stoplightScript.GreenDuration + stoplightScript.YellowDuration + _pauseDuration;
			}
		}

		protected void Update()
		{
			UpdateStoplights(FlightSceneScript.Instance.FlightSceneNetwork.PhysicsTime);
		}

		private void UpdateStoplights(float syncedNetworkTime)
		{
			float num = syncedNetworkTime % _totalCycleDuration;
			int num2 = -1;
			StoplightType stoplightType = StoplightType.Red;
			float num3 = num;
			for (int i = 0; i < _stoplights.Length; i++)
			{
				StoplightScript stoplightScript = _stoplights[i];
				float num4 = stoplightScript.GreenDuration + stoplightScript.YellowDuration;
				float num5 = num4 + _pauseDuration;
				if (num3 < num4)
				{
					num2 = i;
					stoplightType = ((!(num3 < stoplightScript.GreenDuration)) ? StoplightType.Yellow : StoplightType.Green);
					break;
				}
				if (num3 < num5)
				{
					num2 = -1;
					break;
				}
				num3 -= num5;
			}
			for (int j = 0; j < _stoplights.Length; j++)
			{
				StoplightType lightType = ((j == num2) ? stoplightType : StoplightType.Red);
				_stoplights[j].ChangeLight(lightType);
			}
		}
	}
}
