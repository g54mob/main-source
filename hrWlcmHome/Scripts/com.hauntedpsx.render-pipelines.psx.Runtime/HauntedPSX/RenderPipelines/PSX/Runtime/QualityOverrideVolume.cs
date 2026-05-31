using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	[Serializable]
	[VolumeComponentMenu("HauntedPS1/QualityOverrideVolume")]
	public class QualityOverrideVolume : VolumeComponent
	{
		public BoolParameter isPSXQualityEnabled = new BoolParameter(value: false);

		private static QualityOverrideVolume s_Default;

		public static QualityOverrideVolume @default
		{
			get
			{
				if (s_Default == null)
				{
					s_Default = ScriptableObject.CreateInstance<QualityOverrideVolume>();
					s_Default.hideFlags = HideFlags.HideAndDontSave;
				}
				return s_Default;
			}
		}
	}
}
