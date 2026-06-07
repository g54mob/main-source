using System.Collections.Generic;
using Factory;
using JetBrains.Annotations;
using UnityEngine;

public interface IEnvironment
{
	DeviceCategory DeviceCategory { get; }

	[CanBeNull]
	List<string> FeatureConfigs { get; }

	void PopulateAppAssembler(Assembler baseAssembler);

	void PopulateGameAssembler(Assembler baseAssembler);

	BaseInputOverride AddInputOverrideToGameObject(GameObject gameObject);
}
