using System;
using Restory.Data.Equipment;
using Restory.Gameplay.Equipment.Ultrasonic;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Views
{
	public sealed class UltrasonicToolView : ToolView
	{
		[SerializeField]
		private GameObject decorations;

		private DiContainer diContainer;

		public event Action<UltrasonicToolInfo, SonicBathView> OnUltrasonicToolActivated;

		[Inject]
		private void Construct(DiContainer diContainer)
		{
			this.diContainer = diContainer;
		}

		public override void SetTool(ToolInfo toolInfo, bool instantly)
		{
			if (!(toolInfo is UltrasonicToolInfo arg))
			{
				Debug.LogError(toolInfo.ID + " is not UltrasonicToolInfo");
			}
			else
			{
				if ((bool)base.toolInfo && (base.toolInfo == toolInfo || base.toolInfo.ToolLevel >= toolInfo.ToolLevel))
				{
					return;
				}
				SonicBathView sonicBathView = diContainer.InstantiatePrefabForComponent<SonicBathView>(toolInfo.ViewPrefab, base.transform);
				if (!sonicBathView)
				{
					Debug.LogError("Failed to find SonicBathView component on tool view prefab " + toolInfo.ViewPrefab.name);
					UnityEngine.Object.Destroy(sonicBathView.gameObject);
					return;
				}
				base.toolInfo = toolInfo;
				decorations.SetActive(value: false);
				this.OnUltrasonicToolActivated?.Invoke(arg, sonicBathView);
				if (!instantly)
				{
					PlayPlacementEffect(sonicBathView.transform);
				}
			}
		}
	}
}
