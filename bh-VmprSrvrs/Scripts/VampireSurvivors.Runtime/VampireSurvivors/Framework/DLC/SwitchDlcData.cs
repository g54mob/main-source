using System;
using UnityEngine;

namespace VampireSurvivors.Framework.DLC
{
	[Serializable]
	public class SwitchDlcData
	{
		[Tooltip("A value between 1 and 2000. It is used for identifying downloadable content. Must be unique amongst all DLC.")]
		public int _AocIndex;

		public string _Tag;
	}
}
