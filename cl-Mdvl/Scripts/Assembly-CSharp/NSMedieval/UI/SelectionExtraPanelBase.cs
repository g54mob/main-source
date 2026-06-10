using System;
using NSEipix;
using NSEipix.Base;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.UI
{
	public abstract class SelectionExtraPanelBase : UIView
	{
		[SerializeField]
		private SelectionExtraWindowView parentPanel;

		[NonSerialized]
		private AnimalInstance animal;

		[NonSerialized]
		private HumanoidInstance humanoid;

		protected HumanoidInstance Humanoid
		{
			get
			{
				if (parentPanel is SelectionExtraWorker selectionExtraWorker)
				{
					if (humanoid == null || humanoid != selectionExtraWorker.Humanoid)
					{
						humanoid = selectionExtraWorker.Humanoid;
					}
					return humanoid;
				}
				if (parentPanel is SelectionExtraEnemy selectionExtraEnemy)
				{
					if (humanoid == null || humanoid != selectionExtraEnemy.HumanoidInstance)
					{
						humanoid = selectionExtraEnemy.HumanoidInstance;
					}
					return humanoid;
				}
				return null;
			}
		}

		protected AnimalInstance Animal
		{
			get
			{
				if (!(parentPanel is SelectionExtraAnimal selectionExtraAnimal))
				{
					return null;
				}
				if (animal == null || animal != selectionExtraAnimal.Animal)
				{
					animal = selectionExtraAnimal.Animal;
				}
				return animal;
			}
		}

		protected CreatureBase CreatureBase
		{
			get
			{
				if (Humanoid != null)
				{
					return Humanoid;
				}
				if (Animal != null)
				{
					return Animal;
				}
				return null;
			}
		}

		public void SetActive(bool active = true)
		{
			if (active)
			{
				ShowPanel();
			}
			else
			{
				Hide();
			}
		}

		public void UpdateData()
		{
			UpdateTabPanel();
		}

		protected FillBarLayoutItemView CreateLayoutItem(LayoutGroupView group)
		{
			return UnityEngine.Object.Instantiate(group.Prefab, group.gameObject.transform) as FillBarLayoutItemView;
		}

		protected abstract void SetupTabPanel();

		protected abstract void UpdateTabPanel();

		private void ShowPanel()
		{
			Show();
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				if (CreatureBase == null || CreatureBase.HasDied || CreatureBase.HasDisposed)
				{
					Hide();
				}
				else
				{
					SetupTabPanel();
				}
			});
		}
	}
}
