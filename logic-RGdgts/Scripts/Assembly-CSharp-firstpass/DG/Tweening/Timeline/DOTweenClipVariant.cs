using System;
using System.Collections.Generic;
using System.Reflection;
using DG.Tweening.Timeline.Core;
using UnityEngine;

namespace DG.Tweening.Timeline
{
	[Serializable]
	public class DOTweenClipVariant : DOTweenClipBase
	{
		[Serializable]
		public class TargetSwap
		{
			public UnityEngine.Object originalTarget;

			public UnityEngine.Object newTarget;

			public TargetSwap(UnityEngine.Object originalTarget)
			{
			}
		}

		public string clipGuid;

		public bool overrideClipSettings;

		public Component clipComponent;

		public TargetSwap[] targetSwaps;

		public bool lookForClipInNestedObjs;

		public bool editor_foldout;

		private bool _initialized;

		private DOTweenClip _clip;

		private static readonly Type _TClip;

		private static readonly Type _TClipArray;

		private static readonly Type _TClipList;

		private static readonly Type _TSerializeFieldAttribute;

		private static readonly Type _TNonSerializedAttribute;

		private static readonly Type _TUnityObject;

		private static readonly List<FieldInfo> _TmpFInfos;

		public DOTweenClipVariant()
		{
		}

		public DOTweenClipVariant(string guid)
		{
		}

		private void Init()
		{
		}

		public override Sequence Play(bool restartIfExists = true)
		{
			return null;
		}

		public override Sequence GenerateTween(StartupBehaviour? behaviour = null, bool? andPlay = null, bool rewindIfExists = true)
		{
			return null;
		}

		public override Sequence ForceGenerateTween(bool rewindIfExists = true, StartupBehaviour? behaviour = null, bool? andPlay = null)
		{
			return null;
		}

		private UnityEngine.Object[] ConvertTargetSwapsToTargetPairs()
		{
			return null;
		}

		private static DOTweenClip FindClip(object withinObj, string clipGuid, bool lookInNestedObjs = true)
		{
			return null;
		}

		private static DOTweenClip FindClipFromFieldInfo(FieldInfo fInfo, object withinObj, string clipGuid, bool lookInNestedObjs, ref List<object> nestedObjs)
		{
			return null;
		}
	}
}
