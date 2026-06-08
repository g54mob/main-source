using System.Runtime.CompilerServices;

namespace ProtoBuf.Meta
{
	internal static class TypeModelExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool HasOption(this TypeModel model, TypeModel.TypeModelOptions options)
		{
			TypeModel.TypeModelOptions typeModelOptions = model?.Options ?? TypeModel.TypeModelOptions.None;
			return (typeModelOptions & options) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static bool OmitsOption(this TypeModel model, TypeModel.TypeModelOptions options)
		{
			TypeModel.TypeModelOptions typeModelOptions = model?.Options ?? TypeModel.TypeModelOptions.None;
			return (typeModelOptions & options) == 0;
		}
	}
}
