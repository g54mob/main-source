using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UniHumanoid
{
	public class RuntimeBvhLoader : MonoBehaviour
	{
		[SerializeField]
		private Button m_openButton;

		[SerializeField]
		private HumanPoseTransfer m_dst;

		private UnityAction m_onClick;

		private static string m_lastDir;

		private BvhImporterContext m_context;

		private void Awake()
		{
			m_onClick = OnClick;
		}

		private void OnEnable()
		{
			m_openButton.onClick.AddListener(m_onClick);
		}

		private void OnDisable()
		{
			m_openButton.onClick.RemoveListener(m_onClick);
		}

		public void OnClick()
		{
			string path = null;
			Open(path);
		}

		private void Open(string path)
		{
			Debug.LogFormat("Open: {0}", path);
			if (m_context != null)
			{
				m_context.Destroy(destroySubAssets: true);
				m_context = null;
			}
			m_context = new BvhImporterContext();
			m_context.Parse(path);
			m_context.Load();
			HumanPoseTransfer source = m_context.Root.AddComponent<HumanPoseTransfer>();
			if (m_dst != null)
			{
				m_dst.SourceType = HumanPoseTransfer.HumanPoseTransferSourceType.HumanPoseTransfer;
				m_dst.Source = source;
			}
		}
	}
}
