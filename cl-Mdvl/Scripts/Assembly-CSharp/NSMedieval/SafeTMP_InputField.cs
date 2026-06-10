using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace NSMedieval
{
	public class SafeTMP_InputField : TMP_InputField
	{
		public class NonInteractableClickedEvent : UnityEvent
		{
		}

		private NonInteractableClickedEvent _nonInteractableClickEvent = new NonInteractableClickedEvent();

		public NonInteractableClickedEvent onNonInteractableClick
		{
			get
			{
				return _nonInteractableClickEvent;
			}
			set
			{
				_nonInteractableClickEvent = value;
			}
		}

		public override void OnUpdateSelected(BaseEventData eventData)
		{
			try
			{
				base.OnUpdateSelected(eventData);
			}
			catch (Exception ex)
			{
				string text = (m_Text = (base.text = base.text.Trim()));
				base.textComponent.SetText(text);
				SetTextWithoutNotify(text);
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\SafeTMP_InputField.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("TextMeshPro exception caught: ");
					messageBuilder.AppendFormatted(ex.Message);
				}
				Log.Error(messageBuilder);
			}
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			if (!IsInteractable())
			{
				_nonInteractableClickEvent?.Invoke();
				Log.Info("_nonInteractableClickEvent", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\SafeTMP_InputField.cs");
			}
			base.OnPointerClick(eventData);
		}
	}
}
