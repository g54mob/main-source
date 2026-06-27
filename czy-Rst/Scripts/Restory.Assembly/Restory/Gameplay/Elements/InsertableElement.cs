using Restory.Data.Equipment;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class InsertableElement : ElementBase
	{
		[SerializeField]
		private ElementAttachmentBase attachment;

		public override bool InSocket
		{
			get
			{
				return base.InSocket;
			}
			set
			{
				if (base.InSocket != value)
				{
					base.InSocket = value;
					attachment?.ChangeState(value);
				}
			}
		}

		public override void InitInteraction(ToolInfo toolInfo)
		{
			base.InitInteraction(toolInfo);
			tweener.Play();
		}

		public override void CancelInteraction()
		{
			tweener.Stop();
			base.CancelInteraction();
			base.OnInteractionCanceled.Invoke();
			AttachToDevice();
		}

		public override void AttachToDevice()
		{
			base.Progress = 0f;
			base.AttachToDevice();
		}

		public override void Reset()
		{
			if (tweener.IsPlaying)
			{
				CancelInteraction();
			}
			base.Reset();
		}

		protected override void CompleteInteraction()
		{
			base.Progress = 1f;
			base.CompleteInteraction();
		}
	}
}
