using System;

namespace JetBrains.Annotations;

internal sealed class MeansImplicitUseAttribute : Attribute
{
	private ImplicitUseKindFlags _003CUseKindFlags_003Ek__BackingField;

	private ImplicitUseTargetFlags _003CTargetFlags_003Ek__BackingField;

	public ImplicitUseKindFlags UseKindFlags
	{
		get
		{
			return _003CUseKindFlags_003Ek__BackingField;
		}
		private set
		{
			_003CUseKindFlags_003Ek__BackingField = value;
		}
	}

	public ImplicitUseTargetFlags TargetFlags
	{
		get
		{
			return _003CTargetFlags_003Ek__BackingField;
		}
		private set
		{
			_003CTargetFlags_003Ek__BackingField = value;
		}
	}

	public MeansImplicitUseAttribute()
	{
		_003CUseKindFlags_003Ek__BackingField = ImplicitUseKindFlags.Default;
		_003CTargetFlags_003Ek__BackingField = ImplicitUseTargetFlags.Default;
	}

	public MeansImplicitUseAttribute(ImplicitUseKindFlags useKindFlags)
	{
		_003CUseKindFlags_003Ek__BackingField = useKindFlags;
		_003CTargetFlags_003Ek__BackingField = ImplicitUseTargetFlags.Default;
	}

	public MeansImplicitUseAttribute(ImplicitUseTargetFlags targetFlags)
	{
		_003CUseKindFlags_003Ek__BackingField = ImplicitUseKindFlags.Default;
		_003CTargetFlags_003Ek__BackingField = targetFlags;
	}

	public MeansImplicitUseAttribute(ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags)
	{
		_003CUseKindFlags_003Ek__BackingField = useKindFlags;
		_003CTargetFlags_003Ek__BackingField = targetFlags;
	}
}
