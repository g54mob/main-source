using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	public class CGModuleSlot
	{
		protected List<CGModuleSlot> mLinkedSlots;

		public CGModule Module { get; internal set; }

		public SlotInfo Info { get; internal set; }

		public Vector2 Origin { get; set; }

		public Rect DropZone { get; set; }

		public bool IsLinked => false;

		public bool IsLinkedAndConfigured => false;

		public IOnRequestProcessing OnRequestModule => null;

		public IPathProvider PathProvider => null;

		public IExternalInput ExternalInput => null;

		public List<CGModuleSlot> LinkedSlots => null;

		public int Count => 0;

		public string Name => null;

		public bool HasLinkTo(CGModuleSlot other)
		{
			return false;
		}

		public List<CGModule> GetLinkedModules()
		{
			return null;
		}

		public virtual void LinkTo(CGModuleSlot other)
		{
		}

		protected static void LinkInputAndOutput(CGModuleSlot inputSlot, CGModuleSlot outputSlot)
		{
		}

		public virtual void UnlinkFrom([NotNull] CGModuleSlot other)
		{
		}

		public virtual void UnlinkAll()
		{
		}

		public void ReInitializeLinkedSlots()
		{
		}

		protected virtual void LoadLinkedSlots()
		{
		}

		public void SetInfoFromField(FieldInfo fieldInfo)
		{
		}

		public static implicit operator bool(CGModuleSlot a)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
