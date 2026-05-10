using System;

namespace Sirenix.OdinInspector
{
	public sealed class RequiredListLengthAttribute : Attribute
	{
		private PrefabKind prefabKind;

		private bool prefabKindIsSet;

		private int minLength;

		private int maxLength;

		private bool minLengthIsSet;

		private bool maxLengthIsSet;

		public string MinLengthGetter;

		public string MaxLengthGetter;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "minLength", "minLengthIsSet" })]
		public int MinLength
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "maxLength", "maxLengthIsSet" })]
		public int MaxLength
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool MinLengthIsSet => false;

		public bool MaxLengthIsSet => false;

		public bool PrefabKindIsSet => false;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "prefabKind", "prefabKindIsSet" })]
		public PrefabKind PrefabKind
		{
			get
			{
				return default(PrefabKind);
			}
			set
			{
			}
		}

		public RequiredListLengthAttribute()
		{
		}

		public RequiredListLengthAttribute(int fixedLength)
		{
		}

		public RequiredListLengthAttribute(int minLength, int maxLength)
		{
		}

		public RequiredListLengthAttribute(int minLength, string maxLengthGetter)
		{
		}

		public RequiredListLengthAttribute(string fixedLengthGetter)
		{
		}

		public RequiredListLengthAttribute(string minLengthGetter, string maxLengthGetter)
		{
		}

		public RequiredListLengthAttribute(string minLengthGetter, int maxLength)
		{
		}
	}
}
