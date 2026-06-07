using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtRenderingPipeline : ScriptableObject
	{
		private static SgtRenderingPipeline instance;

		[SerializeField]
		private bool isScriptable;

		public static bool IsScriptable => false;

		public static event Action<bool> OnPipelineChanged
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
	}
}
