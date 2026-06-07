using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class CameraPreRender : MonoBehaviour
	{
		public static event EventHandler onPreCull
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

		private void OnPreCull()
		{
		}
	}
}
