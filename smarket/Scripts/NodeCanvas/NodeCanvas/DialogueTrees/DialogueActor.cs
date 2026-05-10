using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[AddComponentMenu("NodeCanvas/Dialogue Actor")]
	public class DialogueActor : MonoBehaviour, IDialogueActor
	{
		[SerializeField]
		protected string _name;

		[SerializeField]
		protected Texture2D _portrait;

		[SerializeField]
		protected Color _dialogueColor;

		[SerializeField]
		protected Vector3 _dialogueOffset;

		private Sprite _portraitSprite;

		public new string name => null;

		public Texture2D portrait => null;

		public Sprite portraitSprite => null;

		public Color dialogueColor => default(Color);

		public Vector3 dialoguePosition => default(Vector3);

		Transform IDialogueActor.transform => null;
	}
}
