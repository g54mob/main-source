using System;

namespace FullSerializerSave
{
	public interface fsIAotConverter
	{
		Type ModelType { get; }

		fsAotVersionInfo VersionInfo { get; }
	}
}
