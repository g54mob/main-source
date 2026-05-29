using System;
using UnityEngine;

namespace CW.Common
{
	public class CwGuide : ScriptableObject
	{
		public string LongName;

		public string ShortName;

		public TextAsset Documentation;

		[NonSerialized]
		private Texture2D icon;

		[NonSerialized]
		private string version;

		public Texture2D Icon => null;

		public string Version => null;
	}
}
