using UnityEngine;
using UnityEngine.UI;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class RawImageScrollerComponent : MonoBehaviour
	{
		[SerializeField]
		private RawImage _targetRawImage;

		[SerializeField]
		private float _xScrollSpeed;

		[SerializeField]
		private float _yScrollSpeed;

		private void Update()
		{
			_targetRawImage.uvRect = new Rect(_targetRawImage.uvRect.position + new Vector2(_xScrollSpeed, _yScrollSpeed) * Time.deltaTime, _targetRawImage.uvRect.size);
		}
	}
}
