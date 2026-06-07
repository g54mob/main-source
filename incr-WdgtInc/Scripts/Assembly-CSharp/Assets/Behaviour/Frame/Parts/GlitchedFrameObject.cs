using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class GlitchedFrameObject : MonoBehaviour
	{
		private float _fadeTimer;

		private void Start()
		{
			_fadeTimer = SeededRandom.Global.RandomRange(2f, 4f);
			if (SeededRandom.Global.RandomBool())
			{
				SpriteRenderer component = GetComponent<SpriteRenderer>();
				component.flipX = SeededRandom.Global.RandomBool();
				component.flipY = SeededRandom.Global.RandomBool();
			}
		}

		private void Update()
		{
			_fadeTimer -= Time.deltaTime;
			if (_fadeTimer < 0f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
