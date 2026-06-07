using System;
using UnityEngine;
using VRTK.Highlighters;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactables/VRTK_InteractObjectHighlighter")]
	public class VRTK_InteractObjectHighlighter : VRTK_InteractableListener
	{
		[Header("Object Interaction Settings")]
		[Tooltip("The colour to highlight the object on the near touch interaction.")]
		public Color nearTouchHighlight = Color.clear;

		[Tooltip("The colour to highlight the object on the touch interaction.")]
		public Color touchHighlight = Color.clear;

		[Tooltip("The colour to highlight the object on the grab interaction.")]
		public Color grabHighlight = Color.clear;

		[Tooltip("The colour to highlight the object on the use interaction.")]
		public Color useHighlight = Color.clear;

		[Header("Custom Settings")]
		[Tooltip("The Interactable Object to monitor the interactions on. If this is left blank, then the Interactable Object will need to be on the current or a parent GameObject.")]
		public VRTK_InteractableObject objectToMonitor;

		[Tooltip("The GameObject to highlight.")]
		public GameObject objectToHighlight;

		[Tooltip("An optional Highlighter to use when highlighting the specified Object. If this is left blank, then the first active highlighter on the same GameObject will be used, if one isn't found then a Material Color Swap Highlighter will be created at runtime.")]
		public VRTK_BaseHighlighter objectHighlighter;

		[Header("Obsolete Settings")]
		[Obsolete("`objectToAffect` has been replaced with `objectToHighlight`. This parameter will be removed in a future version of VRTK.")]
		[ObsoleteInspector]
		public VRTK_InteractableObject objectToAffect;

		protected Color currentColour = Color.clear;

		protected VRTK_BaseHighlighter baseHighlighter;

		protected bool createBaseHighlighter;

		protected GameObject currentAffectingObject;

		public event InteractObjectHighlighterEventHandler InteractObjectHighlighterHighlighted;

		public event InteractObjectHighlighterEventHandler InteractObjectHighlighterUnhighlighted;

		public virtual void OnInteractObjectHighlighterHighlighted(InteractObjectHighlighterEventArgs e)
		{
			if (this.InteractObjectHighlighterHighlighted != null)
			{
				this.InteractObjectHighlighterHighlighted(this, e);
			}
		}

		public virtual void OnInteractObjectHighlighterUnhighlighted(InteractObjectHighlighterEventArgs e)
		{
			if (this.InteractObjectHighlighterUnhighlighted != null)
			{
				this.InteractObjectHighlighterUnhighlighted(this, e);
			}
		}

		public virtual void ResetHighlighter()
		{
			if (baseHighlighter != null)
			{
				baseHighlighter.ResetHighlighter();
			}
		}

		public virtual void Highlight(Color highlightColor)
		{
			InitialiseHighlighter(highlightColor);
			if (baseHighlighter != null && highlightColor != Color.clear)
			{
				baseHighlighter.Highlight(highlightColor);
			}
			else
			{
				Unhighlight();
			}
		}

		public virtual void Unhighlight()
		{
			if (baseHighlighter != null)
			{
				baseHighlighter.Unhighlight();
			}
		}

		public virtual Color GetCurrentHighlightColor()
		{
			return currentColour;
		}

		public virtual GameObject GetAffectingObject()
		{
			return currentAffectingObject;
		}

		protected virtual void OnEnable()
		{
			objectToMonitor = ((objectToMonitor == null) ? objectToAffect : objectToMonitor);
			objectToHighlight = ((objectToHighlight == null && objectToAffect != null) ? objectToAffect.gameObject : objectToHighlight);
			objectToHighlight = ((objectToHighlight != null) ? objectToHighlight : base.gameObject);
			if (GetValidHighlighter() != baseHighlighter)
			{
				baseHighlighter = null;
			}
			EnableListeners();
		}

		protected virtual void OnDisable()
		{
			if (createBaseHighlighter)
			{
				UnityEngine.Object.Destroy(baseHighlighter);
			}
			DisableListeners();
		}

		protected override bool SetupListeners(bool throwError)
		{
			objectToMonitor = ((objectToMonitor != null) ? objectToMonitor : GetComponentInParent<VRTK_InteractableObject>());
			if (objectToMonitor != null)
			{
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.NearTouch, NearTouchHighlightObject);
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.NearUntouch, NearTouchUnHighlightObject);
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Touch, TouchHighlightObject);
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Untouch, TouchUnHighlightObject);
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Grab, GrabHighlightObject);
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Ungrab, GrabUnHighlightObject);
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Use, UseHighlightObject);
				objectToMonitor.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Unuse, UseUnHighlightObject);
				return true;
			}
			if (throwError)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_InteractObjectHighlighter", "VRTK_InteractableObject", "the same or parent"));
			}
			return false;
		}

		protected override void TearDownListeners()
		{
			if (objectToMonitor != null)
			{
				objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.NearTouch, NearTouchHighlightObject);
				objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.NearUntouch, NearTouchUnHighlightObject);
				objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Touch, TouchHighlightObject);
				objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Untouch, TouchUnHighlightObject);
				objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Grab, GrabHighlightObject);
				objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Ungrab, GrabUnHighlightObject);
				objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Use, UseHighlightObject);
				objectToMonitor.UnsubscribeFromInteractionEvent(VRTK_InteractableObject.InteractionType.Unuse, UseUnHighlightObject);
			}
		}

		protected virtual InteractObjectHighlighterEventArgs SetEventArgs(VRTK_InteractableObject.InteractionType interactionType, GameObject affectingObject)
		{
			currentAffectingObject = affectingObject;
			InteractObjectHighlighterEventArgs result = default(InteractObjectHighlighterEventArgs);
			result.interactionType = interactionType;
			result.highlightColor = currentColour;
			result.affectingObject = affectingObject;
			result.objectToMonitor = objectToMonitor;
			result.affectedObject = objectToHighlight;
			return result;
		}

		protected virtual void NearTouchHighlightObject(object sender, InteractableObjectEventArgs e)
		{
			Highlight(nearTouchHighlight);
			OnInteractObjectHighlighterHighlighted(SetEventArgs(VRTK_InteractableObject.InteractionType.NearTouch, e.interactingObject));
		}

		protected virtual void NearTouchUnHighlightObject(object sender, InteractableObjectEventArgs e)
		{
			if (!(sender as VRTK_InteractableObject).IsTouched())
			{
				Unhighlight();
				OnInteractObjectHighlighterUnhighlighted(SetEventArgs(VRTK_InteractableObject.InteractionType.NearUntouch, e.interactingObject));
			}
		}

		protected virtual void TouchHighlightObject(object sender, InteractableObjectEventArgs e)
		{
			Highlight(touchHighlight);
			OnInteractObjectHighlighterHighlighted(SetEventArgs(VRTK_InteractableObject.InteractionType.Touch, e.interactingObject));
		}

		protected virtual void TouchUnHighlightObject(object sender, InteractableObjectEventArgs e)
		{
			if ((sender as VRTK_InteractableObject).IsNearTouched())
			{
				Highlight(nearTouchHighlight);
				OnInteractObjectHighlighterHighlighted(SetEventArgs(VRTK_InteractableObject.InteractionType.NearTouch, e.interactingObject));
			}
			else
			{
				Unhighlight();
				OnInteractObjectHighlighterUnhighlighted(SetEventArgs(VRTK_InteractableObject.InteractionType.Untouch, e.interactingObject));
			}
		}

		protected virtual void GrabHighlightObject(object sender, InteractableObjectEventArgs e)
		{
			if (!(sender as VRTK_InteractableObject).IsUsing())
			{
				Highlight(grabHighlight);
				OnInteractObjectHighlighterHighlighted(SetEventArgs(VRTK_InteractableObject.InteractionType.Grab, e.interactingObject));
			}
		}

		protected virtual void GrabUnHighlightObject(object sender, InteractableObjectEventArgs e)
		{
			VRTK_InteractableObject vRTK_InteractableObject = sender as VRTK_InteractableObject;
			if (vRTK_InteractableObject.IsTouched())
			{
				Highlight(touchHighlight);
				OnInteractObjectHighlighterHighlighted(SetEventArgs(VRTK_InteractableObject.InteractionType.Touch, e.interactingObject));
			}
			else if (vRTK_InteractableObject.IsNearTouched())
			{
				Highlight(nearTouchHighlight);
				OnInteractObjectHighlighterHighlighted(SetEventArgs(VRTK_InteractableObject.InteractionType.NearTouch, e.interactingObject));
			}
			else
			{
				Unhighlight();
				OnInteractObjectHighlighterUnhighlighted(SetEventArgs(VRTK_InteractableObject.InteractionType.Ungrab, e.interactingObject));
			}
		}

		protected virtual void UseHighlightObject(object sender, InteractableObjectEventArgs e)
		{
			Highlight(useHighlight);
			OnInteractObjectHighlighterHighlighted(SetEventArgs(VRTK_InteractableObject.InteractionType.Use, e.interactingObject));
		}

		protected virtual void UseUnHighlightObject(object sender, InteractableObjectEventArgs e)
		{
			VRTK_InteractableObject vRTK_InteractableObject = sender as VRTK_InteractableObject;
			if (vRTK_InteractableObject.IsGrabbed())
			{
				Highlight(grabHighlight);
				OnInteractObjectHighlighterHighlighted(SetEventArgs(VRTK_InteractableObject.InteractionType.Grab, e.interactingObject));
			}
			else if (vRTK_InteractableObject.IsTouched())
			{
				Highlight(touchHighlight);
				OnInteractObjectHighlighterHighlighted(SetEventArgs(VRTK_InteractableObject.InteractionType.Touch, e.interactingObject));
			}
			else if (vRTK_InteractableObject.IsNearTouched())
			{
				Highlight(nearTouchHighlight);
				OnInteractObjectHighlighterHighlighted(SetEventArgs(VRTK_InteractableObject.InteractionType.NearTouch, e.interactingObject));
			}
			else
			{
				Unhighlight();
				OnInteractObjectHighlighterUnhighlighted(SetEventArgs(VRTK_InteractableObject.InteractionType.Unuse, e.interactingObject));
			}
		}

		protected virtual void InitialiseHighlighter(Color highlightColor)
		{
			if (baseHighlighter == null && highlightColor != Color.clear)
			{
				createBaseHighlighter = false;
				baseHighlighter = GetValidHighlighter();
				if (baseHighlighter == null)
				{
					createBaseHighlighter = true;
					baseHighlighter = objectToHighlight.AddComponent<VRTK_MaterialColorSwapHighlighter>();
				}
				baseHighlighter.Initialise(highlightColor, objectToHighlight);
			}
		}

		protected virtual VRTK_BaseHighlighter GetValidHighlighter()
		{
			if (!(objectHighlighter != null))
			{
				return VRTK_BaseHighlighter.GetActiveHighlighter(objectToHighlight);
			}
			return objectHighlighter;
		}
	}
}
