using Mandragora.PWS;
using Restory.Data.Elements.Condition;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class ElementConditionHandler : MonoBehaviour
	{
		[SerializeField]
		private ElementData elementData;

		[SerializeField]
		private ElementTintColorApplier elementTintColorApplier;

		[SerializeField]
		private ElementDamagedStatusSwitcher elementDamagedStatusSwitcher;

		[SerializeField]
		private TextureMaskHolder textureMaskHolder;

		public ElementData ElementData => elementData;

		public TextureMaskHolder TextureMaskHolder => textureMaskHolder;

		private void Reset()
		{
			textureMaskHolder = GetComponentInChildren<TextureMaskHolder>();
			elementDamagedStatusSwitcher = GetComponentInChildren<ElementDamagedStatusSwitcher>();
			elementTintColorApplier = GetComponentInChildren<ElementTintColorApplier>();
		}

		public void InitCondition(ElementData elementData)
		{
			if (elementData.Info != this.elementData.Info)
			{
				Debug.LogError("elementData is not compatible with " + this.elementData.Info.ID);
				return;
			}
			this.elementData = elementData;
			if ((bool)elementTintColorApplier)
			{
				elementTintColorApplier.ApplyColorToElement(elementData.Info.SourceDevice.DefaultColor);
			}
			if ((bool)elementDamagedStatusSwitcher)
			{
				elementDamagedStatusSwitcher.SwitchDamagedStatus(elementData.Condition is DamagedElementCondition);
			}
			if ((bool)textureMaskHolder)
			{
				if (elementData.Condition is DirtyElementCondition)
				{
					textureMaskHolder.Initialize(elementData.DirtMaskTextureSize);
				}
				else
				{
					textureMaskHolder.Clean();
				}
			}
		}

		public void RestoreCondition(ElementData elementData, Texture2D restoredTexture)
		{
			if (elementData.Info != this.elementData.Info)
			{
				Debug.LogError("elementData is not compatible with " + this.elementData.Info.ID);
				return;
			}
			this.elementData = elementData;
			if ((bool)elementTintColorApplier)
			{
				elementTintColorApplier.ApplyColorToElement(elementData.Info.SourceDevice.DefaultColor);
			}
			if ((bool)textureMaskHolder && elementData.Condition is DirtyElementCondition)
			{
				textureMaskHolder.RestoreWorkTexture(restoredTexture);
				textureMaskHolder.SetInitialDirtyPixelsCount(elementData.DirtyPixelsData.InitialDirtyPixelsCount.R, elementData.DirtyPixelsData.InitialDirtyPixelsCount.G, elementData.DirtyPixelsData.InitialDirtyPixelsCount.B);
				textureMaskHolder.SetPixelsToLeaveDirtyCount(elementData.DirtyPixelsData.PixelsToLeaveDirtyCountRG, elementData.DirtyPixelsData.PixelsToLeaveDirtyCountB);
				textureMaskHolder.SetCurrentDirtyPixelsCount(elementData.DirtyPixelsData.CurrentDirtyPixelsCount.R, elementData.DirtyPixelsData.CurrentDirtyPixelsCount.G, elementData.DirtyPixelsData.CurrentDirtyPixelsCount.B);
			}
		}

		public void MakeElementDamaged(DamagedElementCondition damagedElementCondition)
		{
			if ((bool)elementDamagedStatusSwitcher)
			{
				elementDamagedStatusSwitcher.SwitchDamagedStatus(shouldBeDamaged: true);
			}
			else
			{
				Debug.LogError("[ElementConditionHandler] changed condition to 'Damaged', but failed to update the visuals, because in order to do that it needs a [ElementDamagedStatusSwitcher] component.");
			}
			UpdateCondition(damagedElementCondition);
		}

		public void UpdateCondition(ElementConditionBase newCondition)
		{
			if (elementData.Condition is DamagedElementCondition && !(newCondition is DamagedElementCondition))
			{
				elementDamagedStatusSwitcher.SwitchDamagedStatus(shouldBeDamaged: false);
			}
			elementData.Condition = newCondition;
		}

		public void CaptureCleaningData()
		{
			elementData.DirtyPixelsData.CurrentDirtyPixelsCount = textureMaskHolder.GetCurrentDirtyPixelsCount();
			elementData.DirtyPixelsData.PixelsToLeaveDirtyCountRG = textureMaskHolder.PixelsToLeaveDirtyCountRG;
			elementData.DirtyPixelsData.PixelsToLeaveDirtyCountB = textureMaskHolder.PixelsToLeaveDirtyCountB;
			elementData.DirtyPixelsData.InitialDirtyPixelsCount = textureMaskHolder.GetInitialDirtyPixelsCount();
		}
	}
}
