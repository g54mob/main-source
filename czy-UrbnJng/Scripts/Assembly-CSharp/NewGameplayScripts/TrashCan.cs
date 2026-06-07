using System;
using UI;

namespace NewGameplayScripts
{
	public class TrashCan : MovableItem
	{
		private TrashCanUI trashCanUI;

		protected override void Start()
		{
			base.Start();
			trashCanUI = GetComponent<TrashCanUI>();
			MovementSystem.Instance.OnStartMovingTrash += ShowTrashCanUI;
			MovementSystem.Instance.OnStopMovingItem += HideTrashCanUI;
		}

		public override void StartMoving()
		{
			base.StartMoving();
			isColliding = false;
			canPlace = true;
		}

		private void OnDestroy()
		{
			MovementSystem.Instance.OnStartMovingTrash -= ShowTrashCanUI;
			MovementSystem.Instance.OnStopMovingItem -= HideTrashCanUI;
		}

		private void HideTrashCanUI(object sender, EventArgs e)
		{
			trashCanUI.Hide();
		}

		private void ShowTrashCanUI(object sender, EventArgs e)
		{
			trashCanUI.Show();
		}
	}
}
