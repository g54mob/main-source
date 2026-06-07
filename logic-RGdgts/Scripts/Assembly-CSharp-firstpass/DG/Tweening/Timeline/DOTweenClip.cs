using System;
using System.Collections.Generic;
using DG.Tweening.Timeline.Core;
using UnityEngine;

namespace DG.Tweening.Timeline
{
	[Serializable]
	public class DOTweenClip : DOTweenClipBase
	{
		[Serializable]
		public struct EditorData
		{
			public Vector2 areaShift;

			public Vector2Int roundedAreaShift
			{
				get
				{
					return default(Vector2Int);
				}
				set
				{
				}
			}
		}

		[Serializable]
		public class ClipLayer
		{
			public bool isActive;

			public string[] clipElementGuids;

			public string name;

			public bool locked;

			public Color color;

			public static readonly Color DefColor;

			public ClipLayer(string name)
			{
			}

			public ClipLayer Clone()
			{
				return null;
			}

			private string[] CloneClipElementGuids()
			{
				return null;
			}
		}

		public bool isActive;

		public string name;

		public DOTweenClipElement[] elements;

		public ClipLayer[] layers;

		public EditorData editor;

		private static readonly List<UnityEngine.Object> _TmpOldComponentsToReplace;

		private static readonly List<UnityEngine.Object> _TmpNewComponentsToReplace;

		private static readonly List<DOTweenClipElement> _TmpClipElements;

		public DOTweenClip(string name)
		{
		}

		public DOTweenClip()
		{
		}

		public DOTweenClip(string guid, string name)
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

		public Sequence GenerateIndependentTween(bool andPlay = true, float? startupDelay = null, params UnityEngine.Object[] targetsToReplace)
		{
			return null;
		}

		internal Sequence INTERNAL_DoGenerateTween(bool isApplicationPlaying, SettingsSnapshot settings, UnityEngine.Object[] targetsToReplace = null)
		{
			return null;
		}

		public DOTweenClipElement FindClipElementByGuid(string clipElementGuid)
		{
			return null;
		}

		public List<DOTweenClipElement> FindClipElementsByPin(int pin)
		{
			return null;
		}

		public List<DOTweenClipElement> FindClipElementsByPinNoAlloc(int pin)
		{
			return null;
		}

		public List<DOTweenClipElement> FindClipElementsByTarget(UnityEngine.Object target)
		{
			return null;
		}

		public List<DOTweenClipElement> FindClipElementsByTargetNoAlloc(UnityEngine.Object target)
		{
			return null;
		}

		public int FindClipElementLayerIndexByGuid(string clipElementGuid)
		{
			return 0;
		}

		public DOTweenClip ReplaceTarget(UnityEngine.Object oldTarget, UnityEngine.Object newTarget)
		{
			return null;
		}

		public DOTweenClip Clone(bool regenerateGuid = true)
		{
			return null;
		}

		public void AssignPropertiesFrom(DOTweenClip clip, bool cloneProperties)
		{
		}

		private DOTweenClipElement[] CloneClipElements()
		{
			return null;
		}

		private ClipLayer[] CloneVisualLayers()
		{
			return null;
		}

		private void AssignEventsReferencesFrom(DOTweenClip clip)
		{
		}

		private static void InsertSequentiableTween(ref Sequence s, DOTweenClip clip, DOTweenClipElement clipElement, bool isGlobal, float timeMultiplier, bool replaceTargets = false)
		{
		}

		private static void InsertEvent(ref Sequence s, DOTweenClip clip, DOTweenClipElement clipElement, float timeMultiplier)
		{
		}

		private static void InsertAction(ref Sequence s, DOTweenClip clip, DOTweenClipElement clipElement, float timeMultiplier)
		{
		}

		private static void InsertInterval(ref Sequence s, DOTweenClip clip, DOTweenClipElement clipElement, float timeMultiplier)
		{
		}
	}
}
