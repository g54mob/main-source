using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Stages;

public class EME_BiomeBounds : MonoBehaviour
{
	[Serializable]
	public struct EmeraldsBiomeBounds
	{
		public Color BoundsColor;

		public float UpperLimit;

		public float LowerLimit;
	}

	private List<EmeraldsBiomeBounds> _biomeBoundsList;

	private float _invertedBoundsYOffset;

	private bool IsStageInverted
	{
		get
		{
			//IL_0184: Expected I4, but got O
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				Stage stage = core._stage;
				if ((object)core._stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
				{
					goto IL_0170;
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					Stage stage2 = core2._stage;
					if ((object)core2._stage != null)
					{
						TilingTileset tilingTileset = stage2._tilingTileset;
						if ((object)stage2._tilingTileset == null || ((UnityEngine.Object)tilingTileset).m_CachedPtr == (IntPtr)0)
						{
							goto IL_0170;
						}
						GameManager core3 = GM.Core;
						if ((object)GM.Core != null)
						{
							Stage stage3 = core3._stage;
							if ((object)core3._stage != null)
							{
								TilingTileset tilingTileset2 = stage3._tilingTileset;
								if ((object)stage3._tilingTileset != null)
								{
									return tilingTileset2._visuallyInverted;
								}
							}
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0170:
			return false;
		}
	}

	public unsafe EmeraldsBiomeBounds GetBoundsForBiome(BackgroundEmerald.EmeraldsBiomes biome)
	{
		//IL_00fa: Expected O, but got I4
		//IL_00f5: Expected native int or pointer, but got O
		//IL_0103: Expected native int or pointer, but got O
		//IL_003c: Expected O, but got I
		//IL_004f: Expected O, but got I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0097: Expected F4, but got I4
		//IL_012f: Expected O, but got I4
		//IL_012a: Expected native int or pointer, but got O
		//IL_0138: Expected native int or pointer, but got O
		//IL_00bf: Expected O, but got I
		//IL_0177: Expected native int or pointer, but got O
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_01b6: Expected native int or pointer, but got O
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		EmeraldsBiomeBounds emeraldsBiomeBounds = default(EmeraldsBiomeBounds);
		((EmeraldsBiomeBounds*)(nint)emeraldsBiomeBounds)->BoundsColor = (Color)0;
		((EmeraldsBiomeBounds*)(nint)emeraldsBiomeBounds)->UpperLimit = 0f;
		List<EmeraldsBiomeBounds> biomeBoundsList = _biomeBoundsList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Stages.EME_BiomeBounds+EmeraldsBiomeBounds>)+18]");
		if ((nint)biome < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Stages.EME_BiomeBounds+EmeraldsBiomeBounds>)+10]");
			object obj = 0;
			object obj2 = (int)biome * 2;
			object obj3 = biome + obj2;
			float num = ((!IsStageInverted) ? 0f : _invertedBoundsYOffset);
			((EmeraldsBiomeBounds*)(nint)emeraldsBiomeBounds)->BoundsColor = (Color)0;
			((EmeraldsBiomeBounds*)(nint)emeraldsBiomeBounds)->UpperLimit = 0f;
			object obj4;
			object obj5 = default(object);
			if (IsStageInverted)
			{
				obj4 = obj5 ^ -0f;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v4+30+v127 @ rcx_v3*8]");
				obj4 = 0;
			}
			float upperLimit = (float)obj4 + num;
			((EmeraldsBiomeBounds*)(nint)emeraldsBiomeBounds)->UpperLimit = upperLimit;
			object obj6;
			if (IsStageInverted)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v4+30+v127 @ rcx_v3*8]");
				obj6 = 0 ^ -0f;
			}
			else
			{
				obj6 = obj5;
			}
			float lowerLimit = (float)obj6 + num;
			((EmeraldsBiomeBounds*)(nint)emeraldsBiomeBounds)->LowerLimit = lowerLimit;
			return emeraldsBiomeBounds;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		EmeraldsBiomeBounds result = default(EmeraldsBiomeBounds);
		return result;
	}

	public float GetBiomeCentreY(BackgroundEmerald.EmeraldsBiomes biome)
	{
		object obj = default(object);
		float num = (float)obj + GetBoundsForBiome(biome).UpperLimit;
		return num * 0.5f;
	}

	public unsafe bool TryGetBiomePositionIsInside(Vector2 position, out BackgroundEmerald.EmeraldsBiomes biome)
	{
		//IL_00e0: Expected I4, but got O
		//IL_0056: Invalid comparison between F4 and O
		ref BackgroundEmerald.EmeraldsBiomes reference = ref *(BackgroundEmerald.EmeraldsBiomes*)6;
		List<EmeraldsBiomeBounds> biomeBoundsList = _biomeBoundsList;
		if (_biomeBoundsList != null)
		{
			BackgroundEmerald.EmeraldsBiomes emeraldsBiomes = BackgroundEmerald.EmeraldsBiomes.Biome1;
			BackgroundEmerald.EmeraldsBiomes emeraldsBiomes2 = BackgroundEmerald.EmeraldsBiomes.Biome1;
			object obj = default(object);
			object obj2 = default(object);
			while (true)
			{
				BackgroundEmerald.EmeraldsBiomes num = emeraldsBiomes2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Stages.EME_BiomeBounds+EmeraldsBiomeBounds>)+18]");
				if ((nint)num < (nint)0)
				{
					EmeraldsBiomeBounds boundsForBiome = GetBoundsForBiome(emeraldsBiomes);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
					{
						float upperLimit = boundsForBiome.UpperLimit;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)upperLimit) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
						{
							reference = ref *(BackgroundEmerald.EmeraldsBiomes*)(int)emeraldsBiomes;
							return true;
						}
					}
					biomeBoundsList = _biomeBoundsList;
					emeraldsBiomes++;
					if (_biomeBoundsList == null)
					{
						break;
					}
					emeraldsBiomes2 = emeraldsBiomes;
					continue;
				}
				return false;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public EME_BiomeBounds()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
