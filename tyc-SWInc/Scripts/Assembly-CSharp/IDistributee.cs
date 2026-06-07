public interface IDistributee
{
	bool IsValid { get; }

	void UpdateNow(float delta);

	void UpdateNow2(float delta);

	bool NeedUpdate(bool firstFunction);
}
