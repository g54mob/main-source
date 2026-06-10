using NSEipix.Base;
using NSMedieval.Research;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ForceInitializer : MonoSingleton<ForceInitializer>
	{
		[SerializeField]
		private GameObject researchTreeContent;

		private void Start()
		{
			ForceInitializeResearchNodes();
		}

		private void ForceInitializeResearchNodes()
		{
			ResearchNodeView[] componentsInChildren = researchTreeContent.GetComponentsInChildren<ResearchNodeView>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].ForceInitialize();
			}
		}
	}
}
