using System;
using System.Diagnostics;
using UnityEngine;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class PreviewFieldAttribute : Attribute
	{
		private ObjectFieldAlignment alignment;

		private bool alignmentHasValue;

		private string previewGetter;

		public float Height;

		public FilterMode FilterMode;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "alignment", "alignmentHasValue" })]
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

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "previewGetter", "PreviewGetterHasValue" })]
		public string PreviewGetter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool PreviewGetterHasValue { get; private set; }

		public PreviewFieldAttribute()
		{
		}

		public PreviewFieldAttribute(float height)
		{
		}

		public PreviewFieldAttribute(string previewGetter, FilterMode filterMode = FilterMode.Bilinear)
		{
		}

		public PreviewFieldAttribute(string previewGetter, float height, FilterMode filterMode = FilterMode.Bilinear)
		{
		}

		public PreviewFieldAttribute(float height, ObjectFieldAlignment alignment)
		{
		}

		public PreviewFieldAttribute(string previewGetter, ObjectFieldAlignment alignment, FilterMode filterMode = FilterMode.Bilinear)
		{
		}

		public PreviewFieldAttribute(string previewGetter, float height, ObjectFieldAlignment alignment, FilterMode filterMode = FilterMode.Bilinear)
		{
		}

		public PreviewFieldAttribute(ObjectFieldAlignment alignment)
		{
		}
	}
}
