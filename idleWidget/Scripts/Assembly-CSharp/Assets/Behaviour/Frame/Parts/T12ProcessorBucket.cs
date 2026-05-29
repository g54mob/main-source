using System.Collections;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12ProcessorBucket : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _requiredSprite;

		[SerializeField]
		private SpriteRenderer _requiredBackdrop;

		[SerializeField]
		private Sprite[] _processorSprites;

		private ActiveWorldFrame _parent;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		private void OnEnable()
		{
			SetupPuzzle();
		}

		public void SetupPuzzle()
		{
			Sprite sprite;
			do
			{
				sprite = SeededRandom.Global.Choose(_processorSprites);
			}
			while (sprite == _requiredSprite.sprite);
			_requiredSprite.sprite = sprite;
			_requiredBackdrop.sprite = sprite;
		}

		private IEnumerator OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.GetComponentInChildren<SpriteRenderer>().sprite == _requiredSprite.sprite)
			{
				_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
				yield return new WaitForSeconds(0.5f);
				SetupPuzzle();
			}
			else
			{
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Incorrect processor inserted!");
			}
			Object.Destroy(collision.gameObject);
		}
	}
}
