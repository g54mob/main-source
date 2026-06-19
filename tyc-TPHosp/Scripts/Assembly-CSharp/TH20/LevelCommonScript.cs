using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class LevelCommonScript : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _menusTransform;

		[SerializeField]
		private RectTransform _inWorldTransform;

		[SerializeField]
		private GraphicRaycaster _graphicRaycaster;

		[SerializeField]
		private GameObject _debugLargeRenderTargetGameObject;

		[SerializeField]
		private RawImage _debugLargeRenderTextureRaw;

		public RectTransform MenusTransform => _menusTransform;

		public RectTransform InWorldTransform => _inWorldTransform;

		public GraphicRaycaster Raycaster => _graphicRaycaster;

		public GameObject DebugLargeRenderTargetGameObject => _debugLargeRenderTargetGameObject;

		public RawImage DebugLargeRenderTextureImage => _debugLargeRenderTextureRaw;
	}
}
