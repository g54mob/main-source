using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ModApi.Ui
{
	public interface IXmlElement
	{
		bool AllowDragging { get; set; }

		float AnimationDuration { get; set; }

		CanvasGroup CanvasGroup { get; }

		float DefaultOpacity { get; set; }

		EventTrigger EventTrigger { get; }

		GameObject GameObject { get; }

		float HideAnimationDelay { get; set; }

		string Id { get; }

		string InternalId { get; }

		bool IsAnimating { get; }

		bool IsDropReceiver { get; set; }

		AudioClip OnClickSound { get; set; }

		AudioClip OnHideSound { get; set; }

		AudioClip OnMouseEnterSound { get; set; }

		AudioClip OnMouseExitSound { get; set; }

		AudioClip OnShowSound { get; set; }

		RectTransform RectTransform { get; }

		bool RestrictDraggingToParentBounds { get; set; }

		bool ReturnToOriginalPositionWhenReleased { get; set; }

		float ShowAnimationDelay { get; set; }

		string Tooltip { get; set; }

		bool Visible { get; set; }

		IXmlLayout XmlLayout { get; }

		void AddChildElement(IXmlElement child, bool adjustRectTransform = true);

		void AddClass(string name);

		void AddOnBeginDragEvent(Action action, bool clearExisting = false);

		void AddOnClickEvent(Action action, bool clearExisting = false);

		void AddOnDragEvent(Action action, bool clearExisting = false);

		void AddOnElementDroppedEvent(Action<IXmlElement, IXmlElement> action, bool clearExisting = false);

		void AddOnEndDragEvent(Action action, bool clearExisting = false);

		void AddOnHideEvent(Action action, bool clearExisting = false);

		void AddOnMouseDownEvent(Action action, bool clearExisting = false);

		void AddOnMouseEnterEvent(Action action, bool clearExisting = false);

		void AddOnMouseExitEvent(Action action, bool clearExisting = false);

		void AddOnMouseUpEvent(Action action, bool clearExisting = false);

		void AddOnShowEvent(Action action, bool clearExisting = false);

		void AddOnSubmitEvent(Action action, bool clearExisting = false);

		IXmlElement ApplyAttributes();

		string GetAttribute(string name, string defaultValue = null);

		List<IXmlElement> GetChildElementsWithClass(string name);

		IXmlElement GetElementByInternalId(string internalId);

		T GetElementByInternalId<T>(string internalId) where T : MonoBehaviour;

		string GetValue();

		bool HasAttribute(string name);

		bool HasClass(string name);

		void Hide(Action onCompleteCallback = null, bool forceEvenIfNotVisible = false);

		void PlaySound(AudioClip sound);

		void PlaySoundOneShot(AudioClip sound);

		IXmlElement RemoveAttribute(string name);

		void RemoveChildElement(IXmlElement child, bool destroyChild = false);

		void RemoveClass(string name);

		void SetAndApplyAttribute(string name, string value);

		IXmlElement SetAttribute(string name, string value);

		void SetAudioMixerGroup(AudioSource audioSource, string path);

		void SetClass(params string[] newClasses);

		void SetPivot(Vector2 pivot, RectTransform rectTransform = null);

		void Show(Action onCompleteCallback = null, bool forceEvenIfVisible = false);
	}
}
