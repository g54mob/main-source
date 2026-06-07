using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T1GlitchedFrameAutocrafter : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _sprite;

		[SerializeField]
		private Sprite[] _available;

		private float _progress = 999999f;

		private ActiveAutoCrafter _crafter;

		private void OnEnable()
		{
			_crafter = GetComponent<ActiveAutoCrafter>();
		}

		private void Update()
		{
			AutoCrafter autoCrafter = (AutoCrafter)_crafter.Worker;
			if (autoCrafter != null)
			{
				if (autoCrafter.TimeAccumulated < _progress)
				{
					_sprite.sprite = SeededRandom.Global.Choose(_available);
				}
				_progress = autoCrafter.TimeAccumulated;
			}
		}
	}
}
