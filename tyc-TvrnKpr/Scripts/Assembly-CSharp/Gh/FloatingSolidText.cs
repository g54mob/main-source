using I18n;
using UnityEngine;

namespace Gh
{
	public class FloatingSolidText : MonoBehaviour
	{
		[SerializeField]
		protected TextMeshProI18n _textObj;

		public string text;

		public Color textColor;

		protected Vector2 objectPosition;

		private Camera _currentCam;

		private Camera _overrideCam;

		private Vector3 _worldPositionAnchor;

		private float _zLevel;

		public bool lockPosition;

		private Vector3 _lastPosition;

		private Quaternion _lastRotation;

		public float scaleFactor;

		public float maxScale;

		public static FloatingSolidText Spawn(string text, Vector3 spawnPosition, Color? color = null)
		{
			return null;
		}

		private static FloatingSolidText SpawnFloatingText(GameObject prefab, string text, Vector3 spawnPosition, Color? color)
		{
			return null;
		}

		public void SetText(string value)
		{
		}

		private void Start()
		{
		}

		protected void SetLookAtCamera(Camera cam)
		{
		}

		public void SetPositionData(float zLevel, Vector3 worldPosition)
		{
		}

		private void UpdateAnchoredPosition()
		{
		}

		protected void LateUpdate()
		{
		}

		private void UpdateRotation()
		{
		}

		private void UpdateTextSize()
		{
		}

		protected virtual void OnDestroy()
		{
		}
	}
}
