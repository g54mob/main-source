using System;
using System.ComponentModel;

namespace ProtoBuf
{
	public enum WireType
	{
		None = -1,
		[Obsolete("This is an embarrassing typo... sorry; see also: Varint")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		Variant = 0,
		Varint = 0,
		Fixed64 = 1,
		String = 2,
		StartGroup = 3,
		EndGroup = 4,
		Fixed32 = 5,
		[Obsolete("This is an embarrassing typo... sorry; see also: SignedVarint")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		SignedVariant = 8,
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		SignedVarint = 8
	}
}
