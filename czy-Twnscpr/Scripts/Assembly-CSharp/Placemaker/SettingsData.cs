using System;
using UnityEngine;

namespace Placemaker
{
	[Serializable]
	public class SettingsData
	{
		[Serializable]
		public struct Screenshot
		{
			public string path;

			public int x;

			public int y;
		}

		[Serializable]
		public struct ObjExport
		{
			public string path;
		}

		[Serializable]
		public struct Axis
		{
			public bool rotationXInverted;

			public bool rotationYInverted;
		}

		[SerializeField]
		public int version;

		[SerializeField]
		public string lastSave;

		[SerializeField]
		public byte currentColor;

		[SerializeField]
		public byte audioVolume;

		[SerializeField]
		public bool antiAliasing;

		[SerializeField]
		public Axis axis;

		[SerializeField]
		public bool vSync;

		[SerializeField]
		public bool fullscreen;

		public string language;

		public Screenshot screenshot;

		public ObjExport objExport;

		[SerializeField]
		public byte uiSizePercentage;

		[SerializeField]
		public string lastRunVersion;
	}
}
