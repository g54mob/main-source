using System;
using UnityEngine;

namespace PG
{
	[Serializable]
	public struct SceneField
	{
		public UnityEngine.Object SceneAsset;

		public string SceneName;

		public static implicit operator string(SceneField s)
		{
			return null;
		}
	}
}
