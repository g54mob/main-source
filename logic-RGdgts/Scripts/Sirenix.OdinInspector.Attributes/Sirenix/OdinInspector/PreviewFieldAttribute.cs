using System;

namespace Sirenix.OdinInspector
{
	public class PreviewFieldAttribute : Attribute
	{
		private ObjectFieldAlignment alignment;

		private bool alignmentHasValue;

		public float Height;

		public ObjectFieldAlignment Alignment
		{
			get
			{
				return default(ObjectFieldAlignment);
			}
			set
			{
			}
		}

		public bool AlignmentHasValue => false;

		public PreviewFieldAttribute()
		{
		}

		public PreviewFieldAttribute(float height)
		{
		}

		public PreviewFieldAttribute(float height, ObjectFieldAlignment alignment)
		{
		}

		public PreviewFieldAttribute(ObjectFieldAlignment alignment)
		{
		}
	}
}
