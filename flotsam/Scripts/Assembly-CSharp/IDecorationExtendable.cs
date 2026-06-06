public interface IDecorationExtendable
{
	Decoration Decoration { get; }

	bool Active { get; }

	void Initialize(Decoration decoration);

	void Finish();

	void Upgrade(Decoration decoration);

	void OnDeconstruct()
	{
	}

	void Remove();

	bool CanBeDeconstructed()
	{
		return true;
	}

	string GetDescription(string text)
	{
		return text;
	}
}
