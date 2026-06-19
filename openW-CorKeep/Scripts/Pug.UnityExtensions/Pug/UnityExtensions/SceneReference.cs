using System;
using System.IO;
using UnityEngine;

namespace Pug.UnityExtensions
{
	[Serializable]
	public class SceneReference : ISerializationCallbackReceiver
	{
		[SerializeField]
		private string scenePath = string.Empty;

		public string ScenePath
		{
			get
			{
				return scenePath;
			}
			set
			{
				scenePath = value;
			}
		}

		public string SceneName => Path.GetFileNameWithoutExtension(scenePath);

		public bool SceneIsAssigned()
		{
			return scenePath != string.Empty;
		}

		public static implicit operator string(SceneReference sceneReference)
		{
			return sceneReference.ScenePath;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
