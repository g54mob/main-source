public interface IServerItem : IReferenceFix
{
	bool UsesISP { get; }

	bool CancelOnUnload();

	float GetLoadRequirement();

	void HandleLoad(float load);

	string GetDescription();

	void SerializeServer(string name);
}
