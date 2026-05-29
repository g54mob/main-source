using System;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[Obsolete]
	public class TESTING_AddPower : MonoBehaviour
	{
		private Worker curentWorker;

		private void Start()
		{
			curentWorker = GetComponent<Worker>();
		}
	}
}
