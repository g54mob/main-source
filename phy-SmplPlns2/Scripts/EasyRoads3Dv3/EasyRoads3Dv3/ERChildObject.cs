using System;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERChildObject
	{
		public GameObject goSource;

		public GameObject goInstance;

		public ERChildObject(GameObject _goSource, GameObject _goInstance)
		{
			goSource = _goSource;
			goInstance = _goInstance;
		}
	}
}
