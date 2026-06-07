using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Multiplayer.SyncData;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public abstract class PartModifierScript : MonoBehaviour
	{
		protected struct PartModifierUpdateRegistrar
		{
			private CraftUpdateScript _craftUpdateScript;

			private PartModifierScript _partModifierScript;

			public PartModifierUpdateRegistrar(PartModifierScript partModifierScript)
			{
				_partModifierScript = partModifierScript;
				_craftUpdateScript = partModifierScript.PartScript.Aircraft.CraftUpdate;
			}

			public void RegisterFirstFrameLateUpdate(CraftUpdateDelegate updateDelegate, CraftUpdateFlags flags = CraftUpdateFlags.Default, int executionOrder = 0)
			{
				_craftUpdateScript.RegisterUpdate(CraftUpdateType.FirstFrameLateUpdate, _partModifierScript, updateDelegate, flags, executionOrder);
			}

			public void RegisterFixedUpdate(CraftUpdateDelegate updateDelegate, CraftUpdateFlags flags = CraftUpdateFlags.Default, int executionOrder = 0)
			{
				_craftUpdateScript.RegisterUpdate(CraftUpdateType.FixedUpdate, _partModifierScript, updateDelegate, flags, executionOrder);
			}

			public void RegisterLateUpdate(CraftUpdateDelegate updateDelegate, CraftUpdateFlags flags = CraftUpdateFlags.Default, int executionOrder = 0)
			{
				_craftUpdateScript.RegisterUpdate(CraftUpdateType.LateUpdate, _partModifierScript, updateDelegate, flags, executionOrder);
			}

			public void RegisterStart(CraftUpdateDelegate updateDelegate, CraftUpdateFlags flags = CraftUpdateFlags.Default, int executionOrder = 0)
			{
				_craftUpdateScript.RegisterUpdate(CraftUpdateType.Start, _partModifierScript, updateDelegate, flags, executionOrder);
			}

			public void RegisterUpdate(CraftUpdateDelegate updateDelegate, CraftUpdateFlags flags = CraftUpdateFlags.Default, int executionOrder = 0)
			{
				_craftUpdateScript.RegisterUpdate(CraftUpdateType.Update, _partModifierScript, updateDelegate, flags, executionOrder);
			}
		}

		private AircraftControls _controls;

		private bool _initialized;

		private PartScript _partScript;

		public AircraftControls Controls
		{
			get
			{
				if (_controls == null)
				{
					_controls = PartScript.Aircraft.Controls;
				}
				return _controls;
			}
		}

		public CraftLoadContext LoadContext => PartScript.Part.LoadContext;

		public PartModifierData PartModifier { get; private set; }

		public PartScript PartScript => _partScript ?? (_partScript = GetComponentInParent<PartScript>(includeInactive: true));

		public virtual void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
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

		public IInputController GetInputController(Expression<Func<AircraftControls, float>> control)
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
			Func<AircraftControls, float> defaultControl = (Func<AircraftControls, float>)propertyInfo.GetGetMethod().CreateDelegate(typeof(Func<AircraftControls, float>));
			return GetInputController(propertyInfo.Name, defaultControl);
		}

		public IInputController GetInputController(string id, Func<AircraftControls, float> defaultControl)
		{
			IInputController inputController = GetInputController(id);
			if (inputController == null)
			{
				inputController = new SimpleInputController(id, this, defaultControl);
			}
			return inputController;
		}

		public virtual void GetRenderersForHighlight(ICollection<Renderer> renderers)
		{
		}

		public void Initialize(PartModifierData modifier, PartScript partScript)
		{
			PartModifier = modifier;
			_partScript = partScript;
			if (base.isActiveAndEnabled)
			{
				RegisterUpdateMethods(new PartModifierUpdateRegistrar(this));
			}
			OnInitialize();
			_initialized = true;
		}

		public virtual void InitializePartSyncData(PartSyncData syncData)
		{
		}

		public virtual void OnBeginReposition()
		{
		}

		public virtual void OnConnectedToPart(AttachPointData thisAttachPoint, PartData targetPart, AttachPointData targetAttachPoint, bool isSymmetryOperation)
		{
		}

		public virtual void OnDamaged(float damage, Vector3 position, Vector3 direction)
		{
		}

		public virtual void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
		}

		public virtual void OnEndReposition()
		{
		}

		public virtual void OnEnterWater()
		{
		}

		public virtual void OnExitWater()
		{
		}

		public virtual void OnExplosiveForceApplied(float force, Vector3 forceDirection)
		{
		}

		public virtual void OnMirrored(PartData sourcePart)
		{
		}

		public virtual void OnPartAdded()
		{
		}

		public void OnPreDisable(ModifierScriptDisableConditionType disableCondition)
		{
		}

		public virtual void OnReceiveNetworkMessage(byte messageType, PooledReader reader)
		{
		}

		public virtual void PreviewPartPlacement(AttachPointData myAttachPointBeingUsed, AttachPointData theirAttachPointToPreviewConnectionTo, PartSelection selection)
		{
		}

		protected virtual void OnDisable()
		{
			if (_initialized)
			{
				PartScript.Aircraft.CraftUpdate.UnregisterUpdate(this);
			}
		}

		protected virtual void OnEnable()
		{
			if (_initialized)
			{
				RegisterUpdateMethods(new PartModifierUpdateRegistrar(this));
			}
		}

		protected virtual void OnInitialize()
		{
		}

		protected virtual void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
		}
	}
}
