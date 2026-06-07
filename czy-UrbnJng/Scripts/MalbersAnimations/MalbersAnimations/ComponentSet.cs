using System;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	public class ComponentSet
	{
		public string name = "Description Here";

		[TextArea]
		public string tooltip;

		public bool active = true;

		public GameObject[] gameObjects;

		public MonoBehaviour[] monoBehaviours;
	}
}
