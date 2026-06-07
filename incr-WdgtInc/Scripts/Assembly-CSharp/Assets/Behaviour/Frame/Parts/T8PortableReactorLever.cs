using System.Collections;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T8PortableReactorLever : MonoBehaviour
	{
		private bool _mouseDown;

		private float _leverAngle = 360f;

		[SerializeField]
		private SpriteRenderer _hint;

		private void Update()
		{
			if (PlayerControls.InteractRelease)
			{
				_mouseDown = false;
			}
			if (!_mouseDown)
			{
				return;
			}
			Vector3 vector = PlayerControls.MouseWorld;
			float num = 360f - Vector2.SignedAngle(base.transform.position - vector, Vector2.right);
			if (_leverAngle < 360f && num > 360f)
			{
				num -= 360f;
			}
			if (!(num < _leverAngle) || !(_leverAngle - num < 150f))
			{
				return;
			}
			if ((bool)_hint)
			{
				StartCoroutine(_hideHint());
			}
			_leverAngle = num;
			base.transform.localEulerAngles = new Vector3(0f, 0f, _leverAngle);
			if (num < 10f)
			{
				T8PortableReactor t8PortableReactor = GetComponentInParent<ActiveWorldFrame>().ActiveFrame as T8PortableReactor;
				if (!t8PortableReactor.GetManualCrafter(0).Active)
				{
					UISounds.CraftStep();
					t8PortableReactor.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
				}
				_leverAngle = 360f + num;
			}
		}

		private void OnMouseDown()
		{
			_mouseDown = true;
		}

		private IEnumerator _hideHint()
		{
			SpriteRenderer hint = _hint;
			_hint = null;
			Color start = hint.color;
			Color end = new Color(0f, 0f, 0f, 0f);
			float time = 0.5f;
			while (time > 0f)
			{
				time -= Time.deltaTime;
				hint.color = Color.Lerp(start, end, 1f - time * 2f);
				yield return null;
			}
			Object.Destroy(hint.gameObject);
		}
	}
}
