using Cainos.LucidEditor;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Village
{
	public class Door : MonoBehaviour
	{
		[FoldoutGroup("Params")]
		public bool enableAutoClose;

		[FoldoutGroup("Params")]
		public float autoCloseTime;

		[FoldoutGroup("Reference")]
		public SpriteRenderer spriteRendererDoor;

		[FoldoutGroup("Reference")]
		public SpriteRenderer spriteRendererShadow;

		[Space]
		[FoldoutGroup("Reference")]
		public Sprite spriteDoorOpened;

		[FoldoutGroup("Reference")]
		public Sprite spriteDoorClosed;

		[Space]
		[FoldoutGroup("Reference")]
		public Sprite spriteShadowOpened;

		[FoldoutGroup("Reference")]
		public Sprite spriteShadowClosed;

		private float autoCloseTimer;

		private Animator animator;

		[SerializeField]
		[HideInInspector]
		private bool isOpened;

		private Animator Animator => null;

		[FoldoutGroup("Runtime")]
		[ShowInInspector]
		public bool IsOpened
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[FoldoutGroup("Runtime")]
		[HorizontalGroup("Runtime/Button")]
		[Button("Open")]
		public void Open()
		{
		}

		[FoldoutGroup("Runtime")]
		[HorizontalGroup("Runtime/Button")]
		[Button("Close")]
		public void Close()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
