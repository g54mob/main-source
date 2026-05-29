using System;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[Serializable]
	public struct GraphDataline
	{
		public LocalizedString name;

		public Color colorActive;

		public Color colorInactive;
	}
}
