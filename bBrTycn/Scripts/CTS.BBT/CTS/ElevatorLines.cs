using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(2)]
	public class ElevatorLines : MonoBehaviour
	{
		[SerializeField]
		private List<ElevatorLine> _elevatorLines = new List<ElevatorLine>();

		[SerializeField]
		private bool _debug;

		private void Awake()
		{
			foreach (ElevatorLine elevatorLine in _elevatorLines)
			{
				elevatorLine.Awake();
			}
		}
	}
}
