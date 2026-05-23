public interface WatchHost
{
	bool inHunt { get; }

	bool canHunt { get; }

	string enteringMomentId { get; }

	void StartEnterMoment(string momentId, bool fast);

	void CancelEnterMoment();

	void StartHunt();

	void StartInception(CorpseBox corpseBox);

	void StartPullCorpse(CorpseBox corpseBox);
}
