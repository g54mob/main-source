using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public sealed class ClipLod : Lod
	{
		[Tooltip("The default clipping behaviour.\n\nWhether to clip nothing by default (and clip inputs remove patches of surface), or to clip everything by default (and clip inputs add patches of surface).")]
		[SerializeField]
		internal DefaultClippingState _DefaultClippingState;

		internal static readonly Color s_GizmoColor = new Color(0f, 1f, 1f, 0.5f);

		internal static readonly SortedList<int, ILodInput> s_Inputs = new SortedList<int, ILodInput>(Helpers.DuplicateComparison);

		internal override string ID => "Clip";

		internal override string Name => "Clip Surface";

		internal override Color GizmoColor => s_GizmoColor;

		private protected override Color ClearColor
		{
			get
			{
				if (_DefaultClippingState != DefaultClippingState.EverythingClipped)
				{
					return Color.black;
				}
				return Color.white;
			}
		}

		private protected override bool NeedToReadWriteTextureData => true;

		private protected override bool RequiresClearBorder => true;

		internal override bool SkipEndOfFrame => true;

		private protected override GraphicsFormat RequestedTextureFormat => _TextureFormatMode switch
		{
			LodTextureFormatMode.Performance => GraphicsFormat.R8_UNorm, 
			LodTextureFormatMode.Precision => GraphicsFormat.R16_UNorm, 
			LodTextureFormatMode.Manual => _TextureFormat, 
			_ => throw new NotImplementedException(), 
		};

		private protected override SortedList<int, ILodInput> Inputs => s_Inputs;

		public DefaultClippingState DefaultClippingState
		{
			get
			{
				return _DefaultClippingState;
			}
			set
			{
				SetDefaultClippingState(_DefaultClippingState, _DefaultClippingState = value);
			}
		}

		internal ClipLod()
		{
			_TextureFormat = GraphicsFormat.R8_UNorm;
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnLoad()
		{
			s_Inputs.Clear();
		}

		private void SetDefaultClippingState(DefaultClippingState previous, DefaultClippingState current)
		{
			if (previous != current && !(_Water == null) && _Water.isActiveAndEnabled && base.Enabled)
			{
				_TargetsToClear = true;
			}
		}
	}
}
