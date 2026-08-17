namespace JetBrains.Annotations;

internal enum ImplicitUseKindFlags
{
	Default = 7,
	Access = 1,
	Assign = 2,
	InstantiatedWithFixedConstructorSignature = 4,
	InstantiatedNoFixedConstructorSignature = 8
}
