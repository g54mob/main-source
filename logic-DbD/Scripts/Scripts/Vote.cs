public class Vote
{
	public string username;

	public string candidate_voted;

	public int net_worth;

	public int vote_weighted;

	public Vote(string username, string candidate_voted, int net_worth, int vote_weighted)
	{
		this.username = username;
		this.net_worth = net_worth;
		this.candidate_voted = candidate_voted;
		this.vote_weighted = vote_weighted;
	}

	public override string ToString()
	{
		return $"'{username}', {net_worth}, '{candidate_voted}', {vote_weighted}";
	}
}
