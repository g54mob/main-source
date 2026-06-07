using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public class SgtDocumentation : ScriptableObject
	{
		public string Title;

		public string YouTube;

		public string Forum;

		public string Link;

		public string IconData;

		public string HTML;

		[NonSerialized]
		private Texture2D icon;

		public Texture2D Icon => null;
	}
}
