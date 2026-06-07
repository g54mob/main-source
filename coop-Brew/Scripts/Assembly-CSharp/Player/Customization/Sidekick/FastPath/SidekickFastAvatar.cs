using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Synty.SidekickCharacters.Database.DTO;
using Synty.SidekickCharacters.Enums;
using Unity.Netcode;
using UnityEngine;

namespace Player.Customization.Sidekick.FastPath
{
	[DefaultExecutionOrder(-1000)]
	[RequireComponent(typeof(SidekickCharacterCustomizer))]
	public class SidekickFastAvatar : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CBuildJob_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickFastAvatar _003C_003E4__this;

			public SidekickSaveData data;

			private SidekickMeshPreloader _003Cpreloader_003E5__2;

			private GameObject _003CbaseModelSrc_003E5__3;

			private Dictionary<CharacterPartType, Dictionary<string, SidekickPart>> _003CpartLibrary_003E5__4;

			private List<SidekickSaveData.PartEntry> _003CeffectiveParts_003E5__5;

			private int _003CattachedCount_003E5__6;

			private int _003CprefabMissCount_003E5__7;

			private int _003CsmrMissCount_003E5__8;

			private StringBuilder _003CmissLog_003E5__9;

			private List<SidekickSaveData.PartEntry>.Enumerator _003C_003E7__wrap9;

			private List<SidekickColorProperty> _003CallProps_003E5__11;

			private List<SidekickSaveData.ColorEntry>.Enumerator _003C_003E7__wrap11;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CBuildJob_003Ed__20(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CStart_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickFastAvatar _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CStart_003Ed__17(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CWatchForSaveDataLoop_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SidekickFastAvatar _003C_003E4__this;

			private int _003Ci_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWatchForSaveDataLoop_003Ed__19(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private static FieldInfo s_isRebuildingField;

		private static FieldInfo s_animatorControllerField;

		private static FieldInfo s_onCharacterRebuiltEvent;

		private static bool s_reflectionProbed;

		private static bool s_reflectionOk;

		private SidekickCharacterCustomizer _legacy;

		private NetworkObject _netObj;

		private SidekickFastAvatarConfig _cfg;

		private GameObject _fastModel;

		private Transform _fastSkeletonRoot;

		private readonly Dictionary<string, Transform> _boneMap;

		private readonly List<SkinnedMeshRenderer> _spawnedParts;

		private readonly List<GameObject> _accessoryBones;

		private int _lastBuiltHash;

		private bool _sabotaged;

		private bool _interceptActive;

		private void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__17))]
		private IEnumerator Start()
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003CWatchForSaveDataLoop_003Ed__19))]
		private IEnumerator WatchForSaveDataLoop()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CBuildJob_003Ed__20))]
		private IEnumerator BuildJob(SidekickSaveData data)
		{
			return null;
		}

		private static List<SidekickSaveData.PartEntry> BuildEffectivePartsList(SidekickSaveData data, Dictionary<CharacterPartType, Dictionary<string, SidekickPart>> partLibrary)
		{
			return null;
		}

		private GameObject ResolvePartPrefab(Dictionary<CharacterPartType, Dictionary<string, SidekickPart>> partLibrary, CharacterPartType partType, string partName)
		{
			return null;
		}

		private void EnsureAccessoryBones(SkinnedMeshRenderer source, CharacterPartType partType)
		{
		}

		private Transform GetPartTypeAnchor(CharacterPartType partType)
		{
			return null;
		}

		private Transform EnsureBoneInMap(Transform srcBone, CharacterPartType partType)
		{
			return null;
		}

		private void AttachPart(SkinnedMeshRenderer source, CharacterPartType partType)
		{
		}

		private void DestroyPreExistingModels()
		{
		}

		private static Transform FindSourceBoneByName(Transform anySrcBone, string name)
		{
			return null;
		}

		private static Transform FindRecursive(Transform t, string name)
		{
			return null;
		}

		private void BuildBoneMap(Transform root)
		{
		}

		private void PromoteChildAvatarToRoot()
		{
		}

		private static void ProbeReflection()
		{
		}

		private static void TrySet(FieldInfo f, object target, object value)
		{
		}

		private void InvokeLegacyOnCharacterRebuilt()
		{
		}

		private static void EnsureDefaultEyeIris(List<SidekickSaveData.ColorEntry> colors, List<SidekickColorProperty> allProperties)
		{
		}

		private static int HashSaveData(SidekickSaveData d)
		{
			return 0;
		}
	}
}
