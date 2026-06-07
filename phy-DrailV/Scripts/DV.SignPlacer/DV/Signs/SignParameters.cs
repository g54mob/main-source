using System;
using UnityEngine;

namespace DV.Signs
{
	[Serializable]
	public struct SignParameters
	{
		public SignType type;

		public BaseSign sign;

		public string signText;

		public GameObject[] accessories;
	}
}
