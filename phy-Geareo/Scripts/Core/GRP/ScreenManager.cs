using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GRP
{
	public class ScreenManager : MonoBehaviour
	{
		private bool fullscreen;

		private int width;

		private int height;

		public static ScreenManager instance;

		public event Action onSizeChanged
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

		public event Action onFullscreenChanged
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

		public event Action onChanged
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

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
