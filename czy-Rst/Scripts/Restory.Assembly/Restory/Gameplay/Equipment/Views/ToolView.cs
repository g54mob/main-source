using System;
using Restory.Data.Equipment;
using Restory.Gameplay.Effects;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Views
{
	public class ToolView : MonoBehaviour
	{
		[SerializeField]
		private ToolsCategory toolsCategory;

		private GameObject viewInstance;

		protected ToolInfo toolInfo;

		private VfxService vfxService;

		public ToolsCategory ToolCategory => toolsCategory;

		public ToolInfo ToolInfo => toolInfo;

		public event Action OnToolPlaced;

		[Inject]
		private void Construct(VfxService vfxService)
		{
			this.vfxService = vfxService;
		}

		public virtual void SetTool(ToolInfo toolInfo, bool instantly)
		{
			if ((bool)this.toolInfo && this.toolInfo == toolInfo)
			{
				if (!instantly && toolInfo.IsConsumable)
				{
					PlayPlacementEffect(viewInstance.transform);
				}
				return;
			}
			this.toolInfo = toolInfo;
			if ((bool)viewInstance)
			{
				UnityEngine.Object.Destroy(viewInstance);
			}
			if ((bool)toolInfo.ViewPrefab)
			{
				viewInstance = UnityEngine.Object.Instantiate(toolInfo.ViewPrefab, base.transform);
				if (!instantly)
				{
					PlayPlacementEffect(viewInstance.transform);
				}
			}
		}

		public void RemoveTool()
		{
			toolInfo = null;
			if ((bool)viewInstance)
			{
				vfxService.PlayDestroyEffect(viewInstance.transform);
				UnityEngine.Object.Destroy(viewInstance);
				viewInstance = null;
			}
		}

		protected void PlayPlacementEffect(Transform vfxSpawnPoint)
		{
			vfxService.PlayPlacementEffect(vfxSpawnPoint);
			this.OnToolPlaced?.Invoke();
		}
	}
}
