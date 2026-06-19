#define LOG_LEVEL_VERBOSE
using UnityEngine;

namespace TH20
{
	public class ResearchNetworkConnectorItem : MonoBehaviour
	{
		[SerializeField]
		private ResearchNetworkConnectorLine _line;

		[SerializeField]
		private ResearchNetworkConnectorChevrons _chevrons;

		private ResearchNetworkNodeItem _parentNodeItem;

		private ResearchNetworkNodeItem _nodeItem;

		private IResearchNetworkState _networkState;

		public void Setup(IResearchNetworkState networkState, ResearchNetworkNodeItem parentNodeItem, ResearchNetworkNodeItem nodeItem)
		{
			_parentNodeItem = parentNodeItem;
			_nodeItem = nodeItem;
			_networkState = networkState;
			Logging.Info(LogChannels.GUI, $"Connector: {nodeItem.Node.NodeID} => {parentNodeItem.Node.NodeID}, Start = {parentNodeItem.transform.localPosition}, End = {nodeItem.transform.localPosition}");
			_line.Setup(TransformToGridSpace(_parentNodeItem.transform), TransformToGridSpace(_nodeItem.transform));
			_chevrons.Setup(_parentNodeItem.transform.localPosition, _nodeItem.transform.localPosition);
		}

		private Vector3 TransformToGridSpace(Transform inTransform)
		{
			RectTransform rectTransform = (RectTransform)inTransform.parent;
			Vector2 vector = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
			return new Vector3(inTransform.localPosition.x + vector.x * 0.5f, inTransform.localPosition.y + vector.y * 0.5f, 0f);
		}

		public void Refresh()
		{
			if (_nodeItem.Node.Status == CollaborativeNode.State.Completed || _nodeItem.Node.Status == CollaborativeNode.State.Debug || _parentNodeItem.Node.IsRoot)
			{
				GameObjectUtils.SetActive(_line.gameObject, isActive: true);
				GameObjectUtils.SetActive(_chevrons.gameObject, isActive: false);
			}
			else if (_nodeItem.Node.Status == CollaborativeNode.State.Discovered || _nodeItem.Node.Status == CollaborativeNode.State.Debug)
			{
				GameObjectUtils.SetActive(_line.gameObject, isActive: false);
				GameObjectUtils.SetActive(_chevrons.gameObject, isActive: true);
				bool flag = _networkState.IsLocalPlayerAttemptingNode(_nodeItem.Node.NodeID);
				_chevrons.SetColor(flag ? Color.green : Color.white);
				_chevrons.Animate();
			}
			else
			{
				GameObjectUtils.SetActive(_line.gameObject, isActive: false);
				GameObjectUtils.SetActive(_chevrons.gameObject, isActive: false);
			}
		}
	}
}
