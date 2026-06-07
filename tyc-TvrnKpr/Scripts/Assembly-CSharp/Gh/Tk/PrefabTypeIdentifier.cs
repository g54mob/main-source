using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gh.Tk
{
	[DisallowMultipleComponent]
	public class PrefabTypeIdentifier : MonoBehaviour
	{
		public static List<PrefabTypeIdentifier> AllPrefabTypeIdentifierInstances;

		[Tooltip("Must be the same as the prefabs name.")]
		public string uniqueType;

		public string animationKeyOverride;

		[SerializeField]
		[FormerlySerializedAs("IgnoreWhenSaving")]
		private bool _ignoreWhenSaving;

		public bool NeedsGameObjectX;

		public bool IgnoreWhenSaving
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event EventHandler<EventArgs<bool>> IgnoreWhenSavingChanged
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

		private void OnDestroy()
		{
		}

		public bool IsOfTypeOrVariantOfType(string type)
		{
			return false;
		}

		public static bool IsOfTypeOrVariantOfType(string uniqueType, string type)
		{
			return false;
		}
	}
}
