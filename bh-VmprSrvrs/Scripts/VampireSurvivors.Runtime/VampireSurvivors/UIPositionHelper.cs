using UnityEngine;

namespace VampireSurvivors
{
	public class UIPositionHelper : MonoBehaviour
	{
		[SerializeField]
		private bool _ShowDebug;

		[SerializeField]
		private RectTransform _PositionHelperTarget;

		private GameObject UITarget;

		private GameObject WorldTarget;

		private Canvas _canvas;

		private static UIPositionHelper Instance;

		[SerializeField]
		private RectTransform rTrans;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public static Vector3 GetWorldPosition(Vector2 pos)
		{
			return default(Vector3);
		}

		public static Vector3 GetWorldPositionFromUIElement(RectTransform rTransform)
		{
			return default(Vector3);
		}

		public static float GetYPositionFromScreenPosition(float screenPosY)
		{
			return 0f;
		}

		public static float GetXPositionFromScreenPosition(float screenPosX)
		{
			return 0f;
		}

		public static float ScreenWidth()
		{
			return 0f;
		}

		public static float ScreenHeight()
		{
			return 0f;
		}
	}
}
