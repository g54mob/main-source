using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public interface IResearchNetworkState
	{
		bool IsNodeCompleted(int nodeID);

		bool IsNodeCompletedByLocalPlayer(int nodeID);

		int GetNumNodeCompletions(int nodeID);

		int GetNumCompletionsRequired(int nodeID);

		int GetNodeCompletionCountForPlayer(OnlinePlayerID playerID);

		List<int> GetCompletableNodesForLocalPlayer();

		List<OnlinePlayerID> GetPlayerAttemptingNode(int nodeID);

		bool IsLocalPlayerAttemptingNode(int nodeID);

		int GetSelectedNodeID();

		CollaborativePortfolio GetPortfolio();

		CollaborativeProject GetProject();

		ResearchNetwork.Node GetParentNode(int nodeID);

		void GetAllNodeParents(int nodeID, ref List<ResearchNetwork.Node> parentList);

		void GetAllNodeChildren(int nodeID, ref List<ResearchNetwork.Node> childList);

		Sprite GetVictoryNodeSprite(int nodeID);

		Sprite GetRootNodeSprite();

		bool IsShowAllMode();

		bool IsAllCompletedMode();

		bool IsAllDiscoveredMode();

		ResearchNetworkNodeItem GetNodeUIItem(int nodeID);
	}
}
