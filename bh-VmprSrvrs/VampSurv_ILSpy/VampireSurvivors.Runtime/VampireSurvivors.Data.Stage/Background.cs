using System;
using Cpp2ILInjected;

namespace VampireSurvivors.Data.Stage;

[Serializable]
public class Background
{
	private string _003Ctexture_003Ek__BackingField;

	private StageType? _003CstageType_003Ek__BackingField;

	public string texture
	{
		get
		{
			return _003Ctexture_003Ek__BackingField;
		}
		set
		{
			_003Ctexture_003Ek__BackingField = value;
		}
	}

	public StageType? stageType
	{
		get
		{
			return _003CstageType_003Ek__BackingField;
		}
		set
		{
			_003CstageType_003Ek__BackingField = value;
		}
	}

	public Background()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C72]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_003Ctexture_003Ek__BackingField = "";
	}
}
