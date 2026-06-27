using System;
using Restory.Data.Equipment;
using Restory.Gameplay.Effects;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Views
{
	public sealed class DevicePainterToolView : ToolView
	{
		[SerializeField]
		private GameObject model;

		[SerializeField]
		private BounceEffect bounceEffect;

		private bool wasActivated;

		public event Action OnDevicePainterToolAdded;

		public override void SetTool(ToolInfo toolInfo, bool instantly)
		{
			model.SetActive(value: true);
			if (!instantly)
			{
				bounceEffect.PlayBounce();
			}
			base.SetTool(toolInfo, instantly);
			this.OnDevicePainterToolAdded?.Invoke();
		}
	}
}
