using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[CreateAssetMenu(menuName = "ParadoxNotion/NodeCanvas/Dialogue Actor")]
	public class DialogueActorAsset : ScriptableObject, IDialogueActor
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

		public Color dialogueColor => default(Color);

		public Vector3 dialoguePosition => default(Vector3);

		public Transform transform => null;

		public Sprite portraitSprite => null;
	}
}
