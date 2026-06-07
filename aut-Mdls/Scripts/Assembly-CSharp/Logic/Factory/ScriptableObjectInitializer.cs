using System.Collections.Generic;
using UnityEngine;

namespace Logic.Factory
{
	public class ScriptableObjectInitializer : MonoBehaviour
	{
		[SerializeField]
		private List<InitScriptableObject> _scriptableObjects;

		private void Awake()
		{
			foreach (InitScriptableObject scriptableObject in _scriptableObjects)
			{
				scriptableObject.Init();
			}
		}
	}
}
