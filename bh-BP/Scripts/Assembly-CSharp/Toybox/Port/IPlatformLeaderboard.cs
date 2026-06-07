using System;
using System.Collections.Generic;

namespace Toybox.Port
{
	public interface IPlatformLeaderboard
	{
		int GetNumLBEntries(LBType t);

		void FetchLBEntries(LBType t, LBFilter filt, int rangeStart, int rangeEnd, Action<List<LBEntry>, LBType> callback);

		void PostScore(LBType t, int score, int[] extraData = null);

		int GetNumLBEntries(string lbID);

		void FetchLBEntries(string lbID, LBFilter filt, int rangeStart, int rangeEnd, Action<List<LBEntry>, string> callback);

		void PostScore(string lbID, int score, int[] extraData = null, LBSortDir sortMethod = LBSortDir.kAscending, LBDisplayType displayType = LBDisplayType.kNumeric);
	}
}
