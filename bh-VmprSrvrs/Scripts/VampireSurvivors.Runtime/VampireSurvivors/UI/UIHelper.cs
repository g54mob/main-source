using System.Runtime.CompilerServices;
using UnityEngine;

namespace VampireSurvivors.UI
{
	public class UIHelper : MonoBehaviour
	{
		public delegate void OnInputMethodChanged(ActiveInputType newInput);

		public enum ActiveInputType
		{
			VOID = 0,
			MOUSE = 1,
			KEYBOARD = 2,
			CONTROLLER = 3
		}

		[SerializeField]
		private bool _ForceAspectRatio;

		[SerializeField]
		private RectTransform _SafeArea;

		[SerializeField]
		private RectTransform _AspectMask;

		[SerializeField]
		private bool _DisablePixelPerfectOnLowEndDevices;

		private Vector3 _prevMousePos;

		private ActiveInputType _prevInput;

		private Canvas _canvas;

		private ActiveInputType _currentInput;

		private static UIHelper Instance;

		private static float _scaleFactor;

		public static float JS_MAGIC_SCALE_NUMBER;

		public static Canvas Canvas => null;

		public static ActiveInputType ActiveInput => default(ActiveInputType);

		public static float ScaleFactor => 0f;

		public static float ScreenHeight => 0f;

		public static float SafeScreenHeight => 0f;

		public static float SafeScreenWidth => 0f;

		public static bool IsPortrait => false;

		public static float WidthToHeightRatio => 0f;

		public static bool IsPortraitAndMobile => false;

		public static float ScreenWidth => 0f;

		public static Vector2 SafeArea => default(Vector2);

		public static float AspectRatio => 0f;

		public static event OnInputMethodChanged InputMethodChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static float GetAspectLockedWidth()
		{
			return 0f;
		}

		public static RectTransform GetSafeAreaObject()
		{
			return null;
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void SetUpLandscape()
		{
		}
	}
}
