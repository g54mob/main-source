using System.Collections.Generic;
using Coffee.UISoftMaskInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

namespace Coffee.UISoftMask
{
	public class UISoftMaskProjectSettings : PreloadedProjectSettings<UISoftMaskProjectSettings>
	{
		public enum FallbackBehavior
		{
			DefaultSoftMaskable = 0,
			None = 1
		}

		public enum TransformSensitivity
		{
			Low = 0,
			Medium = 1,
			High = 2
		}

		private static bool s_UseStereoMock;

		[Header("Setting")]
		[Tooltip("Enable SoftMask globally.")]
		[SerializeField]
		internal bool m_SoftMaskEnabled = true;

		[Tooltip("Enable stereo rendering for VR devices.")]
		[SerializeField]
		private bool m_StereoEnabled = true;

		[Tooltip("Behavior when SoftMaskable shader is not found.")]
		[SerializeField]
		private FallbackBehavior m_FallbackBehavior;

		[Tooltip("Sensitivity of transform that automatically rebuilds the soft mask buffer.")]
		[SerializeField]
		private TransformSensitivity m_TransformSensitivity = TransformSensitivity.Medium;

		[Header("Editor")]
		[Tooltip("In the Scene view, objects outside the screen are displayed as stencil masks, allowing for more intuitive editing.")]
		[SerializeField]
		private bool m_UseStencilOutsideScreen = true;

		[Tooltip("Hide the automatically generated components.\n  - SoftMaskable\n  - MaskingShapeContainer\n  - TerminalMaskingShape")]
		[SerializeField]
		private bool m_HideGeneratedComponents = true;

		[Header("Shader")]
		[Tooltip("Automatically include shaders required for SoftMask.")]
		[SerializeField]
		private bool m_AutoIncludeShaders = true;

		[Tooltip("Strip unused shader variants in the build.")]
		[SerializeField]
		internal bool m_StripShaderVariants = true;

		public static bool softMaskEnabled => PreloadedProjectSettings<UISoftMaskProjectSettings>.instance.m_SoftMaskEnabled;

		public static bool useStencilOutsideScreen => false;

		public static bool stereoEnabled
		{
			get
			{
				if (softMaskEnabled)
				{
					return XRSettings.enabled;
				}
				return false;
			}
		}

		public static FallbackBehavior fallbackBehavior => PreloadedProjectSettings<UISoftMaskProjectSettings>.instance.m_FallbackBehavior;

		public static HideFlags hideFlagsForTemp
		{
			get
			{
				if (!PreloadedProjectSettings<UISoftMaskProjectSettings>.instance.m_HideGeneratedComponents)
				{
					return HideFlags.DontSave | HideFlags.NotEditable;
				}
				return HideFlags.HideAndDontSave | HideFlags.HideInInspector;
			}
		}

		public static TransformSensitivity transformSensitivity
		{
			get
			{
				return PreloadedProjectSettings<UISoftMaskProjectSettings>.instance.m_TransformSensitivity;
			}
			set
			{
				PreloadedProjectSettings<UISoftMaskProjectSettings>.instance.m_TransformSensitivity = value;
			}
		}

		public static float sensitivity => PreloadedProjectSettings<UISoftMaskProjectSettings>.instance.m_TransformSensitivity switch
		{
			TransformSensitivity.Low => 0.25f, 
			TransformSensitivity.Medium => 1f / 32f, 
			TransformSensitivity.High => 0.00024414062f, 
			_ => 1f / (float)(1 << (int)PreloadedProjectSettings<UISoftMaskProjectSettings>.instance.m_TransformSensitivity), 
		};

		public static bool useStereoMock
		{
			get
			{
				return s_UseStereoMock;
			}
			set
			{
				if (s_UseStereoMock != value)
				{
					s_UseStereoMock = value;
					ResetAllSoftMasks();
				}
			}
		}

		private static void ResetAllSoftMasks()
		{
			List<SoftMask> toRelease = ListPool<SoftMask>.Rent();
			List<IMaskable> toRelease2 = ListPool<IMaskable>.Rent();
			SoftMask[] array = Object.FindObjectsOfType<SoftMask>();
			foreach (SoftMask softMask in array)
			{
				softMask.GetComponentsInParent(includeInactive: true, toRelease);
				if (1 >= toRelease.Count)
				{
					softMask.GetComponentsInChildren(includeInactive: true, toRelease2);
					toRelease2.ForEach(delegate(IMaskable c)
					{
						c.RecalculateMasking();
					});
				}
			}
			ListPool<IMaskable>.Return(ref toRelease2);
			ListPool<SoftMask>.Return(ref toRelease);
		}
	}
}
