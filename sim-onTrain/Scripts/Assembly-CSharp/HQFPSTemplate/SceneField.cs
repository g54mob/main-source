using System;
using UnityEngine;

namespace HQFPSTemplate
{
	[Serializable]
	public class SceneField
	{
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		[SerializeField]
		private string m_SceneName = "";

		public UnityEngine.Object SceneAsset => m_SceneAsset;

		public string SceneName => m_SceneName;

		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}
	}
}
