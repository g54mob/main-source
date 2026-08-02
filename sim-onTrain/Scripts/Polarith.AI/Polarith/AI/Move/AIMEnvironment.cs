using System;
using System.Collections.Generic;
using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Perception/AIM Environment")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-environment.html")]
	public sealed class AIMEnvironment : MonoBehaviour
	{
		[Tooltip("Identifies this environment within the AI components of an agent. Needs to be unique, otherwise, the agent components can only identify the first environment found with the specified label.")]
		public string Label;

		[Tooltip("Determines if the contained game objects should be considered static by derived 'AIMPerceiver' components.")]
		public bool Static;

		[Tooltip("Every game object having one of the specified layers is belonging to the world which might be visible to (multiple) agents. Objects belonging to layers are updated at least once on every runtime start.")]
		[Layer]
		public List<string> Layers = new List<string>();

		[Tooltip("Every instance within this list belongs to the world which might be visible to (multiple) agents.")]
		public List<GameObject> GameObjects = new List<GameObject>();

		[NonSerialized]
		public List<GameObject> LayerGameObjects = new List<GameObject>();

		[SerializeField]
		[HideInInspector]
		private TabState tabState;

		public void UpdateLayerGameObjects()
		{
			LayerGameObjects.Clear();
			for (int i = 0; i < Layers.Count; i++)
			{
				LayerGameObjects.AddRange(Polarith.UnityUtils.GameObjects.FindGameObjectsWithLayer(Layers[i]));
			}
		}

		private void Start()
		{
			UpdateLayerGameObjects();
		}
	}
}
