namespace RoslynCSharp.Modding
{
	public enum ScriptReplacerOptions
	{
		Default = 10,
		DontRequireAttribute = 1,
		CopySerializeFields = 2,
		CopyNonSerializeFields = 4,
		DestroyOriginalScript = 8,
		DisableOriginalScript = 16,
		ReplaceDisabledScripts = 32,
		RequireExplicitTypeMatches = 64
	}
}
