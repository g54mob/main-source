using System.Collections.Generic;
using Febucci.TextAnimatorCore.Data;
using Febucci.TextAnimatorCore.Typing;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity
{
	internal class GlobalActionComponentsDatabase : MonoBehaviour, IDatabaseProvider<ITypewriterAction>
	{
		private static GlobalActionComponentsDatabase instance;

		public static GlobalActionComponentsDatabase Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new GameObject("Text Animator - Global Action Components Database").AddComponent<GlobalActionComponentsDatabase>();
					Object.DontDestroyOnLoad(instance.gameObject);
					instance.gameObject.hideFlags = HideFlags.HideAndDontSave;
					instance.Database = new Dictionary<string, ITypewriterAction>();
				}
				return instance;
			}
		}

		public Dictionary<string, ITypewriterAction> Database { get; private set; }

		public void Register(ITypewriterAction action)
		{
			if (!Database.ContainsKey(action.TagID))
			{
				Database.Add(action.TagID, action);
			}
		}

		public void Unregister(ITypewriterAction action)
		{
			if (Database.ContainsKey(action.TagID) && Database.ContainsValue(action))
			{
				Database.Remove(action.TagID);
			}
		}

		private void OnDestroy()
		{
			instance = null;
		}
	}
}
