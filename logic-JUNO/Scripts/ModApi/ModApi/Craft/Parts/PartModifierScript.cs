using System;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using ModApi.Craft.Parts.Input;
using ModApi.Design;
using ModApi.Flight.GameView;
using ModApi.GameLoop;
using ModApi.Scripts.State.Validation;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	[GameLoopExecutionOrder(-4600)]
	public abstract class PartModifierScript : MonoBehaviourBase, IDisposable, IGameViewPointerEventHandler
	{
		public virtual bool CanRefuseConnection => false;

		public IPartScript PartScript { get; protected set; }

		public virtual bool AcceptConnection(AttachPointScript ourAttachPoint, AttachPointScript targetAttachPoint)
		{
			return true;
		}

		void IDisposable.Dispose()
		{
			OnDisposed();
		}

		public virtual void FlightEnd()
		{
		}

		public abstract PartModifierData GetData();

		public virtual float GetEstimatedDragForce()
		{
			return 0f;
		}

		public IInputController GetInputController()
		{
			IInputController inputController = GetInputController(GetData().InputId);
			if (inputController == null)
			{
				Debug.LogWarning($"Unable to find input controller with ID '{GetData().InputId}' for {PartScript.Data.Name} (ID {PartScript.Data.Id})");
			}
			return inputController;
		}

		public IInputController GetInputController(string id)
		{
			foreach (PartModifierScript modifier in PartScript.Modifiers)
			{
				if (modifier is IInputController inputController && inputController.InputId == id)
				{
					return inputController;
				}
			}
			return null;
		}

		public IInputController GetInputController(Expression<Func<CraftControls, float>> control)
		{
			if (control == null)
			{
				throw new ArgumentNullException("control");
			}
			if (!(control.Body is MemberExpression memberExpression))
			{
				Debug.LogError("The control expression is using an invalid expression format. Use this format: x => x.Property");
				return null;
			}
			PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
			if (propertyInfo == null)
			{
				Debug.LogError("The control expression did not provide a property. Use this format: x => x.Property");
				return null;
			}
			Func<CraftControls, float> defaultControl = (Func<CraftControls, float>)propertyInfo.GetGetMethod().CreateDelegate(typeof(Func<CraftControls, float>));
			return GetInputController(propertyInfo.Name, defaultControl);
		}

		public IInputController GetInputController(string id, Func<CraftControls, float> defaultControl)
		{
			IInputController inputController = GetInputController(id);
			if (inputController == null)
			{
				inputController = new SimpleInputController(id, this, defaultControl);
			}
			return inputController;
		}

		public virtual IGameViewPointerEventHandler HandleGameViewPointerEvent(GameViewPointerEvent pointerEvent)
		{
			return null;
		}

		public abstract void Initialize(PartModifierData data);

		public virtual void OnActivated()
		{
		}

		public virtual void OnAddedToCraftInDesigner(bool isSubassembly)
		{
		}

		public virtual void OnAttachmentDestroyed(PartConnection.Attachment attachment)
		{
		}

		public virtual void OnBeforePhysicsChanged(bool enabled)
		{
		}

		public virtual void OnCloned()
		{
		}

		public virtual bool OnCollision(IPartFlightCollision partCollision)
		{
			return false;
		}

		public virtual void OnConnectedToPart(PartConnectedEventData e)
		{
		}

		public virtual void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
		}

		public virtual void OnCraftStructureChanged(ICraftScript craftScript)
		{
		}

		public virtual void OnDeactivated()
		{
		}

		public virtual void OnDesignerPullout(Assembly assembly)
		{
		}

		public virtual void OnGenerateInspectorModel(PartInspectorModel model)
		{
		}

		public virtual void OnInitialLaunch()
		{
		}

		public virtual void OnIsPlayerCraftChanged(bool isPlayer, ICraftNode other)
		{
		}

		public virtual void OnModifiersCreated()
		{
		}

		public virtual void OnNodeLoaded()
		{
		}

		public virtual void OnPartDestroyed()
		{
		}

		public virtual void OnPhysicsChanged(bool enabled)
		{
		}

		public virtual void OnPreNodeLoaded()
		{
		}

		public virtual void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
		}

		public virtual void PrepareForPartIcon()
		{
		}

		public virtual void RecalculateFrameState(Vector3 positionDelta, Vector3 velocityDelta)
		{
		}

		public virtual void ValidatePart(ValidationResult result)
		{
		}

		protected internal virtual void OnRemoveModifier()
		{
		}

		protected virtual void OnDisposed()
		{
		}
	}
	public abstract class PartModifierScript<T> : PartModifierScript where T : PartModifierData
	{
		public T Data { get; private set; }

		public sealed override PartModifierData GetData()
		{
			return Data;
		}

		public sealed override void Initialize(PartModifierData data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data", "Cannot initialize the part modifier script because the specified part modifier data is null");
			}
			if (Data != null)
			{
				throw new Exception("The part modifier script has already been initialized");
			}
			if (data.GetType() != typeof(T))
			{
				throw new Exception($"The type of the part modifier data ({data.GetType().FullName}) does not match the type expected ({typeof(T).FullName}) by the part modifier script.");
			}
			T data2 = (T)data;
			Data = data2;
			base.PartScript = data.Part.PartScript;
			OnInitialized();
		}

		protected virtual void OnInitialized()
		{
		}

		protected void ScheduleCoroutineAction(Action action, YieldInstruction waitType)
		{
			StartCoroutine(ScheduleCoroutineActionCoroutine(action, waitType));
		}

		private IEnumerator ScheduleCoroutineActionCoroutine(Action action, YieldInstruction waitInstruction)
		{
			yield return waitInstruction;
			action();
		}
	}
}
