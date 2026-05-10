using System;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[Serializable]
	public class ProxyDialogueActor : IDialogueActor
	{
		private string _name;

		private Transform _transform;

		public string name => null;

		public Texture2D portrait => null;

		public Sprite portraitSprite => null;

		public Color dialogueColor => default(Color);

		public Vector3 dialoguePosition => default(Vector3);

		public Transform transform => null;

		public ProxyDialogueActor(string name, Transform transform)
		{
		}
	}
}
