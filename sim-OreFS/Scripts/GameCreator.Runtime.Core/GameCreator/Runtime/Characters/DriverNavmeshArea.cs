using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class DriverNavmeshArea
	{
		[SerializeField]
		private int m_Area;

		public int Area => m_Area;
	}
}
