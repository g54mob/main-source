using UnityEngine;

namespace SceneFocus
{
	[RequireComponent(typeof(Camera))]
	public class SceneFocusInfoCollector : MonoBehaviour
	{
		public SceneFocusInfo sceneFocusInfo;

		private void Awake()
		{
		}

		public SceneFocusInfo CollectComponents()
		{
			return null;
		}

		private void Start()
		{
		}
	}
}
