using System;
using System.Collections.Generic;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("https://curvyeditor.com/doclink/cginputtransformspots")]
	[ModuleInfo("Input/Transform Spots", ModuleName = "Input Transform Spots", Description = "Defines an array of placement spots taken from existing Transforms")]
	public class InputTransformSpots : CGModule
	{
		[Serializable]
		public struct TransformSpot : IEquatable<TransformSpot>
		{
			[SerializeField]
			private int index;

			[SerializeField]
			private Transform transform;

			public int Index => 0;

			public Transform Transform => null;

			public bool Equals(TransformSpot other)
			{
				return false;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}

			public static bool operator ==(TransformSpot left, TransformSpot right)
			{
				return false;
			}

			public static bool operator !=(TransformSpot left, TransformSpot right)
			{
				return false;
			}
		}

		[HideInInspector]
		[OutputSlotInfo(typeof(CGSpots))]
		public CGModuleOutputSlot OutSpots;

		[ArrayEx]
		[SerializeField]
		private List<TransformSpot> transformSpots;

		private readonly Dictionary<CGSpot, TransformSpot> outputToInputDictionary;

		public List<TransformSpot> TransformSpots
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		public override void Reset()
		{
		}

		[UsedImplicitly]
		private void Update()
		{
		}

		public override void Refresh()
		{
		}

		protected override void ResetOnEnable()
		{
		}
	}
}
