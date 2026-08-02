using System;
using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace
{
	[AddComponentMenu("FImpossible Creations/Utilities/Hierarchy Shortcut")]
	public class FHierarchyShortcut : FimpossibleComponent
	{
		[Serializable]
		private class SceneReference
		{
			public string Title = "Scene Object";

			public UnityEngine.Object Reference;
		}

		[SerializeField]
		[HideInInspector]
		private List<SceneReference> References = new List<SceneReference>();
	}
}
