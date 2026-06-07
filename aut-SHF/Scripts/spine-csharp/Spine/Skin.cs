using System.Collections.Generic;

namespace Spine
{
	public class Skin
	{
		public struct SkinEntry
		{
			internal readonly int slotIndex;

			internal readonly string name;

			internal readonly Attachment attachment;

			public int SlotIndex => 0;

			public string Name => null;

			public Attachment Attachment => null;

			public SkinEntry(int slotIndex, string name, Attachment attachment)
			{
				this.slotIndex = 0;
				this.name = null;
				this.attachment = null;
			}
		}

		private struct SkinKey
		{
			internal readonly int slotIndex;

			internal readonly string name;

			internal readonly int hashCode;

			public SkinKey(int slotIndex, string name)
			{
				this.slotIndex = 0;
				this.name = null;
				hashCode = 0;
			}
		}

		private class SkinKeyComparer : IEqualityComparer<SkinKey>
		{
			internal static readonly SkinKeyComparer Instance;

			bool IEqualityComparer<SkinKey>.Equals(SkinKey e1, SkinKey e2)
			{
				return false;
			}

			int IEqualityComparer<SkinKey>.GetHashCode(SkinKey e)
			{
				return 0;
			}
		}

		internal string name;

		private Dictionary<SkinKey, SkinEntry> attachments;

		internal readonly ExposedList<BoneData> bones;

		internal readonly ExposedList<ConstraintData> constraints;

		public string Name => null;

		public ICollection<SkinEntry> Attachments => null;

		public ExposedList<BoneData> Bones => null;

		public ExposedList<ConstraintData> Constraints => null;

		public Skin(string name)
		{
		}

		public void SetAttachment(int slotIndex, string name, Attachment attachment)
		{
		}

		public void AddSkin(Skin skin)
		{
		}

		public void CopySkin(Skin skin)
		{
		}

		public Attachment GetAttachment(int slotIndex, string name)
		{
			return null;
		}

		public void RemoveAttachment(int slotIndex, string name)
		{
		}

		public void GetAttachments(int slotIndex, List<SkinEntry> attachments)
		{
		}

		public void Clear()
		{
		}

		public override string ToString()
		{
			return null;
		}

		internal void AttachAll(Skeleton skeleton, Skin oldSkin)
		{
		}
	}
}
