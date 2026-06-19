using System;
using Sentry.Protocol;

namespace Sentry.Internal.Extensions
{
	internal static class PEDebugImageDataExtensions
	{
		internal static DebugImage? ToDebugImage(this PEDebugImageData? imageData, string? codeFile, Guid? moduleVersionId)
		{
			if (imageData != null && imageData.DebugId != null)
			{
				return new DebugImage
				{
					Type = imageData.Type,
					CodeId = imageData.CodeId,
					CodeFile = codeFile,
					DebugId = imageData.DebugId,
					DebugChecksum = imageData.DebugChecksum,
					DebugFile = imageData.DebugFile,
					ModuleVersionId = moduleVersionId
				};
			}
			return null;
		}
	}
}
