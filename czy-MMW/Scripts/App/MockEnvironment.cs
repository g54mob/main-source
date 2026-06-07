using System.Collections.Generic;
using Factory;
using UnityEngine;

public class MockEnvironment : IEnvironment
{
	private readonly IEnvironment _emulatedEnvironment;

	public DeviceCategory DeviceCategory
	{
		get
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.MockPhone))
			{
				return DeviceCategory.Phone;
			}
			if (Diagnostics.Verify(_emulatedEnvironment != null, "Emulated environment can't be null for mock environment!"))
			{
				return _emulatedEnvironment.DeviceCategory;
			}
			return DeviceCategory.Desktop;
		}
	}

	public List<string> FeatureConfigs => new List<string>();

	public MockEnvironment(IEnvironment emulatedEnvironment)
	{
		_emulatedEnvironment = emulatedEnvironment;
	}

	public virtual void PopulateAppAssembler(Assembler baseAssembler)
	{
		if (Diagnostics.Verify(_emulatedEnvironment != null, "Cannot provide a null environment to the Mock Environment!"))
		{
			_emulatedEnvironment.PopulateAppAssembler(baseAssembler);
		}
	}

	public virtual void PopulateGameAssembler(Assembler baseAssembler)
	{
		_emulatedEnvironment?.PopulateGameAssembler(baseAssembler);
	}

	public BaseInputOverride AddInputOverrideToGameObject(GameObject gameObject)
	{
		return gameObject.AddComponent<BaseInputOverride>();
	}
}
