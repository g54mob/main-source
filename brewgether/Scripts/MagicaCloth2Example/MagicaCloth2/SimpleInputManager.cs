using UnityEngine;
using UnityEngine.Events;

namespace MagicaCloth2
{
	public class SimpleInputManager : CreateSingleton<SimpleInputManager>
	{
		private const int MaxFinger = 3;

		public float tapRadiusCm;

		public float flickRangeCm;

		public float flickCheckSpeed;

		public float mouseWheelSpeed;

		private int mainFingerId;

		private int subFingerId;

		private Vector2[] downPos;

		private Vector2[] lastPos;

		private Vector2[] flickDownPos;

		private float[] flickDownTime;

		private float lastTime;

		private bool mobilePlatform;

		private bool[] mouseDown;

		private Vector2[] mouseOldMovePos;

		private float screenDpi;

		private float screenDpc;

		public static UnityAction<int, Vector2> OnTouchDown;

		public static UnityAction<int, Vector2, Vector2, Vector2> OnTouchMove;

		public static UnityAction<int, Vector2, Vector2, Vector2> OnDoubleTouchMove;

		public static UnityAction<int, Vector2> OnTouchUp;

		public static UnityAction<int, Vector2> OnTouchMoveCancel;

		public static UnityAction<int, Vector2> OnTouchTap;

		public static UnityAction<int, Vector2, Vector2, Vector2> OnTouchFlick;

		public static UnityAction<float, float> OnTouchPinch;

		public static UnityAction OnBackButton;

		public static float ScreenDpi => 0f;

		public static float ScreenDpc => 0f;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Init()
		{
		}

		protected override void InitSingleton()
		{
		}

		protected void Update()
		{
		}

		private void CalcScreenDpi()
		{
		}

		private void AllResetTouchInfo()
		{
		}

		public int GetTouchCount()
		{
			return 0;
		}

		public bool IsUI()
		{
			return false;
		}

		private void UpdateMobile()
		{
		}

		private Vector2 CalcScreenRatioVector(Vector2 vec)
		{
			return default(Vector2);
		}

		private bool CheckFlic(int fid, Vector2 oldpos, Vector2 nowpos, Vector2 downpos, float flicktime)
		{
			return false;
		}

		private void UpdateMouse()
		{
		}
	}
}
