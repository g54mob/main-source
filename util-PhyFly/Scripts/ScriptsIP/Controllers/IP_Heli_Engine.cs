using UnityEngine;
using System.Collections;

namespace SPACE_IP
{
	public class IP_Heli_Engine : MonoBehaviour
	{
		[SerializeField] int _maxHP = 140;
		[SerializeField] int _maxRPM = 2000;
		[SerializeField] float _powerDelay = 2f;

		[Header("just to log")]
		public float currHP;
		public float currRPM;

		// called externally
		public void UpdateEngine(float throttleInput)
		{
			Debug.Log(throttleInput);
		}
	}
}

/*
	called externally
	customized externally
*/