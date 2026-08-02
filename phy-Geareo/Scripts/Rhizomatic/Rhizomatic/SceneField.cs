using System;
using UnityEngine;

namespace Rhizomatic
{
	[Serializable]
	public class SceneField
	{
		[SerializeField]
		private UnityEngine.Object _asset;

		[SerializeField]
		private string _name;

		[SerializeField]
		private string _path;

		public string name => null;

		public string path => null;
	}
}
