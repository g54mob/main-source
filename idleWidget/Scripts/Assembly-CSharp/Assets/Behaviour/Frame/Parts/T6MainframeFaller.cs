using System.Collections;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T6MainframeFaller : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _renderer;

		[SerializeField]
		private Sprite[] _sprites;

		[SerializeField]
		private float _yOffset;

		[SerializeField]
		private float _endY;

		[SerializeField]
		private Color _endColor;

		private Color _startColor;

		private void Start()
		{
			_startColor = _renderer.color;
			_renderer.sprite = SeededRandom.Global.Choose(_sprites);
			StartCoroutine(_doFaller());
		}

		private IEnumerator _doFaller()
		{
			yield return new WaitForSeconds(0.15f);
			float num = base.transform.localPosition.y + _yOffset;
			if (num > _endY)
			{
				Object.Instantiate(base.gameObject, base.transform.parent).transform.localPosition = new Vector3(base.transform.localPosition.x, num, base.transform.localPosition.z);
			}
			else
			{
				GetComponentInParent<T6MainframeConsole>().CheckFaller(this);
			}
			float timer = 0f;
			while (timer < 1f)
			{
				timer += Time.deltaTime;
				_renderer.color = Color.Lerp(_startColor, _endColor, timer);
				yield return null;
			}
			Object.Destroy(base.gameObject);
		}
	}
}
