using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class DynamicCanvasScaler : MonoBehaviour
	{
		[SerializeField]
		private Vector2 _ReferenceResolution;

		private CanvasScaler _scaler;

		private float _referenceAspect;

		[SerializeField]
		private Vector2 _CurrentResolution;

		[SerializeField]
		private float _currentAspect;

		[SerializeField]
		private float _panelWidth;

		[SerializeField]
		private float _lerp;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
