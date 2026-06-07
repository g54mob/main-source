using System;
using JetBrains.Annotations;

namespace FluffyUnderware.Curvy.Generator
{
	[AttributeUsage(AttributeTargets.Field)]
	public class SlotInfo : Attribute, IComparable
	{
		public enum SlotArrayType
		{
			Unknown = 0,
			Normal = 1,
			Hidden = 2
		}

		[ItemNotNull]
		[NotNull]
		public readonly Type[] DataTypes;

		public string Name;

		private string displayName;

		public string Tooltip;

		public bool Array;

		public SlotArrayType ArrayType;

		public string DisplayName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected SlotInfo(string name, [ItemNotNull][NotNull] params Type[] type)
		{
		}

		protected SlotInfo([NotNull][ItemNotNull] params Type[] type)
		{
		}

		public int CompareTo(object obj)
		{
			return 0;
		}

		public void CheckDataTypes()
		{
		}
	}
}
