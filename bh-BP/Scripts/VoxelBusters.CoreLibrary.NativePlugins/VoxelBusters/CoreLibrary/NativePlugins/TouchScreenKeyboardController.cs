using System.Runtime.CompilerServices;
using UnityEngine;

namespace VoxelBusters.CoreLibrary.NativePlugins
{
	public class TouchScreenKeyboardController : MonoBehaviour
	{
		[ClearOnReload]
		private static TouchScreenKeyboardController s_sharedInstance;

		public static bool IsSupported => false;

		public static bool IsVisible { get; private set; }

		[ClearOnReload]
		public static event Callback OnKeyboardDidShow
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

		[ClearOnReload]
		public static event Callback OnKeyboardWillHide
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

		public static int GetKeyboardHeight(bool includeInput)
		{
			return 0;
		}

		private static bool IsKeyboardVisibleInternal()
		{
			return false;
		}

		private static bool IsKeyboardActiveInternal()
		{
			return false;
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void SendKeyboardDidShow()
		{
		}

		private void SendKeyboardWillHide()
		{
		}
	}
}
