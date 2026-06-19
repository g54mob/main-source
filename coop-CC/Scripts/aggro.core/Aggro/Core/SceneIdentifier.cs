using System;
using UnityEngine;

namespace Aggro.Core
{
	[Serializable]
	public struct SceneIdentifier
	{
		public string guid;

		[HideInInspector]
		public SceneIdentifiableDatabase database;
	}
}
