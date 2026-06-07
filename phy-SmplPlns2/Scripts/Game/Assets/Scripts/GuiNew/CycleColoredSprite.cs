using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GuiNew
{
	public class CycleColoredSprite : MonoBehaviour
	{
		[SerializeField]
		private Color _activeColor = new Color(0.972549f, 0.7019608f, 0.007843138f, 1f);

		[SerializeField]
		private float _cycleDelay = 0.25f;

		[SerializeField]
		private Color _idleColor = new Color(0.4862745f, 0.3509804f, 0.003921569f, 1f);

		[SerializeField]
		private Image[] _images;

		private int _lastChangedIndex;

		[SerializeField]
		private bool _oneCycleWithNoneActive = true;

		protected virtual void OnEnable()
		{
			StartCoroutine(Cycle());
		}

		private IEnumerator Cycle()
		{
			while (_images != null && _images.Length != 0)
			{
				_images[_lastChangedIndex].color = _idleColor;
				if (_lastChangedIndex == _images.Length - 1 && _oneCycleWithNoneActive)
				{
					yield return new WaitForSeconds(_cycleDelay);
					_images[_lastChangedIndex].color = _idleColor;
					yield return new WaitForSeconds(_cycleDelay);
				}
				_lastChangedIndex = ((_lastChangedIndex != _images.Length - 1) ? (_lastChangedIndex + 1) : 0);
				_images[_lastChangedIndex].color = _activeColor;
				yield return new WaitForSeconds(_cycleDelay);
			}
		}
	}
}
